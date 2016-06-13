using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NewtonPlugin
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Rigid Body")]
    public class NewtonBody : MonoBehaviour
    {
        /*
                public bool Kinematic = false;
                public bool KinematicCollidable = false;
                public float Mass = 1.0f;

                public Matrix4x4 BodyTransform
                {
                    get
                    {
                        Matrix4x4 mat = Matrix4x4.identity;
                        IntPtr ptrmat = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Matrix4x4)));
                        //Marshal.StructureToPtr(test_struct_simple, ptest_struct_simple, false);
                        NewtonWrapper.NewtonBodyGetMatrix(m_body, ptrmat);
                        Marshal.PtrToStructure(ptrmat, mat);
                        Marshal.FreeHGlobal(ptrmat);

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


        */

        void Start()
        {
        }

        void OnDestroy()
        {
            DestroyRigidBody();
        }

        public void InitRigidBody()
        {
/*
            if (m_userDataGlueObject == null)
            {
                m_userDataGlueObject = GCHandle.Alloc(this);

                // get the list of all collision components associated with the body
                List<NewtonCollider> colliders = new List<NewtonCollider>();
                TraverseColliders(gameObject, colliders);

                // generate the collision shape
                dNewtonCollision collision = m_world.BuildCollision(colliders);

                // create the body
                Matrix4x4 matrix = Matrix4x4.identity;
                matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

                IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
                // Copy the struct to unmanaged memory.
                Marshal.StructureToPtr(matrix, pnt, false);
                m_body = new dNewtonDynamicBody(m_world.GetWorld(), collision, pnt, GCHandle.ToIntPtr(m_userDataGlueObject));
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }
*/
        }

        public void DestroyRigidBody()
        {
            if (m_body != null)
            {
  //              m_body.Destroy();
//                m_body = null;
//                m_userDataGlueObject.Free();
            }
        }

        private void TraverseColliders(GameObject obj, List<NewtonPlugin.NewtonCollider> colliders)
        {
            // Don't fetch colliders from children with NewtonBodies
            if (obj != this.gameObject && obj.GetComponent<NewtonPlugin.NewtonBody>() != null)
            {
                return;
            }

            //Fetch all colliders
            foreach (NewtonPlugin.NewtonCollider coll in obj.GetComponents<NewtonPlugin.NewtonCollider>())
            {
                colliders.Add(coll);
            }

            foreach (Transform child in obj.transform)
            {
                TraverseColliders(child.gameObject, colliders);
            }
        }

        public NewtonWorld m_world;
//      public float m_mass;
        private dNewtonBody m_body = null;
//      private GCHandle m_userDataGlueObject;
    }
}

