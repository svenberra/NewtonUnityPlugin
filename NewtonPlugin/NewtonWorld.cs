using System;
using System.Collections.Generic;
using NewtonAPI;
using UnityEngine;
using System.Runtime.InteropServices;

// TODO: Move world creation into Disposable class to assure unmanaged resource cleanup if Unity Editor stops playmode due to exception.
// The same goes for BodyTransformState       
// On the other hand, play mode never seems to stop due to exception, it just logs it and moves on. So maybe not necessary.

namespace NewtonPlugin
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct BodyTransformState
    {
        public Vector3 previousPosition;
        public Quaternion previousRotation;
        public Vector3 currentPosition;
        public Quaternion currentRotation;

        public Vector3 GetInterpolatedPosition(float t)
        {
            return Vector3.Lerp(previousPosition, currentPosition, t);
        }

        public Quaternion GetInterpolatedRotation(float t)
        {
            return Quaternion.Lerp(previousRotation, currentRotation, t);
        }
    }


    internal static class NewtonManager
    {
        private static IntPtr worldPtr = IntPtr.Zero;
        private static HashSet<int> references = new HashSet<int>(); //Components that require the World

        private static IntPtr vehicleManagerPtr = IntPtr.Zero;
        internal static IntPtr VehicleManagerPointer
        {
            get { return vehicleManagerPtr; }
        }

        private static IntPtr sceneBodyPtr = IntPtr.Zero;

        internal static float TimeAlpha { get; set; }

        internal unsafe static IntPtr Register(MonoBehaviour mb)
        {
            if (worldPtr == IntPtr.Zero)
            {
                CreateWorld();
            }

            references.Add(mb.GetInstanceID());

            return worldPtr;
        }

        internal static void Unregister(MonoBehaviour mb)
        {
            references.Remove(mb.GetInstanceID());

            if (references.Count == 0) // All references are gone, destroy world
            {
                DestroyWorld();
            }
        }

        public unsafe static void CreateWorld()
        {
            // Create a world instance
            worldPtr = NewtonInvoke.NewtonCreate();
            Debug.Log("World created: " + worldPtr.ToString());

            // Setup default values
            int defaultMaterial = NewtonInvoke.NewtonMaterialGetDefaultGroupID(worldPtr);
            NewtonInvoke.NewtonMaterialSetDefaultFriction(worldPtr, defaultMaterial, defaultMaterial, 0.6f, 0.5f);

            NewtonInvoke.NewtonSetSolverModel(worldPtr, 4);
            //NewtonInvoke.NewtonSetSolverConvergenceQuality(worldPtr, 0);
            NewtonInvoke.NewtonSetThreadsCount(worldPtr, 4);

            // Create a vehicle manager instance
            vehicleManagerPtr = NewtonInvoke.NewtonCreateVehicleManager(worldPtr);

            // Setup Static Scene Collision
            IntPtr sceneCollisionPtr = NewtonInvoke.NewtonCreateSceneCollision(worldPtr, 0);
            IntPtr nullColliderPtr = NewtonInvoke.NewtonCreateNull(worldPtr);
            NewtonInvoke.NewtonSceneCollisionBeginAddRemove(sceneCollisionPtr);
            NewtonInvoke.NewtonSceneCollisionAddSubCollision(sceneCollisionPtr, nullColliderPtr);
            NewtonInvoke.NewtonDestroyCollision(nullColliderPtr);

            Matrix4x4 mat = Matrix4x4.identity;
            sceneBodyPtr = NewtonInvoke.NewtonCreateDynamicBody(worldPtr, sceneCollisionPtr, (float*)&mat);
            NewtonInvoke.NewtonDestroyCollision(sceneCollisionPtr);

            // Add NewtonWorldController to scene if user hasn't added one.
            if (GameObject.FindObjectOfType<NewtonWorldController>() == null)
            {
                GameObject worldController = new GameObject("NewtonWorldController");
                worldController.AddComponent<NewtonWorldController>();
            }
        }

        public static void DestroyWorld()
        {
            // Don't destroy the Vehicle Manager, it will be destroyed by the World

            // Destroy static scene body
            NewtonInvoke.NewtonDestroyBody(sceneBodyPtr);

            //NewtonInvoke.NewtonWaitForUpdateToFinish(worldPtr);
            NewtonInvoke.NewtonDestroy(worldPtr);
            Debug.Log("World destroyed: " + worldPtr.ToString());
            vehicleManagerPtr = IntPtr.Zero;
            worldPtr = IntPtr.Zero;

        }


        public static unsafe void ApplyForceAndTorque(IntPtr body, float timestep, int threadIndex)
        {
            float mass, ixx, iyy, izz;
            NewtonInvoke.NewtonBodyGetMassMatrix(body, &mass, &ixx, &iyy, &izz);

            Vector3 force = new Vector3(0.0f, -9.8f * mass, 0.0f);

            NewtonInvoke.NewtonBodySetForce(body, &force.x);
        }


    }

    [AddComponentMenu("Newton Physics/World Controller")]
    public class NewtonWorldController : MonoBehaviour
    {
        public float timeStep = 1.0f / 60.0f;
        public float maxFrameTime = 0.25f;
        public float timeScale = 1.0f;

        private const float MaxTimeStep = 1.0f / 30.0f;

        public bool debugRender = false;

        private IntPtr worldPtr = IntPtr.Zero;

        private float accumulator = 0.0f;

        public void OnValidate()
        {
            if (timeStep > MaxTimeStep)
                timeStep = MaxTimeStep;
        }

        public void Awake()
        {
            worldPtr = NewtonManager.Register(this);
        }

        public unsafe void Update()
        {
            float frameTime = Time.deltaTime;
            if (frameTime > maxFrameTime)
                frameTime = maxFrameTime;

            accumulator += frameTime * timeScale;

            // We are about to step the simulation, save the current states
            if (accumulator >= timeStep)
            {
                NewtonInvoke.NewtonSaveBodyStates(worldPtr);
            }

            bool stepsTaken = false;
            while (accumulator >= timeStep)
            {
                NewtonInvoke.NewtonUpdate(worldPtr, timeStep);
                accumulator -= timeStep;
                stepsTaken = true;
            }

            NewtonManager.TimeAlpha = accumulator / timeStep;

            if (stepsTaken)
            {
                // Update transforms
                NewtonInvoke.NewtonUpdateBodyStates(worldPtr);


                if (debugRender)
                    RenderDebugLines();
            }


        }

        unsafe void RenderDebugLines()
        {

            Matrix4x4 mat = Matrix4x4.identity;

            IntPtr pBody = NewtonInvoke.NewtonWorldGetFirstBody(worldPtr);
            while (pBody != IntPtr.Zero)
            {
                NewtonInvoke.NewtonBodyGetMatrix(pBody, (float*)&mat);
                IntPtr collPtr = NewtonInvoke.NewtonBodyGetCollision(pBody);
                NewtonInvoke.NewtonCollisionForEachPolygonDo(collPtr, (float*)&mat, CollisionIterator, IntPtr.Zero);

                pBody = NewtonInvoke.NewtonWorldGetNextBody(worldPtr, pBody);
            }

            //Debug.Log("BodyCount:" + bodyCount.ToString());

            //Vector3 p0 = new Vector3(-100, -100, -100);
            //Vector3 p1 = new Vector3(100, 100, 100);
            //WorldForEachBodyInAABBDo(ref p0, ref p1, NewtonBodyIterator, IntPtr.Zero);

        }

        //static float[] points = new float[64 * 3]; //Vertexbuffer
        static unsafe void CollisionIterator(IntPtr userData, int vertexCount, float* faceArray, int faceId)
        {
            //Marshal.Copy(faceArray, points, 0, vertexCount * 3);

            Vector3 pA = Vector3.zero;
            Vector3 pB = Vector3.zero;
            for (int i = 0; i < vertexCount - 1; i++)
            {
                pA = new Vector3(faceArray[i * 3], faceArray[i * 3 + 1], faceArray[i * 3 + 2]);
                pB = new Vector3(faceArray[(i + 1) * 3], faceArray[(i + 1) * 3 + 1], faceArray[(i + 1) * 3 + 2]);
                Debug.DrawLine(pA, pB, Color.magenta, Time.deltaTime, false);
            }
            pA = new Vector3(faceArray[0], faceArray[1], faceArray[2]);
            Debug.DrawLine(pA, pB, Color.magenta, Time.deltaTime, false);
        }


        public void OnDestroy()
        {
            NewtonManager.Unregister(this);
        }

    }


}
