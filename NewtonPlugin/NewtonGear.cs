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
            localMatrix1.SetTRS(Vector3.zero, Quaternion.Euler(m_parentRotation), Vector3.one);

            Vector4 childPin = localMatrix0.GetColumn(0);
            Vector4 parentPin = localMatrix1.GetColumn(0);

            IntPtr childPinPtr = Marshal.AllocHGlobal(Marshal.SizeOf(childPin));
            IntPtr parentPinPtr = Marshal.AllocHGlobal(Marshal.SizeOf(parentPin));
            Marshal.StructureToPtr(childPin, childPinPtr, false);
            Marshal.StructureToPtr(parentPin, parentPinPtr, false);

            NewtonBody child = GetComponent<NewtonBody>();
            m_joint = new dNewtonJointGear(m_gearRatio, childPinPtr, parentPinPtr, child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
        }
    }

    void OnDrawGizmosSelected()
    {
        Matrix4x4 bodyMatrix0 = Matrix4x4.identity;
        Matrix4x4 localMatrix0 = Matrix4x4.identity;
        bodyMatrix0.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrix0.SetTRS(Vector3.zero, Quaternion.Euler(m_rotation), Vector3.one);

        Gizmos.color = Color.cyan;
        Gizmos.matrix = bodyMatrix0;
        Vector4 childPin = localMatrix0.GetColumn(0) * m_gizmoScale;
        Gizmos.DrawLine(Vector3.zero, childPin);
        if (m_otherBody != null)
        {
            Matrix4x4 bodyMatrix1 = Matrix4x4.identity;
            Matrix4x4 localMatrix1 = Matrix4x4.identity;
            bodyMatrix1.SetTRS(m_otherBody.transform.position, m_otherBody.transform.rotation, Vector3.one);
            localMatrix1.SetTRS(Vector3.zero, Quaternion.Euler(m_parentRotation), Vector3.one);

            Gizmos.color = Color.cyan;
            Gizmos.matrix = bodyMatrix1;
            Vector4 parentPin = localMatrix1.GetColumn(0) * m_gizmoScale;
            Gizmos.DrawLine(Vector3.zero, parentPin);
        }
    }

/*
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



