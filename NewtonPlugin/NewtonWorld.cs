using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[DisallowMultipleComponent]
[AddComponentMenu("Newton Physics/Newton World")]
public class NewtonWorld : MonoBehaviour, ISerializationCallbackReceiver
//public class NewtonWorld : MonoBehaviour
{
    public dNewtonWorld GetWorld()
    {
        if (m_world == null)
        {
            m_world = new dNewtonWorld();
        }
        return m_world;
    }

    void Start()
    {
        GetWorld();
        m_world.SetFrameRate (m_updateRate);
        InitScene();
    }

    public void OnAfterDeserialize()
    {
        UnityEngine.Debug.Log("xxxxxxxxxxxxxxxxxxx " + m_updateRate + "   " + m_updateRate____);
        m_updateRate = m_updateRate____;
    }

    public void OnBeforeSerialize()
    {
        UnityEngine.Debug.Log("xxxxxxxxx " + m_updateRate + "   " + m_updateRate____);
        m_updateRate____ = m_updateRate;
    }

    void OnDestroy()
    {
        UnityEngine.Debug.Log("xxxxxxxxx 5");
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
        Debug.Log("Update time :" + Time.deltaTime);
        m_world.Update(Time.deltaTime);
    }

    private dNewtonWorld m_world = null;
    private int m_updateRate____ = 120;
    public int m_updateRate = 120;
}


