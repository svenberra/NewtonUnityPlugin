using System;
using System.Runtime.InteropServices;

namespace NewtonAPI
{

	internal unsafe delegate IntPtr NewtonAllocMemory(int sizeInBytes);
	internal unsafe delegate void NewtonFreeMemory(IntPtr ptr, int sizeInBytes);
	internal unsafe delegate void NewtonWorldDestructorCallback(IntPtr world);
	internal unsafe delegate void NewtonWorldListenerBodyDestroyCallback(IntPtr world, IntPtr listenerUserData, IntPtr body);
	internal unsafe delegate void NewtonWorldUpdateListenerCallback(IntPtr world, IntPtr listenerUserData, float timestep);
	internal unsafe delegate void NewtonWorldDestroyListenerCallback(IntPtr world, IntPtr listenerUserData);
	internal unsafe delegate uint NewtonGetTicksCountCallback();
	internal unsafe delegate void NewtonSerializeCallback(IntPtr serializeHandle, IntPtr buffer, int size);
	internal unsafe delegate void NewtonDeserializeCallback(IntPtr serializeHandle, IntPtr buffer, int size);
	internal unsafe delegate void NewtonOnBodySerializationCallback(IntPtr body, IntPtr userData, NewtonSerializeCallback function, IntPtr serializeHandle);
	internal unsafe delegate void NewtonOnBodyDeserializationCallback(IntPtr body, IntPtr userData, NewtonDeserializeCallback function, IntPtr serializeHandle);
	internal unsafe delegate void NewtonOnJointSerializationCallback(IntPtr joint, NewtonSerializeCallback function, IntPtr serializeHandle);
	internal unsafe delegate void NewtonOnJointDeserializationCallback(IntPtr body0, IntPtr body1, NewtonDeserializeCallback function, IntPtr serializeHandle);
	internal unsafe delegate void NewtonOnUserCollisionSerializationCallback(IntPtr userData, NewtonSerializeCallback function, IntPtr serializeHandle);
	internal unsafe delegate void NewtonUserMeshCollisionDestroyCallback(IntPtr userData);
	internal unsafe delegate float NewtonUserMeshCollisionRayHitCallback(IntPtr lineDescData);
	internal unsafe delegate void NewtonUserMeshCollisionGetCollisionInfo(IntPtr userData, IntPtr infoRecord);
	internal unsafe delegate int NewtonUserMeshCollisionAABBTest(IntPtr userData, float* boxP0, float* boxP1);
	internal unsafe delegate int NewtonUserMeshCollisionGetFacesInAABB(IntPtr userData, float* p0, float* p1, float** vertexArray, int* vertexCount, int* vertexStrideInBytes, int* indexList, int maxIndexCount, int* userDataList);
	internal unsafe delegate void NewtonUserMeshCollisionCollideCallback(IntPtr collideDescData, IntPtr continueCollisionHandle);
	internal unsafe delegate int NewtonTreeCollisionFaceCallback(IntPtr context, float* polygon, int strideInBytes, int* indexArray, int indexCount);
	internal unsafe delegate float NewtonCollisionTreeRayCastCallback(IntPtr body, IntPtr treeCollision, float intersection, float* normal, int faceId, IntPtr usedData);
	internal unsafe delegate float NewtonHeightFieldRayCastCallback(IntPtr body, IntPtr heightFieldCollision, float intersection, int row, int col, float* normal, int faceId, IntPtr usedData);
	internal unsafe delegate void NewtonCollisionCopyConstructionCallback(IntPtr newtonWorld, IntPtr collision, IntPtr sourceCollision);
	internal unsafe delegate void NewtonCollisionDestructorCallback(IntPtr newtonWorld, IntPtr collision);
	internal unsafe delegate void NewtonTreeCollisionCallback(IntPtr bodyWithTreeCollision, IntPtr body, int faceID, int vertexCount, float* vertex, int vertexStrideInBytes);
	internal unsafe delegate void NewtonBodyDestructor(IntPtr body);
	internal unsafe delegate void NewtonApplyForceAndTorque(IntPtr body, float timestep, int threadIndex);
	internal unsafe delegate void NewtonSetTransform(IntPtr body, float* matrix, int threadIndex);
	internal unsafe delegate int NewtonIslandUpdate(IntPtr newtonWorld, IntPtr islandHandle, int bodyCount);
	internal unsafe delegate void NewtonFractureCompoundCollisionOnEmitCompoundFractured(IntPtr fracturedBody);
	internal unsafe delegate void NewtonFractureCompoundCollisionOnEmitChunk(IntPtr chunkBody, IntPtr fracturexChunkMesh, IntPtr fracturedCompountCollision);
	internal unsafe delegate void NewtonFractureCompoundCollisionReconstructMainMeshCallBack(IntPtr body, IntPtr mainMesh, IntPtr fracturedCompountCollision);
	internal unsafe delegate uint NewtonWorldRayPrefilterCallback(IntPtr body, IntPtr collision, IntPtr userData);
	internal unsafe delegate float NewtonWorldRayFilterCallback(IntPtr body, IntPtr shapeHit, float* hitContact, float* hitNormal, long collisionID, IntPtr userData, float intersectParam);
	internal unsafe delegate void NewtonContactsProcess(IntPtr contact, float timestep, int threadIndex);
	internal unsafe delegate int NewtonOnAABBOverlap(IntPtr material, IntPtr body0, IntPtr body1, int threadIndex);
	internal unsafe delegate int NewtonOnCompoundSubCollisionAABBOverlap(IntPtr material, IntPtr body0, IntPtr collsionNode0, IntPtr body1, IntPtr collsionNode1, int threadIndex);
	internal unsafe delegate int NewtonOnContactGeneration(IntPtr material, IntPtr body0, IntPtr collision0, IntPtr body1, IntPtr collision1, IntPtr contactBuffer, int maxCount, int threadIndex);
	internal unsafe delegate int NewtonBodyIterator(IntPtr body, IntPtr userData);
	internal unsafe delegate void NewtonJointIterator(IntPtr joint, IntPtr userData);
	internal unsafe delegate void NewtonCollisionIterator(IntPtr userData, int vertexCount, float* faceArray, int faceId);
	internal unsafe delegate void NewtonBallCallback(IntPtr ball, float timestep);
	internal unsafe delegate uint NewtonHingeCallback(IntPtr hinge, IntPtr desc);
	internal unsafe delegate uint NewtonSliderCallback(IntPtr slider, IntPtr desc);
	internal unsafe delegate uint NewtonUniversalCallback(IntPtr universal, IntPtr desc);
	internal unsafe delegate uint NewtonCorkscrewCallback(IntPtr corkscrew, IntPtr desc);
	internal unsafe delegate void NewtonUserBilateralCallback(IntPtr userJoint, float timestep, int threadIndex);
	internal unsafe delegate void NewtonUserBilateralGetInfoCallback(IntPtr userJoint, IntPtr info);
	internal unsafe delegate void NewtonConstraintDestructor(IntPtr me);
	internal unsafe delegate void NewtonSkeletontDestructor(IntPtr me);
	internal unsafe delegate void NewtonJobTask(IntPtr world, IntPtr userData, int threadIndex);
	internal unsafe delegate bool NewtonReportProgress(float normalizedProgressPercent, IntPtr userData);

