using System;
using UnityEngine;
using UnityEditor;
using NewtonPlugin;
using System.Collections.Generic;


namespace NewtonPlugin
{

    [CustomEditor(typeof(NewtonPlugin.NewtonCollider))]
    public class NewtonColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UnityEngine.Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxx 6");
            //LevelScript myTarget = (LevelScript)target;
            //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
            //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
        }
    }
}
