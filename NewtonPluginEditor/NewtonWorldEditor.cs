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
        world.m_updateRate = (NewtonWorld.UpdateRate) EditorGUILayout.EnumPopup("fpx", world.m_updateRate);
        //world.m_updateRate = EditorGUILayout.FloatField("posit", world.m_updateRate);
    }
}



