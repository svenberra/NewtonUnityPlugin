using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NewtonPlugin
{
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
            m_pinThisObject = GCHandle.Alloc(this);

            // create the low lever physic world
            m_world = new dNewtonWorld(GCHandle.ToIntPtr(m_pinThisObject));

            GameObject[] objectList = gameObject.scene.GetRootGameObjects();
            foreach (GameObject rootObj in objectList)
            {
                InitPhysicsScene(rootObj);
            }
        }

        void OnDestroy()
        {
            GameObject[] objectList = gameObject.scene.GetRootGameObjects();
            foreach (GameObject rootObj in objectList)
            {
                DestroyPhysicsScene(rootObj);
            }

            m_world.Dispose();
            m_pinThisObject.Free();
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
        

        public dNewtonCollision BuildCollision(List<NewtonCollider> colliders)
        {
            dNewtonCollision coll = null;
            if (colliders.Count == 1)
            {
                NewtonCollider collider = colliders[0];
                coll = colliders[0].Create(this);
            }
            return coll;
        }

        private dNewtonWorld m_world;
        private GCHandle m_pinThisObject;
    }
}

