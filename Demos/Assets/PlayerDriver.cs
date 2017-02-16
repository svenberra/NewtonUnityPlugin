using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDriver : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        motor = transform.Find("motor").GetComponent<NewtonBody>();
//      motorJoint = transform.Find("motor").GetComponent<NewtonUniversalActuator>();
        if (motor != null)
        {
            Debug.Log("xxxxx motor found");
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    NewtonBody motor = null;
    NewtonUniversalActuator motorJoint = null;
}
