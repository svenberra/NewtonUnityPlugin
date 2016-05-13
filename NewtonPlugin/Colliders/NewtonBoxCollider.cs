using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Box Collider")]
    public class NewtonBoxCollider : NewtonCollider
    {
        public Vector3 Size = Vector3.one;
        private Vector3 prevSize = Vector3.one;

        public unsafe override IntPtr CreateCollider(IntPtr world, bool applyOffset)
        {
            Matrix4x4 offsetMatrix = Matrix4x4.identity;

            if (applyOffset)
                offsetMatrix.SetTRS(transform.localPosition, transform.localRotation, Vector3.one);

            IntPtr collider = NewtonInvoke.NewtonCreateBox(world, Size.x, Size.y, Size.z, 0, (float*)&offsetMatrix);

            return collider;
        }

        public new void OnValidate()
        {
            if (!Size.Equals(prevSize))
                needRebuild = true;

            if (Size.x <= 0 | Size.y <= 0 | Size.z <= 0)
            {
                //Debug.Log("Size invalid, won't update debug lines");
                Size = prevSize;
                return;
            }

            prevSize = Size;

            base.OnValidate();
        }

    }

}