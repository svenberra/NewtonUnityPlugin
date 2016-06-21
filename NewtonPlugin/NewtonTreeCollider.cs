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
            for (int j = 0; j < m_mesh.subMeshCount / 3; j++)
            {
                triVertices[j * 9 + 0] = m_mesh.vertices[j * 3 + 0].x;
                triVertices[j * 9 + 1] = m_mesh.vertices[j * 3 + 0].y;
                triVertices[j * 9 + 2] = m_mesh.vertices[j * 3 + 0].z;

                triVertices[j * 9 + 3] = m_mesh.vertices[j * 3 + 1].x;
                triVertices[j * 9 + 4] = m_mesh.vertices[j * 3 + 1].y;
                triVertices[j * 9 + 5] = m_mesh.vertices[j * 3 + 1].z;

                triVertices[j * 9 + 6] = m_mesh.vertices[j * 3 + 2].x;
                triVertices[j * 9 + 7] = m_mesh.vertices[j * 3 + 2].y;
                triVertices[j * 9 + 8] = m_mesh.vertices[j * 3 + 2].z;
                Marshal.Copy(triVertices, 0, floatsPtr, triVertices.Length);
                collision.AddFace(3, floatsPtr, 3 * sizeof(float), i);
            }
            collision.EndFace(m_optimize);
        }
    
        Marshal.FreeHGlobal(floatsPtr);
        return collision;
    }

    public Mesh m_mesh;
    public bool m_optimize = true;
}

