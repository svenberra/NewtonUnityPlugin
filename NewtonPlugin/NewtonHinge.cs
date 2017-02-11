using System;
using UnityEngine;
using System.Runtime.InteropServices;


[AddComponentMenu("Newton Physics/Joints/Hinge")]
public class NewtonHinge : NewtonJoint
{
    public override void Create()
    {
        Matrix4x4 bodyMatrix = Matrix4x4.identity;
        Matrix4x4 localMatrx = Matrix4x4.identity;

        bodyMatrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrx.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);

        Matrix4x4 matrix = localMatrx * bodyMatrix;

        IntPtr floatsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
        Marshal.StructureToPtr(matrix, floatsPtr, false);
        NewtonBody child = GetComponent<NewtonBody>();
        if (m_otherBody == null)
        {
            m_joint = new dNewtonHinge(floatsPtr, child.GetBody().GetBody());
        }
        else
        {
            m_joint = new dNewtonHinge(floatsPtr, child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
        }
    }

    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
}




