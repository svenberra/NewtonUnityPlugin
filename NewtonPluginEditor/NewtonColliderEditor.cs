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
            NewtonCollider collision = (NewtonCollider)target;

            //UnityEngine.Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxx 6");
            //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
            //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
            //EditorGUILayout.LabelField("testing editor script", "xxxxxxxx");

            EditorGUILayout.Vector3Field("scale", collision.m_scale);
            collision.UpdateParams();
        }
    }
}