	internal static unsafe partial class NewtonInvoke
	{
		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetVersion", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldGetVersion();

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldFloatSize", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldFloatSize();

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetMemoryUsed", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetMemoryUsed();

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetMemorySystem", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetMemorySystem(NewtonAllocMemory malloc, NewtonFreeMemory free);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreate();

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroy", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDestroy(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyAllBodies", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDestroyAllBodies(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonAlloc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonAlloc(int sizeInBytes);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFree", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonFree(IntPtr ptr);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonEnumerateDevices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonEnumerateDevices(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetCurrentDevice", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetCurrentDevice(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetCurrentDevice", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetCurrentDevice(IntPtr newtonWorld, int deviceIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetDeviceString", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonGetDeviceString(IntPtr newtonWorld, int deviceIndex, sbyte* vendorString, int maxSize);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetContactMergeTolerance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonGetContactMergeTolerance(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetContactMergeTolerance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetContactMergeTolerance(IntPtr newtonWorld, float tolerance);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonInvalidateCache", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonInvalidateCache(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetSolverModel", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetSolverModel(IntPtr newtonWorld, int model);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetSolverConvergenceQuality", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetSolverConvergenceQuality(IntPtr newtonWorld, int lowOrHigh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetMultiThreadSolverOnSingleIsland", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetMultiThreadSolverOnSingleIsland(IntPtr newtonWorld, int mode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetMultiThreadSolverOnSingleIsland", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetMultiThreadSolverOnSingleIsland(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetBroadphaseAlgorithm", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetBroadphaseAlgorithm(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSelectBroadphaseAlgorithm", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSelectBroadphaseAlgorithm(IntPtr newtonWorld, int algorithmType);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUpdate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUpdate(IntPtr newtonWorld, float timestep);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUpdateAsync", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUpdateAsync(IntPtr newtonWorld, float timestep);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWaitForUpdateToFinish", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWaitForUpdateToFinish(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSerializeToFile", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSerializeToFile(IntPtr newtonWorld, string filename, NewtonOnBodySerializationCallback bodyCallback, IntPtr bodyUserData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeserializeFromFile", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeserializeFromFile(IntPtr newtonWorld, string filename, NewtonOnBodyDeserializationCallback bodyCallback, IntPtr bodyUserData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetJointSerializationCallbacks", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetJointSerializationCallbacks(IntPtr newtonWorld, NewtonOnJointSerializationCallback serializeJoint, NewtonOnJointDeserializationCallback deserializeJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetJointSerializationCallbacks", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonGetJointSerializationCallbacks(IntPtr newtonWorld, NewtonOnJointSerializationCallback serializeJoint, NewtonOnJointDeserializationCallback deserializeJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldCriticalSectionLock", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldCriticalSectionLock(IntPtr newtonWorld, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldCriticalSectionUnlock", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldCriticalSectionUnlock(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetThreadsCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetThreadsCount(IntPtr newtonWorld, int threads);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetThreadsCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetThreadsCount(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetMaxThreadsCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonGetMaxThreadsCount(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDispachThreadJob", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDispachThreadJob(IntPtr newtonWorld, NewtonJobTask task, IntPtr usedData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSyncThreadJobs", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSyncThreadJobs(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonAtomicAdd", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonAtomicAdd(int* ptr, int value);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonAtomicSwap", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonAtomicSwap(int* ptr, int value);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonYield", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonYield();

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetFrictionModel", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetFrictionModel(IntPtr newtonWorld, int model);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetMinimumFrameRate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetMinimumFrameRate(IntPtr newtonWorld, float frameRate);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetIslandUpdateEvent", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetIslandUpdateEvent(IntPtr newtonWorld, NewtonIslandUpdate islandUpdate);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldForEachJointDo", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldForEachJointDo(IntPtr newtonWorld, NewtonJointIterator callback, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldForEachBodyInAABBDo", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldForEachBodyInAABBDo(IntPtr newtonWorld, float* p0, float* p1, NewtonBodyIterator callback, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldSetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldSetUserData(IntPtr newtonWorld, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetUserData(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetListenerUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetListenerUserData(IntPtr newtonWorld, IntPtr listener);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldListenerGetBodyDestroyCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe NewtonWorldListenerBodyDestroyCallback NewtonWorldListenerGetBodyDestroyCallback(IntPtr newtonWorld, IntPtr listener);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldListenerSetBodyDestroyCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldListenerSetBodyDestroyCallback(IntPtr newtonWorld, IntPtr listener, NewtonWorldListenerBodyDestroyCallback bodyDestroyCallback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetPreListener", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetPreListener(IntPtr newtonWorld, string nameId);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldAddPreListener", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldAddPreListener(IntPtr newtonWorld, string nameId, IntPtr listenerUserData, NewtonWorldUpdateListenerCallback update, NewtonWorldDestroyListenerCallback destroy);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetPostListener", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetPostListener(IntPtr newtonWorld, string nameId);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldAddPostListener", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldAddPostListener(IntPtr newtonWorld, string nameId, IntPtr listenerUserData, NewtonWorldUpdateListenerCallback update, NewtonWorldDestroyListenerCallback destroy);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldSetDestructorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldSetDestructorCallback(IntPtr newtonWorld, NewtonWorldDestructorCallback destructor);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetDestructorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe NewtonWorldDestructorCallback NewtonWorldGetDestructorCallback(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldSetCollisionConstructorDestructorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldSetCollisionConstructorDestructorCallback(IntPtr newtonWorld, NewtonCollisionCopyConstructionCallback constructor, NewtonCollisionDestructorCallback destructor);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldRayCast", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonWorldRayCast(IntPtr newtonWorld, float* p0, float* p1, NewtonWorldRayFilterCallback filter, IntPtr userData, NewtonWorldRayPrefilterCallback prefilter, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldConvexCast", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldConvexCast(IntPtr newtonWorld, float* matrix, float* target, IntPtr shape, float* param, IntPtr userData, NewtonWorldRayPrefilterCallback prefilter, IntPtr info, int maxContactsCount, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldCollide", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldCollide(IntPtr newtonWorld, float* matrix, IntPtr shape, IntPtr userData, NewtonWorldRayPrefilterCallback prefilter, IntPtr info, int maxContactsCount, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetBodyCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldGetBodyCount(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetConstraintCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonWorldGetConstraintCount(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonIslandGetBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonIslandGetBody(IntPtr island, int bodyIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonIslandGetBodyAABB", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonIslandGetBodyAABB(IntPtr island, int bodyIndex, float* p0, float* p1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialCreateGroupID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMaterialCreateGroupID(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetDefaultGroupID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMaterialGetDefaultGroupID(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialDestroyAllGroupID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialDestroyAllGroupID(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMaterialGetUserData(IntPtr newtonWorld, int id0, int id1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetSurfaceThickness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetSurfaceThickness(IntPtr newtonWorld, int id0, int id1, float thickness);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetCallbackUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetCallbackUserData(IntPtr newtonWorld, int id0, int id1, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactGenerationCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactGenerationCallback(IntPtr newtonWorld, int id0, int id1, NewtonOnContactGeneration contactGeneration);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetCompoundCollisionCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetCompoundCollisionCallback(IntPtr newtonWorld, int id0, int id1, NewtonOnCompoundSubCollisionAABBOverlap compoundAabbOverlap);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetCollisionCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetCollisionCallback(IntPtr newtonWorld, int id0, int id1, NewtonOnAABBOverlap aabbOverlap, NewtonContactsProcess process);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetDefaultSoftness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetDefaultSoftness(IntPtr newtonWorld, int id0, int id1, float value);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetDefaultElasticity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetDefaultElasticity(IntPtr newtonWorld, int id0, int id1, float elasticCoef);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetDefaultCollidable", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetDefaultCollidable(IntPtr newtonWorld, int id0, int id1, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetDefaultFriction", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetDefaultFriction(IntPtr newtonWorld, int id0, int id1, float staticFriction, float kineticFriction);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetFirstMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetFirstMaterial(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetNextMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetNextMaterial(IntPtr newtonWorld, IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetFirstBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetFirstBody(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonWorldGetNextBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonWorldGetNextBody(IntPtr newtonWorld, IntPtr curBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetMaterialPairUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMaterialGetMaterialPairUserData(IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactFaceAttribute", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe uint NewtonMaterialGetContactFaceAttribute(IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetBodyCollidingShape", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMaterialGetBodyCollidingShape(IntPtr material, IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactNormalSpeed", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonMaterialGetContactNormalSpeed(IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialGetContactForce(IntPtr material, IntPtr body, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactPositionAndNormal", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialGetContactPositionAndNormal(IntPtr material, IntPtr body, float* posit, float* normal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactTangentDirections", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialGetContactTangentDirections(IntPtr material, IntPtr body, float* dir0, float* dir1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactTangentSpeed", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonMaterialGetContactTangentSpeed(IntPtr material, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactMaxNormalImpact", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonMaterialGetContactMaxNormalImpact(IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactMaxTangentImpact", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonMaterialGetContactMaxTangentImpact(IntPtr material, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialGetContactPenetration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonMaterialGetContactPenetration(IntPtr material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactSoftness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactSoftness(IntPtr material, float softness);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactElasticity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactElasticity(IntPtr material, float restitution);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactFrictionState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactFrictionState(IntPtr material, int state, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactFrictionCoef", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactFrictionCoef(IntPtr material, float staticFrictionCoef, float kineticFrictionCoef, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactNormalAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactNormalAcceleration(IntPtr material, float accel);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactNormalDirection", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactNormalDirection(IntPtr material, float* directionVector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactPosition", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactPosition(IntPtr material, float* position);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactTangentFriction", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactTangentFriction(IntPtr material, float friction, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialSetContactTangentAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialSetContactTangentAcceleration(IntPtr material, float accel, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMaterialContactRotateTangentDirections", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMaterialContactRotateTangentDirections(IntPtr material, float* directionVector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateNull", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateNull(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateSphere", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateSphere(IntPtr newtonWorld, float radius, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateBox", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateBox(IntPtr newtonWorld, float dx, float dy, float dz, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCone", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCone(IntPtr newtonWorld, float radius, float height, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCapsule", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCapsule(IntPtr newtonWorld, float radius0, float radius1, float height, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCylinder", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCylinder(IntPtr newtonWorld, float radio0, float radio1, float height, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateChamferCylinder", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateChamferCylinder(IntPtr newtonWorld, float radius, float height, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateConvexHull", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateConvexHull(IntPtr newtonWorld, int count, float* vertexCloud, int strideInBytes, float tolerance, int shapeID, float* offsetMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateConvexHullFromMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateConvexHullFromMesh(IntPtr newtonWorld, IntPtr mesh, float tolerance, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionGetMode(IntPtr convexCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetMode(IntPtr convexCollision, int mode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConvexHullGetFaceIndices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonConvexHullGetFaceIndices(IntPtr convexHullCollision, int face, int* faceIndices);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConvexHullGetVertexData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonConvexHullGetVertexData(IntPtr convexHullCollision, float** vertexData, int* strideInBytes);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConvexCollisionCalculateVolume", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonConvexCollisionCalculateVolume(IntPtr convexCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConvexCollisionCalculateInertialMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonConvexCollisionCalculateInertialMatrix(IntPtr convexCollision, float* inertia, float* origin);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConvexCollisionCalculateBuoyancyAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonConvexCollisionCalculateBuoyancyAcceleration(IntPtr convexCollision, float* matrix, float* shapeOrigin, float* gravityVector, float* fluidPlane, float fluidDensity, float fluidViscosity, float* accel, float* alpha);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionDataPointer", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionDataPointer(IntPtr convexCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCompoundCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCompoundCollision(IntPtr newtonWorld, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCompoundCollisionFromMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCompoundCollisionFromMesh(IntPtr newtonWorld, IntPtr mesh, float hullTolerance, int shapeID, int subShapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionBeginAddRemove", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCompoundCollisionBeginAddRemove(IntPtr compoundCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionAddSubCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCompoundCollisionAddSubCollision(IntPtr compoundCollision, IntPtr convexCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionRemoveSubCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCompoundCollisionRemoveSubCollision(IntPtr compoundCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionRemoveSubCollisionByIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCompoundCollisionRemoveSubCollisionByIndex(IntPtr compoundCollision, int nodeIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionSetSubCollisionMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCompoundCollisionSetSubCollisionMatrix(IntPtr compoundCollision, IntPtr collisionNode, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionEndAddRemove", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCompoundCollisionEndAddRemove(IntPtr compoundCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionGetFirstNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCompoundCollisionGetFirstNode(IntPtr compoundCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionGetNextNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCompoundCollisionGetNextNode(IntPtr compoundCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionGetNodeByIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCompoundCollisionGetNodeByIndex(IntPtr compoundCollision, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionGetNodeIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCompoundCollisionGetNodeIndex(IntPtr compoundCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCompoundCollisionGetCollisionFromNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCompoundCollisionGetCollisionFromNode(IntPtr compoundCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateFracturedCompoundCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateFracturedCompoundCollision(IntPtr newtonWorld, IntPtr solidMesh, int shapeID, int fracturePhysicsMaterialID, int pointcloudCount, float* vertexCloud, int strideInBytes, int materialID, float* textureMatrix, NewtonFractureCompoundCollisionReconstructMainMeshCallBack regenerateMainMeshCallback, NewtonFractureCompoundCollisionOnEmitCompoundFractured emitFracturedCompound, NewtonFractureCompoundCollisionOnEmitChunk emitFracfuredChunk);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundPlaneClip", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundPlaneClip(IntPtr fracturedCompound, float* plane);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundSetCallbacks", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonFracturedCompoundSetCallbacks(IntPtr fracturedCompound, NewtonFractureCompoundCollisionReconstructMainMeshCallBack regenerateMainMeshCallback, NewtonFractureCompoundCollisionOnEmitCompoundFractured emitFracturedCompound, NewtonFractureCompoundCollisionOnEmitChunk emitFracfuredChunk);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundIsNodeFreeToDetach", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundIsNodeFreeToDetach(IntPtr fracturedCompound, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundNeighborNodeList", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundNeighborNodeList(IntPtr fracturedCompound, IntPtr collisionNode, void** list, int maxCount);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundGetMainMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundGetMainMesh(IntPtr fracturedCompound);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundGetFirstSubMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundGetFirstSubMesh(IntPtr fracturedCompound);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundGetNextSubMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundGetNextSubMesh(IntPtr fracturedCompound, IntPtr subMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundCollisionGetVertexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundCollisionGetVertexCount(IntPtr fracturedCompound, IntPtr meshOwner);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundCollisionGetVertexPositions", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float* NewtonFracturedCompoundCollisionGetVertexPositions(IntPtr fracturedCompound, IntPtr meshOwner);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundCollisionGetVertexNormals", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float* NewtonFracturedCompoundCollisionGetVertexNormals(IntPtr fracturedCompound, IntPtr meshOwner);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundCollisionGetVertexUVs", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float* NewtonFracturedCompoundCollisionGetVertexUVs(IntPtr fracturedCompound, IntPtr meshOwner);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundMeshPartGetIndexStream", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundMeshPartGetIndexStream(IntPtr fracturedCompound, IntPtr meshOwner, IntPtr segment, int* index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundMeshPartGetFirstSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundMeshPartGetFirstSegment(IntPtr fractureCompoundMeshPart);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundMeshPartGetNextSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonFracturedCompoundMeshPartGetNextSegment(IntPtr fractureCompoundMeshSegment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundMeshPartGetMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundMeshPartGetMaterial(IntPtr fractureCompoundMeshSegment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonFracturedCompoundMeshPartGetIndexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonFracturedCompoundMeshPartGetIndexCount(IntPtr fractureCompoundMeshSegment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateSceneCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateSceneCollision(IntPtr newtonWorld, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionBeginAddRemove", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSceneCollisionBeginAddRemove(IntPtr sceneCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionAddSubCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSceneCollisionAddSubCollision(IntPtr sceneCollision, IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionRemoveSubCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSceneCollisionRemoveSubCollision(IntPtr compoundCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionRemoveSubCollisionByIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSceneCollisionRemoveSubCollisionByIndex(IntPtr sceneCollision, int nodeIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionSetSubCollisionMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSceneCollisionSetSubCollisionMatrix(IntPtr sceneCollision, IntPtr collisionNode, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionEndAddRemove", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSceneCollisionEndAddRemove(IntPtr sceneCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionGetFirstNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSceneCollisionGetFirstNode(IntPtr sceneCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionGetNextNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSceneCollisionGetNextNode(IntPtr sceneCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionGetNodeByIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSceneCollisionGetNodeByIndex(IntPtr sceneCollision, int index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionGetNodeIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonSceneCollisionGetNodeIndex(IntPtr sceneCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSceneCollisionGetCollisionFromNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSceneCollisionGetCollisionFromNode(IntPtr sceneCollision, IntPtr collisionNode);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateUserMeshCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateUserMeshCollision(IntPtr newtonWorld, float* minBox, float* maxBox, IntPtr userData, NewtonUserMeshCollisionCollideCallback collideCallback, NewtonUserMeshCollisionRayHitCallback rayHitCallback, NewtonUserMeshCollisionDestroyCallback destroyCallback, NewtonUserMeshCollisionGetCollisionInfo getInfoCallback, NewtonUserMeshCollisionAABBTest getLocalAABBCallback, NewtonUserMeshCollisionGetFacesInAABB facesInAABBCallback, NewtonOnUserCollisionSerializationCallback serializeCallback, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserMeshCollisionContinuousOverlapTest", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonUserMeshCollisionContinuousOverlapTest(IntPtr collideDescData, IntPtr continueCollisionHandle, float* minAabb, float* maxAabb);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateCollisionFromSerialization", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateCollisionFromSerialization(IntPtr newtonWorld, NewtonDeserializeCallback deserializeFunction, IntPtr serializeHandle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSerialize", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSerialize(IntPtr newtonWorld, IntPtr collision, NewtonSerializeCallback serializeFunction, IntPtr serializeHandle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetInfo", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionGetInfo(IntPtr collision, IntPtr collisionInfo);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateHeightFieldCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateHeightFieldCollision(IntPtr newtonWorld, int width, int height, int gridsDiagonals, int elevationdatType, IntPtr elevationMap, string attributeMap, float verticalScale, float horizontalScale, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHeightFieldSetUserRayCastCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonHeightFieldSetUserRayCastCallback(IntPtr heightfieldCollision, NewtonHeightFieldRayCastCallback rayHitCallback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHeightFieldSetHorizontalDisplacement", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonHeightFieldSetHorizontalDisplacement(IntPtr heightfieldCollision, ushort* horizontalMap, float scale);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateTreeCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateTreeCollision(IntPtr newtonWorld, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateTreeCollisionFromMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateTreeCollisionFromMesh(IntPtr newtonWorld, IntPtr mesh, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionSetUserRayCastCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionSetUserRayCastCallback(IntPtr treeCollision, NewtonCollisionTreeRayCastCallback rayHitCallback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionBeginBuild", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionBeginBuild(IntPtr treeCollision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionAddFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionAddFace(IntPtr treeCollision, int vertexCount, float* vertexPtr, int strideInBytes, int faceAttribute);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionEndBuild", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionEndBuild(IntPtr treeCollision, int optimize);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionGetFaceAttribute", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonTreeCollisionGetFaceAttribute(IntPtr treeCollision, int* faceIndexArray, int indexCount);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionSetFaceAttribute", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionSetFaceAttribute(IntPtr treeCollision, int* faceIndexArray, int indexCount, int attribute);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionForEachFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonTreeCollisionForEachFace(IntPtr treeCollision, NewtonTreeCollisionFaceCallback forEachFaceCallback, IntPtr context);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonTreeCollisionGetVertexListTriangleListInAABB", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonTreeCollisionGetVertexListTriangleListInAABB(IntPtr treeCollision, float* p0, float* p1, float** vertexArray, int* vertexCount, int* vertexStrideInBytes, int* indexList, int maxIndexCount, int* faceAttribute);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonStaticCollisionSetDebugCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonStaticCollisionSetDebugCallback(IntPtr staticCollision, NewtonTreeCollisionCallback userCallback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionCreateInstance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionCreateInstance(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetType", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionGetType(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionIsConvexShape", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionIsConvexShape(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionIsStaticShape", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionIsStaticShape(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetUserData(IntPtr collision, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionGetUserData(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetUserData1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetUserData1(IntPtr collision, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetUserData1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionGetUserData1(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetUserID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetUserID(IntPtr collision, uint id);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetUserID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe uint NewtonCollisionGetUserID(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetSubCollisionHandle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionGetSubCollisionHandle(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetParentInstance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionGetParentInstance(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetMatrix(IntPtr collision, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionGetMatrix(IntPtr collision, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSetScale", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSetScale(IntPtr collision, float scaleX, float scaleY, float scaleZ);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetScale", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionGetScale(IntPtr collision, float* scaleX, float* scaleY, float* scaleZ);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDestroyCollision(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionGetSkinThickness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCollisionGetSkinThickness(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionIntersectionTest", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionIntersectionTest(IntPtr newtonWorld, IntPtr collisionA, float* matrixA, IntPtr collisionB, float* matrixB, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionPointDistance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionPointDistance(IntPtr newtonWorld, float* point, IntPtr collision, float* matrix, float* contact, float* normal, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionClosestPoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionClosestPoint(IntPtr newtonWorld, IntPtr collisionA, float* matrixA, IntPtr collisionB, float* matrixB, float* contactA, float* contactB, float* normalAB, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionCollide", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionCollide(IntPtr newtonWorld, int maxSize, IntPtr collisionA, float* matrixA, IntPtr collisionB, float* matrixB, float* contacts, float* normals, float* penetration, long* attributeA, long* attributeB, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionCollideContinue", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionCollideContinue(IntPtr newtonWorld, int maxSize, float timestep, IntPtr collisionA, float* matrixA, float* velocA, float* omegaA, IntPtr collisionB, float* matrixB, float* velocB, float* omegaB, float* timeOfImpact, float* contacts, float* normals, float* penetration, long* attributeA, long* attributeB, int threadIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionSupportVertex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionSupportVertex(IntPtr collision, float* dir, float* vertex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionRayCast", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCollisionRayCast(IntPtr collision, float* p0, float* p1, float* normal, long* attribute);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionCalculateAABB", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionCalculateAABB(IntPtr collision, float* matrix, float* p0, float* p1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionForEachPolygonDo", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionForEachPolygonDo(IntPtr collision, float* matrix, NewtonCollisionIterator callback, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateCreate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCollisionAggregateCreate(IntPtr world);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateDestroy", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionAggregateDestroy(IntPtr aggregate);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateAddBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionAggregateAddBody(IntPtr aggregate, IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateRemoveBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionAggregateRemoveBody(IntPtr aggregate, IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateGetSelfCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonCollisionAggregateGetSelfCollision(IntPtr aggregate);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCollisionAggregateSetSelfCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCollisionAggregateSetSelfCollision(IntPtr aggregate, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSetEulerAngle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSetEulerAngle(float* eulersAngles, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonGetEulerAngle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonGetEulerAngle(float* matrix, float* eulersAngles0, float* eulersAngles1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCalculateSpringDamperAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCalculateSpringDamperAcceleration(float dt, float ks, float x, float kd, float s);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateDynamicBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateDynamicBody(IntPtr newtonWorld, IntPtr collision, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateKinematicBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateKinematicBody(IntPtr newtonWorld, IntPtr collision, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateDeformableBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateDeformableBody(IntPtr newtonWorld, IntPtr deformableMesh, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyBody", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDestroyBody(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetSimulationState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetSimulationState(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetSimulationState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetSimulationState(IntPtr bodyPtr, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetType", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetType(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetCollidable", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetCollidable(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetCollidable", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetCollidable(IntPtr body, int collidableState);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyAddForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyAddForce(IntPtr body, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyAddTorque", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyAddTorque(IntPtr body, float* torque);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyCalculateInverseDynamicsForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyCalculateInverseDynamicsForce(IntPtr body, float timestep, float* desiredVeloc, float* forceOut);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetCentreOfMass", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetCentreOfMass(IntPtr body, float* com);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMassMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMassMatrix(IntPtr body, float mass, float Ixx, float Iyy, float Izz);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetFullMassMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetFullMassMatrix(IntPtr body, float mass, float* inertiaMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMassProperties", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMassProperties(IntPtr body, float mass, IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMatrix(IntPtr body, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMatrixNoSleep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMatrixNoSleep(IntPtr body, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMatrixRecursive", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMatrixRecursive(IntPtr body, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMaterialGroupID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMaterialGroupID(IntPtr body, int id);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetContinuousCollisionMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetContinuousCollisionMode(IntPtr body, uint state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetJointRecursiveCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetJointRecursiveCollision(IntPtr body, uint state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetOmega", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetOmega(IntPtr body, float* omega);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetOmegaNoSleep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetOmegaNoSleep(IntPtr body, float* omega);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetVelocity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetVelocity(IntPtr body, float* velocity);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetVelocityNoSleep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetVelocityNoSleep(IntPtr body, float* velocity);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetForce(IntPtr body, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetTorque", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetTorque(IntPtr body, float* torque);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetLinearDamping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetLinearDamping(IntPtr body, float linearDamp);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetAngularDamping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetAngularDamping(IntPtr body, float* angularDamp);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetCollision(IntPtr body, IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetCollisionScale", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetCollisionScale(IntPtr body, float scaleX, float scaleY, float scaleZ);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetMaxRotationPerStep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonBodyGetMaxRotationPerStep(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetMaxRotationPerStep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetMaxRotationPerStep(IntPtr body, float angleInRadians);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetSleepState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetSleepState(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetSleepState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetSleepState(IntPtr body, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetAutoSleep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetAutoSleep(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetAutoSleep", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetAutoSleep(IntPtr body, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetFreezeState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetFreezeState(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetFreezeState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetFreezeState(IntPtr body, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetDestructorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetDestructorCallback(IntPtr body, NewtonBodyDestructor callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetDestructorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe NewtonBodyDestructor NewtonBodyGetDestructorCallback(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetTransformCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetTransformCallback(IntPtr body, NewtonSetTransform callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetTransformCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe NewtonSetTransform NewtonBodyGetTransformCallback(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetForceAndTorqueCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetForceAndTorqueCallback(IntPtr body, NewtonApplyForceAndTorque callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetForceAndTorqueCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe NewtonApplyForceAndTorque NewtonBodyGetForceAndTorqueCallback(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetID(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodySetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodySetUserData(IntPtr body, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetUserData(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetWorld", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetWorld(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetCollision(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetMaterialGroupID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetMaterialGroupID(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetContinuousCollisionMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetContinuousCollisionMode(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetJointRecursiveCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonBodyGetJointRecursiveCollision(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetPosition", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetPosition(IntPtr body, float* pos);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetMatrix(IntPtr body, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetRotation", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetRotation(IntPtr body, float* rotation);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetMassMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetMassMatrix(IntPtr body, float* mass, float* Ixx, float* Iyy, float* Izz);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetInvMass", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetInvMass(IntPtr body, float* invMass, float* invIxx, float* invIyy, float* invIzz);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetInertiaMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetInertiaMatrix(IntPtr body, float* inertiaMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetInvInertiaMatrix", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetInvInertiaMatrix(IntPtr body, float* invInertiaMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetOmega", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetOmega(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetVelocity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetVelocity(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetForce(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetTorque", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetTorque(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetForceAcc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetForceAcc(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetTorqueAcc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetTorqueAcc(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetCentreOfMass", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetCentreOfMass(IntPtr body, float* com);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetPointVelocity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetPointVelocity(IntPtr body, float* point, float* velocOut);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyAddImpulse", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyAddImpulse(IntPtr body, float* pointDeltaVeloc, float* pointPosit);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyApplyImpulseArray", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyApplyImpulseArray(IntPtr body, int impuleCount, int strideInByte, float* impulseArray, float* pointArray);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyApplyImpulsePair", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyApplyImpulsePair(IntPtr body, float* linearImpulse, float* angularImpulse);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyIntegrateVelocity", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyIntegrateVelocity(IntPtr body, float timestep);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetLinearDamping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonBodyGetLinearDamping(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetAngularDamping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetAngularDamping(IntPtr body, float* vector);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetAABB", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBodyGetAABB(IntPtr body, float* p0, float* p1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetFirstJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetFirstJoint(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetNextJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetNextJoint(IntPtr body, IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetFirstContactJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetFirstContactJoint(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetNextContactJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetNextContactJoint(IntPtr body, IntPtr contactJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBodyGetSkeleton", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonBodyGetSkeleton(IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactJointGetFirstContact", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactJointGetFirstContact(IntPtr contactJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactJointGetNextContact", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactJointGetNextContact(IntPtr contactJoint, IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactJointGetContactCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonContactJointGetContactCount(IntPtr contactJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactJointRemoveContact", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonContactJointRemoveContact(IntPtr contactJoint, IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactJointGetClosestDistance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonContactJointGetClosestDistance(IntPtr contactJoint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactGetMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactGetMaterial(IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactGetCollision0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactGetCollision0(IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactGetCollision1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactGetCollision1(IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactGetCollisionID0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactGetCollisionID0(IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonContactGetCollisionID1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonContactGetCollisionID1(IntPtr contact);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonJointGetUserData(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointSetUserData", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonJointSetUserData(IntPtr joint, IntPtr userData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetBody0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonJointGetBody0(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetBody1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonJointGetBody1(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetInfo", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonJointGetInfo(IntPtr joint, IntPtr info);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetCollisionState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonJointGetCollisionState(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointSetCollisionState", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonJointSetCollisionState(IntPtr joint, int state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointGetStiffness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonJointGetStiffness(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointSetStiffness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonJointSetStiffness(IntPtr joint, float state);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDestroyJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDestroyJoint(IntPtr newtonWorld, IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointSetDestructor", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonJointSetDestructor(IntPtr joint, NewtonConstraintDestructor destructor);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonJointIsActive", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonJointIsActive(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateClothPatch", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateClothPatch(IntPtr newtonWorld, IntPtr mesh, int shapeID, IntPtr structuralMaterial, IntPtr bendMaterial);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCreateDeformableMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonCreateDeformableMesh(IntPtr newtonWorld, IntPtr mesh, int shapeID);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshCreateClusters", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshCreateClusters(IntPtr deformableMesh, int clusterCount, float overlapingWidth);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshSetDebugCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshSetDebugCallback(IntPtr deformableMesh, NewtonCollisionIterator callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetParticleCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonDeformableMeshGetParticleCount(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetParticlePosition", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshGetParticlePosition(IntPtr deformableMesh, int particleIndex, float* posit);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshBeginConfiguration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshBeginConfiguration(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshUnconstraintParticle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshUnconstraintParticle(IntPtr deformableMesh, int particleIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshConstraintParticle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshConstraintParticle(IntPtr deformableMesh, int particleIndex, float* posit, IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshEndConfiguration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshEndConfiguration(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshSetSkinThickness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshSetSkinThickness(IntPtr deformableMesh, float skinThickness);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshUpdateRenderNormals", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshUpdateRenderNormals(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetVertexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonDeformableMeshGetVertexCount(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetVertexStreams", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonDeformableMeshGetVertexStreams(IntPtr deformableMesh, int vertexStrideInByte, float* vertex, int normalStrideInByte, float* normal, int uvStrideInByte0, float* uv0);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetFirstSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonDeformableMeshGetFirstSegment(IntPtr deformableMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshGetNextSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonDeformableMeshGetNextSegment(IntPtr deformableMesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshSegmentGetMaterialID", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonDeformableMeshSegmentGetMaterialID(IntPtr deformableMesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshSegmentGetIndexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonDeformableMeshSegmentGetIndexCount(IntPtr deformableMesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonDeformableMeshSegmentGetIndexList", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int* NewtonDeformableMeshSegmentGetIndexList(IntPtr deformableMesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateBall", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateBall(IntPtr newtonWorld, float* pivotPoint, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBallSetUserCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBallSetUserCallback(IntPtr ball, NewtonBallCallback callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBallGetJointAngle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBallGetJointAngle(IntPtr ball, float* angle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBallGetJointOmega", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBallGetJointOmega(IntPtr ball, float* omega);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBallGetJointForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBallGetJointForce(IntPtr ball, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonBallSetConeLimits", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonBallSetConeLimits(IntPtr ball, float* pin, float maxConeAngle, float maxTwistAngle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateHinge", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateHinge(IntPtr newtonWorld, float* pivotPoint, float* pinDir, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHingeSetUserCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonHingeSetUserCallback(IntPtr hinge, NewtonHingeCallback callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHingeGetJointAngle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonHingeGetJointAngle(IntPtr hinge);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHingeGetJointOmega", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonHingeGetJointOmega(IntPtr hinge);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHingeGetJointForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonHingeGetJointForce(IntPtr hinge, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonHingeCalculateStopAlpha", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonHingeCalculateStopAlpha(IntPtr hinge, IntPtr desc, float angle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateSlider", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateSlider(IntPtr newtonWorld, float* pivotPoint, float* pinDir, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSliderSetUserCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSliderSetUserCallback(IntPtr slider, NewtonSliderCallback callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSliderGetJointPosit", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonSliderGetJointPosit(IntPtr slider);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSliderGetJointVeloc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonSliderGetJointVeloc(IntPtr slider);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSliderGetJointForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSliderGetJointForce(IntPtr slider, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSliderCalculateStopAccel", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonSliderCalculateStopAccel(IntPtr slider, IntPtr desc, float position);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateCorkscrew", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateCorkscrew(IntPtr newtonWorld, float* pivotPoint, float* pinDir, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewSetUserCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCorkscrewSetUserCallback(IntPtr corkscrew, NewtonCorkscrewCallback callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewGetJointPosit", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewGetJointPosit(IntPtr corkscrew);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewGetJointAngle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewGetJointAngle(IntPtr corkscrew);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewGetJointVeloc", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewGetJointVeloc(IntPtr corkscrew);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewGetJointOmega", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewGetJointOmega(IntPtr corkscrew);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewGetJointForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonCorkscrewGetJointForce(IntPtr corkscrew, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewCalculateStopAlpha", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewCalculateStopAlpha(IntPtr corkscrew, IntPtr desc, float angle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonCorkscrewCalculateStopAccel", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonCorkscrewCalculateStopAccel(IntPtr corkscrew, IntPtr desc, float position);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateUniversal", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateUniversal(IntPtr newtonWorld, float* pivotPoint, float* pinDir0, float* pinDir1, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalSetUserCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUniversalSetUserCallback(IntPtr universal, NewtonUniversalCallback callback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalGetJointAngle0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalGetJointAngle0(IntPtr universal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalGetJointAngle1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalGetJointAngle1(IntPtr universal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalGetJointOmega0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalGetJointOmega0(IntPtr universal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalGetJointOmega1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalGetJointOmega1(IntPtr universal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalGetJointForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUniversalGetJointForce(IntPtr universal, float* force);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalCalculateStopAlpha0", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalCalculateStopAlpha0(IntPtr universal, IntPtr desc, float angle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUniversalCalculateStopAlpha1", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUniversalCalculateStopAlpha1(IntPtr universal, IntPtr desc, float angle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateUpVector", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateUpVector(IntPtr newtonWorld, float* pinDir, IntPtr body);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUpVectorGetPin", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUpVectorGetPin(IntPtr upVector, float* pin);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUpVectorSetPin", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUpVectorSetPin(IntPtr upVector, float* pin);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonConstraintCreateUserJoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonConstraintCreateUserJoint(IntPtr newtonWorld, int maxDOF, NewtonUserBilateralCallback callback, NewtonUserBilateralGetInfoCallback getInfo, IntPtr childBody, IntPtr parentBody);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetFeedbackCollectorCallback", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetFeedbackCollectorCallback(IntPtr joint, NewtonUserBilateralCallback getFeedback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointAddLinearRow", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointAddLinearRow(IntPtr joint, float* pivot0, float* pivot1, float* dir);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointAddAngularRow", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointAddAngularRow(IntPtr joint, float relativeAngle, float* dir);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointAddGeneralRow", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointAddGeneralRow(IntPtr joint, float* jacobian0, float* jacobian1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetRowMinimumFriction", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetRowMinimumFriction(IntPtr joint, float friction);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetRowMaximumFriction", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetRowMaximumFriction(IntPtr joint, float friction);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserCalculateRowZeroAccelaration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUserCalculateRowZeroAccelaration(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetRowAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetRowAcceleration(IntPtr joint, float acceleration);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetRowSpringDamperAcceleration", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetRowSpringDamperAcceleration(IntPtr joint, float spring, float damper);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointSetRowStiffness", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointSetRowStiffness(IntPtr joint, float stiffness);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJoinRowsCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonUserJoinRowsCount(IntPtr joint);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointGetGeneralRow", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonUserJointGetGeneralRow(IntPtr joint, int index, float* jacobian0, float* jacobian1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonUserJointGetRowForce", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe float NewtonUserJointGetRowForce(IntPtr joint, int row);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerCreate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerCreate(IntPtr world, IntPtr rootBone, NewtonSkeletontDestructor onDestroyCallback);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerDelete", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSkeletonContainerDelete(IntPtr skeleton);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonGetSolverMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonSkeletonGetSolverMode(IntPtr skeleton);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonSetSolverMode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSkeletonSetSolverMode(IntPtr skeleton, int hardJointMotors);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerAttachJointArray", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSkeletonContainerAttachJointArray(IntPtr skeleton, int jointCount, IntPtr jointArray);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerAttachBone", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerAttachBone(IntPtr skeleton, IntPtr childBone, IntPtr parentBone);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerFinalize", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonSkeletonContainerFinalize(IntPtr skeleton);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerGetRoot", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerGetRoot(IntPtr skeleton);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerGetParent", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerGetParent(IntPtr skeleton, IntPtr node);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerFirstChild", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerFirstChild(IntPtr skeleton, IntPtr parent);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerNextSibling", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerNextSibling(IntPtr skeleton, IntPtr sibling);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerGetBodyFromNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerGetBodyFromNode(IntPtr skeleton, IntPtr node);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonSkeletonContainerGetParentJointFromNode", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonSkeletonContainerGetParentJointFromNode(IntPtr skeleton, IntPtr node);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreate(IntPtr newtonWorld);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateFromMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateFromMesh(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateFromCollision", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateFromCollision(IntPtr collision);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateConvexHull", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateConvexHull(IntPtr newtonWorld, int pointCount, float* vertexCloud, int strideInBytes, float tolerance);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateDelaunayTetrahedralization", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateDelaunayTetrahedralization(IntPtr newtonWorld, int pointCount, float* vertexCloud, int strideInBytes, int materialID, float* textureMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateVoronoiConvexDecomposition", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateVoronoiConvexDecomposition(IntPtr newtonWorld, int pointCount, float* vertexCloud, int strideInBytes, int materialID, float* textureMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateFromSerialization", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateFromSerialization(IntPtr newtonWorld, NewtonDeserializeCallback deserializeFunction, IntPtr serializeHandle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshDestroy", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshDestroy(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshSerialize", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshSerialize(IntPtr mesh, NewtonSerializeCallback serializeFunction, IntPtr serializeHandle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshSaveOFF", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshSaveOFF(IntPtr mesh, string filename);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshLoadOFF", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshLoadOFF(IntPtr newtonWorld, string filename);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApplyTransform", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshApplyTransform(IntPtr mesh, float* matrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCalculateOOBB", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshCalculateOOBB(IntPtr mesh, float* matrix, float* x, float* y, float* z);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCalculateVertexNormals", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshCalculateVertexNormals(IntPtr mesh, float angleInRadians);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApplySphericalMapping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshApplySphericalMapping(IntPtr mesh, int material);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApplyCylindricalMapping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshApplyCylindricalMapping(IntPtr mesh, int cylinderMaterial, int capMaterial);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApplyBoxMapping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshApplyBoxMapping(IntPtr mesh, int frontMaterial, int sideMaterial, int topMaterial);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApplyAngleBasedMapping", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshApplyAngleBasedMapping(IntPtr mesh, int material, NewtonReportProgress reportPrograssCallback, IntPtr reportPrgressUserData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshIsOpenMesh", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshIsOpenMesh(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshFixTJoints", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshFixTJoints(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshPolygonize", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshPolygonize(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshTriangulate", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshTriangulate(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshUnion", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshUnion(IntPtr mesh, IntPtr clipper, float* clipperMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshDifference", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshDifference(IntPtr mesh, IntPtr clipper, float* clipperMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshIntersection", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshIntersection(IntPtr mesh, IntPtr clipper, float* clipperMatrix);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshClip", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshClip(IntPtr mesh, IntPtr clipper, float* clipperMatrix, IntPtr topMesh, IntPtr bottomMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshConvexMeshIntersection", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshConvexMeshIntersection(IntPtr mesh, IntPtr convexMesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshSimplify", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshSimplify(IntPtr mesh, int maxVertexCount, NewtonReportProgress reportPrograssCallback, IntPtr reportPrgressUserData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshApproximateConvexDecomposition", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshApproximateConvexDecomposition(IntPtr mesh, float maxConcavity, float backFaceDistanceFactor, int maxCount, int maxVertexPerHull, NewtonReportProgress reportProgressCallback, IntPtr reportProgressUserData);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonRemoveUnusedVertices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonRemoveUnusedVertices(IntPtr mesh, int* vertexRemapTable);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshBeginFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshBeginFace(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshAddFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshAddFace(IntPtr mesh, int vertexCount, float* vertex, int strideInBytes, int materialIndex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshEndFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshEndFace(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshBuildFromVertexListIndexList", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshBuildFromVertexListIndexList(IntPtr mesh, int faceCount, int* faceIndexCount, int* faceMaterialIndex, float* vertex, int vertexStrideInBytes, int* vertexIndex, float* normal, int normalStrideInBytes, int* normalIndex, float* uv0, int uv0StrideInBytes, int* uv0Index, float* uv1, int uv1StrideInBytes, int* uv1Index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexStreams", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetVertexStreams(IntPtr mesh, int vertexStrideInByte, float* vertex, int normalStrideInByte, float* normal, int uvStrideInByte0, float* uv0, int uvStrideInByte1, float* uv1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetIndirectVertexStreams", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetIndirectVertexStreams(IntPtr mesh, int vertexStrideInByte, float* vertex, int* vertexIndices, int* vertexCount, int normalStrideInByte, float* normal, int* normalIndices, int* normalCount, int uvStrideInByte0, float* uv0, int* uvIndices0, int* uvCount0, int uvStrideInByte1, float* uv1, int* uvIndices1, int* uvCount1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshBeginHandle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshBeginHandle(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshEndHandle", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshEndHandle(IntPtr mesh, IntPtr handle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshFirstMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshFirstMaterial(IntPtr mesh, IntPtr handle);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshNextMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshNextMaterial(IntPtr mesh, IntPtr handle, int materialId);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshMaterialGetMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshMaterialGetMaterial(IntPtr mesh, IntPtr handle, int materialId);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshMaterialGetIndexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshMaterialGetIndexCount(IntPtr mesh, IntPtr handle, int materialId);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshMaterialGetIndexStream", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshMaterialGetIndexStream(IntPtr mesh, IntPtr handle, int materialId, int* index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshMaterialGetIndexStreamShort", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshMaterialGetIndexStreamShort(IntPtr mesh, IntPtr handle, int materialId, short* index);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateFirstSingleSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateFirstSingleSegment(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateNextSingleSegment", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateNextSingleSegment(IntPtr mesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateFirstLayer", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateFirstLayer(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCreateNextLayer", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshCreateNextLayer(IntPtr mesh, IntPtr segment);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetTotalFaceCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetTotalFaceCount(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetTotalIndexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetTotalIndexCount(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFaces", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetFaces(IntPtr mesh, int* faceIndexCount, int* faceMaterial, void** faceIndices);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetPointCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetPointCount(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetPointStrideInByte", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetPointStrideInByte(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetPointArray", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe double* NewtonMeshGetPointArray(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetNormalArray", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe double* NewtonMeshGetNormalArray(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetUV0Array", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe double* NewtonMeshGetUV0Array(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetUV1Array", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe double* NewtonMeshGetUV1Array(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetVertexCount(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexStrideInByte", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetVertexStrideInByte(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexArray", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe double* NewtonMeshGetVertexArray(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFirstVertex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetFirstVertex(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetNextVertex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetNextVertex(IntPtr mesh, IntPtr vertex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetVertexIndex(IntPtr mesh, IntPtr vertex);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFirstPoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetFirstPoint(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetNextPoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetNextPoint(IntPtr mesh, IntPtr point);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetPointIndex", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetPointIndex(IntPtr mesh, IntPtr point);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetVertexIndexFromPoint", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetVertexIndexFromPoint(IntPtr mesh, IntPtr point);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFirstEdge", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetFirstEdge(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetNextEdge", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetNextEdge(IntPtr mesh, IntPtr edge);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetEdgeIndices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetEdgeIndices(IntPtr mesh, IntPtr edge, int* v0, int* v1);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFirstFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetFirstFace(IntPtr mesh);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetNextFace", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe IntPtr NewtonMeshGetNextFace(IntPtr mesh, IntPtr face);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshIsFaceOpen", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshIsFaceOpen(IntPtr mesh, IntPtr face);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFaceMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetFaceMaterial(IntPtr mesh, IntPtr face);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFaceIndexCount", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe int NewtonMeshGetFaceIndexCount(IntPtr mesh, IntPtr face);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFaceIndices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetFaceIndices(IntPtr mesh, IntPtr face, int* indices);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshGetFacePointIndices", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshGetFacePointIndices(IntPtr mesh, IntPtr face, int* indices);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshCalculateFaceNormal", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshCalculateFaceNormal(IntPtr mesh, IntPtr face, double* normal);

		[DllImport("NewtonWrapper", EntryPoint = "WRAP_NewtonMeshSetFaceMaterial", CallingConvention = CallingConvention.Cdecl)]
		internal static extern unsafe void NewtonMeshSetFaceMaterial(IntPtr mesh, IntPtr face, int matId);

		}
	}
