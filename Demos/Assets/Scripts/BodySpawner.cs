using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour {

    public GameObject reference;
    public int BodiesToSpawn = 10;
    public float SpawnRadius = 10.0f;

	// Use this for initialization
	void Start () {

        for(var i = 0;i<BodiesToSpawn;i++)
        {
            var pos = Random.insideUnitSphere * SpawnRadius + reference.transform.position;
            var rot = Random.rotation;
            var go = Instantiate(reference, pos, rot);
            go.GetComponent<NewtonBody>().InitRigidBody();
        }


    }

}
