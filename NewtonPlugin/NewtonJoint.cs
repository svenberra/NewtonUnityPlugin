using System;
using UnityEngine;


abstract public class NewtonJoint : MonoBehaviour
{
    abstract public void Create(NewtonWorld world);

//  CustomJoint m_joint;
    public NewtonBody m_body0;
    public NewtonBody m_body1;
}

    



