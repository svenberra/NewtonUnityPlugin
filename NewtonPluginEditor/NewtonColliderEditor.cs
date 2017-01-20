using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using static ValidationHelpers;

[CustomEditor(typeof(NewtonCollider))]
public class NewtonColliderEditor : Editor
{
    protected void SetupBaseProps()
    {
        // Setup the SerializedProperties
        posProp = serializedObject.FindProperty("m_posit");
        rotProp = serializedObject.FindProperty("m_rotation");
        inheritScaleProp = serializedObject.FindProperty("m_inheritTransformScale");
        scaleProp = serializedObject.FindProperty("m_scale");
    }

    
    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        EditorGUILayout.PropertyField(posProp, new GUIContent("Position"));
        EditorGUILayout.PropertyField(rotProp, new GUIContent("Rotation"));
        EditorGUILayout.PropertyField(inheritScaleProp, new GUIContent("Inherit Scale"));
        EditorGUILayout.PropertyField(scaleProp, new GUIContent("Scale"));
        serializedObject.ApplyModifiedProperties();
    }

    SerializedProperty posProp;
    SerializedProperty rotProp;
    SerializedProperty inheritScaleProp;
    SerializedProperty scaleProp;

}

[CustomEditor(typeof(NewtonSphereCollider))]
public class NewtonSphereColliderEditor: NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        radiusProp = serializedObject.FindProperty("m_radius");

        Undo.undoRedoPerformed += OnUndoRedo;
    }

    void OnDestroy()
    {
        Undo.undoRedoPerformed -= OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        NewtonSphereCollider collision = (NewtonSphereCollider)target;

        if (RadiusChangedAndValid(collision.m_radius, radiusProp.floatValue, 0.01f))
        {
            collision.RecreateEditorShape();
            Debug.Log("Sphere radius changed by undo/redo");
        }
    }

    public override void OnInspectorGUI()
    {
        NewtonSphereCollider collision = (NewtonSphereCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldRadius = radiusProp.floatValue;
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));

        if (RadiusChangedAndValid(oldRadius, radiusProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Sphere radius changed");
        }

    }

    SerializedProperty radiusProp;
}


[CustomEditor(typeof(NewtonBoxCollider))]
public class NewtonBoxColliderEditor: NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        dimensionProp = serializedObject.FindProperty("m_size");
    }

    public override void OnInspectorGUI()
    {
        NewtonBoxCollider collision = (NewtonBoxCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldDimension = dimensionProp.vector3Value;
        EditorGUILayout.PropertyField(dimensionProp, new GUIContent("Dimension"));

        if(VolumeChangedAndValid(oldDimension, dimensionProp.vector3Value, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Box dimensions changed");
        }
    }

    SerializedProperty dimensionProp;

}


[CustomEditor(typeof(NewtonCylinderCollider))]
public class NewtonCylinderColliderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        radius0Prop = serializedObject.FindProperty("m_radius0");
        radius1Prop = serializedObject.FindProperty("m_radius1");
        heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        NewtonCylinderCollider collision = (NewtonCylinderCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldRadius0 = radius0Prop.floatValue;
        var oldRadius1 = radius1Prop.floatValue;
        var oldHeight = heightProp.floatValue;
        EditorGUILayout.PropertyField(radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));

        if (RadiusChangedAndValid(oldRadius0, radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(oldRadius1, radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(oldHeight, heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Cylinder shape changed");
        }

    }

    SerializedProperty radius0Prop;
    SerializedProperty radius1Prop;
    SerializedProperty heightProp;

}

[CustomEditor(typeof(NewtonCapsuleCollider))]
public class NewtonCapsuleColliderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        radius0Prop = serializedObject.FindProperty("m_radius0");
        radius1Prop = serializedObject.FindProperty("m_radius1");
        heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        NewtonCapsuleCollider collision = (NewtonCapsuleCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldRadius0 = radius0Prop.floatValue;
        var oldRadius1 = radius1Prop.floatValue;
        var oldHeight = heightProp.floatValue;
        EditorGUILayout.PropertyField(radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));

        if (RadiusChangedAndValid(oldRadius0, radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(oldRadius1, radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(oldHeight, heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Capsule shape changed");
        }

    }

    SerializedProperty radius0Prop;
    SerializedProperty radius1Prop;
    SerializedProperty heightProp;

}

[CustomEditor(typeof(NewtonConeCollider))]
public class NewtonCapsuleConeEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        radiusProp = serializedObject.FindProperty("m_radius");
        heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        NewtonConeCollider collision = (NewtonConeCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldRadius = radiusProp.floatValue;
        var oldHeight = heightProp.floatValue;
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));

        if (RadiusChangedAndValid(oldRadius, radiusProp.floatValue, 0.01f) || HeightChangedAndValid(oldHeight, heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Cone shape changed");
        }
    }

    SerializedProperty radiusProp;
    SerializedProperty heightProp;

}


[CustomEditor(typeof(NewtonChamferedCylinderCollider))]
public class NewtonChamferedCylinderEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        radiusProp = serializedObject.FindProperty("m_radius");
        heightProp = serializedObject.FindProperty("m_height");
    }

    public override void OnInspectorGUI()
    {
        NewtonChamferedCylinderCollider collision = (NewtonChamferedCylinderCollider)target;
        base.OnInspectorGUI();

        serializedObject.Update();
        var oldRadius = radiusProp.floatValue;
        var oldHeight = heightProp.floatValue;
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));

        if (RadiusChangedAndValid(oldRadius, radiusProp.floatValue, 0.01f) || HeightChangedAndValid(oldHeight, heightProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Chamfer cylinder shape changed");
        }

    }

    SerializedProperty radiusProp;
    SerializedProperty heightProp;

}


