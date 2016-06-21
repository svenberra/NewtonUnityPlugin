using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public delegate void OnWorldUpdateCallback(float timestep);

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
        m_world.SetAsyncUpdate(m_asyncUpdate);
        m_world.SetFrameRate (m_updateRate);
        m_world.SetGravity(m_gravity.x, m_gravity.y, m_gravity.z);
        InitScene();
    }

    void OnDestroy()
    {
       DestroyScene();
    }

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

    void Update()
    {
        //Debug.Log("Update time :" + Time.deltaTime);
        m_world.Update(Time.deltaTime, OnWorldUpdate);
    }

    void OnWorldUpdate(float timestep)
    {
        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            OnWorldUpdate(rootObj, timestep);
        }
    }

    private void OnWorldUpdate(GameObject root, float timestep)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics != null)
        {
            bodyPhysics.OnApplyForceAndTorque(timestep);
        }

        foreach (Transform child in root.transform)
        {
            OnWorldUpdate(child.gameObject, timestep);
        }
    }



    private dNewtonWorld m_world = new dNewtonWorld();
    public int m_updateRate = 120;
    public Vector3 m_gravity = new Vector3 (0.0f, -9.8f, 0.0f);
    public bool m_asyncUpdate = true;
}


