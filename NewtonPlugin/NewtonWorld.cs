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
            // create the low lever physic world
            //m_world = new dNewtonWorld(m_updateRate);

            float fps = 60.0f;
            switch (m_updateRate)
            {
                case UpdateRate.Sixty_fps:
                    fps = 60.0f;
                    break;

                case UpdateRate.Ninety_fps:
                    fps = 90.0f;
                    break;

                case UpdateRate.Hundred_twenty_fps:
                    fps = 120.0f;
                    break;

                case UpdateRate.Hundred_fifty_fps:
                    fps = 150.0f;
                    break;

                case UpdateRate.Hundred_eighty_fps:
                    fps = 180.0f;
                    break;
            }


            m_world = new dNewtonWorld(fps);
        }
        return m_world;
    }
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 1000;

        //m_updateRate = 60.0f;
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
        m_world.Update(Time.deltaTime);
    }

    public enum UpdateRate
    {
        Sixty_fps,
        Ninety_fps,
        Hundred_twenty_fps,
        Hundred_fifty_fps,
        Hundred_eighty_fps,
    }

    private dNewtonWorld m_world = null;
    public UpdateRate m_updateRate;
}


