//using UnityEngine;
//using System.Collections;
//using System;

//[DisallowMultipleComponent]
//[AddComponentMenu("Newton Physics/Vehicle/Vehicle")]
//public class NewtonVehicle : MonoBehaviour {

//    public float mass = 1500.0f;
//    public float maxSteeringAngle = 25.0f;
//    public float maxBrakeTorque = 3000.0f;

//    public Vector3 centerOfMass = Vector3.zero;

//    public NewtonPlugin.EngineParameters engineParameters;

//    IntPtr vehicle = IntPtr.Zero;
//    IntPtr body = IntPtr.Zero;

//    NewtonVehicleTire[] tires;

//    void Start()
//    {
//        Debug.Log("Creating vehicle");

//        IntPtr umColl = IntPtr.Zero; //Unmanaged collider pointer

//        NewtonCollider[] colliders = GetComponentsInChildren<NewtonCollider>();

//        if (colliders.Length == 0)
//        {
//            umColl = NewtonPlugin.CreateNull();
//        }
//        else if (colliders.Length == 1)
//        {
//            NewtonCollider coll = colliders[0];

//            if (coll.transform == transform)
//                umColl = coll.CreateCollider(false);
//            else
//                umColl = coll.CreateCollider(true);
//        }
//        else
//        {
//            umColl = NewtonPlugin.CreateCompoundCollision(0);
//            NewtonPlugin.CompoundCollisionBeginAddRemove(umColl);

//            foreach (NewtonCollider coll in colliders)
//            {
//                IntPtr umSubColl = IntPtr.Zero;

//                if (coll.transform == transform)
//                    umSubColl = coll.CreateCollider(false);
//                else
//                    umSubColl = coll.CreateCollider(true);

//                NewtonPlugin.CompoundCollisionAddSubCollision(umColl, umSubColl);
//                NewtonPlugin.DestroyCollision(umSubColl);
//            }

//            NewtonPlugin.CompoundCollisionEndAddRemove(umColl);
//        }

//        Matrix4x4 matrix = Matrix4x4.identity;
//        matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

//        // Create vehicle base
//        vehicle = NewtonPlugin.CreateVehicle(umColl, ref matrix, mass, maxSteeringAngle, maxBrakeTorque);
//        body = NewtonPlugin.VehicleGetBody(vehicle);

//        NewtonPlugin.VehicleSetCOM(vehicle, ref centerOfMass);

//        // Add tires
//        tires = GetComponentsInChildren<NewtonVehicleTire>();
//        foreach (NewtonVehicleTire tire in tires)
//        {

//            Vector3 position = tire.transform.localPosition;
//            tire._tirePtr = NewtonPlugin.VehicleAddTire(vehicle, ref position, tire.tireParameters);
//        }
        
//        // Add the steering tires
//        NewtonPlugin.VehicleSteeringAddTire(vehicle, tires[0]._tirePtr);
//        NewtonPlugin.VehicleSteeringAddTire(vehicle, tires[1]._tirePtr);

//        // Add brakes
//        NewtonPlugin.VehicleBrakesAddTire(vehicle, tires[0]._tirePtr);
//        NewtonPlugin.VehicleBrakesAddTire(vehicle, tires[1]._tirePtr);
//        NewtonPlugin.VehicleBrakesAddTire(vehicle, tires[2]._tirePtr);
//        NewtonPlugin.VehicleBrakesAddTire(vehicle, tires[3]._tirePtr);

//        // Add handbrakes
//        NewtonPlugin.VehicleHandBrakesAddTire(vehicle, tires[2]._tirePtr);
//        NewtonPlugin.VehicleHandBrakesAddTire(vehicle, tires[3]._tirePtr);

//        // Set engine parameters(tires must be added first)
//        NewtonPlugin.VehicleSetEngineParams(vehicle, engineParameters, tires[0]._tirePtr, tires[1]._tirePtr, tires[2]._tirePtr, tires[3]._tirePtr, 2); //AWD

