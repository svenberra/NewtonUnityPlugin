using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeRotate : MonoBehaviour {

    NewtonHingeActuator na = null;
    float targetAngle = 120.0f;

    // Use this for initialization
    void Start () {
        na = GetComponent<NewtonHingeActuator>();
        targetAngle = na.MaximumAngle;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (na)
        {
            float angle = na.GetJointAngle();
            if (targetAngle - angle < 1.0f)
            {
                na.TargetAngle = na.MaximumAngle;
            }
            else
            {
                na.TargetAngle = na.MinimumAngle;
            }
        }	
	}
}

