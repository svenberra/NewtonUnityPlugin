using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NewtonPlugin
{

    internal static class NewtonAPI
    {

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public class TireParameters
        {
            public float width;
            public float radius;
            public float mass;
            public float suspensionLength;
            public float springStrength;
            public float dampingRatio;
            public float lateralStiffness;
            public float longitudinalStiffness;
            public float aligningMomentTrail;
        };

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public class EngineParameters
        {
            public float mass;
            public float ratio;
            public float topSpeed;
            public float peakTorque;
            public float rpmAtPeakTorque;
            public float peakHorsePower;
            public float rpmAtPeakHorsePower;
            public float redLineTorque;
            public float rpmAtRedLineTorque;
            public float idleTorque;
            public float rpmAtIdleTorque;
            public int gearsCount;
            public float gearRatioReverse;
            public float gearRatio1;
            public float gearRatio2;
            public float gearRatio3;
            public float gearRatio4;
            public float gearRatio5;
            public float gearRatio6;
            public float gearRatio7;
            public float gearRatio8;
            public float gearRatio9;
            public float gearRatio10;
            public float clutchFrictionTorque;
        };

        internal delegate void NewtonBodyIteratorDelegate(IntPtr body, IntPtr userData);
        internal delegate void NewtonCollisionIteratorDelegate(IntPtr userData, int vertexCount, IntPtr faceArray, int faceId);
        internal delegate void NewtonApplyForceAndTorqueDelegate(IntPtr body, float timestep, int threadIndex);
        internal delegate void NewtonSetTransformDelegate(IntPtr body, ref Matrix4x4 matrix, int threadIndex);

        // World
        [DllImportAttribute("Newton", EntryPoint = "NewtonCreate", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreate();

        [DllImportAttribute("Newton", EntryPoint = "NewtonDestroy", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroy(IntPtr newtonWorld);

        [DllImportAttribute("Newton", EntryPoint = "NewtonUpdate", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyAllBodies(IntPtr newtonWorld);

        [DllImportAttribute("Newton", EntryPoint = "NewtonUpdate", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonUpdate(IntPtr newtonWorld,float timestep);

        [DllImportAttribute("Newton", EntryPoint = "NewtonWorldGetFirstBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonWorldGetFirstBody(IntPtr newtonWorld);

        [DllImportAttribute("Newton", EntryPoint = "NewtonWorldGetNextBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonWorldGetNextBody(IntPtr newtonWorld, IntPtr body);

        [DllImportAttribute("Newton", EntryPoint = "NewtonWorldForEachBodyInAABBDo", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonWorldForEachBodyInAABBDo(IntPtr newtonWorld, ref Vector3 p0, ref Vector3 p1, NewtonBodyIteratorDelegate callback, IntPtr userData);

        [DllImportAttribute("Newton", EntryPoint = "NewtonSerializeToFile", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonSerializeToFile(IntPtr newtonWorld, String filename);

        // Collision
        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateNull", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateNull(IntPtr newtonWorld);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateBox", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateBox(IntPtr newtonWorld, float x, float y, float z, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateSphere", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateSphere(IntPtr newtonWorld, float radius, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateCone", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateCone(IntPtr newtonWorld, float radius, float height, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateCapsule", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateCapsule(IntPtr newtonWorld, float radius0, float radius1, float height, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateCylinder", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateCylinder(IntPtr newtonWorld, float radius0, float radius1, float height, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateChamferCylinder", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateChamferCylinder(IntPtr newtonWorld, float radius, float height, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateCompoundCollision", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateCompoundCollision(IntPtr newtonWorld, int ShapeID);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCompoundCollisionBeginAddRemove", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonCompoundCollisionBeginAddRemove(IntPtr compoundCollision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCompoundCollisionAddSubCollision", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCompoundCollisionAddSubCollision(IntPtr compoundCollision, IntPtr collision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCompoundCollisionEndAddRemove", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonCompoundCollisionEndAddRemove(IntPtr compoundCollision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateConvexHull", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateConvexHull(IntPtr newtonWorld, int vertexCount, Vector3[] vertices, int strideInBytes, float tolerance, int ShapeID, ref Matrix4x4 offsetmatrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateTreeCollision", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateTreeCollision(IntPtr newtonWorld, int ShapeID);

        [DllImportAttribute("Newton", EntryPoint = "NewtonTreeCollisionBeginBuild", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonTreeCollisionBeginBuild(IntPtr treeCollision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonTreeCollisionAddFace", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonTreeCollisionAddFace(IntPtr treeCollision, int vertexCount, Vector3[] vertices, int strideInBytes, int faceAttribute);

        [DllImportAttribute("Newton", EntryPoint = "NewtonTreeCollisionEndBuild", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonTreeCollisionEndBuild(IntPtr treeCollision, int optimize);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCollisionSetScale", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonCollisionSetScale(IntPtr collision, float x, float y, float z);

        [DllImportAttribute("Newton", EntryPoint = "NewtonDestroyCollision", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyCollision(IntPtr collision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCollisionForEachPolygonDo", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonCollisionForEachPolygonDo(IntPtr collision, ref Matrix4x4 matrix, NewtonCollisionIteratorDelegate callback, IntPtr userData);

        // Body
        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateDynamicBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateDynamicBody(IntPtr newtonWorld, IntPtr collision, ref Matrix4x4 matrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateKinematicBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateKinematicBody(IntPtr newtonWorld, IntPtr collision, ref Matrix4x4 matrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetUserData", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetUserData(IntPtr body, IntPtr userData);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetUserData", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonBodyGetUserData(IntPtr body);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetForceAndTorqueCallback", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetForceAndTorqueCallback(IntPtr body, NewtonApplyForceAndTorqueDelegate callback);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetTransformCallback", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetTransformCallback(IntPtr body, NewtonSetTransformDelegate callback);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetCollidable", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetCollidable(IntPtr body, int enable);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetVelocity", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetVelocity(IntPtr body, ref Vector3 velocity);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetVelocity", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyGetVelocity(IntPtr body, ref Vector3 velocity);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetOmega", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetOmega(IntPtr body, ref Vector3 omega);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetOmega", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyGetOmega(IntPtr body, ref Vector3 omega);
        
        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetCollision", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonBodyGetCollision(IntPtr body);

        [DllImportAttribute("Newton", EntryPoint = "NewtonDestroyBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyBody(IntPtr body);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetMassProperties", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetMassProperties(IntPtr body, float mass, IntPtr collision);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodySetMatrix", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodySetMatrix(IntPtr body, ref Matrix4x4 matrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetMatrix", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyGetMatrix(IntPtr body, ref Matrix4x4 matrix);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyGetMassMatrix", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyGetMassMatrix(IntPtr body, ref float mass, ref float Ixx, ref float Iyy, ref float Izz);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyAddForce", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyAddForce(IntPtr body, ref Vector3 force);

        [DllImportAttribute("Newton", EntryPoint = "NewtonBodyAddTorque", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonBodyAddTorque(IntPtr body, ref Vector3 torque);


        //Joint
        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonCreateBallAndSocket", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateBallAndSocket(ref Matrix4x4 matrix, IntPtr child, IntPtr parent);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonCreateBallAndSocketWithFriction", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateBallAndSocketWithFriction(ref Matrix4x4 matrix, IntPtr child, IntPtr parent, float friction);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonCreateHinge", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateHinge(ref Matrix4x4 matrix, IntPtr child, IntPtr parent);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonHingeEnableLimits", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonHingeEnableLimits(IntPtr hinge, bool state);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonHingeSetLimits", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonHingeSetLimits(IntPtr hinge, float minAngle, float maxAngle);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonHingeSetFriction", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonHingeSetFriction(IntPtr hinge, float friction);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonCreateRollingFriction", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateRollingFriction(IntPtr child, float radius, float coeff);

        [DllImportAttribute("NewtonWrapper", EntryPoint = "NewtonDestroyJoint", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyJoint(IntPtr joint);


        // Vehicle
        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateVehicleManager", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateVehicleManager(IntPtr newtonWorld);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateVehicleManager", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyVehicleManager(IntPtr vehicleManager);

        [DllImportAttribute("Newton", EntryPoint = "NewtonCreateVehicle", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonCreateVehicle(IntPtr chassi, ref Matrix4x4 matrix, float mass, float steeringMaxAngle, float maxBrakeTorque);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetCOM", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetCOM(IntPtr vehicle, ref Vector3 CenterOfMass);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleAddTire", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonVehicleAddTire(IntPtr vehicle, ref Vector3 position, TireParameters tireParams);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSteeringAddTire", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSteeringAddTire(IntPtr vehicle, IntPtr tire);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleBrakesAddTire", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleBrakesAddTire(IntPtr vehicle, IntPtr tire);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleHandBrakesAddTire", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleHandBrakesAddTire(IntPtr vehicle, IntPtr tire);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetEngineParams", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetEngineParams(IntPtr vehicle, EngineParameters engineParams, IntPtr leftFrontTire, IntPtr rightFrontTire, IntPtr leftRearTire, IntPtr rightRearTire, int diffType);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleFinalize", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleFinalize(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonDestroyVehicle", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonDestroyVehicle(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetThrottle", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetThrottle(IntPtr vehicle, float param);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetSteering", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetSteering(IntPtr vehicle, float param);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetBrakes", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetBrakes(IntPtr vehicle, float param);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetHandBrakes", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetHandBrakes(IntPtr vehicle, float param);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleSetGear", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NewtonVehicleSetGear(IntPtr vehicle, int gear);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleGetGear", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NewtonVehicleGetGear(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleGetSpeed", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern float NewtonVehicleGetSpeed(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleGetRPM", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern float NewtonVehicleGetRPM(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleGetBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonVehicleGetBody(IntPtr vehicle);

        [DllImportAttribute("Newton", EntryPoint = "NewtonVehicleTireGetBody", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewtonVehicleTireGetBody(IntPtr tire);

    }

}
