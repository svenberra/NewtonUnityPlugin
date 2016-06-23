using UnityEngine;
using System;

namespace NewtonPlugin
{

    abstract public class NewtonJoint : MonoBehaviour
    {
        abstract public IntPtr CreateJoint();
    }
    private NewtonBody m_body;
    public NewtonBody m_parentBody;
}


