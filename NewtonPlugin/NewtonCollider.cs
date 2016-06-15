using UnityEditor;
using UnityEngine;
using System;
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

            //Vector3 posit = new Vector3 (0.0f, 0.0f, 0.0f);
            //Gizmos.DrawSphere(posit, 1.0f);
            //DrawFaceDelegateCallback drawCallback = new DrawFaceDelegateCallback(DrawFace);

            dNewtonCollision shape = GetShape();
            m_shape.DebugRender(DrawFace);
        }

        abstract public dNewtonCollision Create(NewtonWorld world);

        public void Destroy()
        {
            m_shape = null;
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
                }
            }
            return m_shape;
        }

        private dNewtonCollision m_shape;
        public Vector3 m_size = Vector3.one;
        public Vector3 m_posit = Vector3.zero;
        public Vector3 m_rotation = Vector3.zero;
        public Vector3 m_scale = Vector3.one;

        // Reuse the same buffer for debug display
        static Vector3 m_lineP0 = Vector3.zero;
        static Vector3 m_lineP1 = Vector3.zero;
        static float[] m_debugDisplayVertexBuffer = new float[64 * 3];
    }

/*
// for some reason this do no complele, so we are no allowe to write Eitor scripts whic sucks big time


    [CustomEditor(typeof(NewtonCollider))]
    public class NewtonColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //LevelScript myTarget = (LevelScript)target;
            //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
            //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
        }
    }
*/
}
