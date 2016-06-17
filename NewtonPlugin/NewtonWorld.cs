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
        //UnityEngine.Debug.Log("xxxxxxxxx 6");
        if (m_world == null)
        {
            m_userDataGlueObject = GCHandle.Alloc(this);

            // create the low lever physic world
            m_world = new dNewtonWorld(GCHandle.ToIntPtr(m_userDataGlueObject));
        }
        return m_world;
    }
    void Start()
    {
        InitScene();
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

    public void InitScene()
    {
        GetWorld();
        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            InitPhysicsScene(rootObj);
        }
    }


    public void DestroyScene()
    {
        if (m_world != null)
        {
            GameObject[] objectList = gameObject.scene.GetRootGameObjects();
            foreach (GameObject rootObj in objectList)
            {
                DestroyPhysicsScene(rootObj);
            }

            m_world = null;
            m_userDataGlueObject.Free();
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

    private dNewtonWorld m_world = null;
    private GCHandle m_userDataGlueObject;
}


