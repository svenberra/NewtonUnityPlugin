using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Tree Collider")]
    public class NewtonTreeCollider : NewtonCollider
    {
        public bool Optimize = true;
        public Mesh mesh;

        public unsafe override IntPtr CreateCollider(IntPtr world, bool applyOffset)
        {
            if (mesh == null)
                return IntPtr.Zero;

            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;

            int numTris = triangles.Length / 3;

            IntPtr collider = NewtonInvoke.NewtonCreateTreeCollision(world, 0);
            NewtonInvoke.NewtonTreeCollisionBeginBuild(collider);

            Vector3[] triVertices = new Vector3[3];

            fixed (float* vPtr = &triVertices[0].x)
            {
                for (int i = 0; i < numTris; i++)
                {

                    triVertices[0] = vertices[triangles[i * 3 + 0]];
                    triVertices[1] = vertices[triangles[i * 3 + 1]];
                    triVertices[2] = vertices[triangles[i * 3 + 2]];

                    triVertices[0].Scale(transform.localScale);
                    triVertices[1].Scale(transform.localScale);
                    triVertices[2].Scale(transform.localScale);

                    NewtonInvoke.NewtonTreeCollisionAddFace(collider, 3, vPtr, 12, 0);
                }
            }

            int opt = (Optimize) ? 1 : 0;
            NewtonInvoke.NewtonTreeCollisionEndBuild(collider, opt);

            return collider;
        }

    }

}
