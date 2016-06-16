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
            return new dNewtonCollisionBox(world.GetWorld(), m_size.x, m_size.y, m_size.z);
        }

        public Vector3 m_size = Vector3.one;
    }
}