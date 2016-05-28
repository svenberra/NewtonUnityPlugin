using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Convex Hull Collider")]
    public class NewtonConvexHullCollider : NewtonCollider
    {
        public Vector3 Size = Vector3.one;
        public Mesh mesh;
        public float tolerance = 0.1f;

        public override IntPtr CreateCollider(bool applyOffset)
        {
            if (mesh == null)
                return IntPtr.Zero;

            Matrix4x4 offsetMatrix = Matrix4x4.identity;

            if (applyOffset)
                offsetMatrix.SetTRS(transform.localPosition, transform.localRotation, Vector3.one);

            Vector3[] vertices = mesh.vertices;

            IntPtr collider = NewtonAPI.NewtonCreateConvexHull(NewtonWorld.Instance.pWorld, vertices.Length, vertices, 12, tolerance, 0, ref offsetMatrix);
            NewtonAPI.NewtonCollisionSetScale(collider, Scale.x, Scale.y, Scale.z);

            return collider;
        }

    }

}