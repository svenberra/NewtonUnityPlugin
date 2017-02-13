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

[AddComponentMenu("Newton Physics/Colliders/Convex Hull")]
public class NewtonConvexHullCollider : NewtonCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        if (m_mesh == null)
        {
            return null;
        }

        if (m_mesh.vertices.Length < 4)
        {
            return null;
        }

        float[] array = new float[3 * m_mesh.vertices.Length];
        for (int i = 0; i < m_mesh.vertices.Length; i ++)
        {
            array[i * 3 + 0] = m_mesh.vertices[i].x;
            array[i * 3 + 1] = m_mesh.vertices[i].y;
            array[i * 3 + 2] = m_mesh.vertices[i].z;
        }

        IntPtr floatsPtr = Marshal.AllocHGlobal(array.Length * Marshal.SizeOf(typeof(float)));
        Marshal.Copy(array, 0, floatsPtr, array.Length);
        dNewtonCollision collision = new dNewtonCollisionConvexHull(world.GetWorld(), m_mesh.vertices.Length, floatsPtr, 0.01f * (1.0f - m_quality));
        if (collision.IsValid() == false)
        {
            collision.Dispose();
            collision = null;
        }
        Marshal.FreeHGlobal(floatsPtr);
        return collision;
    }

    public Mesh m_mesh;
    public float m_quality = 0.5f;
}

