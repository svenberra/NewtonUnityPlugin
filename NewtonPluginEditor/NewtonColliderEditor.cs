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
        posProp = serializedObject.FindProperty("m_posit");
        rotProp = serializedObject.FindProperty("m_rotation");
        inheritScaleProp = serializedObject.FindProperty("m_inheritTransformScale");
        scaleProp = serializedObject.FindProperty("m_scale");

        Undo.undoRedoPerformed += OnUndoRedo;

    }

    void OnDestroy()
    {
        Undo.undoRedoPerformed -= OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        Validate(); // Trigger derived class to Validate and check if value changed.
    }

    protected abstract void Validate();

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
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonSphereCollider collision = (NewtonSphereCollider)target;
        if (RadiusChangedAndValid(collision.m_radius, radiusProp.floatValue, 0.01f))
        {
            serializedObject.ApplyModifiedProperties(); //Transfer Editor value change to target object and add the change to the Undo/Redo stack
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
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(dimensionProp, new GUIContent("Dimension"));
        Validate();
    }

    protected override void Validate()
    {
        NewtonBoxCollider collision = (NewtonBoxCollider)target;

        if (VolumeChangedAndValid(collision.m_size, dimensionProp.vector3Value, 0.01f))
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
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonCylinderCollider collision = (NewtonCylinderCollider)target;

        if (RadiusChangedAndValid(collision.m_radius0, radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(collision.m_radius1, radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, heightProp.floatValue, 0.01f))
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
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(radius0Prop, new GUIContent("Radius 0"));
        EditorGUILayout.PropertyField(radius1Prop, new GUIContent("Radius 1"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonCapsuleCollider collision = (NewtonCapsuleCollider)target;

        if (RadiusChangedAndValid(collision.m_radius0, radius0Prop.floatValue, 0.01f) || RadiusChangedAndValid(collision.m_radius1, radius1Prop.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, heightProp.floatValue, 0.01f))
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
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonConeCollider collision = (NewtonConeCollider)target;

        if (RadiusChangedAndValid(collision.m_radius, radiusProp.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, heightProp.floatValue, 0.01f))
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
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(radiusProp, new GUIContent("Radius"));
        EditorGUILayout.PropertyField(heightProp, new GUIContent("Height"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonChamferedCylinderCollider collision = (NewtonChamferedCylinderCollider)target;

        if (RadiusChangedAndValid(collision.m_radius, radiusProp.floatValue, 0.01f) || HeightChangedAndValid(collision.m_height, heightProp.floatValue, 0.01f))
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
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(meshProp, new GUIContent("Mesh"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonConvexHullCollider collision = (NewtonConvexHullCollider)target;

        if (collision.m_mesh != (Mesh)meshProp.objectReferenceValue)
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

        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(meshProp, new GUIContent("Mesh"));
        EditorGUILayout.PropertyField(optimizeProp, new GUIContent("Optimize"));
        EditorGUILayout.PropertyField(freezeTransformProp, new GUIContent("Freeze Transform"));
        EditorGUILayout.PropertyField(rebuildMeshProp, new GUIContent("Rebuild mesh"));
        Validate();

    }

    protected override void Validate()
    {
        NewtonTreeCollider collision = (NewtonTreeCollider)target;

        if (collision.m_mesh != (Mesh)meshProp.objectReferenceValue || collision.m_optimize != optimizeProp.boolValue || collision.m_freezeScale != freezeTransformProp.boolValue || collision.m_rebuildMesh != rebuildMeshProp.boolValue)
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
