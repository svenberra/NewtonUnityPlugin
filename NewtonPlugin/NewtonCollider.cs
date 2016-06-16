using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;


public delegate void DrawFaceDelegateCallback(IntPtr points, int vertexCount);

namespace NewtonPlugin
{
    abstract public class NewtonCollider : MonoBehaviour
    {
        public void DrawFace(IntPtr vertexDataPtr, int vertexCount)
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
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.color = Color.yellow;
            dNewtonCollision shape = GetShape();
            m_shape.DebugRender(DrawFace);
        }

        abstract public dNewtonCollision Create(NewtonWorld world);

        public Matrix4x4 GetMatrix ()
        {
            return Matrix4x4.TRS(m_posit, Quaternion.Euler(m_rotation), Vector3.one);
        }

        public Vector3 GetScale()
        {
            Vector3 scale = m_scale;
            scale.x *= transform.localScale.x;
            scale.y *= transform.localScale.y;
            scale.z *= transform.localScale.z;
            return scale;
        }

        void OnDestroy()
        {
            Destroy();
        }

        public void Destroy()
        {
            if (m_shape != null)
            {
                m_shape.Cleanup();
                m_shape = null;
            }
        }

        public void RecreateShape()
        {
            Destroy();
            GetShape();
            UpdateParams();
        }

        public void UpdateParams()
        {
            Matrix4x4 matrix = GetMatrix();
            Vector3 scale = GetScale();
           
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(matrix));
            Marshal.StructureToPtr(matrix, pnt, false);

            m_shape.SetMatrix(pnt);
            m_shape.SetScale(scale.x, scale.y, scale.z);
        }

        dNewtonCollision GetShape()
        {
            if (m_shape == null)
            {
                GameObject owner = gameObject;

                // find the world that own this collision shape
                NewtonBody body = owner.GetComponent<NewtonBody>();
                while (body == null)
                {
                    // this is a child body we need to fin the root rigid body owning the shape
                    owner = owner.GetComponentInParent<Transform>().gameObject;
                    body = owner.GetComponent<NewtonBody>();
                }
                
                if (body.m_world != null)
                {
                    m_shape = Create(body.m_world);
                    UpdateParams();
                }
            }
            return m_shape;
        }

        private dNewtonCollision m_shape;
        public Vector3 m_posit = Vector3.zero;
        public Vector3 m_rotation = Vector3.zero;
        public Vector3 m_scale = Vector3.one;

        // Reuse the same buffer for debug display
        static Vector3 m_lineP0 = Vector3.zero;
        static Vector3 m_lineP1 = Vector3.zero;
        static float[] m_debugDisplayVertexBuffer = new float[64 * 3];
    }
}
