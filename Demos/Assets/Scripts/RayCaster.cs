using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayCaster : MonoBehaviour {

	public NewtonWorld m_world;
	public float rayLength = 5.0f;

	private int dir = -1;
	private GameObject lastHitObj;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.deltaTime;

		var pos = transform.position;
		pos.x = pos.x + dir * dt;
		if (pos.x < -4) {
			pos.x = -4;
			dir = 1;
		} else if (pos.x > 12) {
			pos.x = 12;
			dir = -1;
		}

		transform.position = pos;

		if (m_world) {

			Vector3 direction = Vector3.down;
			Vector3 startPos = transform.position;
			Vector3 endPos = startPos + (direction * rayLength);

			NewtonRayHitInfo hitInfo;

			var excludemask = (1 << 9);	// Raycast against all layers except Layer 9

			if (m_world.Raycast (startPos, direction, rayLength, out hitInfo, excludemask)) {

				Debug.DrawLine (startPos, hitInfo.position, Color.red);

				if (hitInfo.body != null) {

					if (lastHitObj != hitInfo.body) {
						lastHitObj = hitInfo.body.gameObject;
						var material = lastHitObj.GetComponent<Renderer>().material;
						material.color = Color.green;				
					}
				}


			} else {

				if (lastHitObj != null) {
					var material = lastHitObj.GetComponent<Renderer>().material;
					material.color = Color.white;
					lastHitObj = null;
				}

				Debug.DrawLine (startPos, endPos, Color.yellow);
			}
		
		}

	}

}
