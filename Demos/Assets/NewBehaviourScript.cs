using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : NewtonScript
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    override public void OnCollision(dNewtonBody otherBody)
    {
        Debug.Log("xxxxxx woohoo collision notification script !!");
    }

}
