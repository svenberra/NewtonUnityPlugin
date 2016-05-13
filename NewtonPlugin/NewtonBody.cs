using System;
using NewtonAPI;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NewtonPlugin
{

    public abstract class NewtonBody : MonoBehaviour
    {
        protected IntPtr worldPtr;
        protected IntPtr bodyPtr;
        protected IntPtr btsPtr;

        public delegate void BodyDestroyEvent();
        public event BodyDestroyEvent OnBodyDestroy;

        internal abstract IntPtr GetBodyPointer();

        public unsafe void Update()
        {

            if (btsPtr != IntPtr.Zero)
            {
                BodyTransformState* bts = (BodyTransformState*)btsPtr;
                transform.position = bts->GetInterpolatedPosition(NewtonManager.TimeAlpha);
                transform.rotation = bts->GetInterpolatedRotation(NewtonManager.TimeAlpha);
            }

            //NewtonInvoke.NewtonBodyGetPositionAndRotation(bodyPtr, (float*)&pos, (float*)&rot);
            //transform.position = pos;
            //transform.rotation = new Quaternion(rot.y, rot.z, rot.w, rot.x);

            //BodyTransformState bts = null;
            //if(NewtonManager.bodyPointers.TryGetValue(bodyPtr, out bts))
            //{
            //    transform.position = bts.currentPosition;
            //    transform.rotation = bts.currentRotation;
            //}

        }

        public void OnDestroy()
        {
            // Inform connected joints to destroy themselves.
            if (OnBodyDestroy != null)
                OnBodyDestroy();

        }


    }


    [AddComponentMenu("Newton Physics/Rigid Body")]
    public class NewtonRigidBody: NewtonBody
    {
        public bool Kinematic = false;
        public bool KinematicCollidable = false;
        public float Mass = 1.0f;

        public void Awake()
        {
            CreateBody();
        }

        internal override IntPtr GetBodyPointer()
        {

            if (bodyPtr == IntPtr.Zero)
                CreateBody();

            return bodyPtr;
        }

        private unsafe void CreateBody()
        {
            if (bodyPtr != IntPtr.Zero)
                return;

            worldPtr = NewtonManager.Register(this);

            if (worldPtr == IntPtr.Zero)
            {
                Debug.Log("Something went wrong, world is 0");
                return;
            }

            IntPtr pColl = IntPtr.Zero;

            NewtonCollider[] colliders = Helpers.GetAllColliders(this.gameObject);

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

            if (!Kinematic)
                bodyPtr = NewtonInvoke.NewtonCreateDynamicBody(worldPtr, pColl, (float*)&matrix);
            else
            {
                bodyPtr = NewtonInvoke.NewtonCreateKinematicBody(worldPtr, pColl, (float*)&matrix);
                if (KinematicCollidable)
                    NewtonInvoke.NewtonBodySetCollidable(bodyPtr, 1);
            }

            NewtonInvoke.NewtonBodySetMassProperties(bodyPtr, Mass, pColl);

            NewtonInvoke.NewtonBodySetForceAndTorqueCallback(bodyPtr, NewtonManager.ApplyForceAndTorque);

            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            btsPtr = NewtonInvoke.NewtonCreateBodyTransformState((float*)&pos, (float*)&rot);
            NewtonInvoke.NewtonBodySetUserData(bodyPtr, btsPtr);

            NewtonInvoke.NewtonDestroyCollision(pColl); // Release the reference

            //Debug.Log("Created body(" + pBody.ToString() + ")");

        }

        public new void OnDestroy()
        {
            base.OnDestroy();

            if (bodyPtr != IntPtr.Zero)
            {
                NewtonInvoke.NewtonDestroyBodyTransformState(btsPtr);
                NewtonInvoke.NewtonDestroyBody(bodyPtr);
                bodyPtr = IntPtr.Zero;
                Debug.Log("[NewtonBody] Deleted unmanaged Body ptr attached to " + this.gameObject.name);


                NewtonManager.Unregister(this);
            }

        }



    }

}
