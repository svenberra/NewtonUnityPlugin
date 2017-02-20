/*
* This software is provided 'as-is', without any express or implied
* warranty. In no event will the authors be held liable for any damages
* arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
*/

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
        m_onWorldCallback = new OnWorldUpdateCallback(OnWorldUpdate);
      
        m_world.SetAsyncUpdate(m_asyncUpdate);
        m_world.SetFrameRate (m_updateRate);
        m_world.SetThreadsCount(m_numberOfThreads);
        m_world.SetSolverMode(m_solverIterationsCount);
        m_world.SetBroadPhase(m_broadPhaseType);
        m_world.SetGravity(m_gravity.x, m_gravity.y, m_gravity.z);
        m_world.SetSubSteps(m_subSteps);
        m_world.SetDefaultMaterial(m_defaultRestitution, m_defaultStaticFriction, m_defaultKineticFriction, true);
        m_world.SetCallbacks(m_onWorldCallback);
        InitScene();
    }

    void OnDestroy()
    {
       DestroyScene();
       m_onWorldCallback = null;
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

    private void InitPhysicsJoints(GameObject root)
    {
        foreach (NewtonJoint joint in root.GetComponents<NewtonJoint>())
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
        Resources.LoadAll("Newton Materials");
        NewtonMaterialInteraction[] materialList = Resources.FindObjectsOfTypeAll<NewtonMaterialInteraction>();
        foreach (NewtonMaterialInteraction materialInteraction in materialList)
        {
            // register all material interactions.
            if (materialInteraction.m_material_0 && materialInteraction.m_material_1)
            {
                int id0 = materialInteraction.m_material_0.GetInstanceID();
                int id1 = materialInteraction.m_material_1.GetInstanceID();
                m_world.SetMaterialInteraction(id0, id1, materialInteraction.m_restitution, materialInteraction.m_staticFriction, materialInteraction.m_kineticFriction, materialInteraction.m_collisionEnabled);
            }
        }

        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            InitPhysicsScene(rootObj);
        }

        foreach (GameObject rootObj in objectList)
        {
            InitPhysicsJoints(rootObj);
        }
    }


    private void DestroyScene()
    {
        if (m_world != null)
        {
            GameObject[] objectList = gameObject.scene.GetRootGameObjects();
            foreach (GameObject rootObj in objectList)
            {
                DestroySceneRigidBody(rootObj);
            }
            m_world = null;
        }
    }

    void Update()
    {
        //Debug.Log("Update time :" + Time.deltaTime);
        m_world.Update(Time.deltaTime);
    }

    private void UpdateRigidBody(GameObject root, float timestep)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics)
        {
            // apply collision notification here
            if (bodyPhysics.m_needsCollisionNotification)
            {
                dNewtonBody newtonBody = bodyPhysics.GetBody();
                for (IntPtr contact = m_world.GetFirstContactJoint(newtonBody); contact != IntPtr.Zero; contact = m_world.GetNextContactJoint(newtonBody, contact))
                {
                    dNewtonBody otherBody = (m_world.GetBody0(contact) == newtonBody) ? m_world.GetBody1(contact) : m_world.GetBody0(contact);
                    bodyPhysics.OnCollision(otherBody);
                }
            }

            // apply new external force and torque
            bodyPhysics.OnApplyForceAndTorque(timestep);
        }

        foreach (Transform child in root.transform)
        {
            UpdateRigidBody(child.gameObject, timestep);
        }
    }

    private void DestroySceneRigidBody(GameObject root)
    {
        NewtonBody bodyPhysics = root.GetComponent<NewtonBody>();
        if (bodyPhysics != null)
        {
            bodyPhysics.DestroyRigidBody();
        }

        foreach (Transform child in root.transform)
        {
            DestroySceneRigidBody(child.gameObject);
        }
    }

    private void OnWorldUpdate(float timestep)
    {
        GameObject[] objectList = gameObject.scene.GetRootGameObjects();
        foreach (GameObject rootObj in objectList)
        {
            UpdateRigidBody(rootObj, timestep);
        }
    }

    private dNewtonWorld m_world = new dNewtonWorld();
    public bool m_asyncUpdate = true;
    public int m_broadPhaseType = 0;
    public int m_numberOfThreads = 0;
    public int m_solverIterationsCount = 1;
    public int m_updateRate = 120;
    public int m_subSteps = 1;
    public Vector3 m_gravity = new Vector3 (0.0f, -9.8f, 0.0f);

    public float m_defaultRestitution = 0.4f;
    public float m_defaultStaticFriction = 0.8f;
    public float m_defaultKineticFriction = 0.6f;
    
    private OnWorldUpdateCallback m_onWorldCallback;

}


