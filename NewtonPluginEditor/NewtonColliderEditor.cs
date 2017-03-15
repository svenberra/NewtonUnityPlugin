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

using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using static ValidationHelpers;

[CustomEditor(typeof(NewtonCollider))]
public abstract class NewtonColliderEditor : Editor
{
    protected void SetupBaseProps()
    {
        // Setup the SerializedProperties
        m_showGizmoProp = serializedObject.FindProperty("m_showGizmo");
        m_posProp = serializedObject.FindProperty("m_posit");
        m_rotProp = serializedObject.FindProperty("m_rotation");
        m_scaleProp = serializedObject.FindProperty("m_scale");
        m_materialProp = serializedObject.FindProperty("m_material");
        m_isTriggerProp = serializedObject.FindProperty("m_isTrigger");
        m_inheritScaleProp = serializedObject.FindProperty("m_inheritTransformScale");
        //Undo.undoRedoPerformed += OnUndoRedo;
    }

    void OnDestroy()
    {
        //Undo.undoRedoPerformed -= OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        Validate(); // Trigger derived class to Validate and check if value changed.
    }

    protected abstract void Validate();

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(m_posProp, new GUIContent("Position"));
        EditorGUILayout.PropertyField(m_rotProp, new GUIContent("Rotation"));
        EditorGUILayout.PropertyField(m_scaleProp, new GUIContent("Scale"));
        EditorGUILayout.PropertyField(m_inheritScaleProp, new GUIContent("Inherit Scale"));
        EditorGUILayout.PropertyField(m_showGizmoProp, new GUIContent("Show Gizmo"));
        EditorGUILayout.PropertyField(m_isTriggerProp, new GUIContent("Is Trigger"));
        EditorGUILayout.PropertyField(m_materialProp, new GUIContent("Material"));
        
        serializedObject.ApplyModifiedProperties();
    }

    SerializedProperty m_showGizmoProp;
    SerializedProperty m_posProp;
    SerializedProperty m_rotProp;
    SerializedProperty m_scaleProp;
    SerializedProperty m_materialProp;
    SerializedProperty m_isTriggerProp;
    SerializedProperty m_inheritScaleProp;
}

[CustomEditor(typeof(NewtonSphereCollider))]
public class NewtonSphereColliderEditor: NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_radiusProp = serializedObject.FindProperty("m_radius");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_radiusProp, new GUIContent("Radius"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonSphereCollider collision = (NewtonSphereCollider)target;
        if (RadiusChangedAndValid(collision.m_radius, m_radiusProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties(); //Transfer Editor value change to target object and add the change to the Undo/Redo stack
            collision.RecreateEditorShape();
            //Debug.Log("Sphere radius changed");
        }
    }
    SerializedProperty m_radiusProp;
}

[CustomEditor(typeof(NewtonBoxCollider))]
public class NewtonBoxColliderEditor: NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_dimensionProp = serializedObject.FindProperty("m_size");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_dimensionProp, new GUIContent("Dimension"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonBoxCollider collision = (NewtonBoxCollider)target;

        if (VolumeChangedAndValid(collision.m_size, m_dimensionProp.vector3Value, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Box dimensions changed");
        }
    }

    SerializedProperty m_dimensionProp;
}

[CustomEditor(typeof(NewtonCylinderCollider))]
public class NewtonCylinderColliderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_radius0Prop = serializedObject.FindProperty("m_radius0");
        m_radius1Prop = serializedObject.FindProperty("m_radius1");
        m_heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(m_radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(m_heightProp, new GUIContent("Height"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonCylinderCollider collision = (NewtonCylinderCollider)target;

        if (RadiusChangedAndValid(collision.m_radius0, m_radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(collision.m_radius1, m_radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, m_heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Cylinder shape changed");
        }
    }

    SerializedProperty m_radius0Prop;
    SerializedProperty m_radius1Prop;
    SerializedProperty m_heightProp;
}

[CustomEditor(typeof(NewtonCapsuleCollider))]
public class NewtonCapsuleColliderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_radius0Prop = serializedObject.FindProperty("m_radius0");
        m_radius1Prop = serializedObject.FindProperty("m_radius1");
        m_heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(m_radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(m_heightProp, new GUIContent("Height"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonCapsuleCollider collision = (NewtonCapsuleCollider)target;

        if (RadiusChangedAndValid(collision.m_radius0, m_radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(collision.m_radius1, m_radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, m_heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Capsule shape changed");
        }
    }

    SerializedProperty m_radius0Prop;
    SerializedProperty m_radius1Prop;
    SerializedProperty m_heightProp;
}

[CustomEditor(typeof(NewtonConeCollider))]
public class NewtonCapsuleConeEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_radiusProp = serializedObject.FindProperty("m_radius");
        m_heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(m_heightProp, new GUIContent("Height"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonConeCollider collision = (NewtonConeCollider)target;

        if (RadiusChangedAndValid(collision.m_radius, m_radiusProp.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, m_heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Cone shape changed");
        }
    }

    SerializedProperty m_radiusProp;
    SerializedProperty m_heightProp;
}

[CustomEditor(typeof(NewtonChamferedCylinderCollider))]
public class NewtonChamferedCylinderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_radiusProp = serializedObject.FindProperty("m_radius");
        m_heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(m_heightProp, new GUIContent("Height"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonChamferedCylinderCollider collision = (NewtonChamferedCylinderCollider)target;

        if (RadiusChangedAndValid(collision.m_radius, m_radiusProp.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, m_heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Chamfer cylinder shape changed");
        }
    }

    SerializedProperty m_radiusProp;
    SerializedProperty m_heightProp;
}

[CustomEditor(typeof(NewtonConvexHullCollider))]
public class NewtonConvexHullEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_meshProp = serializedObject.FindProperty("m_mesh");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(m_meshProp, new GUIContent("Mesh"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonConvexHullCollider collision = (NewtonConvexHullCollider)target;

        if (collision.m_mesh != (Mesh)m_meshProp.objectReferenceValue)
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Convex mesh changed");
        }
    }

    SerializedProperty m_meshProp;
}

[CustomEditor(typeof(NewtonTreeCollider))]
public class NewtonTreeColliderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        m_meshProp = serializedObject.FindProperty("m_mesh");
        m_optimizeProp = serializedObject.FindProperty("m_optimize");
        m_freezeTransformProp = serializedObject.FindProperty("m_freezeScale");
        m_rebuildMeshProp = serializedObject.FindProperty("m_rebuildMesh");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(m_meshProp, new GUIContent("Mesh"));
        EditorGUILayout.PropertyField(m_optimizeProp, new GUIContent("Optimize"));
        EditorGUILayout.PropertyField(m_freezeTransformProp, new GUIContent("Freeze Transform"));
        EditorGUILayout.PropertyField(m_rebuildMeshProp, new GUIContent("Rebuild mesh"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonTreeCollider collision = (NewtonTreeCollider)target;

        if (collision.m_mesh != (Mesh)m_meshProp.objectReferenceValue || collision.m_optimize != m_optimizeProp.boolValue || collision.m_freezeScale != m_freezeTransformProp.boolValue || collision.m_rebuildMesh != m_rebuildMeshProp.boolValue)
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            //Debug.Log("Tree collider changed");
        }
    }

    SerializedProperty m_meshProp;
    SerializedProperty m_optimizeProp;
    SerializedProperty m_rebuildMeshProp;
    SerializedProperty m_freezeTransformProp;
}
