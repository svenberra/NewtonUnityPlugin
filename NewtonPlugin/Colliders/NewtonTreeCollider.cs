using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Colliders/Tree Collider")]
    public class NewtonTreeCollider : NewtonCollider
    {
        public bool Optimize = true;
        public Mesh mesh;

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
    }
}
