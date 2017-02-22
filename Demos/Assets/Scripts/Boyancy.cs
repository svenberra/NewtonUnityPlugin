using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyancy : NewtonBodyScript
{

    void Start()
    {
    }

    void Update()
    {
    }

    public override void OnApplyForceAndTorque(float timestep)
    {
    }

    override public void OnCollision(NewtonBody otherBody)
    {
        otherBody.m_forceAcc += new Vector3(0, 11, 0);
    }

}
