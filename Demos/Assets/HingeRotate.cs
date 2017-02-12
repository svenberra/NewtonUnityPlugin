using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeRotate : MonoBehaviour {

    NewtonActuator na = null;
    float angle = 0.0f;

    // Use this for initialization
    void Start () {

        na = GetComponent<NewtonActuator>();
	}
	
	// Update is called once per frame
	void Update () {

        angle += 1.0f * Time.deltaTime;
        if (angle >= 360)
            angle = angle - 360.0f;

        if (na)
        {
            na.TargetAngle = angle;
        }

		
	}
}

