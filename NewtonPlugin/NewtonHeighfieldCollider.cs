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

[AddComponentMenu("Newton Physics/Colliders/Height field Collider")]
class NewtonHeighfieldCollider: NewtonCollider
{
    public override bool IsStatic()
    {
        return true;
    }
    public override Vector3 GetScale()
    {
        if (m_freezeScale == true)
        {
            return new Vector3(1.0f, 1.0f, 1.0f);
        }
        return GetBaseScale();
    }

    public Vector3 GetBaseScale()
    {
        return base.GetScale();
    }

    public override dNewtonCollision Create(NewtonWorld world)
    {
        TerrainData data = m_terrain.terrainData;
        //Debug.Log("xxxx  " + data.alphamapWidth + "   xxx  " + data.detailHeight);
        //Debug.Log("xxxx  " + data.heightmapScale);
        //Debug.Log("xxxx  " + data.size);

        int resolution = data.heightmapResolution;
        dVector scale = new dVector(data.size.x, data.size.y, data.size.z, 0.0f);

        m_oldSize = data.size;
        m_oldResolution = resolution;

        data.GetHeights(0, 0, resolution, resolution);

        float[] elevation = new float [resolution * resolution];
        for (int z = 0; z < resolution; z ++)
        {
            for (int x = 0; x < resolution; x++)
            {
                elevation[z * resolution + x] = data.GetHeight(x, z);
            }
        }
        IntPtr elevationPtr = Marshal.AllocHGlobal(resolution * resolution * Marshal.SizeOf(typeof(float)));
        Marshal.Copy(elevation, 0, elevationPtr, elevation.Length);
        dNewtonCollision collider = new dNewtonCollisionHeightField(world.GetWorld(), elevationPtr, resolution, scale);
        Marshal.FreeHGlobal(elevationPtr);

        SetMaterial(collider);
        return collider;
    }

    public override void OnDrawGizmosSelected()
    {
        //Debug.Log("xxxx  ");
        TerrainData data = m_terrain.terrainData;
        Debug.Log("xxxx  " + m_terrain.drawHeightmap);

        if ((data.heightmapResolution != m_oldResolution) || (m_oldSize != data.size))
        {
            RecreateEditorShape();
        }

        base.OnDrawGizmosSelected();
    }

    public Terrain m_terrain = null;
    public bool m_freezeScale = true;
    private int m_oldResolution;
    private Vector3 m_oldSize;
}

