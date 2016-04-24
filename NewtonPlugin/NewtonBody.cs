using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace NewtonPlugin
{

    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Rigid Body")]
    public class NewtonBody : MonoBehaviour
    {
        public bool Kinematic = false;
        public bool KinematicCollidable = false;
        public float Mass = 1.0f;

        internal IntPtr pBody = IntPtr.Zero;

        public Matrix4x4 BodyTransform
        {
            get
            {
                Matrix4x4 mat = Matrix4x4.identity;
                NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);
                return mat;
            }

            set
            {
                NewtonAPI.NewtonBodySetMatrix(pBody, ref value);
            }
        }

        public Vector3 GetPosition()
        {
            Matrix4x4 mat = Matrix4x4.identity;
            NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);
            return new Vector3(mat.m03, mat.m13, mat.m23);
        }

        public Quaternion GetRotation()
        {
            Matrix4x4 mat = Matrix4x4.identity;
            NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);
            Quaternion q = new Quaternion();
            q.w = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] + mat[1, 1] + mat[2, 2])) / 2;
            q.x = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] - mat[1, 1] - mat[2, 2])) / 2;
            q.y = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] + mat[1, 1] - mat[2, 2])) / 2;
            q.z = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] - mat[1, 1] + mat[2, 2])) / 2;
            q.x *= Mathf.Sign(q.x * (mat[2, 1] - mat[1, 2]));
            q.y *= Mathf.Sign(q.y * (mat[0, 2] - mat[2, 0]));
            q.z *= Mathf.Sign(q.z * (mat[1, 0] - mat[0, 1]));
            return q;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(position, rotation, Vector3.one);
            BodyTransform = matrix;
        }

        void Start()
        {

            IntPtr pWorld = NewtonWorld.Instance.pWorld;
            IntPtr pColl = IntPtr.Zero;

            NewtonCollider[] colliders = GetComponentsInChildren<NewtonCollider>();

            if (colliders.Length == 0) // No collider found, create null collision
            {
                pColl = NewtonAPI.NewtonCreateNull(pWorld);
            }
            else if (colliders.Length == 1) // One collider found
            {
                NewtonCollider coll = colliders[0];

                if (coll.transform == transform)
                    pColl = coll.CreateCollider(false); // Collider is a component of the same GameObject the Body is attached to. No offset available in this case.
                else
                    pColl = coll.CreateCollider(true); // Collider is a component of a child GameObject, apply the child GameObjects offset transform.
            }
            else // Several colliders found, create a compound.
            {
                pColl = NewtonAPI.NewtonCreateCompoundCollision(pWorld, 0);
                NewtonAPI.NewtonCompoundCollisionBeginAddRemove(pColl);

                foreach (NewtonCollider coll in colliders)
                {
                    IntPtr pSubColl;

                    if (coll.transform == transform)
                        pSubColl = coll.CreateCollider(false);
                    else
                        pSubColl = coll.CreateCollider(true);

                    NewtonAPI.NewtonCompoundCollisionAddSubCollision(pColl, pSubColl);
                    NewtonAPI.NewtonDestroyCollision(pSubColl);
                }

                NewtonAPI.NewtonCompoundCollisionEndAddRemove(pColl);
            }

            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

            if (!Kinematic)
                pBody = NewtonAPI.NewtonCreateDynamicBody(pWorld, pColl, ref matrix);
            else
            {
                pBody = NewtonAPI.NewtonCreateKinematicBody(pWorld, pColl, ref matrix);
                if (KinematicCollidable)
                    NewtonAPI.NewtonBodySetCollidable(pBody, 1);
            }

            NewtonAPI.NewtonBodySetMassProperties(pBody, Mass, pColl);

            NewtonAPI.NewtonBodySetForceAndTorqueCallback(pBody, ApplyForceAndTorque);

            //NewtonAPI.NewtonBodySetTransformCallback(pBody, SetTransform);

            //gcHandle_instance = GCHandle.Alloc(this, GCHandleType.Normal);
            //NewtonAPI.NewtonBodySetUserData(pBody, GCHandle.ToIntPtr(gcHandle_instance));

            NewtonAPI.NewtonDestroyCollision(pColl); // Release the reference

            Debug.Log("Created body(" + pBody.ToString() + ")");


        }

        // Update is called once per frame
        void Update()
        {

            //TODO: Use Newton transform callback instead, not need to fetch the transform if the body hasn't moved.
            Matrix4x4 mat = Matrix4x4.identity;
            NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);

            Quaternion q = new Quaternion();
            q.w = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] + mat[1, 1] + mat[2, 2])) / 2;
            q.x = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] - mat[1, 1] - mat[2, 2])) / 2;
            q.y = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] + mat[1, 1] - mat[2, 2])) / 2;
            q.z = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] - mat[1, 1] + mat[2, 2])) / 2;
            q.x *= Mathf.Sign(q.x * (mat[2, 1] - mat[1, 2]));
            q.y *= Mathf.Sign(q.y * (mat[0, 2] - mat[2, 0]));
            q.z *= Mathf.Sign(q.z * (mat[1, 0] - mat[0, 1]));


            transform.position = new Vector3(mat.m03, mat.m13, mat.m23);
            transform.rotation = q;

        }

        void OnDestroy()
        {
            //Debug.Log("Destroying body");

            //gcHandle_instance.Free();

            NewtonWorld world = NewtonWorld.Instance;

            // No need to destroy the body if the application is shutting down, Newton will have destroyed all remaining bodies.
            if (world!=null)
            {
                Debug.Log("Destroyed body(" + pBody.ToString() + ")");
                NewtonAPI.NewtonDestroyBody(pBody);
            }
            //else
            //    Debug.Log("World already destroyed");
        }

        static void ApplyForceAndTorque(IntPtr body, float timestep, int threadIndex)
        {
            float mass = 0, iXX = 0, iYY = 0, iZZ = 0;
            NewtonAPI.NewtonBodyGetMassMatrix(body, ref mass, ref iXX, ref iYY, ref iZZ);

            Vector3 force = new Vector3(0.0f, -9.8f * mass, 0.0f);
            NewtonAPI.NewtonBodyAddForce(body, ref force);
        }

        static void SetTransform(IntPtr pBody, ref Matrix4x4 matrix, int threadIndex)
        {

            //GCHandle gch = GCHandle.FromIntPtr(NewtonAPI.NewtonBodyGetUserData(pBody));

            //NewtonBody body = (NewtonBody)gch.Target;

            //Matrix4x4 mat = Matrix4x4.identity;
            //NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);

            //Quaternion q = new Quaternion();
            //q.w = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] + mat[1, 1] + mat[2, 2])) / 2;
            //q.x = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] - mat[1, 1] - mat[2, 2])) / 2;
            //q.y = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] + mat[1, 1] - mat[2, 2])) / 2;
            //q.z = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] - mat[1, 1] + mat[2, 2])) / 2;
            //q.x *= Mathf.Sign(q.x * (mat[2, 1] - mat[1, 2]));
            //q.y *= Mathf.Sign(q.y * (mat[0, 2] - mat[2, 0]));
            //q.z *= Mathf.Sign(q.z * (mat[1, 0] - mat[0, 1]));

            //body.transform.position = new Vector3(mat.m03, mat.m13, mat.m23);
            //body.transform.rotation = q;
        }

        //void TraverseColliders(GameObject obj)
        //{
        //    Debug.Log(obj.name);
        //    foreach (Transform child in obj.transform)
        //    {
        //        TraverseColliders(child.gameObject);
        //    }


        //}


    }

}