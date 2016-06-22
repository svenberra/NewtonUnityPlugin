using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public class NewtonColliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NewtonCollider collision = (NewtonCollider)target;

        collision.m_posit = EditorGUILayout.Vector3Field("posit", collision.m_posit);
        collision.m_rotation = EditorGUILayout.Vector3Field("rotation", collision.m_rotation);
        collision.m_inheritTransformScale = EditorGUILayout.Toggle("inherit transform scale", collision.m_inheritTransformScale);
        collision.m_scale = EditorGUILayout.Vector3Field("scale", collision.m_scale);
        collision.UpdateEditorParams();
    }
}


[CustomEditor(typeof(NewtonSphereCollider))]
public class NewtonSphereColliderEditor: NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonSphereCollider collision = (NewtonSphereCollider)target;
        base.OnInspectorGUI();

        float radius = EditorGUILayout.FloatField("radius", collision.m_radius);
        float error = radius - collision.m_radius;
        if (error * error > 0.000001f)
        {
            collision.m_radius = radius;
            collision.RecreateEditorShape();
        }
        EditorUtility.SetDirty(target);
    }
}


[CustomEditor(typeof(NewtonBoxCollider))]
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
           collision.RecreateEditorShape();
        }
        EditorUtility.SetDirty(target);
    }
}

[CustomEditor(typeof(NewtonCylinderCollider))]
public class NewtonCylinderColliderEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonCylinderCollider collision = (NewtonCylinderCollider)target;
        base.OnInspectorGUI();

        bool shapeChanged = false;
        float radius = EditorGUILayout.FloatField("radius 0", collision.m_radius0);
        radius = radius > 0.01f ? radius : 0.01f; 
        float error = radius - collision.m_radius0;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius0 = radius;
        }

        radius = EditorGUILayout.FloatField("radius 1", collision.m_radius1);
        radius = radius > 0.01f ? radius : 0.01f;
        error = radius - collision.m_radius1;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius1 = radius;
        }

        float height = EditorGUILayout.FloatField("height", collision.m_height);
        height = height > 0.01f ? height : 0.01f;
        error = height - collision.m_height;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_height = height;
        }

        if (shapeChanged)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}

[CustomEditor(typeof(NewtonCapsuleCollider))]
public class NewtonCapsuleColliderEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonCapsuleCollider collision = (NewtonCapsuleCollider)target;
        base.OnInspectorGUI();

        bool shapeChanged = false;
        float radius = EditorGUILayout.FloatField("radius 0", collision.m_radius0);
        radius = radius > 0.01f ? radius : 0.01f;
        float error = radius - collision.m_radius0;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius0 = radius;
        }

        radius = EditorGUILayout.FloatField("radius 1", collision.m_radius1);
        radius = radius > 0.01f ? radius : 0.01f;
        error = radius - collision.m_radius1;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius1 = radius;
        }

        float height = EditorGUILayout.FloatField("height", collision.m_height);
        height = height > 0.01f ? height : 0.01f;
        error = height - collision.m_height;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_height = height;
        }

        if (shapeChanged)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}

[CustomEditor(typeof(NewtonConeCollider))]
public class NewtonCapsuleConeEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonConeCollider collision = (NewtonConeCollider)target;
        base.OnInspectorGUI();

        bool shapeChanged = false;
        float radius = EditorGUILayout.FloatField("radius", collision.m_radius);
        radius = radius > 0.01f ? radius : 0.01f;
        float error = radius - collision.m_radius;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius = radius;
        }

        float height = EditorGUILayout.FloatField("height", collision.m_height);
        height = height > 0.01f ? height : 0.01f;
        error = height - collision.m_height;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_height = height;
        }

        if (shapeChanged)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}


[CustomEditor(typeof(NewtonChamferedCylinderCollider))]
public class NewtonChamferedCylinderEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonChamferedCylinderCollider collision = (NewtonChamferedCylinderCollider)target;
        base.OnInspectorGUI();

        bool shapeChanged = false;
        float radius = EditorGUILayout.FloatField("radius", collision.m_radius);
        radius = radius > 0.01f ? radius : 0.01f;
        float error = radius - collision.m_radius;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_radius = radius;
        }

        float height = EditorGUILayout.FloatField("height", collision.m_height);
        height = height > 0.01f ? height : 0.01f;
        error = height - collision.m_height;
        if (error * error > 0.000001f)
        {
            shapeChanged = true;
            collision.m_height = height;
        }

        if (shapeChanged)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}


[CustomEditor(typeof(NewtonConvexHullCollider))]
public class NewtonConvexHullEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonConvexHullCollider collision = (NewtonConvexHullCollider)target;
        base.OnInspectorGUI();

        bool shapeChanged = false;
        Mesh newMesh = (UnityEngine.Mesh)EditorGUILayout.ObjectField("Mesh", collision.m_mesh, typeof(Mesh), true);
        if (newMesh != collision.m_mesh)
        {
            shapeChanged = true;
            collision.m_mesh = newMesh;
        }

        float value = EditorGUILayout.Slider("quality", collision.m_quality, 0.0f, 1.0f);
        float error = value - collision.m_quality;
        if (error * error > 0.00001f)
        {
            shapeChanged = true;
            collision.m_quality = value;
        }

        if (shapeChanged == true)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}


[CustomEditor(typeof(NewtonTreeCollider))]
public class NewtonTreeColliderEditor : NewtonColliderEditor
{
    public override void OnInspectorGUI()
    {
        NewtonTreeCollider collision = (NewtonTreeCollider)target;

        base.OnInspectorGUI();

        bool shapeChanged = false;
        Mesh newMesh = (UnityEngine.Mesh)EditorGUILayout.ObjectField("Mesh", collision.m_mesh, typeof(Mesh), true);
        if (newMesh != collision.m_mesh)
        {
            shapeChanged = true;
            collision.m_mesh = newMesh;
        }

        bool optimize = EditorGUILayout.Toggle("optimize", collision.m_optimize);
        if (optimize != collision.m_optimize)
        {
            shapeChanged = true;
            collision.m_optimize = optimize;
        }

        bool freezeScale = EditorGUILayout.Toggle("freeze transform scale", collision.m_freezeScale);
        if (freezeScale != collision.m_freezeScale)
        {
            shapeChanged = true;
            collision.m_freezeScale = freezeScale;
        }

        bool rebuildMesh = EditorGUILayout.Toggle("rebuild Mesh", collision.m_rebuildMesh);
        if (rebuildMesh == true)
        {
            shapeChanged = true;
        }

        if (shapeChanged == true)
        {
            collision.RecreateEditorShape();
        }

        EditorUtility.SetDirty(target);
    }
}
