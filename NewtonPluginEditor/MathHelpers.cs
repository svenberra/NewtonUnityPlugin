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
