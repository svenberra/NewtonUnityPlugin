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
        world.m_asyncUpdate = EditorGUILayout.Toggle("async update", world.m_asyncUpdate);
        world.m_numberOfThreads = EditorGUILayout.IntPopup("worked threads", world.m_numberOfThreads, m_numberOfThreads, m_numberOfThreadsValues);

        world.m_solverIterationsCount = EditorGUILayout.IntField("solver iterations", world.m_solverIterationsCount);
        if (world.m_solverIterationsCount < 1)
        {
            world.m_solverIterationsCount = 1;
        }
        world.m_updateRate = EditorGUILayout.IntPopup("frame rate", world.m_updateRate, m_displayedOptions, m_displayedOptionsValues);

        world.m_broadPhaseType = EditorGUILayout.IntPopup("broad phase type", world.m_broadPhaseType, m_broaphase, m_broaphaseValues);

        world.m_gravity = EditorGUILayout.Vector3Field("gravity", world.m_gravity);
    }

    static private int[] m_displayedOptionsValues = {60, 90, 120, 150, 180, 240};
    static private string[] m_displayedOptions = { "60.0f fps", "90.0f fps", "120.0f fps", "150.0f fps", "180.0f fps", "240.0f fps" };

    static private int[] m_numberOfThreadsValues = { 0, 2, 3, 4, 8};
    static private string[] m_numberOfThreads = { "single threaded", "2 worked threads", "3 worked threads", "4 worked threads", "8 worked threads"};

    static private int[] m_broaphaseValues = { 0, 1};
    static private string[] m_broaphase = { "optimized for dynamic scenes", "optimize for static scenes"};

}



