using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.InteropServices;


//[InitializeOnLoad]
//public class NewtonStartup
//{
//    static NewtonStartup()
//    {
//        Debug.Log("Up and running");

//        string nManager = typeof(NewtonPlugin.NewtonManager).Name;
//        string nBS = typeof(NewtonPlugin.NewtonBallAndSocket).Name;
//        string nH = typeof(NewtonPlugin.NewtonHinge).Name;
//        string nR = typeof(NewtonPlugin.NewtonRollingFriction).Name;

//        foreach (MonoScript monoScript in MonoImporter.GetAllRuntimeMonoScripts())
//        {
//            if (monoScript.name == nManager)
//            {
//                if (MonoImporter.GetExecutionOrder(monoScript) != -100)
//                {
//                    MonoImporter.SetExecutionOrder(monoScript, -100);
//                    Debug.Log("Adjusted NewtonManager execution order.");
//                }
//            }

//            if (monoScript.name == nBS)
//            {
//                if (MonoImporter.GetExecutionOrder(monoScript) != 100)
//                {
//                    MonoImporter.SetExecutionOrder(monoScript, 100);
//                    Debug.Log("Adjusted NewtonBallAndSocket execution order.");
//                }
//            }

//            if (monoScript.name == nH)
//            {
//                if (MonoImporter.GetExecutionOrder(monoScript) != 101)
//                {
//                    MonoImporter.SetExecutionOrder(monoScript, 101);
//                    Debug.Log("Adjusted NewtonHinge execution order.");
//                }
//            }

//            if (monoScript.name == nR)
//            {
//                if (MonoImporter.GetExecutionOrder(monoScript) != 102)
//                {
//                    MonoImporter.SetExecutionOrder(monoScript, 102);
//                    Debug.Log("Adjusted NewtonRollingFriction execution order.");
//                }
//            }

//        }

//    }
//}

namespace NewtonPlugin
{

    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Manager")]
    public class NewtonManager : MonoBehaviour
    {
        private IntPtr pWorld;

        public bool DebugRender = false;

        void Awake()
        {
            pWorld = NewtonWorld.Instance.pWorld;
        }

        void FixedUpdate()
        {
            NewtonAPI.NewtonUpdate(pWorld, Time.deltaTime);

            //if (DebugRender)
            //    RenderDebugLines();
        }

        void RenderDebugLines()
        {

            Matrix4x4 mat = Matrix4x4.identity;

            IntPtr pBody = NewtonAPI.NewtonWorldGetFirstBody(pWorld);
            while (pBody != IntPtr.Zero)
            {
                NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);
                IntPtr pColl = NewtonAPI.NewtonBodyGetCollision(pBody);
                NewtonAPI.NewtonCollisionForEachPolygonDo(pColl, ref mat, NewtonCollisionIterator, IntPtr.Zero);

                pBody = NewtonAPI.NewtonWorldGetNextBody(pWorld, pBody);
            }

            //Vector3 p0 = new Vector3(-100, -100, -100);
            //Vector3 p1 = new Vector3(100, 100, 100);
            //WorldForEachBodyInAABBDo(ref p0, ref p1, NewtonBodyIterator, IntPtr.Zero);

        }

        static void NewtonBodyIterator(IntPtr pBody, IntPtr userData)
        {
            Matrix4x4 mat = Matrix4x4.identity;
            NewtonAPI.NewtonBodyGetMatrix(pBody, ref mat);
            IntPtr pColl = NewtonAPI.NewtonBodyGetCollision(pBody);
            NewtonAPI.NewtonCollisionForEachPolygonDo(pColl, ref mat, NewtonCollisionIterator, IntPtr.Zero);
        }

        static float[] points = new float[64 * 3]; //Vertexbuffer
        static void NewtonCollisionIterator(IntPtr userData, int vertexCount, IntPtr faceArray, int faceId)
        {
            Marshal.Copy(faceArray, points, 0, vertexCount * 3);

            Vector3 pA = Vector3.zero;
            Vector3 pB = Vector3.zero;
            for (int i = 0; i < vertexCount - 1; i++)
            {
                pA = new Vector3(points[i * 3], points[i * 3 + 1], points[i * 3 + 2]);
                pB = new Vector3(points[(i + 1) * 3], points[(i + 1) * 3 + 1], points[(i + 1) * 3 + 2]);
                Debug.DrawLine(pA, pB, Color.magenta, Time.deltaTime, false);
            }
            pA = new Vector3(points[0], points[1], points[2]);
            Debug.DrawLine(pA, pB, Color.magenta, Time.deltaTime, false);
        }

    }
}


