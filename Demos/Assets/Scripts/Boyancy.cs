using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyancy : NewtonBodyScript
{
    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
    }

    public override void OnApplyForceAndTorque(float timestep)
    {
    }

    override public void OnCollision(NewtonBody otherBody)
    {
        Vector4 plane = new Vector4(0, 1, 0, -mr.bounds.max.y);
        Vector3 force = Vector3.zero;
        Vector3 torque = Vector3.zero;

        float density = 0.8f;
        if (otherBody.gameObject.tag == "Ice")
            density = 0.9f;
        else if (otherBody.gameObject.tag == "Wood")
            density = 0.6f;
        else if (otherBody.gameObject.tag == "Metal")
            density = 1.2f;

        otherBody.CalculateBuoyancyForces(plane, ref force, ref torque, density);
        otherBody.m_forceAcc += force;
        otherBody.m_torqueAcc += torque;
    }

}
