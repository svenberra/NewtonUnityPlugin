using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


[CustomEditor(typeof(NewtonWorld))]
public class NewtonWorldEditor: Editor
{
    public override void OnInspectorGUI()
    {
        NewtonWorld world = (NewtonWorld)target;
        world.m_updateRate = EditorGUILayout.IntPopup("frame rate", world.m_updateRate, m_displayedOptions, m_values);
        world.m_gravity = EditorGUILayout.Vector3Field("gravity", world.m_gravity);
    }

    private int[] m_values = {60, 90, 120, 150, 180, 240};
    private string[] m_displayedOptions = { "60.0f fps", "90.0f fps", "120.0f fps", "150.0f fps", "180.0f fps", "240.0f fps" };
}



