/*
* This software is provided 'as-is', without any express or implied
* warranty. In no event will the authors be held liable for any damages
* arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
*/

using System;
using UnityEngine;
using System.Runtime.InteropServices;


[AddComponentMenu("Newton Physics/Joints/Plane 3 dof")]
public class NewtonPlane3DOF: NewtonJoint
{
    public override void Create()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        Matrix4x4 localMatrix = Matrix4x4.identity;
        localMatrix.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);
        IntPtr otherBody = (m_otherBody != null) ? m_otherBody.GetBody().GetBody() : new IntPtr(0);

        Vector3 pin = localMatrix.GetColumn(0);
        dVector normal = new dVector(pin.x, pin.y, pin.z, 0.0f);
        dVector posit = new dVector(m_posit.x, m_posit.y, m_posit.z, 1.0f);
        m_joint = new dNewtonJointPlane3DOF(posit, normal, child.GetBody().GetBody(), otherBody);
        Stiffness = m_stiffness;
    }

    void OnDrawGizmosSelected()
    {
        Matrix4x4 bodyMatrix = Matrix4x4.identity;
        Matrix4x4 localMatrix = Matrix4x4.identity;
        bodyMatrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrix.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);

        Gizmos.color = Color.red;
        Gizmos.matrix = bodyMatrix;
        Gizmos.DrawRay(m_posit, localMatrix.GetColumn(0) * m_gizmoScale);
    }

    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
}

[AddComponentMenu("Newton Physics/Joints/Plane 5 dof")]
public class NewtonPlane5DOF : NewtonJoint
{
    public override void Create()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        Matrix4x4 localMatrix = Matrix4x4.identity;
        localMatrix.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);
        IntPtr otherBody = (m_otherBody != null) ? m_otherBody.GetBody().GetBody() : new IntPtr(0);

        Vector3 pin = localMatrix.GetColumn(0);
        dVector normal = new dVector(pin.x, pin.y, pin.z, 0.0f);
        dVector posit = new dVector(m_posit.x, m_posit.y, m_posit.z, 1.0f);
        m_joint = new dNewtonJointPlane3DOF(posit, normal, child.GetBody().GetBody(), otherBody);
        Stiffness = m_stiffness;
    }

    void OnDrawGizmosSelected()
    {
        Matrix4x4 bodyMatrix = Matrix4x4.identity;
        Matrix4x4 localMatrix = Matrix4x4.identity;
        bodyMatrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrix.SetTRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);

        Gizmos.color = Color.red;
        Gizmos.matrix = bodyMatrix;
        Gizmos.DrawRay(m_posit, localMatrix.GetColumn(0) * m_gizmoScale);
    }

    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
}


