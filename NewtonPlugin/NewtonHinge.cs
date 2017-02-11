using System;
using UnityEngine;
using System.Runtime.InteropServices;


[AddComponentMenu("Newton Physics/Joints/Hinge")]
public class NewtonHinge : NewtonJoint
{
    public override void Create()
    {
     Debug.Log("xxxxxxxx I am here");

        Matrix4x4 matrix = Matrix4x4.identity;
        matrix.SetTRS(transform.position, transform.rotation, Vector3.one);
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
}




