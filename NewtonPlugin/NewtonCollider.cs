using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;


public delegate void OnDrawFaceCallback(IntPtr points, int vertexCount);

abstract public class NewtonCollider : MonoBehaviour
{
    abstract public dNewtonCollision Create(NewtonWorld world);

    public void OnDrawFace(IntPtr vertexDataPtr, int vertexCount)
    {
        Marshal.Copy(vertexDataPtr, m_debugDisplayVertexBuffer, 0, vertexCount * 3);
        int i0 = vertexCount - 1;
        for (int i1 = 0; i1 < vertexCount; i1++)
        {
            m_lineP0.x = m_debugDisplayVertexBuffer[i0 * 3 + 0];
            m_lineP0.y = m_debugDisplayVertexBuffer[i0 * 3 + 1];
            m_lineP0.z = m_debugDisplayVertexBuffer[i0 * 3 + 2];
            m_lineP1.x = m_debugDisplayVertexBuffer[i1 * 3 + 0];
            m_lineP1.y = m_debugDisplayVertexBuffer[i1 * 3 + 1];
            m_lineP1.z = m_debugDisplayVertexBuffer[i1 * 3 + 2];
            Gizmos.DrawLine(m_lineP0, m_lineP1);
            i0 = i1;
        }
    }

    void OnDrawGizmosSelected()
    {
        ValidateEditorShape();
        if (m_shape != null)
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.color = Color.yellow;

            Camera camera = Camera.current;
            Matrix4x4 matrix = Matrix4x4.Inverse (camera.worldToCameraMatrix * Gizmos.matrix);

            //SceneCamera(-0.06834328 5.960464E-08 0.9976619 - 10.51591)(-0.2695866 0.9627991 - 0.01846763 - 5.616923)(-0.960548 - 0.2702184 - 0.06580079 6.189371)(0 0 0 1)
            Vector4 eyepoint = matrix.GetColumn(3);
            //Debug.Log(camera.name + " " + eyepoint.x + " " + eyepoint.y + " " + eyepoint.z);

            IntPtr floatPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Vector4)));
            Marshal.StructureToPtr(eyepoint, floatPtr, false);

            m_shape.DebugRender(OnDrawFace, floatPtr);

            Marshal.FreeHGlobal(floatPtr);
        }
    }

    public Matrix4x4 GetMatrix ()
    {
        return Matrix4x4.TRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);
    }

    virtual public Vector3 GetScale()
    {
        Vector3 scale = m_scale;
        if (m_inheritTransformScale)
        {
            scale.x *= transform.localScale.x;
            scale.y *= transform.localScale.y;
            scale.z *= transform.localScale.z;
        }
        return scale;
    }
    
    public void RecreateEditorShape()
    {
        if (m_shape != null)
        {
            m_shape.Dispose();
            m_shape = null;
            UpdateEditorParams();
        }
    }
    private void UpdateParams(dNewtonCollision shape)
    {
        Vector3 scale = GetScale();
        shape.SetScale(scale.x, scale.y, scale.z);

        Matrix4x4 matrix = GetMatrix();
        IntPtr floatPtr = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
        Marshal.StructureToPtr(matrix, floatPtr, false);
        shape.SetMatrix(floatPtr);
        Marshal.FreeHGlobal(floatPtr);
    }

    public void UpdateEditorParams()
    {
        ValidateEditorShape();
        if (m_shape != null)
        {
            UpdateParams(m_shape);
        }
    }

    public dNewtonCollision CreateBodyShape(NewtonWorld world)
    {
        dNewtonCollision shape = Create(world);
        if (shape != null)
        {
            UpdateParams(shape);
        }
        return shape;
    }

    private void ValidateEditorShape()
    {
        if (m_shape == null)
        {
            NewtonBody body = null;
            Transform gameTransform = transform;
            while (gameTransform != null)
            {
                // this is a child body we need to fin the root rigid body owning the shape
                if (body == null)
                {
                     body = transform.gameObject.GetComponent<NewtonBody>();
                }
                gameTransform = gameTransform.parent;
            }

            if (body != null)
            {
                if (body.m_world != null)
                {
                    m_shape = Create(body.m_world);
                }
            }
        }
    }

    private dNewtonCollision m_shape = null;
    public Vector3 m_posit = Vector3.zero;
    public Vector3 m_rotation = Vector3.zero;
    public Vector3 m_scale = Vector3.one;
    public bool m_inheritTransformScale = true;

    // Reuse the same buffer for debug display
    static Vector3 m_lineP0 = Vector3.zero;
    static Vector3 m_lineP1 = Vector3.zero;
    static float[] m_debugDisplayVertexBuffer = new float[64 * 3];
}

