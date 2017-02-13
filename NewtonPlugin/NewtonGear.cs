using System;
using UnityEngine;
using System.Runtime.InteropServices;


[AddComponentMenu("Newton Physics/Joints/Gear")]
public class NewtonGear : NewtonJoint
{
    public override void Create()
    {
        if (m_otherBody)
        {
            Matrix4x4 localMatrix0 = Matrix4x4.identity;
            Matrix4x4 localMatrix1 = Matrix4x4.identity;
            localMatrix0.SetTRS(Vector3.zero, Quaternion.Euler(m_rotation), Vector3.one);
            localMatrix0.SetTRS(Vector3.zero, Quaternion.Euler(m_parentRotation), Vector3.one);

            Vector4 childPin = localMatrix0.GetRow(0);
            Vector4 parentPin = localMatrix1.GetRow(0);

            IntPtr childPinPtr = Marshal.AllocHGlobal(Marshal.SizeOf(childPin));
            IntPtr parentPinPtr = Marshal.AllocHGlobal(Marshal.SizeOf(parentPin));
            Marshal.StructureToPtr(childPin, childPinPtr, false);
            Marshal.StructureToPtr(parentPin, parentPinPtr, false);

            NewtonBody child = GetComponent<NewtonBody>();
            m_joint = new dNewtonJointGear(m_gearRatio, childPinPtr, parentPinPtr, child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
        }
    }

/*
    void OnDrawGizmosSelected()
    {
        Matrix4x4 bodyMatrix = Matrix4x4.identity;
        Matrix4x4 localMatrix = Matrix4x4.identity;
        bodyMatrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrix.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);

        Gizmos.color = Color.red;

        Gizmos.matrix = bodyMatrix;
        Vector3 direction = localMatrix.MultiplyPoint3x4(new Vector3(m_gizmoScale, 0.0f, 0.0f));

        Gizmos.DrawLine(m_posit, direction);
    }


    public float MaxTorque
    {
        get
        {
            return m_maxTorque;
        }
        set
        {
            m_maxTorque = value;
            if (m_joint != null)
            {
                dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
                hinge.SetMaxToque(m_maxTorque);
            }
        }
    }

    public float AngularRate
    {
        get
        {
            return m_angularRate;
        }
        set
        {
            m_angularRate = value;
            if (m_joint != null)
            {
                dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
                hinge.SetAngularRate(m_angularRate);
            }
        }
    }

    public float TargetAngle
    {
        get
        {
            return m_targetAngle;
        }
        set
        {
            m_targetAngle = value;
            if (m_joint != null)
            {
                dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
                hinge.SetTargetAngle(m_targetAngle, m_minAngle, m_maxAngle);
            }
        }
    }

    public float MinimumAngle
    {
        get
        {
            return m_minAngle;
        }
        set
        {
            m_minAngle = value;
            if (m_joint != null)
            {
                dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
                hinge.SetTargetAngle(m_targetAngle, m_minAngle, m_maxAngle);
            }
        }
    }

    public float MaximumAngle
    {
        get
        {
            return m_maxAngle;
        }
        set
        {
            m_maxAngle = value;
            if (m_joint != null)
            {
                dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
                hinge.SetTargetAngle(m_targetAngle, m_minAngle, m_maxAngle);
            }
        }
    }

    public float GetJointAngle()
    {
        float angle = 0.0f;
        if (m_joint != null)
        {
            dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
            angle = hinge.GetAngle();
        }
        return angle;
    }

    public float GetJointSpeed()
    {
        float angle = 0.0f;
        if (m_joint != null)
        {
            dNewtonHingeActuator hinge = (dNewtonHingeActuator)m_joint;
            angle = hinge.GetAngle();
        }
        return angle;
    }
*/

    public Vector3 m_rotation = Vector3.zero;
    public Vector3 m_parentRotation = Vector3.zero;
    public float m_gearRatio = 1.0f;
}



