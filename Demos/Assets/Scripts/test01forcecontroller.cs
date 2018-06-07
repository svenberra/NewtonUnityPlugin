using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01forcecontroller : NewtonBodyScript {

	public Vector3 force = new Vector3(100,0,0);
	private NewtonBody body;

	// Use this for initialization
	void Start () {

		body = GetComponent<NewtonBody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnApplyForceAndTorque(float timestep)
	{
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			body.GetBody().AddForce(force.x * body.m_mass, force.y * body.m_mass, force.z * body.m_mass);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			body.GetBody().AddForce (-force.x * body.m_mass, -force.y * body.m_mass , -force.z * body.m_mass);
		}

	}

}
