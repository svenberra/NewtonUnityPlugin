using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour {

    public GameObject reference;
    public int BodiesToSpawn = 10;
    

	// Use this for initialization
	void Start () {

        for(var i = 0;i<BodiesToSpawn;i++)
        {
            var pos = Random.insideUnitSphere * 15 + reference.transform.position;
            var rot = Random.rotation;
            var go = Instantiate(reference, pos, rot);
            go.GetComponent<NewtonBody>().InitRigidBody();
        }


    }

}
