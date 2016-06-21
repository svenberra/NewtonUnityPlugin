using System;
using UnityEngine;
using System.Runtime.InteropServices;



[AddComponentMenu("Newton Physics/Colliders/Tree Collider")]
public class NewtonTreeCollider : NewtonCollider
{
    /*
        public override IntPtr CreateCollider(bool applyOffset)
        {
            if (mesh == null)
                return IntPtr.Zero;

            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;

            int numTris = triangles.Length / 3;

            IntPtr collider = NewtonAPI.NewtonCreateTreeCollision(NewtonWorld.Instance.pWorld, 0);
            NewtonAPI.NewtonTreeCollisionBeginBuild(collider);

            Vector3[] triVertices = new Vector3[3];

            for (int i = 0; i < numTris; i++)
            {
                triVertices[0] = vertices[triangles[i * 3 + 0]];
                triVertices[1] = vertices[triangles[i * 3 + 1]];
                triVertices[2] = vertices[triangles[i * 3 + 2]];

                triVertices[0].Scale(transform.localScale);
                triVertices[1].Scale(transform.localScale);
                triVertices[2].Scale(transform.localScale);

                NewtonAPI.NewtonTreeCollisionAddFace(collider, 3, triVertices, 12, 0);
            }

            int opt = (Optimize) ? 1 : 0;
            NewtonAPI.NewtonTreeCollisionEndBuild(collider, opt);

            return collider;
        }
    */

    public override dNewtonCollision Create(NewtonWorld world)
    {
        if (m_mesh == null)
        {
            return null;
        }

        if (m_mesh.triangles.Length < 3)
        {
            return null;
        }

        float[] triVertices = new float[3 * 3];
        IntPtr floatsPtr = Marshal.AllocHGlobal(3 * 3 * Marshal.SizeOf(typeof(float)));

        Vector3[] vertices = m_mesh.vertices;
        dNewtonCollisionMesh collision = new dNewtonCollisionMesh(world.GetWorld());
        collision.BeginFace();
        for (int i = 0; i < m_mesh.subMeshCount; i++)
        {
            int[] submesh = m_mesh.GetTriangles(i);
            for (int j = 0; j < submesh.Length; j += 3)
            {
                int k = submesh[j];
                triVertices[0] = vertices[k].x;
                triVertices[1] = vertices[k].y;
                triVertices[2] = vertices[k].z;

                k = submesh[j + 1];
                triVertices[3] = vertices[k].x;
                triVertices[4] = vertices[k].y;
                triVertices[5] = vertices[k].z;

                k = submesh[j + 2];
                triVertices[6] = vertices[k].x;
                triVertices[7] = vertices[k].y;
                triVertices[8] = vertices[k].z;

                Marshal.Copy(triVertices, 0, floatsPtr, triVertices.Length);
                collision.AddFace(3, floatsPtr, 3 * sizeof(float), i);
            }
        }

        collision.EndFace(m_optimize);
        Marshal.FreeHGlobal(floatsPtr);
        return collision;
    }

    public Mesh m_mesh;
    public bool m_optimize = true;
}

