using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Cone Collider")]
    public class NewtonConeCollider : NewtonCollider
    {
        public float Radius = 0.5f;
        public float Height = 1.0f;

        public unsafe override IntPtr CreateCollider(IntPtr world, bool applyOffset)
        {
            Matrix4x4 offsetMatrix = Matrix4x4.identity;
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            offsetMatrix.SetTRS(Vector3.zero, rotation, Vector3.one);
            IntPtr collider = NewtonInvoke.NewtonCreateCone(world, Radius, Height, 0, (float*)&offsetMatrix);
            return collider;
        }
        
    }

}