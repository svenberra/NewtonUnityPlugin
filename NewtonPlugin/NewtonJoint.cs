using System;
using UnityEngine;


abstract public class NewtonJoint : MonoBehaviour
{
    abstract public void Create();
    
    public float Stiffness
    {
        get
        {
            return m_stiffness;
        }
        set
        {
            m_stiffness = value;
            if (m_joint != null)
            {
                m_joint.SetStiffness(m_stiffness);
            }
        }
    }
    
    public dNewtonJoint m_joint = null;
    public NewtonBody m_otherBody = null;
    public float m_stiffness = 1.0f;
    public float m_gizmoScale = 1.0f;
}





