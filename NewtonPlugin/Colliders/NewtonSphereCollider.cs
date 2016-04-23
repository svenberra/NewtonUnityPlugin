using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Sphere Collider")]
    public class NewtonSphereCollider : NewtonCollider
    {
        public float Radius = 0.5f;

        public override IntPtr CreateCollider(bool applyOffset)
        {
            Matrix4x4 offsetMatrix = Matrix4x4.identity;
            IntPtr collider = NewtonAPI.NewtonCreateSphere(NewtonWorld.Instance.pWorld, Radius, 0, ref offsetMatrix);
            NewtonAPI.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);
            return collider;
        }


    }

}