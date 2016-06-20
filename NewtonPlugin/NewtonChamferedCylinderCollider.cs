using UnityEngine;
using System;


[AddComponentMenu("Newton Physics/Colliders/ChamferedCylinder")]
public class NewtonChamferedCylinderCollider : NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        return new dNewtonCollisionChamferedCylinder(world.GetWorld(), m_radius, m_height);
    }

    public float m_radius = 0.5f;
    public float m_height = 1.0f;
}

