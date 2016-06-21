using System;
using UnityEngine;
using System.Runtime.InteropServices;

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

        if (mesh.vertices.Length < 4)
        {
            return null;
        }


        //Marshal.StructureToPtr(mesh.vertices, floatsPtr, false);

        float[] array = new float[3 * mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i ++)
        {
            array[i * 3 + 0] = mesh.vertices[i].x;
            array[i * 3 + 1] = mesh.vertices[i].y;
            array[i * 3 + 2] = mesh.vertices[i].z;
        }

        IntPtr floatsPtr = Marshal.AllocHGlobal(array.Length * Marshal.SizeOf(typeof(float)));
        Marshal.Copy(array, 0, floatsPtr, array.Length);
        dNewtonCollision collision = new dNewtonCollisionConvexHull(world.GetWorld(), mesh.vertices.Length, floatsPtr, tolerance);
        if (collision.IsValid() == false)
        {
            collision.Dispose();
            collision = null;
        }
        Marshal.FreeHGlobal(floatsPtr);
        return collision;
    }

    public Mesh mesh;
    public float tolerance = 0.01f;
}

