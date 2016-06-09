using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Box Collider")]
    public class NewtonBoxCollider: NewtonCollider
    {
        void Start()
        {
        }

        void OnDestroy()
        {
        }

        public override dNewtonCollision Create(NewtonWorld world)
        {
            /*
                Matrix4x4 offsetMatrix = Matrix4x4.identity;

                if (applyOffset)
                    offsetMatrix.SetTRS(transform.localPosition, transform.localRotation, Vector3.one);

                IntPtr collider = NewtonAPI.NewtonCreateBox(NewtonWorld.Instance.pWorld, Size.x, Size.y, Size.z, 0, ref offsetMatrix);
                NewtonAPI.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);

                return collider;
            */
            // m_collision = new dNewtonCollisionBox(world.GetWorld(), 1.0f, 1.0f, 1.0f);
            return new dNewtonCollisionBox(world.GetWorld(), 1.0f, 1.0f, 1.0f);
        }
        
    }

}