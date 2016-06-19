using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class NewtonBodyCollision
{
    struct ColliderShapePair
    {
        public NewtonCollider m_collider;
        public dNewtonCollision m_shape;
    }

    public NewtonBodyCollision(NewtonBody body)
    {
        List<NewtonCollider> colliderList = new List<NewtonCollider>();
        TraverseColliders(body.gameObject, colliderList, body.gameObject);

        if (colliderList.Count == 0)
        {
            m_collidersArray = new ColliderShapePair[1];
            NewtonCollider collider = new NewtonNullCollider();
            m_collidersArray[0].m_collider = collider;
            m_collidersArray[0].m_shape = collider.Create(body.m_world);
        }
        else if (colliderList.Count == 1)
        {
            m_collidersArray = new ColliderShapePair[1];
            NewtonCollider collider = colliderList[0];
            m_collidersArray[0].m_collider = collider;
            m_collidersArray[0].m_shape = collider.CreateBodyShape(body.m_world);
        }
        else
        {
            Debug.Log("TODO:: Build compound the NULL collision here");
            /*
            int index = 0;
            m_collidersArray = new ColliderShapePair[colliderList.Count];
            foreach (NewtonCollider collider in colliderList)
            {
                m_collidersArray[index].m_collider = collider;
                m_collidersArray[index].m_shape = collider.CreateBodyShape(body.m_world);
                index++;
            }
            */
        }
    }

    public void Destroy()
    {
        for (int i = 0; i < m_collidersArray.Length; i ++)
        {
            m_collidersArray[i].m_shape.Dispose();
            m_collidersArray[i].m_shape = null;
            m_collidersArray[i].m_collider = null;
        }
    }

    private void TraverseColliders(GameObject gameObject, List<NewtonCollider> colliderList, GameObject rootObject)
    {
        // Don't fetch colliders from children with NewtonBodies
        if ((gameObject == rootObject) || (gameObject.GetComponent<NewtonBody>() == null))
        {
            //Fetch all colliders
            foreach (NewtonCollider collider in gameObject.GetComponents<NewtonCollider>())
            {
                colliderList.Add(collider);
            }

            foreach (Transform child in gameObject.transform)
            {
                TraverseColliders(child.gameObject, colliderList, rootObject);
            }
        }
    }

    public dNewtonCollision GetShape()
    {
        return m_collidersArray[0].m_shape;
    }

    private ColliderShapePair[] m_collidersArray;
}

