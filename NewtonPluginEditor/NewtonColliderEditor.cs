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
            NewtonBoxCollider collision = (NewtonBoxCollider)target;
            base.OnInspectorGUI();
            //EditorGUILayout.LabelField("testing editor script", "xxxxxxxx");
            collision.m_size = EditorGUILayout.Vector3Field("dimension", collision.m_size);
        }
    }


    public class NewtonColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            NewtonCollider collision = (NewtonCollider)target;
            collision.m_posit = EditorGUILayout.Vector3Field("posit", collision.m_posit);
            collision.m_rotation = EditorGUILayout.Vector3Field("rotation", collision.m_rotation);
            collision.m_scale = EditorGUILayout.Vector3Field("scale", collision.m_scale);
            collision.UpdateParams();
        }
    }
}
