using System;
using UnityEngine;
using UnityEditor;
using NewtonPlugin;
using System.Collections.Generic;


namespace NewtonPlugin
{
    [CustomEditor(typeof(NewtonPlugin.NewtonBoxCollider))]
    public class NewtonBoxColliderEditor: NewtonColliderEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }

    public class NewtonColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UnityEngine.Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxx 6");
            NewtonCollider myTarget = (NewtonCollider)target;
            //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
            //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
            EditorGUILayout.LabelField("testing editor script", "xxxxxxxx");
        }
    }
}
