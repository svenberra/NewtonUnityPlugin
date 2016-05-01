using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Box Collider")]
    public class NewtonBoxCollider: NewtonCollider
    {
        public override void CreateCollider(bool applyOffset)
        {
            /*
                        Matrix4x4 offsetMatrix = Matrix4x4.identity;

                        if (applyOffset)
                            offsetMatrix.SetTRS(transform.localPosition, transform.localRotation, Vector3.one);

                        IntPtr collider = NewtonAPI.NewtonCreateBox(NewtonWorld.Instance.pWorld, Size.x, Size.y, Size.z, 0, ref offsetMatrix);
                        NewtonAPI.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);

                        return collider;
            */
        }
        
    }

}