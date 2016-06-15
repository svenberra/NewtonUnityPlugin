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
        /*
            void UpdateLines()
            {
                //Debug.Log("Building debug lines for " + this.name);

                //GCHandle gch = GCHandle.Alloc(lines);
                //IntPtr collider = CreateCollider(false);
                //if (collider != IntPtr.Zero)
                //{
                //    Matrix4x4 offsetMatrix = Matrix4x4.identity;
                //    NewtonAPI.NewtonCollisionForEachPolygonDo(collider, ref offsetMatrix, NewtonCollisionIterator, GCHandle.ToIntPtr(gch));
                //    gch.Free();
                //    NewtonAPI.NewtonDestroyCollision(collider);
                //}

            }


            float[] points = new float[64 * 3]; // Reuse the same buffer

            void NewtonCollisionIterator(IntPtr userData, int vertexCount, IntPtr faceArray, int faceId)
            {
                GCHandle gch = GCHandle.FromIntPtr(userData);

                Debug.Log(userData.ToString());

                List<Line> lines = (List<Line>)gch.Target;

                //float[] points = new float[vertexCount * 3];
                Marshal.Copy(faceArray, points, 0, vertexCount * 3);

                Vector3 pA = Vector3.zero;
                Vector3 pB = Vector3.zero;
                Line line;
                for (int i = 0; i < vertexCount - 1; i++)
                {
                    pA = new Vector3(points[i * 3], points[i * 3 + 1], points[i * 3 + 2]);
                    pB = new Vector3(points[(i + 1) * 3], points[(i + 1) * 3 + 1], points[(i + 1) * 3 + 2]);
                    line = new Line();
                    line.pA = pA;
                    line.pB = pB;
                    lines.Add(line);
                }
                pA = new Vector3(points[0], points[1], points[2]);
                line = new Line();
                line.pA = pA;
                line.pB = pB;
                lines.Add(line);
            }

*/
        //protected dNewtonCollision m_collision;
        //private List<Line> lines = null;
        //Color col = new Color(0.6f, 1.0f, 0.6f);


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
                NewtonBody body = owner.GetComponent<NewtonBody>();
                while (body == null)
                {
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

        public Vector3 m_size = Vector3.one;
        public Vector3 m_posit = Vector3.zero;
        public Vector3 m_rotation = Vector3.zero;
        public Vector3 m_scale = Vector3.one;

        // Reuse the same buffer for debug display
        static Vector3 m_lineP0 = Vector3.zero;
        static Vector3 m_lineP1 = Vector3.zero;
        static float[] m_debugDisplayVertexBuffer = new float[64 * 3];

        private dNewtonCollision m_shape;
        private GCHandle m_userDataGlueObject;
    }

    

    /*
        public struct Line
        {
            public Vector3 pA;
            public Vector3 pB;
        }
    */
}
