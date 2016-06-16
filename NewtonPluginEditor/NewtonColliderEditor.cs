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

            Vector3 size = EditorGUILayout.Vector3Field("dimension", collision.m_size);
            if (Vector3.Distance(size, collision.m_size) > 0.001f)
            {
                collision.m_size = size;
                collision.RecreateShape();
            }
            EditorUtility.SetDirty(target);
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
