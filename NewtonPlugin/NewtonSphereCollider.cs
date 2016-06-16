using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Sphere Collider")]
    public class NewtonSphereCollider : NewtonCollider
    {
        public override dNewtonCollision Create(NewtonWorld world)
        {
            return new dNewtonCollisionSphere(world.GetWorld(), m_radius);
        }

        public float m_radius = 0.5f;
    }

}