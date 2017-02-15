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


[AddComponentMenu("Newton Physics/Joints/Universal")]
public class NewtonUniversal: NewtonJoint
{
    public override void Create()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        if (m_otherBody == null)
        {
            m_joint = new dNewtonJointUniversal(Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation)), child.GetBody().GetBody());
        }
        else
        {
            m_joint = new dNewtonJointUniversal(Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation)), child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
        }

        Stiffness = m_stiffness;
        EnableLimits_0 = m_enableLimits_0;
    }

    void OnDrawGizmosSelected()
    {
        Matrix4x4 bodyMatrix = Matrix4x4.identity;
        Matrix4x4 localMatrix = Matrix4x4.identity;
        bodyMatrix.SetTRS(transform.position, transform.rotation, Vector3.one);
        localMatrix.SetTRS(Vector3.zero, Quaternion.Euler(m_rotation), Vector3.one);

        Gizmos.matrix = bodyMatrix;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(m_posit, localMatrix.GetColumn(0) * m_gizmoScale);

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(m_posit, localMatrix.GetColumn(1) * m_gizmoScale);
    }

    public bool EnableLimits_0
    {
        get
        {
            return m_enableLimits_0;
        }
        set
        {
            m_enableLimits_0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_0(m_enableLimits_0, m_minLimit_0, m_maxLimit_0);
            }
        }
    }

    public float MinimumLimit_0
    {
        get
        {
            return m_minLimit_0;
        }
        set
        {
            m_minLimit_0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_0(m_enableLimits_0, m_minLimit_0, m_maxLimit_0);
            }
        }
    }

    public float MaximunLimit_0
    {
        get
        {
            return m_maxLimit_0;
        }
        set
        {
            m_maxLimit_0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_0(m_enableLimits_0, m_minLimit_0, m_maxLimit_0);
            }
        }
    }


    public bool EnableLimits_1
    {
        get
        {
            return m_enableLimits_1;
        }
        set
        {
            m_enableLimits_1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_1(m_enableLimits_1, m_minLimit_1, m_maxLimit_1);
            }
        }
    }

    public float MinimumLimit_1
    {
        get
        {
            return m_minLimit_1;
        }
        set
        {
            m_minLimit_1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_1(m_enableLimits_1, m_minLimit_1, m_maxLimit_1);
            }
        }
    }

    public float MaximunLimit_1
    {
        get
        {
            return m_maxLimit_1;
        }
        set
        {
            m_maxLimit_1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversal joint = (dNewtonJointUniversal)m_joint;
                joint.SetLimits_1(m_enableLimits_1, m_minLimit_1, m_maxLimit_1);
            }
        }
    }
    
    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
    public bool m_enableLimits_0 = false;
    public float m_minLimit_0 = -30.0f;
    public float m_maxLimit_0 =  30.0f;
    public bool m_enableLimits_1 = false;
    public float m_minLimit_1 = -30.0f;
    public float m_maxLimit_1 = 30.0f;
}


[AddComponentMenu("Newton Physics/Joints/Universal Actuator")]
public class NewtonUniversalActuator: NewtonJoint
{
    public override void Create()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        if (m_otherBody == null)
        {
            m_joint = new dNewtonJointUniversalActuator(Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation)), child.GetBody().GetBody());
        }
        else
        {
            m_joint = new dNewtonJointUniversalActuator(Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation)), child.GetBody().GetBody(), m_otherBody.GetBody().GetBody());
        }

        TargetAngle0 = m_targetAngle0;
        AngularRate0 = m_angularRate0;
        MaxTorque0 = m_maxTorque0;

        TargetAngle1 = m_targetAngle1;
        AngularRate1 = m_angularRate1;
        MaxTorque1 = m_maxTorque1;
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

    public float MaxTorque0
    {
        get
        {
            return m_maxTorque0;
        }
        set
        {
            m_maxTorque0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetMaxToque0(m_maxTorque0);
            }
        }
    }

    public float AngularRate0
    {
        get
        {
            return m_angularRate0;
        }
        set
        {
            m_angularRate0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetAngularRate0(m_angularRate0);
            }
        }
    }

    public float TargetAngle0
    {
        get
        {
            return m_targetAngle0;
        }
        set
        {
            m_targetAngle0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle0(m_targetAngle0, m_minAngle0, m_maxAngle0);
            }
        }
    }

    public float MinimumAngle0
    {
        get
        {
            return m_minAngle0;
        }
        set
        {
            m_minAngle0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle0(m_targetAngle0, m_minAngle0, m_maxAngle0);
            }
        }
    }

    public float MaximumAngle0
    {
        get
        {
            return m_maxAngle0;
        }
        set
        {
            m_maxAngle0 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle0(m_targetAngle0, m_minAngle0, m_maxAngle0);
            }
        }
    }

    public float GetJointAngle0()
    {
        float angle = 0.0f;
        if (m_joint != null)
        {
            dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
            angle = joint.GetAngle0();
        }
        return angle;
    }

    /*
        public float GetJointSpeed0()
        {
            float angle = 0.0f;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                angle = joint.GetAngle();
            }
            return angle;
        }
    */


    public float MaxTorque1
    {
        get
        {
            return m_maxTorque1;
        }
        set
        {
            m_maxTorque1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetMaxToque1(m_maxTorque1);
            }
        }
    }

    public float AngularRate1
    {
        get
        {
            return m_angularRate1;
        }
        set
        {
            m_angularRate1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetAngularRate1(m_angularRate1);
            }
        }
    }

    public float TargetAngle1
    {
        get
        {
            return m_targetAngle1;
        }
        set
        {
            m_targetAngle1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle1(m_targetAngle1, m_minAngle1, m_maxAngle1);
            }
        }
    }

    public float MinimumAngle1
    {
        get
        {
            return m_minAngle1;
        }
        set
        {
            m_minAngle1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle1(m_targetAngle1, m_minAngle1, m_maxAngle1);
            }
        }
    }

    public float MaximumAngle1
    {
        get
        {
            return m_maxAngle1;
        }
        set
        {
            m_maxAngle1 = value;
            if (m_joint != null)
            {
                dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
                joint.SetTargetAngle1(m_targetAngle1, m_minAngle1, m_maxAngle1);
            }
        }
    }

    public float GetJointAngle1()
    {
        float angle = 0.0f;
        if (m_joint != null)
        {
            dNewtonJointUniversalActuator joint = (dNewtonJointUniversalActuator)m_joint;
            angle = joint.GetAngle1();
        }
        return angle;
    }


    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
    public float m_maxTorque0 = 10.0f;
    public float m_angularRate0 = 1.0f;
    public float m_targetAngle0 = 0.0f;
    public float m_minAngle0 = -360.0f;
    public float m_maxAngle0 =  360.0f;

    public float m_maxTorque1 = 10.0f;
    public float m_angularRate1 = 1.0f;
    public float m_targetAngle1 = 0.0f;
    public float m_minAngle1 = -360.0f;
    public float m_maxAngle1 = 360.0f;

}



