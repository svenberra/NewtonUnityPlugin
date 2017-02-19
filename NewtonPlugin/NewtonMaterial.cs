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
using System.Collections.Generic;
using System.Runtime.InteropServices;


[CreateAssetMenu(menuName = "Newton Material")]
public class NewtonMaterial : ScriptableObject
{
}


[CreateAssetMenu(menuName = "Newton Material Interaction")]
public class NewtonMaterialInteraction : ScriptableObject
{
    public NewtonMaterial m_material_0 = null;
    public NewtonMaterial m_material_1 = null;
    public float m_staticFriction = 0.9f; 
    public float m_kineticFriction = 0.75f; 
}