[CustomEditor(typeof(NewtonConvexHullCollider))]
public class NewtonConvexHullEditor : NewtonColliderEditor
{
    void OnEnable()
    {
        base.SetupBaseProps();
        meshProp = serializedObject.FindProperty("m_mesh");
    }

    public override void OnInspectorGUI()
    {
        NewtonConvexHullCollider collision = (NewtonConvexHullCollider)target;
        base.OnInspectorGUI();

        var oldMesh = (Mesh)meshProp.objectReferenceValue;
        EditorGUILayout.PropertyField(meshProp, new GUIContent("Mesh"));

        if(oldMesh != (Mesh)meshProp.objectReferenceValue)
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Convex mesh changed");
        }

    }

    SerializedProperty meshProp;

}


[CustomEditor(typeof(NewtonTreeCollider))]
public class NewtonTreeColliderEditor : NewtonColliderEditor
{

    void OnEnable()
    {
        base.SetupBaseProps();
        meshProp = serializedObject.FindProperty("m_mesh");
        optimizeProp = serializedObject.FindProperty("m_optimize");
        freezeTransformProp = serializedObject.FindProperty("m_freezeScale");
        rebuildMeshProp = serializedObject.FindProperty("m_rebuildMesh");
    }

    public override void OnInspectorGUI()
    {
        NewtonTreeCollider collision = (NewtonTreeCollider)target;

        base.OnInspectorGUI();

        var oldMesh = (Mesh)meshProp.objectReferenceValue;
        var oldOptimize = optimizeProp.boolValue;
        var oldFreezeTransform = freezeTransformProp.boolValue;
        var oldRebuildMesh = rebuildMeshProp.boolValue;
        EditorGUILayout.PropertyField(meshProp, new GUIContent("Mesh"));
        EditorGUILayout.PropertyField(optimizeProp, new GUIContent("Optimize"));
        EditorGUILayout.PropertyField(freezeTransformProp, new GUIContent("Freeze Transform"));
        EditorGUILayout.PropertyField(rebuildMeshProp, new GUIContent("Rebuild mesh"));

        if (oldMesh != (Mesh)meshProp.objectReferenceValue || oldOptimize != optimizeProp.boolValue || oldFreezeTransform != freezeTransformProp.boolValue || oldRebuildMesh != rebuildMeshProp.boolValue)
        {
            serializedObject.ApplyModifiedProperties();
            collision.RecreateEditorShape();
            Debug.Log("Tree collider changed");
        }

    }

    SerializedProperty meshProp;
    SerializedProperty optimizeProp;
    SerializedProperty freezeTransformProp;
    SerializedProperty rebuildMeshProp;

}
