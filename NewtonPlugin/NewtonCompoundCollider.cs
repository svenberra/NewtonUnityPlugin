using UnityEngine;
using System;


public class NewtonCompoundCollider : NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        return new dNewtonCollisionCompound(world.GetWorld());
    }
}
