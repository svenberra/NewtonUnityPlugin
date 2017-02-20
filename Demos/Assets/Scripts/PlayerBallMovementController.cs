using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMovementController : NewtonBodyScript
{
   
    // Use this for initialization
    void Start ()
    {
        body = GetComponent<NewtonBody>();
    }

    override public void OnApplyForceAndTorque(float timestep)
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.SleepState = false;
            body.GetBody().AddTorque(new dVector(m_xScaler, 0.0f, 0.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            body.SleepState = false;
            body.GetBody().AddTorque(new dVector(-m_xScaler, 0.0f, 0.0f, 0.0f));
        }

        // control steering movement
        if (Input.GetKey(KeyCode.A))
        {
            body.SleepState = false;
            body.GetBody().AddTorque(new dVector(0.0f, 0.0f, m_zScaler, 0.0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            body.SleepState = false;
            body.GetBody().AddTorque(new dVector(0.0f, 0.0f, -m_zScaler, 0.0f));
        }
    }

    public float m_xScaler;
    public float m_zScaler;
    NewtonBody body = null;
}
