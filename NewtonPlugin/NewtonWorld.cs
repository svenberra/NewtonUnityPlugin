using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[DisallowMultipleComponent]
[AddComponentMenu("Newton Physics/Newton World")]
public class NewtonWorld : MonoBehaviour
{
    public enum UpdateRate
    {
        _120_fps,
        _60_fps,
        _90_fps,
        _150_fps,
        _180_fps,
        _240_fps,
    }

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
        SetFrameRate ();
        InitScene();
    }

    private void SetFrameRate()
    {
        float fps = 60.0f;
        switch (m_updateRate)
        {
            case UpdateRate._60_fps:
                fps = 60.0f;
                break;

            case UpdateRate._90_fps:
                fps = 90.0f;
                break;

            case UpdateRate._120_fps:
                fps = 120.0f;
                break;

            case UpdateRate._150_fps:
                fps = 150.0f;
                break;

            case UpdateRate._180_fps:
                fps = 180.0f;
                break;

            case UpdateRate._240_fps:
                fps = 240.0f;
                break;

        }


        m_world.SetFrameRate(fps);
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
    public UpdateRate m_updateRate;
}


