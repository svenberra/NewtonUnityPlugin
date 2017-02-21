using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouchTheFloor : NewtonBodyScript
{

    private NewtonBody body;
    private Vector3 force;
    private float timer;

    void Start()
    {
        force = Vector3.zero;
        body = GetComponent<NewtonBody>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public override void OnApplyForceAndTorque(float timestep)
    {
        if (timer > 0)
        {
            body.GetBody().AddForce(new dVector(force.x, force.y, force.z));
        }
    }

    override public void OnCollision(NewtonBody otherBody)
    {
        force = new Vector3(0, 20, 0);
        timer = Random.Range(1.0f, 3.0f);
    }

}