using UnityEngine;
using System;


public class NewtonNullCollider: NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        return new dNewtonCollisionNull(world.GetWorld());
    }
}
