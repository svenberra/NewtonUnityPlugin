using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeRotate : MonoBehaviour
{

    NewtonHingeActuator na = null;

    // Use this for initialization
    void Start ()
    {
        na = GetComponent<NewtonHingeActuator>();
        na.TargetAngle = 2000.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (na)
        {
            float angle = na.GetJointAngle();
            if (na.TargetAngle >= 500.0f)
            {
                if (angle > 498.0f)
                {
                    na.TargetAngle = -1000.0f;
                }
            }
            else
            {
                if (angle < -600.0f)
                {
                    na.TargetAngle = 1000.0f;
                }
            }
        }	
    }
}

