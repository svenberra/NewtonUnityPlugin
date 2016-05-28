using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Sphere Collider")]
    public class NewtonSphereCollider : NewtonCollider
    {
        public float Radius = 0.5f;

        public unsafe override IntPtr CreateCollider(IntPtr world, bool applyOffset)
        {
            Matrix4x4 offsetMatrix = Matrix4x4.identity;
            IntPtr collider = NewtonInvoke.NewtonCreateSphere(world, Radius, 0, (float*)&offsetMatrix);
            NewtonInvoke.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);
            return collider;
        }


    }

}