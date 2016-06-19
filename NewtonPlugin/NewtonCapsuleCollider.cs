using UnityEngine;
using System;


[AddComponentMenu("Newton Physics/Colliders/Capsule")]
public class NewtonCapsuleCollider : NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        return new dNewtonCollisionCapsule(world.GetWorld(), m_radius0, m_radius1, m_height);
    }

    public float m_radius0 = 0.5f;
    public float m_radius1 = 0.5f;
    public float m_height = 1.0f;
}

