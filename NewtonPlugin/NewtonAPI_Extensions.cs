using System;
using System.Runtime.InteropServices;

namespace NewtonAPI
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct NewtonVehicleParameters
    {
		public float weightDistribution;
        public float downForceWeightFactor0;
        public float downForceweightFactor1;
        public float downForceWeightFactorSpeed;
        public float gravity;
    };

    public enum NewtonSuspensionType
    {
        Offroad = 0,
        Comfort = 1,
        Race= 2
    };

    public enum NewtonDifferentialType
    {
        RearWheelDrive = 0,
        FrontWheelDrive = 1,
        FourWheelDrive = 2
    };

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct NewtonTireParameters
    {
        public float width;
        public float radius;
        public float mass;
        public float maxSteeringAngle;
        public bool hasFender;
        public NewtonSuspensionType suspensionType;

        public float suspensionLength;
        public float springStrength;
        public float dampingRatio;

        public float lateralStiffness;
        public float longitudinalStiffness;

        public float aligningMomentTrail;
    };

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct NewtonEngineParameters
    {
		public float mass;
        public float ratio;
        public float topSpeedKPH;
        public float clutchFrictionTorque;

        public float peakTorque;
        public float rpmAtPeakTorque;
        public float peakHorsePower;
        public float rpmAtPeakHorsePower;
        public float redLineTorque;
        public float rpmAtReadLineTorque;
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
    };


    internal static unsafe partial class NewtonInvoke
    {
        // Helpers
        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetPositionAndRotation", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonBodyGetPositionAndRotation(IntPtr body, float* pos, float* rot);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateBodyTransformState", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateBodyTransformState(float* pos, float* rot);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyBodyTransformState", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonDestroyBodyTransformState(IntPtr bts);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSaveBodyStates", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonSaveBodyStates(IntPtr world);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUpdateBodyStates", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonUpdateBodyStates(IntPtr world);

        // Custom Joints
        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyCustomJoint", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonDestroyCustomJoint(IntPtr joint);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateBallAndSocket", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateBallAndSocket(float* matrix, IntPtr child, IntPtr parent);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateBallAndSocketWithFriction", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateBallAndSocketWithFriction(float* matrix, IntPtr child, IntPtr parent, float friction);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateHinge", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateHinge(float* matrix, IntPtr child, IntPtr parent);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateRollingFriction", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateRollingFriction(float* matrix, IntPtr child, float radius, float friction);


        // Vehicle

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateVehicleManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateVehicleManager(IntPtr world);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyVehicleManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonDestroyVehicleManager(IntPtr vehicleManager);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonCreateVehicle(IntPtr vehicleManager, IntPtr chassiCollider, float* matrix, float mass, float maxBrakeTorque, NewtonApplyForceAndTorque forceCallback);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleAddTire", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonVehicleAddTire(IntPtr vehicle, float* pos, void* tireParams);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetEngineParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetEngineParams(IntPtr vehicle, void* vehicleParams, void* engineParams,
            IntPtr leftFrontTire, IntPtr rightFrontTire, IntPtr leftRearTire, IntPtr rightRearTire, NewtonDifferentialType diffType);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSteeringAddTire", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSteeringAddTire(IntPtr vehicle, IntPtr tire);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleCalculateAckermannParameters", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleCalculateAckermannParameters(IntPtr vehicle, IntPtr leftFrontTire, IntPtr rightFrontTire, IntPtr leftRearTire, IntPtr rightRearTire);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleBrakesAddTire", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleBrakesAddTire(IntPtr vehicle, IntPtr tire);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleHandBrakesAddTire", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleHandBrakesAddTire(IntPtr vehicle, IntPtr tire);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleFinalize", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleFinalize(IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyVehicle", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonDestroyVehicle(IntPtr vehicleManager, IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleGetBody", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonVehicleGetBody(IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleTireGetBody", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr NewtonVehicleTireGetBody(IntPtr tire);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetCOM", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetCOM(IntPtr vehicle, float* com);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetThrottle", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetThrottle(IntPtr vehicle, float throttle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetSteering", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetSteering(IntPtr vehicle, float steering);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetBrakes", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetBrakes(IntPtr vehicle, float brakes);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetHandBrakes", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetHandBrakes(IntPtr vehicle, float brakes);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetClutch", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetClutch(IntPtr vehicle, float clutch);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetGear", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetGear(IntPtr vehicle, int gear);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleGetGear", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int NewtonVehicleGetGear(IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleGetSpeed", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float NewtonVehicleGetSpeed(IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleGetRPM", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe float NewtonVehicleGetRPM(IntPtr vehicle);

        [DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonVehicleSetDifferentialLock", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void NewtonVehicleSetDifferentialLock(IntPtr vehicle, bool mode);

    }
}
