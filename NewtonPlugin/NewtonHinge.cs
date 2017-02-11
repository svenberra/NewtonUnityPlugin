using System;
using UnityEngine;
using System.Runtime.InteropServices;


[AddComponentMenu("Newton Physics/Joints/Hinge")]
public class NewtonHinge : NewtonJoint
{
    public override void Create(NewtonWorld world)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        IntPtr floatsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
        Marshal.StructureToPtr(matrix, floatsPtr, false);
        return new CustomHinge(floatsPtr, m_body0.GetBody().GetBody(), m_body1.GetBody().GetBody());
    }

}




