using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public delegate void OnApplyForceAndTorqueCallback(float timestep);

[DisallowMultipleComponent]
[AddComponentMenu("Newton Physics/Rigid Body")]
public class NewtonBody : MonoBehaviour
{
    /*
        public bool Kinematic = false;
        public bool KinematicCollidable = false;

*/

    void OnApplyForceAndTorque(float timestep)
    {
//        float mass = 0, iXX = 0, iYY = 0, iZZ = 0;
//        NewtonAPI.NewtonBodyGetMassMatrix(body, ref mass, ref iXX, ref iYY, ref iZZ);

//        Vector3 force = new Vector3(0.0f, -9.8f * mass, 0.0f);
//        NewtonAPI.NewtonBodyAddForce(body, ref force);
    }


    void OnDestroy()
    {
        DestroyRigidBody();
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
        m_body = new dNewtonDynamicBody(m_world.GetWorld(), m_collision.GetShape(), pnt, m_mass, OnApplyForceAndTorque);
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

    public float m_mass;
    public NewtonWorld m_world;

    private dNewtonBody m_body = null;
    private NewtonBodyCollision m_collision = null;
    private float[] m_positionPtr = new float[3];
    private float[] m_rotationPtr = new float[4];
}


