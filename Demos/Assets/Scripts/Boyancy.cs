using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyancy : NewtonBodyScript
{

    private Vector3 force;
    private NewtonBody body;

    void Start()
    {
        force = Vector3.zero;
        body = GetComponent<NewtonBody>();
    }

    void Update()
    {

    }

    public override void OnApplyForceAndTorque(float timestep)
    {
        body.GetBody().AddForce(new dVector(force.x, force.y, force.z));
        force = Vector3.zero;
    }

    override public void OnCollision(NewtonBody otherBody)
    {
        if (otherBody.gameObject.tag == "Water")
        {
            force = new Vector3(0, 11, 0);
        }
    }

}
