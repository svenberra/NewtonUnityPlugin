using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;


[DisallowMultipleComponent]
[AddComponentMenu("Newton Physics/Newton World")]
public class NewtonWorld : MonoBehaviour
{
    public dNewtonWorld GetWorld()
    {
        return m_world;
    }

    void Start()
    {
        m_world.SetFrameRate (m_updateRate);
//        InitScene();
    }

    void OnDestroy()
    {
//        UnityEngine.Debug.Log("xxxxxxxxx 5");
//        DestroyScene();
    }

/*
    private void InitPhysicsScene(GameObject root)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics != null)
        {
            bodyPhysics.InitRigidBody();
        }

        foreach (Transform child in root.transform)
        {
            InitPhysicsScene(child.gameObject);
        }
    }

    private void InitScene()
    {
        Debug.Log("tttttttttt___");
        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            InitPhysicsScene(rootObj);
        }
    }

    private void DestroyScene()
    {
        if (m_world != null)
        {
            GameObject[] objectList = gameObject.scene.GetRootGameObjects();
            foreach (GameObject rootObj in objectList)
            {
                DestroyPhysicsScene(rootObj);
            }

            m_world = null;
        }
    }

    private void DestroyPhysicsScene(GameObject root)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics != null)
        {
            bodyPhysics.DestroyRigidBody();
        }

        foreach (Transform child in root.transform)
        {
            DestroyPhysicsScene(child.gameObject);
        }
    }
*/
    void Update()
    {
        //Debug.Log("Update time :" + Time.deltaTime);
//        m_world.Update(Time.deltaTime);
    }

    public void OnDestroyNewtonWorld ()
    {
        m_world = null; 
    }

    private dNewtonWorld m_world = new dNewtonWorld();
    public int m_updateRate = 120;
}


