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
        Vector3 plane = new Vector3(0, 5, 0);
        Vector3 force = Vector3.zero;
        Vector3 torque = Vector3.zero;

        otherBody.CalculateBuoyancyForces(plane, ref force, ref torque);

        print(force);

        //Debug.Log(force);

        //otherBody.m_forceAcc += new Vector3(0, 11, 0);
    }

}
