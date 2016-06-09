using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Capsule Collider")]
    public class NewtonCapsuleCollider : NewtonCollider
    {
        public float Radius0 = 0.5f;
        public float Radius1 = 0.5f;
        public float Height = 1.0f;

        public override IntPtr CreateCollider(bool applyOffset)
        {

            Matrix4x4 offsetMatrix = Matrix4x4.identity;
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            offsetMatrix.SetTRS(Vector3.zero, rotation, Vector3.one);

            IntPtr collider = NewtonAPI.NewtonCreateCapsule(NewtonWorld.Instance.pWorld, Radius0, Radius1, Height, 0, ref offsetMatrix);
            NewtonAPI.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);
            return collider;
        }

    }

}