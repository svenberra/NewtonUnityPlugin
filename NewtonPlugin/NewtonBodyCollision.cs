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
        List<ColliderShapePair> colliderList = new List<ColliderShapePair>();
        TraverseColliders(body.gameObject, colliderList, body.gameObject, body);

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
            m_collidersArray[0] = colliderList[0];
        }
        else
        {
            bool isScene = body.m_isScene;
            if (isScene == false)
            {
                foreach (ColliderShapePair pair in colliderList)
                {
                    isScene = isScene || pair.m_collider.IsStatic();
                }
            }

            if (isScene == true)
            {
                Debug.Log("TODO:: Build scene collision here");
            } 
            else
            {
                m_collidersArray = new ColliderShapePair[colliderList.Count + 1];
                NewtonCompoundCollider compoundCollider = new NewtonCompoundCollider();
                dNewtonCollisionCompound compoundShape = (dNewtonCollisionCompound)compoundCollider.Create(body.m_world);

                m_collidersArray[0].m_collider = compoundCollider;
                m_collidersArray[0].m_shape = compoundShape;

                int index = 1;
                compoundShape.BeginAddRemoveCollision();
                foreach (ColliderShapePair pair in colliderList)
                {
                    m_collidersArray[index] = pair;
                    compoundShape.AddCollision(pair.m_shape);
                    index++;
                }
                compoundShape.EndAddRemoveCollision();
            }
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

    private void TraverseColliders(GameObject gameObject, List<ColliderShapePair> colliderList, GameObject rootObject, NewtonBody body)
    {
        // Don't fetch colliders from children with NewtonBodies
        if ((gameObject == rootObject) || (gameObject.GetComponent<NewtonBody>() == null))
        {
            //Fetch all colliders
            foreach (NewtonCollider collider in gameObject.GetComponents<NewtonCollider>())
            {
                dNewtonCollision shape = collider.CreateBodyShape(body.m_world);
                if (shape != null)
                {
                    ColliderShapePair pair;
                    pair.m_collider = collider;
                    pair.m_shape = shape;
                    colliderList.Add(pair);
                }
            }

            foreach (Transform child in gameObject.transform)
            {
                TraverseColliders(child.gameObject, colliderList, rootObject, body);
            }
        }
    }

    public dNewtonCollision GetShape()
    {
        return m_collidersArray[0].m_shape;
    }


    private ColliderShapePair[] m_collidersArray;
    
}

