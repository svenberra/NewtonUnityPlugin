using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour {

    GameObject reference;

	// Use this for initialization
	void Start () {

        reference = GameObject.Find("Box1");
	}

	// Update is called once per frame
	void Update ()
    {
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,100,20),"Spawn object"))
        {
            var pos = Random.insideUnitSphere * 5 + new Vector3(0,6,0);
            var rot = Random.rotation;
            var go = Instantiate(reference, pos, rot);
            go.GetComponent<NewtonBody>().InitRigidBody();
        }
    }
}
