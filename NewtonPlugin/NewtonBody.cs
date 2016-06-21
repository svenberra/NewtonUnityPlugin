using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


abstract public class NewtonBodyForceAction : MonoBehaviour
{
    abstract public void ApplyForceAction(NewtonBody body, float timestep);
}


[AddComponentMenu("Newton Physics/Force Actions/force field")]
public class NewtonBodyForceField :  NewtonBodyForceAction
{
    public override void ApplyForceAction(NewtonBody body, float timestep)
    {
        body.m_forceAcc += m_forceValue;
    }

    public Vector3 m_forceValue;
}


[DisallowMultipleComponent]
[AddComponentMenu("Newton Physics/Rigid Body")]
public class NewtonBody : MonoBehaviour
{
    /*
        public bool Kinematic = false;
        public bool KinematicCollidable = false;

*/



    void Start()
    {
        m_forceAccPtr = Marshal.AllocHGlobal(Marshal.SizeOf(m_forceAcc));
        m_torqueAccPtr = Marshal.AllocHGlobal(Marshal.SizeOf(m_torqueAcc));
    }

    void OnDestroy()
    {
        DestroyRigidBody();
        Marshal.FreeHGlobal(m_forceAccPtr);
        Marshal.FreeHGlobal(m_torqueAccPtr);
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
        IntPtr floatsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
        Marshal.StructureToPtr(matrix, floatsPtr, false);
        m_body = new dNewtonDynamicBody(m_world.GetWorld(), m_collision.GetShape(), floatsPtr, m_mass);
        Marshal.FreeHGlobal(floatsPtr);
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
       

    public void OnApplyForceAndTorque(float timestep)
    {
        if (m_body != null)
        {
            NewtonBodyForceAction[] actions = GetComponents<NewtonBodyForceAction>();
            if (actions.Length >= 1)
            {
                m_forceAcc = new Vector3(0.0f, 0.0f, 0.0f);
                m_torqueAcc = new Vector3(0.0f, 0.0f, 0.0f);
                foreach (NewtonBodyForceAction action in actions)
                {
                    action.ApplyForceAction(this, timestep);
                }

                Marshal.StructureToPtr(m_forceAcc, m_forceAccPtr, false);
                Marshal.StructureToPtr(m_torqueAcc, m_torqueAccPtr, false);
                m_body.AddForceAndTorque(m_forceAccPtr, m_torqueAccPtr);
            }
        }
    }

    public float m_mass;
    public NewtonWorld m_world;

    private dNewtonBody m_body = null;
    private NewtonBodyCollision m_collision = null;
    private float[] m_positionPtr = new float[3];
    private float[] m_rotationPtr = new float[4];

    public Vector3 m_forceAcc { get; set; }
    public Vector3 m_torqueAcc { get; set; }
    private IntPtr m_forceAccPtr;
    private IntPtr m_torqueAccPtr;
}


