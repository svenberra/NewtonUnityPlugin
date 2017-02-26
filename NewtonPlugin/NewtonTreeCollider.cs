/*
* This software is provided 'as-is', without any express or implied
* warranty. In no event will the authors be held liable for any damages
* arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
*/

using System;
using UnityEngine;
using System.Runtime.InteropServices;

[AddComponentMenu("Newton Physics/Colliders/Tree Collider")]
public class NewtonTreeCollider : NewtonCollider
{
    public override bool IsStatic()
    {
        return true;
    }
    public override Vector3 GetScale()
    {
        if (m_freezeScale == true)
        {
            return new Vector3 (1.0f, 1.0f, 1.0f);
        }
        return GetBaseScale();
    }

    public Vector3 GetBaseScale()
    {
        return base.GetScale();
    }

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
        
        Vector3 scale = GetBaseScale();
        if (m_freezeScale == false)
        {
            scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        Vector3[] vertices = m_mesh.vertices;
        float[] triVertices = new float[3 * 3];
        IntPtr floatsPtr = Marshal.AllocHGlobal(3 * 3 * Marshal.SizeOf(typeof(float)));

        dNewtonCollisionMesh collision = new dNewtonCollisionMesh(world.GetWorld());
        collision.BeginFace();
        for (int i = 0; i < m_mesh.subMeshCount; i++)
        {
            int[] submesh = m_mesh.GetTriangles(i);
            for (int j = 0; j < submesh.Length; j += 3)
            {
                int k = submesh[j];
                triVertices[0] = vertices[k].x * scale.x;
                triVertices[1] = vertices[k].y * scale.y;
                triVertices[2] = vertices[k].z * scale.z;

                k = submesh[j + 1];
                triVertices[3] = vertices[k].x * scale.x;
                triVertices[4] = vertices[k].y * scale.y;
                triVertices[5] = vertices[k].z * scale.z;

                k = submesh[j + 2];
                triVertices[6] = vertices[k].x * scale.x;
                triVertices[7] = vertices[k].y * scale.y;
                triVertices[8] = vertices[k].z * scale.z;

                Marshal.Copy(triVertices, 0, floatsPtr, triVertices.Length);
                collision.AddFace(3, floatsPtr, 3 * sizeof(float), i);
            }
        }

        collision.EndFace(m_optimize);
        Marshal.FreeHGlobal(floatsPtr);

        m_isTrigger = false;
        SetMaterial(collision);
        return collision;
    }

    public override void OnDrawGizmosSelected()
    {
        // static meshes can no be triggers.
        m_isTrigger = false;
        base.OnDrawGizmosSelected();
    }

    public Mesh m_mesh;
    public bool m_optimize = true;
    public bool m_rebuildMesh = false;
    public bool m_freezeScale = true;
}

