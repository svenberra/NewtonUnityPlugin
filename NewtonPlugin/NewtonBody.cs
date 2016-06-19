using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


public class NewtonBodyCollision
{
    struct ColliderShapePair
    {
        public NewtonCollider m_collider;
        public dNewtonCollision m_shape;
    }

    public NewtonBodyCollision(NewtonBody body)
    {
        List<NewtonCollider> colliderList = new List<NewtonCollider>();
        TraverseColliders(body.gameObject, colliderList, body.gameObject);

        if (colliderList.Count == 0)
        {
            Debug.Log("TODO: add a NULL collision here");
        }
        else if (colliderList.Count == 1)
        {
            int index = 0;
            m_collidersArray = new ColliderShapePair[colliderList.Count];
            foreach (NewtonCollider collider in colliderList)
            {
                m_collidersArray[index].m_collider = collider;
                m_collidersArray[index].m_shape = collider.CreateBodyShape(body.m_world);
                index++;
            }
        }
        else
        {
            Debug.Log("TODO:: Build compound the NULL collision here");
            /*
                        int index = 0;
                        m_collidersArray = new ColliderShapePair[colliderList.Count];
                        foreach (NewtonCollider collider in colliderList)
                        {
                            m_collidersArray[index].m_collider = collider;
                            m_collidersArray[index].m_shape = collider.CreateBodyShape(m_body.m_world);
                        }
            */
        }
    }

    public void Destroy()
    {
        for (int i = 0; i < m_collidersArray.Length; i ++)
        {
            m_collidersArray[i].m_shape.Dispose();
            m_collidersArray[i].m_shape = null;
            m_collidersArray[i].m_collider = null;
        }
    }

    private void TraverseColliders(GameObject gameObject, List<NewtonCollider> colliderList, GameObject rootObject)
    {
        // Don't fetch colliders from children with NewtonBodies
        if ((gameObject == rootObject) || (gameObject.GetComponent<NewtonBody>() == null))
        {
            //Fetch all colliders
            foreach (NewtonCollider collider in gameObject.GetComponents<NewtonCollider>())
            {
                colliderList.Add(collider);
            }

            foreach (Transform child in gameObject.transform)
            {
                TraverseColliders(child.gameObject, colliderList, rootObject);
            }
        }
    }

    public dNewtonCollision GetShape()
    {
        return m_collidersArray[0].m_shape;
    }

    ColliderShapePair[] m_collidersArray;
}

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
            }    */

    void Start()
    {
        //m_rotBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (Quaternion)));
        //m_positBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Vector3)));
    }

    void OnDestroy()
    {
        DestroyRigidBody();
        //Marshal.FreeHGlobal(m_rotBuffer);
        //Marshal.FreeHGlobal(m_positBuffer);
    }

    // Update is called once per frame
    void Update()
    {
        IntPtr positionPtr = m_body.GetPosition();
        IntPtr rotationPtr = m_body.GetRotation();

        Marshal.Copy(positionPtr, m_positionPtr, 0, 3);
        Marshal.Copy(rotationPtr, m_rotationPtr, 0, 4);
        transform.position = new Vector3(m_positionPtr[0], m_positionPtr[1], m_positionPtr[2]);
        transform.rotation = new Quaternion(m_rotationPtr[1], m_rotationPtr[2], m_rotationPtr[3], m_rotationPtr[0]);
        //Debug.Log("yyyy " + transform.rotation[0] + " " + transform.rotation[1] + " " + transform.rotation[2] + " " + transform.rotation[3]);
    }


    public void InitRigidBody()
    {
        m_collision = new NewtonBodyCollision(this);

        Matrix4x4 matrix = Matrix4x4.identity;
        matrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
        Marshal.StructureToPtr(matrix, pnt, false);
        m_body = new dNewtonDynamicBody(m_world.GetWorld(), m_collision.GetShape(), pnt);
        Marshal.FreeHGlobal(pnt);
        //Debug.Log("xxxx " + transform.rotation[0] + " " + transform.rotation[1] + " " + transform.rotation[2] + " " + transform.rotation[3]);
    }

    public void DestroyRigidBody()
    {
        if (m_body != null)
        {
           m_body.Dispose();
           m_body = null;
        }

        if (m_collision != null)
        {
            m_collision.Destroy();
            m_collision = null;
        }
    }

    //public float m_mass;
    public NewtonWorld m_world;

    private dNewtonBody m_body = null;
    private NewtonBodyCollision m_collision = null;
    private float[] m_positionPtr = new float[3];
    private float[] m_rotationPtr = new float[4];
}


