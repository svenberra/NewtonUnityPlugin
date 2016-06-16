using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Box Collider")]
    public class NewtonBoxCollider: NewtonCollider
    {
        void Start()
        {
        }

        void OnDestroy()
        {
        }

        public override dNewtonCollision Create(NewtonWorld world)
        {
            //UnityEngine.Debug.Log("xxxxxxxxx 6");

            //Mesh mesh = gameObject.GetComponent<Mesh>();
            //if (mesh)
            //{
            //  Bounds box = mesh.bounds;
            //}
            //m_size = box.size;
            //m_size.x = m_size.x * 2.0f;
            //return new dNewtonCollisionBox(world.GetWorld(), m_size.x, m_size.y, m_size.z);
            m_size.x = 2.0f;
            return new dNewtonCollisionBox(world.GetWorld(), m_size.x, m_size.y, m_size.z);
        }
        
    }

}