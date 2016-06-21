using UnityEngine;
using System;


[AddComponentMenu("Newton Physics/Colliders/Convex Hull")]
public class NewtonConvexHullCollider : NewtonCollider
{
    /*
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
    */

    public override dNewtonCollision Create(NewtonWorld world)
    {
        if (mesh == null)
        {
            return null;
        }

        return new dNewtonCollisionCylinder(world.GetWorld(), 1.0f, 1.0f, 1.0f);
    }

    public Mesh mesh;
    //public float tolerance = 0.1f;
}

