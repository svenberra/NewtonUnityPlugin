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

using UnityEngine;

public static class ValidationHelpers
{
    static public bool FloatChangedAndValid(float oldVal, float newVal)
    {
        return !Mathf.Approximately(oldVal, newVal) && !float.IsNaN(newVal);
    }

    static public bool Vector3ChangedAndValid(Vector3 oldVal, Vector3 newVal)
    {
        return (Vector3.Distance(oldVal, newVal) > 0.001f) && (!float.IsNaN(newVal.x) && !float.IsNaN(newVal.y) && !float.IsNaN(newVal.z));
    }

    static public bool VolumeChangedAndValid(Vector3 oldVal, Vector3 newVal, float tolerance = 0.001f)
    {
        return (Vector3.Distance(oldVal, newVal) > 0.001f) && (newVal.x > tolerance && newVal.y > tolerance && newVal.z > tolerance);
    }

    static public bool RadiusChangedAndValid(float oldVal, float newVal, float tolerance = 0.001f)
    {
        return !Mathf.Approximately(oldVal, newVal) && newVal > tolerance;
    }

    static public bool HeightChangedAndValid(float oldVal, float newVal, float tolerance = 0.001f)
    {
        return !Mathf.Approximately(oldVal, newVal) && newVal > tolerance;
    }
}
