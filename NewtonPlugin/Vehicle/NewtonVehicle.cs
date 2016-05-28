using UnityEngine;
using System.Collections;
using System;
using NewtonAPI;
using System.Collections.Generic;

namespace NewtonPlugin
{
    [Serializable]
    public struct NewtonVehicleWheelSetup
    {
        public NewtonVehicleTire FrontLeft;
        public NewtonVehicleTire FrontRight;
        public NewtonVehicleTire RearLeft;
        public NewtonVehicleTire RearRight;

        public List<NewtonVehicleTire> GetList()
        {
            return new List<NewtonVehicleTire>() { FrontLeft, FrontRight, RearLeft, RearRight };
        }

    }

    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Vehicle/Vehicle")]
    public class NewtonVehicle : NewtonBody
    {

        public float mass = 1500.0f;
        public float maxBrakeTorque = 3000.0f;
        public bool DifferentialLock = false;

        public Vector3 centerOfMass = Vector3.zero;
        public NewtonDifferentialType differental;

        public NewtonVehicleParameters vehicleParameters;
        public NewtonEngineParameters engineParameters;

        public NewtonVehicleWheelSetup tires;

        private IntPtr vehiclePtr = IntPtr.Zero;

        public void SetThrottle(float throttle)
        {
            NewtonInvoke.NewtonVehicleSetThrottle(vehiclePtr, throttle);
        }

        public void SetSteering(float steering)
        {
            NewtonInvoke.NewtonVehicleSetSteering(vehiclePtr, steering);
        }

        public void SetBrakes(float brakes)
        {
            NewtonInvoke.NewtonVehicleSetBrakes(vehiclePtr, brakes);
        }

        public void SetHandBrakes(float brakes)
        {
            NewtonInvoke.NewtonVehicleSetHandBrakes(vehiclePtr, brakes);
        }

        public void SetClutch(float clutch)
        {
            NewtonInvoke.NewtonVehicleSetClutch(vehiclePtr, clutch);
        }

        public void SetGear(int gear)
        {
            NewtonInvoke.NewtonVehicleSetGear(vehiclePtr, gear);
        }

        public int GetGear()
        {
            return NewtonInvoke.NewtonVehicleGetGear(vehiclePtr);
        }

        public float GetSpeed()
        {
            return NewtonInvoke.NewtonVehicleGetSpeed(vehiclePtr);
        }

        public float GetRPM()
        {
            return NewtonInvoke.NewtonVehicleGetRPM(vehiclePtr);
        }


        public void Awake()
        {
            CreateVehicle();
        }

        internal override IntPtr GetBodyPointer()
        {

            if (bodyPtr == IntPtr.Zero)
                CreateVehicle();

            return bodyPtr;
        }

