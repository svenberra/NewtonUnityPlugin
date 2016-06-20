using UnityEngine;
using System;


[AddComponentMenu("Newton Physics/Colliders/Cone")]
public class NewtonConeCollider : NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        return new dNewtonCollisionCone(world.GetWorld(), m_radius, m_height);
    }

    public float m_radius = 0.5f;
    public float m_height = 1.0f;
}

