using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySet : MonoBehaviour {

    NewtonBody body = null;

    [Tooltip("Velocity in local space")]
    public Vector3 Velocity = new Vector3(1,0,0);

	// Use this for initialization
	void Start () {

        body = GetComponent<NewtonBody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(body)
        {
            body.Velocity = transform.TransformDirection(Velocity);
        }
		
	}
}
