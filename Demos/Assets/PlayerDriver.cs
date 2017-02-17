using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDriver : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        motor = transform.Find("motor").GetComponent<NewtonBody>();
        motorJoint = transform.Find("motor").GetComponent<NewtonUniversalActuator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (motorJoint != null)
        {
            // control forward and backwoar movement
            if (Input.GetKey(KeyCode.W))
            {
                motor.SleepState = false;
                motorJoint.TargetAngle1 = 1e10f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                motor.SleepState = false;
                motorJoint.TargetAngle1 = -1e10f;
            }
            else
            {
                motorJoint.TargetAngle1 = motorJoint.GetJointAngle1();
            }

            // control sterring movement
            if (Input.GetKey(KeyCode.A))
            {
                motor.SleepState = false;
                motorJoint.TargetAngle0 = 1e10f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                motor.SleepState = false;
                motorJoint.TargetAngle0 = -1e10f;
            }
            else
            {
                motorJoint.TargetAngle0 = motorJoint.GetJointAngle0();
            }
        }
    }

    NewtonBody motor = null;
    NewtonUniversalActuator motorJoint = null;
}
