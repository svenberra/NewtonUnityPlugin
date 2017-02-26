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

public class Utils
{
    static public dMatrix ToMatrix(Vector3 posit, Quaternion rotation)
    {
        dMatrix matrix = new dMatrix();
        Matrix4x4 entMatrix = Matrix4x4.identity;
        entMatrix.SetTRS(posit, rotation, Vector3.one);
        matrix.m_front = new dVector(entMatrix.m00, entMatrix.m10, entMatrix.m20, entMatrix.m30);
        matrix.m_up =    new dVector(entMatrix.m01, entMatrix.m11, entMatrix.m21, entMatrix.m31);
        matrix.m_right = new dVector(entMatrix.m02, entMatrix.m12, entMatrix.m22, entMatrix.m32);
        matrix.m_posit = new dVector(entMatrix.m03, entMatrix.m13, entMatrix.m23, entMatrix.m33);
        return matrix;
    }


    static public int dRand(int seed, int oldSeed)
    {
        return oldSeed + seed * 31415821;
    }
}


