using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;


abstract public class NewtonBodyForceAction : MonoBehaviour
{
    abstract public void ApplyForceAction(NewtonBody body, float timestep);
}


[AddComponentMenu("Newton Physics/Force Actions/force field")]
public class NewtonBodyForceField :  NewtonBodyForceAction
{
    public override void ApplyForceAction(NewtonBody body, float timestep)
    {
        body.m_forceAcc += m_forceValue;
    }

    public Vector3 m_forceValue;
}


