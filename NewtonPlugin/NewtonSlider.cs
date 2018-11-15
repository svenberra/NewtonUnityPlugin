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


[AddComponentMenu("Newton Physics/Joints/Slider")]
public class NewtonSlider: NewtonJoint
{
    public override void InitJoint()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        dMatrix matrix = Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation));
        IntPtr otherBody = (m_otherBody != null) ? m_otherBody.GetBody().GetBody() : new IntPtr(0);
        m_joint = new dNewtonJointSlider(matrix, child.GetBody().GetBody(), otherBody);

        Stiffness = m_stiffness;
        EnableLimits = m_enableLimits;
        SetSpringDamper = m_setSpringDamper;
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
        if (m_enableLimits)
        {
            // draw hinge limit
        }
    }

    public bool EnableLimits
    {
        get
        {
            return m_enableLimits;
        }
        set
        {
            m_enableLimits = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetLimits(m_enableLimits, m_minLimit, m_maxLimit);
            }
        }
    }

    public float MinimumLimit
    {
        get
        {
            return m_minLimit;
        }
        set
        {
            m_minLimit = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetLimits(m_enableLimits, m_minLimit, m_maxLimit);
            }
        }
    }

    public float MaximunLimit
    {
        get
        {
            return m_maxLimit;
        }
        set
        {
            m_maxLimit = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetLimits(m_enableLimits, m_minLimit, m_maxLimit);
            }
        }
    }

    public bool SetSpringDamper
    {
        get
        {
            return m_setSpringDamper;
        }
        set
        {
            m_setSpringDamper = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetAsSpringDamper(m_setSpringDamper, m_springDamperForceMixing, m_springConstant, m_damperConstant);
            }
        }
    }

    public float SpringDamperForceMixing
    {
        get
        {
            return m_springDamperForceMixing;
        }
        set
        {
            m_springDamperForceMixing = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetAsSpringDamper(m_setSpringDamper, m_springDamperForceMixing, m_springConstant, m_damperConstant);
            }
        }
    }

    public float SpringConstant
    {
        get
        {
            return m_springConstant;
        }
        set
        {
            m_springConstant = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetAsSpringDamper(m_setSpringDamper, m_springDamperForceMixing, m_springConstant, m_damperConstant);
            }
        }
    }

    public float DamperConstant
    {
        get
        {
            return m_damperConstant;
        }
        set
        {
            m_damperConstant = value;
            if (m_joint != null)
            {
                dNewtonJointSlider joint = (dNewtonJointSlider)m_joint;
                joint.SetAsSpringDamper(m_setSpringDamper, m_springDamperForceMixing, m_springConstant, m_damperConstant);
            }
        }
    }

    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
    public bool m_enableLimits = false;
    public float m_minLimit = -1.0f;
    public float m_maxLimit =  1.0f;
    public bool m_setSpringDamper = false;
    public float m_springDamperForceMixing = 0.9f;
    public float m_springConstant = 0.0f;
    public float m_damperConstant = 10.0f;
}


[AddComponentMenu("Newton Physics/Joints/Slider Actuator")]
public class NewtonSliderActuator : NewtonJoint
{
    public override void InitJoint()
    {
        NewtonBody child = GetComponent<NewtonBody>();
        dMatrix matrix = Utils.ToMatrix(m_posit, Quaternion.Euler(m_rotation));
        IntPtr otherBody = (m_otherBody != null) ? m_otherBody.GetBody().GetBody() : new IntPtr(0);
        m_joint = new dNewtonJointSliderActuator(matrix, child.GetBody().GetBody(), otherBody);

        Speed = m_speed;
        MaxForce = m_maxForce;
        MinForce = m_minForce;
        TargetPosition = m_targetPosition;
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

    public float MaxForce
    {
        get
        {
            return m_maxForce;
        }
        set
        {
            m_maxForce = Math.Abs (value);
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetMaxForce(m_maxForce);
            }
        }
    }

    public float MinForce
    {
        get
        {
            return m_minForce;
        }
        set
        {
            m_minForce = -Math.Abs(value);
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetMinForce(m_minForce);
            }
        }
    }


    public float Speed
    {
        get
        {
            return m_speed;
        }
        set
        {
            m_speed = value;
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetSpeed(m_speed);
            }
        }
    }

    public float TargetPosition
    {
        get
        {
            return m_targetPosition;
        }
        set
        {
            m_targetPosition = value;
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetTargetPosition(m_targetPosition, m_minPosition, m_maxPosition);
            }
        }
    }

    public float MinimumPosition
    {
        get
        {
            return m_minPosition;
        }
        set
        {
            m_minPosition = value;
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetTargetPosition(m_targetPosition, m_minPosition, m_maxPosition);
            }
        }
    }

    public float MaximumPosition
    {
        get
        {
            return m_maxPosition;
        }
        set
        {
            m_maxPosition = value;
            if (m_joint != null)
            {
                dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
                joint.SetTargetPosition(m_targetPosition, m_minPosition, m_maxPosition);
            }
        }
    }

    public float GetPosition()
    {
        float position = 0.0f;
        if (m_joint != null)
        {
            dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
            position = joint.GetPosition();
        }
        return position;
    }

/*
    public float GetJointSpeed()
    {
        float speed = 0.0f;
        if (m_joint != null)
        {
            dNewtonJointSliderActuator joint = (dNewtonJointSliderActuator)m_joint;
            speed = joint.GetSpeed();
        }
        return speed;
    }
*/
    
    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
    public float m_maxForce = 10.0f;
    public float m_minForce = -10.0f;
    public float m_speed = 1.0f;
    public float m_targetPosition = 0.0f;
    public float m_minPosition = -1.0f;
    public float m_maxPosition = 1.0f;
}