//        // Link tires for AWD...
//        //NewtonPlugin.VehicleLinkTires(vehicle, tires[0]._tirePtr, tires[2]._tirePtr); // Link FrontLeft with RearLeft
//        //NewtonPlugin.VehicleLinkTires(vehicle, tires[1]._tirePtr, tires[3]._tirePtr); // Link FrontRight with RearRight

//        NewtonPlugin.VehicleFinalize(vehicle);

//        NewtonPlugin.DestroyCollision(umColl); // Release the reference

//        NewtonPlugin.VehicleSetGear(vehicle, 2); // 0 = Neutral, 1 = Reverse, 2 = Drive(1st Gear)
//    }


//    void OnGUI()
//    {
//        float kph = NewtonPlugin.VehicleGetSpeed(vehicle) * 3.6f;

//        GUI.contentColor = Color.black;
//        GUI.Label(new Rect(10, 10, 100, 20), "Speed:" + kph.ToString());
//        GUI.Label(new Rect(10, 30, 100, 20), "RPM:" + NewtonPlugin.VehicleGetRPM(vehicle).ToString());
//        GUI.Label(new Rect(10, 50, 100, 20), "Gear:" + NewtonPlugin.VehicleGetGear(vehicle).ToString());

//        float throttle = Input.GetAxis("Horizontal");
//        GUI.Label(new Rect(10, 70, 100, 20), throttle.ToString());

//    }

//    bool braking = false;
//    void Update ()
//    {
//        float speed = NewtonPlugin.VehicleGetSpeed(vehicle);
//        int gear = NewtonPlugin.VehicleGetGear(vehicle);

//        float steer = Input.GetAxis("Horizontal");
//        NewtonPlugin.VehicleSetSteering(vehicle, steer);

//        float throttle = Input.GetAxis("Vertical");

//        braking = false;

//        if (throttle > 0)
//        {
//            if (Math.Abs(speed) < 0.5f && gear < 2)
//                NewtonPlugin.VehicleSetGear(vehicle, 2); // Switch to Drive

//            if (Math.Abs(speed) > 0.1f && gear < 2)
//                braking = true;

//        }
//        else if(throttle < 0)
//        {
//            if (Math.Abs(speed) < 0.9f && gear > 1)
//                NewtonPlugin.VehicleSetGear(vehicle, 1); // Reverse

//            if (Math.Abs(speed) > 0.1f && gear > 1)
//            {
//                braking = true;
//            }

//        }

//        if(braking)
//        {
//            NewtonPlugin.VehicleSetThrottle(vehicle, 0);
//            NewtonPlugin.VehicleSetBrakes(vehicle, 1);
//        }
//        else
//        {
//            NewtonPlugin.VehicleSetThrottle(vehicle, Math.Abs(throttle));
//            NewtonPlugin.VehicleSetBrakes(vehicle, 0);
//        }


//        if (Input.GetKey(KeyCode.Space))
//            NewtonPlugin.VehicleSetHandBrakes(vehicle, 1.0f);
//        else
//            NewtonPlugin.VehicleSetHandBrakes(vehicle, 0.0f);


//        // Update transform
//        Matrix4x4 mat = Matrix4x4.identity;
//        NewtonPlugin.BodyGetMatrix(body, ref mat);

//        Quaternion q = new Quaternion();
//        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] + mat[1, 1] + mat[2, 2])) / 2;
//        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] - mat[1, 1] - mat[2, 2])) / 2;
//        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] + mat[1, 1] - mat[2, 2])) / 2;
//        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] - mat[1, 1] + mat[2, 2])) / 2;
//        q.x *= Mathf.Sign(q.x * (mat[2, 1] - mat[1, 2]));
//        q.y *= Mathf.Sign(q.y * (mat[0, 2] - mat[2, 0]));
//        q.z *= Mathf.Sign(q.z * (mat[1, 0] - mat[0, 1]));

//        transform.position = new Vector3(mat.m03, mat.m13, mat.m23);
//        transform.rotation = q;

//        // Update tire transforms
//        foreach (NewtonVehicleTire tire in tires)
//        {
//            tire.UpdateTransform();
//        }


//    }

//    void OnDestroy()
//    {
//        Debug.Log("Destroying vehicle");
//        NewtonPlugin.DestroyVehicle(vehicle);
//    }

    
    
//}