        public unsafe void CreateVehicle()
        {
            if (bodyPtr != IntPtr.Zero)
                return;

            Debug.Log("Creating vehicle");

            worldPtr = NewtonManager.Register(this);

            if (worldPtr == IntPtr.Zero)
            {
                Debug.Log("Something went wrong, world is 0");
                return;
            }

            NewtonCollider[] colliders = Helpers.GetAllColliders(this.gameObject);
            IntPtr pColl = IntPtr.Zero;

            if (colliders.Length == 0) // No collider found, create null collision
            {
                pColl = NewtonInvoke.NewtonCreateNull(worldPtr);
            }
            else if (colliders.Length == 1) // One collider found
            {
                NewtonCollider coll = colliders[0];

                if (coll.transform == transform)
                    pColl = coll.CreateCollider(worldPtr, false); // Collider is a component of the same GameObject the Body is attached to. No offset available in this case.
                else
                    pColl = coll.CreateCollider(worldPtr, true); // Collider is a component of a child GameObject, apply the child GameObjects offset transform.
            }
            else // Several colliders found, create a compound.
            {
                pColl = NewtonInvoke.NewtonCreateCompoundCollision(worldPtr, 0);
                NewtonInvoke.NewtonCompoundCollisionBeginAddRemove(pColl);

                foreach (NewtonCollider coll in colliders)
                {
                    IntPtr pSubColl;

                    if (coll.transform == transform)
                        pSubColl = coll.CreateCollider(worldPtr, false);
                    else
                        pSubColl = coll.CreateCollider(worldPtr, true);

                    NewtonInvoke.NewtonCompoundCollisionAddSubCollision(pColl, pSubColl);
                    NewtonInvoke.NewtonDestroyCollision(pSubColl);
                }

                NewtonInvoke.NewtonCompoundCollisionEndAddRemove(pColl);
            }

            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

            // Create vehicle base
            vehiclePtr = NewtonInvoke.NewtonCreateVehicle(NewtonManager.VehicleManagerPointer, pColl, (float*)&matrix, mass, maxBrakeTorque, NewtonManager.ApplyForceAndTorque);
            bodyPtr = NewtonInvoke.NewtonVehicleGetBody(vehiclePtr);

            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            btsPtr = NewtonInvoke.NewtonCreateBodyTransformState((float*)&pos, (float*)&rot);
            NewtonInvoke.NewtonBodySetUserData(bodyPtr, btsPtr);

            Vector3 com = this.centerOfMass;
            NewtonInvoke.NewtonVehicleSetCOM(vehiclePtr, (float*)&com);

            // Add tires

            AddTire(tires.FrontLeft);
            AddTire(tires.FrontRight);
            AddTire(tires.RearLeft);
            AddTire(tires.RearRight);

            // Set engine parameters(tires must be added first)
            NewtonVehicleParameters vParams = vehicleParameters;
            NewtonEngineParameters eParams = engineParameters;
            NewtonInvoke.NewtonVehicleSetEngineParams(vehiclePtr, (void*)&vParams, (void*)&eParams, tires.FrontLeft.tirePtr, tires.FrontRight.tirePtr, tires.RearLeft.tirePtr, tires.RearRight.tirePtr, differental);

            NewtonInvoke.NewtonVehicleCalculateAckermannParameters(vehiclePtr, tires.FrontLeft.tirePtr, tires.FrontRight.tirePtr, tires.RearLeft.tirePtr, tires.RearRight.tirePtr);

            NewtonInvoke.NewtonVehicleFinalize(vehiclePtr);

            NewtonInvoke.NewtonDestroyCollision(pColl); // Release the collision reference

            NewtonInvoke.NewtonVehicleSetGear(vehiclePtr, 0); // 0 = Neutral, 1 = Reverse, 2 = Drive(1st Gear)
            NewtonInvoke.NewtonVehicleSetDifferentialLock(vehiclePtr, DifferentialLock);

            bodyPtr = NewtonInvoke.NewtonVehicleGetBody(vehiclePtr);

            foreach (var tire in tires.GetList())
            {
                pos = tire.transform.position;
                rot = tire.transform.rotation * Quaternion.Euler(-tire.rotationOffset);

                tire.bodyPtr = NewtonInvoke.NewtonVehicleTireGetBody(tire.tirePtr);
                tire.btsPtr = NewtonInvoke.NewtonCreateBodyTransformState((float*)&pos, (float*)&rot);
                NewtonInvoke.NewtonBodySetUserData(tire.bodyPtr, tire.btsPtr);
            }


        }

        private unsafe void AddTire(NewtonVehicleTire tire)
        {
            Vector3 position = tire.transform.localPosition;
            NewtonTireParameters tireParams = tire.tireParameters;

            tire.tirePtr = NewtonInvoke.NewtonVehicleAddTire(vehiclePtr, (float*)&position, (float*)&tireParams);

            if (tire.Steering)
                NewtonInvoke.NewtonVehicleSteeringAddTire(vehiclePtr, tire.tirePtr);

            if (tire.Brakes)
                NewtonInvoke.NewtonVehicleBrakesAddTire(vehiclePtr, tire.tirePtr);

            if (tire.HandBrakes)
                NewtonInvoke.NewtonVehicleHandBrakesAddTire(vehiclePtr, tire.tirePtr);

        }


        //bool braking = false;
        public unsafe new void Update()
        {

            base.Update();

            // Update tire transforms
            tires.FrontLeft.UpdateTransform();
            tires.FrontRight.UpdateTransform();
            tires.RearLeft.UpdateTransform();
            tires.RearRight.UpdateTransform();

        }

        public new void OnDestroy()
        {
            base.OnDestroy();

            Debug.Log("Destroying vehicle");
            foreach(var tire in tires.GetList())
            {
                NewtonInvoke.NewtonDestroyBodyTransformState(tire.btsPtr);
            }

            NewtonInvoke.NewtonDestroyVehicle(NewtonManager.VehicleManagerPointer, vehiclePtr);

            NewtonManager.Unregister(this);
            
        }

    }

}