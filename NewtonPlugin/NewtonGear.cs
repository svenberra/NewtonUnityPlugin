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

            NewtonBody child = GetComponent<NewtonBody>();
            m_joint = new dNewtonJointGear(m_gearRatio, new dVector (childPin.x, childPin.y, childPin.z, 0.0f), new dVector(parentPin.x, parentPin.y, parentPin.z, 0.0f), child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
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
        Gizmos.DrawRay(Vector3.zero, localMatrix0.GetColumn(0) * m_gizmoScale);
        if (m_otherBody != null)
        {
            Matrix4x4 bodyMatrix1 = Matrix4x4.identity;
            Matrix4x4 localMatrix1 = Matrix4x4.identity;
            bodyMatrix1.SetTRS(m_otherBody.transform.position, m_otherBody.transform.rotation, Vector3.one);
            localMatrix1.SetTRS(Vector3.zero, Quaternion.Euler(m_parentRotation), Vector3.one);

            Gizmos.color = Color.cyan;
            Gizmos.matrix = bodyMatrix1;
            Gizmos.DrawRay(Vector3.zero, localMatrix1.GetColumn(0) * m_gizmoScale);
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



