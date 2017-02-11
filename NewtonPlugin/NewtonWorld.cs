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
        m_bodyCount = 0;
        m_bodyCapacity = 128;
        m_bodyArray = new NewtonBody[m_bodyCapacity];
        m_onWorldCallcak = new OnWorldUpdateCallback(OnWorldUpdate);

        m_world.SetAsyncUpdate(m_asyncUpdate);
        m_world.SetFrameRate (m_updateRate);
        m_world.SetThreadsCount(m_numberOfThreads);
        m_world.SetSolverMode(m_solverIterationsCount);
        m_world.SetBroadPhase(m_broadPhaseType);
        m_world.SetGravity(m_gravity.x, m_gravity.y, m_gravity.z);
        InitScene();
    }

    void OnDestroy()
    {
       DestroyScene();
       m_onWorldCallcak = null;
    }

    private void InitPhysicsScene(GameObject root)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics != null)
        {
            bodyPhysics.InitRigidBody(m_bodyCount);
            if (m_bodyCount >= m_bodyCapacity)
            {
                m_bodyCapacity *= 2;
                NewtonBody[] bodyArray = new NewtonBody[m_bodyCapacity];
                for (int i = 0; i < m_bodyCount; i++)
                {
                    bodyArray[i] = m_bodyArray[i];
                    m_bodyArray[i] = null;
                }
                m_bodyArray = null;
                m_bodyArray = bodyArray;
            }

            m_bodyArray[m_bodyCount] = bodyPhysics;
            m_bodyCount++; 
        }

        foreach (Transform child in root.transform)
        {
            InitPhysicsScene(child.gameObject);
        }
    }

    private void InitPhysicsJoints(GameObject root)
    {
        foreach (NewtonHinge joint in root.GetComponents<NewtonHinge>())
        {
            joint.Create();
        }

        foreach (Transform child in root.transform)
        {
            InitPhysicsJoints(child.gameObject);
        }
    }

    private void InitScene()
    {
        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            InitPhysicsScene(rootObj);
        }

        foreach (GameObject rootObj in objectList)
        {
  Debug.Log("xxxxxxxxxxxxxxxxx I am here");
            InitPhysicsJoints(rootObj);
        }
    }

    private void DestroyScene()
    {
        if (m_world != null)
        {
            for (int i = 0; i < m_bodyCount; i ++)
            {
                if (m_bodyArray[i] != null)
                {
                    m_bodyArray[i].DestroyRigidBody();
                }
                m_bodyArray[i] = null;
            }
            m_bodyArray = null;
            m_world = null;
        }
    }


    void Update()
    {
        //Debug.Log("Update time :" + Time.deltaTime);
        m_world.Update(Time.deltaTime, m_onWorldCallcak);
    }

    void OnWorldUpdate(float timestep)
    {
        for (int i = 0; i < m_bodyCount; i++)
        {
            if (m_bodyArray[i])
            {
                m_bodyArray[i].OnApplyForceAndTorque(timestep);
            }
        }
    }

    private dNewtonWorld m_world = new dNewtonWorld();
    private int m_bodyCount;
    private int m_bodyCapacity;
    private NewtonBody[] m_bodyArray;

    public bool m_asyncUpdate = true;
    public int m_broadPhaseType = 0;
    public int m_numberOfThreads = 0;
    public int m_solverIterationsCount = 1;
    public int m_updateRate = 120;
    public Vector3 m_gravity = new Vector3 (0.0f, -9.8f, 0.0f);

    private OnWorldUpdateCallback m_onWorldCallcak;
}


