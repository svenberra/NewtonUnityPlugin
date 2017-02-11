using System;
using UnityEngine;


abstract public class NewtonJoint : MonoBehaviour
{
    abstract public void Create();

    public dNewtonJoint m_joint = null;
    public NewtonBody m_otherBody = null;
}





