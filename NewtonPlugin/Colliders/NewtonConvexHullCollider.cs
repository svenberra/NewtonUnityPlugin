using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Convex Hull Collider")]
    public class NewtonConvexHullCollider : NewtonCollider
    {
        public Vector3 Size = Vector3.one;
        public Mesh mesh;
        public float tolerance = 0.1f;

        public unsafe override IntPtr CreateCollider(IntPtr world, bool applyOffset)
        {
            if (mesh == null)
                return IntPtr.Zero;

            Matrix4x4 offsetMatrix = Matrix4x4.identity;

            if (applyOffset)
                offsetMatrix.SetTRS(transform.localPosition, transform.localRotation, Vector3.one);

            Vector3[] vertices = mesh.vertices;
            IntPtr collider;
            fixed (float* vPtr = &vertices[0].x)
            { 
                collider = NewtonInvoke.NewtonCreateConvexHull(world, vertices.Length, vPtr, 12, tolerance, 0, (float*)&offsetMatrix);
            }
            NewtonInvoke.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);

            return collider;
        }

    }

}