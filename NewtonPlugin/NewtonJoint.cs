using System;
using UnityEngine;


abstract public class NewtonJoint : MonoBehaviour
{
    abstract public void Create(NewtonWorld world);

    public CustomJoint m_joint = null;
    public NewtonBody m_body0 = null;
    public NewtonBody m_body1 = null;
}

    



