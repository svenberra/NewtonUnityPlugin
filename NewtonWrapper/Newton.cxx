#include "Newton.h"
#include "NewtonWrapper.h"

extern "C"
{
	NEWTONWRAPPER_API int WRAP_NewtonWorldGetVersion ()
		{ return NewtonWorldGetVersion(); }
	NEWTONWRAPPER_API int WRAP_NewtonWorldFloatSize ()
		{ return NewtonWorldFloatSize(); }
	NEWTONWRAPPER_API int WRAP_NewtonGetMemoryUsed ()
		{ return NewtonGetMemoryUsed(); }
	NEWTONWRAPPER_API void WRAP_NewtonSetMemorySystem (NewtonAllocMemory malloc, NewtonFreeMemory free)
		{ NewtonSetMemorySystem(malloc, free); }
	NEWTONWRAPPER_API NewtonWorld* WRAP_NewtonCreate ()
		{ return NewtonCreate(); }
	NEWTONWRAPPER_API void WRAP_NewtonDestroy (const NewtonWorld* const newtonWorld)
		{ NewtonDestroy(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonDestroyAllBodies (const NewtonWorld* const newtonWorld)
		{ NewtonDestroyAllBodies(newtonWorld); }
	NEWTONWRAPPER_API void* WRAP_NewtonAlloc (int sizeInBytes)
		{ return NewtonAlloc(sizeInBytes); }
	NEWTONWRAPPER_API void WRAP_NewtonFree (void* const ptr)
		{ NewtonFree(ptr); }
	NEWTONWRAPPER_API int WRAP_NewtonEnumerateDevices (const NewtonWorld* const newtonWorld)
		{ return NewtonEnumerateDevices(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonGetCurrentDevice (const NewtonWorld* const newtonWorld)
		{ return NewtonGetCurrentDevice(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSetCurrentDevice (const NewtonWorld* const newtonWorld, int deviceIndex)
		{ NewtonSetCurrentDevice(newtonWorld, deviceIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonGetDeviceString (const NewtonWorld* const newtonWorld, int deviceIndex, char* const vendorString, int maxSize)
		{ NewtonGetDeviceString(newtonWorld, deviceIndex, vendorString, maxSize); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonGetContactMergeTolerance (const NewtonWorld* const newtonWorld)
		{ return NewtonGetContactMergeTolerance(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSetContactMergeTolerance (const NewtonWorld* const newtonWorld, dFloat tolerance)
		{ NewtonSetContactMergeTolerance(newtonWorld, tolerance); }
	NEWTONWRAPPER_API void WRAP_NewtonInvalidateCache (const NewtonWorld* const newtonWorld)
		{ NewtonInvalidateCache(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSetSolverModel (const NewtonWorld* const newtonWorld, int model)
		{ NewtonSetSolverModel(newtonWorld, model); }
	NEWTONWRAPPER_API void WRAP_NewtonSetSolverConvergenceQuality (const NewtonWorld* const newtonWorld, int lowOrHigh)
		{ NewtonSetSolverConvergenceQuality(newtonWorld, lowOrHigh); }
	NEWTONWRAPPER_API void WRAP_NewtonSetMultiThreadSolverOnSingleIsland (const NewtonWorld* const newtonWorld, int mode)
		{ NewtonSetMultiThreadSolverOnSingleIsland(newtonWorld, mode); }
	NEWTONWRAPPER_API int WRAP_NewtonGetMultiThreadSolverOnSingleIsland (const NewtonWorld* const newtonWorld)
		{ return NewtonGetMultiThreadSolverOnSingleIsland(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonGetBroadphaseAlgorithm (const NewtonWorld* const newtonWorld)
		{ return NewtonGetBroadphaseAlgorithm(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSelectBroadphaseAlgorithm (const NewtonWorld* const newtonWorld, int algorithmType)
		{ NewtonSelectBroadphaseAlgorithm(newtonWorld, algorithmType); }
	NEWTONWRAPPER_API void WRAP_NewtonUpdate (const NewtonWorld* const newtonWorld, dFloat timestep)
		{ NewtonUpdate(newtonWorld, timestep); }
	NEWTONWRAPPER_API void WRAP_NewtonUpdateAsync (const NewtonWorld* const newtonWorld, dFloat timestep)
		{ NewtonUpdateAsync(newtonWorld, timestep); }
	NEWTONWRAPPER_API void WRAP_NewtonWaitForUpdateToFinish (const NewtonWorld* const newtonWorld)
		{ NewtonWaitForUpdateToFinish(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSerializeToFile (const NewtonWorld* const newtonWorld, const char* const filename, NewtonOnBodySerializationCallback bodyCallback, void* const bodyUserData)
		{ NewtonSerializeToFile(newtonWorld, filename, bodyCallback, bodyUserData); }
	NEWTONWRAPPER_API void WRAP_NewtonDeserializeFromFile (const NewtonWorld* const newtonWorld, const char* const filename, NewtonOnBodyDeserializationCallback bodyCallback, void* const bodyUserData)
		{ NewtonDeserializeFromFile(newtonWorld, filename, bodyCallback, bodyUserData); }
	NEWTONWRAPPER_API void WRAP_NewtonSetJointSerializationCallbacks (const NewtonWorld* const newtonWorld, NewtonOnJointSerializationCallback serializeJoint, NewtonOnJointDeserializationCallback deserializeJoint)
		{ NewtonSetJointSerializationCallbacks(newtonWorld, serializeJoint, deserializeJoint); }
	NEWTONWRAPPER_API void WRAP_NewtonGetJointSerializationCallbacks (const NewtonWorld* const newtonWorld, NewtonOnJointSerializationCallback* const serializeJoint, NewtonOnJointDeserializationCallback* const deserializeJoint)
		{ NewtonGetJointSerializationCallbacks(newtonWorld, serializeJoint, deserializeJoint); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldCriticalSectionLock (const NewtonWorld* const newtonWorld, int threadIndex)
		{ NewtonWorldCriticalSectionLock(newtonWorld, threadIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldCriticalSectionUnlock (const NewtonWorld* const newtonWorld)
		{ NewtonWorldCriticalSectionUnlock(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonSetThreadsCount (const NewtonWorld* const newtonWorld, int threads)
		{ NewtonSetThreadsCount(newtonWorld, threads); }
	NEWTONWRAPPER_API int WRAP_NewtonGetThreadsCount(const NewtonWorld* const newtonWorld)
		{ return NewtonGetThreadsCount(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonGetMaxThreadsCount(const NewtonWorld* const newtonWorld)
		{ return NewtonGetMaxThreadsCount(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonDispachThreadJob(const NewtonWorld* const newtonWorld, NewtonJobTask task, void* const usedData)
		{ NewtonDispachThreadJob(newtonWorld, task, usedData); }
	NEWTONWRAPPER_API void WRAP_NewtonSyncThreadJobs(const NewtonWorld* const newtonWorld)
		{ NewtonSyncThreadJobs(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonAtomicAdd (int* const ptr, int value)
		{ return NewtonAtomicAdd(ptr, value); }
	NEWTONWRAPPER_API int WRAP_NewtonAtomicSwap (int* const ptr, int value)
		{ return NewtonAtomicSwap(ptr, value); }
	NEWTONWRAPPER_API void WRAP_NewtonYield ()
		{ NewtonYield(); }
	NEWTONWRAPPER_API void WRAP_NewtonSetFrictionModel (const NewtonWorld* const newtonWorld, int model)
		{ NewtonSetFrictionModel(newtonWorld, model); }
	NEWTONWRAPPER_API void WRAP_NewtonSetMinimumFrameRate (const NewtonWorld* const newtonWorld, dFloat frameRate)
		{ NewtonSetMinimumFrameRate(newtonWorld, frameRate); }
	NEWTONWRAPPER_API void WRAP_NewtonSetIslandUpdateEvent (const NewtonWorld* const newtonWorld, NewtonIslandUpdate islandUpdate)
		{ NewtonSetIslandUpdateEvent(newtonWorld, islandUpdate); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldForEachJointDo (const NewtonWorld* const newtonWorld, NewtonJointIterator callback, void* const userData)
		{ NewtonWorldForEachJointDo(newtonWorld, callback, userData); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldForEachBodyInAABBDo (const NewtonWorld* const newtonWorld, const dFloat* const p0, const dFloat* const p1, NewtonBodyIterator callback, void* const userData)
		{ NewtonWorldForEachBodyInAABBDo(newtonWorld, p0, p1, callback, userData); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldSetUserData (const NewtonWorld* const newtonWorld, void* const userData)
		{ NewtonWorldSetUserData(newtonWorld, userData); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldGetUserData (const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetUserData(newtonWorld); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldGetListenerUserData (const NewtonWorld* const newtonWorld, void* const listener)
		{ return NewtonWorldGetListenerUserData(newtonWorld, listener); }
	NEWTONWRAPPER_API NewtonWorldListenerBodyDestroyCallback WRAP_NewtonWorldListenerGetBodyDestroyCallback (const NewtonWorld* const newtonWorld, void* const listener)
		{ return NewtonWorldListenerGetBodyDestroyCallback(newtonWorld, listener); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldListenerSetBodyDestroyCallback (const NewtonWorld* const newtonWorld, void* const listener, NewtonWorldListenerBodyDestroyCallback bodyDestroyCallback)
		{ NewtonWorldListenerSetBodyDestroyCallback(newtonWorld, listener, bodyDestroyCallback); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldGetPreListener (const NewtonWorld* const newtonWorld, const char* const nameId)
		{ return NewtonWorldGetPreListener(newtonWorld, nameId); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldAddPreListener (const NewtonWorld* const newtonWorld, const char* const nameId, void* const listenerUserData, NewtonWorldUpdateListenerCallback update, NewtonWorldDestroyListenerCallback destroy)
		{ return NewtonWorldAddPreListener(newtonWorld, nameId, listenerUserData, update, destroy); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldGetPostListener (const NewtonWorld* const newtonWorld, const char* const nameId)
		{ return NewtonWorldGetPostListener(newtonWorld, nameId); }
	NEWTONWRAPPER_API void* WRAP_NewtonWorldAddPostListener (const NewtonWorld* const newtonWorld, const char* const nameId, void* const listenerUserData, NewtonWorldUpdateListenerCallback update, NewtonWorldDestroyListenerCallback destroy)
		{ return NewtonWorldAddPostListener(newtonWorld, nameId, listenerUserData, update, destroy); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldSetDestructorCallback (const NewtonWorld* const newtonWorld, NewtonWorldDestructorCallback destructor)
		{ NewtonWorldSetDestructorCallback(newtonWorld, destructor); }
	NEWTONWRAPPER_API NewtonWorldDestructorCallback WRAP_NewtonWorldGetDestructorCallback (const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetDestructorCallback(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldSetCollisionConstructorDestructorCallback (const NewtonWorld* const newtonWorld, NewtonCollisionCopyConstructionCallback constructor, NewtonCollisionDestructorCallback destructor)
		{ NewtonWorldSetCollisionConstructorDestructorCallback(newtonWorld, constructor, destructor); }
	NEWTONWRAPPER_API void WRAP_NewtonWorldRayCast (const NewtonWorld* const newtonWorld, const dFloat* const p0, const dFloat* const p1, NewtonWorldRayFilterCallback filter, void* const userData, NewtonWorldRayPrefilterCallback prefilter, int threadIndex)
		{ NewtonWorldRayCast(newtonWorld, p0, p1, filter, userData, prefilter, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonWorldConvexCast (const NewtonWorld* const newtonWorld, const dFloat* const matrix, const dFloat* const target, const NewtonCollision* const shape, dFloat* const param, void* const userData, NewtonWorldRayPrefilterCallback prefilter, NewtonWorldConvexCastReturnInfo* const info, int maxContactsCount, int threadIndex)
		{ return NewtonWorldConvexCast(newtonWorld, matrix, target, shape, param, userData, prefilter, info, maxContactsCount, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonWorldCollide (const NewtonWorld* const newtonWorld, const dFloat* const matrix, const NewtonCollision* const shape, void* const userData, NewtonWorldRayPrefilterCallback prefilter, NewtonWorldConvexCastReturnInfo* const info, int maxContactsCount, int threadIndex)
		{ return NewtonWorldCollide(newtonWorld, matrix, shape, userData, prefilter, info, maxContactsCount, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonWorldGetBodyCount(const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetBodyCount(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonWorldGetConstraintCount(const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetConstraintCount(newtonWorld); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonIslandGetBody (const void* const island, int bodyIndex)
		{ return NewtonIslandGetBody(island, bodyIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonIslandGetBodyAABB (const void* const island, int bodyIndex, dFloat* const p0, dFloat* const p1)
		{ NewtonIslandGetBodyAABB(island, bodyIndex, p0, p1); }
	NEWTONWRAPPER_API int WRAP_NewtonMaterialCreateGroupID(const NewtonWorld* const newtonWorld)
		{ return NewtonMaterialCreateGroupID(newtonWorld); }
	NEWTONWRAPPER_API int WRAP_NewtonMaterialGetDefaultGroupID(const NewtonWorld* const newtonWorld)
		{ return NewtonMaterialGetDefaultGroupID(newtonWorld); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialDestroyAllGroupID(const NewtonWorld* const newtonWorld)
		{ NewtonMaterialDestroyAllGroupID(newtonWorld); }
	NEWTONWRAPPER_API void* WRAP_NewtonMaterialGetUserData (const NewtonWorld* const newtonWorld, int id0, int id1)
		{ return NewtonMaterialGetUserData(newtonWorld, id0, id1); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetSurfaceThickness (const NewtonWorld* const newtonWorld, int id0, int id1, dFloat thickness)
		{ NewtonMaterialSetSurfaceThickness(newtonWorld, id0, id1, thickness); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetCallbackUserData (const NewtonWorld* const newtonWorld, int id0, int id1, void* const userData)
		{ NewtonMaterialSetCallbackUserData(newtonWorld, id0, id1, userData); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactGenerationCallback (const NewtonWorld* const newtonWorld, int id0, int id1, NewtonOnContactGeneration contactGeneration)
		{ NewtonMaterialSetContactGenerationCallback(newtonWorld, id0, id1, contactGeneration); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetCompoundCollisionCallback(const NewtonWorld* const newtonWorld, int id0, int id1, NewtonOnCompoundSubCollisionAABBOverlap compoundAabbOverlap)
		{ NewtonMaterialSetCompoundCollisionCallback(newtonWorld, id0, id1, compoundAabbOverlap); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetCollisionCallback (const NewtonWorld* const newtonWorld, int id0, int id1, NewtonOnAABBOverlap aabbOverlap, NewtonContactsProcess process)
		{ NewtonMaterialSetCollisionCallback(newtonWorld, id0, id1, aabbOverlap, process); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetDefaultSoftness (const NewtonWorld* const newtonWorld, int id0, int id1, dFloat value)
		{ NewtonMaterialSetDefaultSoftness(newtonWorld, id0, id1, value); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetDefaultElasticity (const NewtonWorld* const newtonWorld, int id0, int id1, dFloat elasticCoef)
		{ NewtonMaterialSetDefaultElasticity(newtonWorld, id0, id1, elasticCoef); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetDefaultCollidable (const NewtonWorld* const newtonWorld, int id0, int id1, int state)
		{ NewtonMaterialSetDefaultCollidable(newtonWorld, id0, id1, state); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetDefaultFriction (const NewtonWorld* const newtonWorld, int id0, int id1, dFloat staticFriction, dFloat kineticFriction)
		{ NewtonMaterialSetDefaultFriction(newtonWorld, id0, id1, staticFriction, kineticFriction); }
	NEWTONWRAPPER_API NewtonMaterial* WRAP_NewtonWorldGetFirstMaterial (const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetFirstMaterial(newtonWorld); }
	NEWTONWRAPPER_API NewtonMaterial* WRAP_NewtonWorldGetNextMaterial (const NewtonWorld* const newtonWorld, const NewtonMaterial* const material)
		{ return NewtonWorldGetNextMaterial(newtonWorld, material); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonWorldGetFirstBody (const NewtonWorld* const newtonWorld)
		{ return NewtonWorldGetFirstBody(newtonWorld); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonWorldGetNextBody (const NewtonWorld* const newtonWorld, const NewtonBody* const curBody)
		{ return NewtonWorldGetNextBody(newtonWorld, curBody); }
	NEWTONWRAPPER_API void *WRAP_NewtonMaterialGetMaterialPairUserData (const NewtonMaterial* const material)
		{ return NewtonMaterialGetMaterialPairUserData(material); }
	NEWTONWRAPPER_API unsigned WRAP_NewtonMaterialGetContactFaceAttribute (const NewtonMaterial* const material)
		{ return NewtonMaterialGetContactFaceAttribute(material); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonMaterialGetBodyCollidingShape (const NewtonMaterial* const material, const NewtonBody* const body)
		{ return NewtonMaterialGetBodyCollidingShape(material, body); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonMaterialGetContactNormalSpeed (const NewtonMaterial* const material)
		{ return NewtonMaterialGetContactNormalSpeed(material); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialGetContactForce (const NewtonMaterial* const material, const NewtonBody* const body, dFloat* const force)
		{ NewtonMaterialGetContactForce(material, body, force); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialGetContactPositionAndNormal (const NewtonMaterial* const material, const NewtonBody* const body, dFloat* const posit, dFloat* const normal)
		{ NewtonMaterialGetContactPositionAndNormal(material, body, posit, normal); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialGetContactTangentDirections (const NewtonMaterial* const material, const NewtonBody* const body, dFloat* const dir0, dFloat* const dir1)
		{ NewtonMaterialGetContactTangentDirections(material, body, dir0, dir1); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonMaterialGetContactTangentSpeed (const NewtonMaterial* const material, int index)
		{ return NewtonMaterialGetContactTangentSpeed(material, index); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonMaterialGetContactMaxNormalImpact (const NewtonMaterial* const material)
		{ return NewtonMaterialGetContactMaxNormalImpact(material); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonMaterialGetContactMaxTangentImpact (const NewtonMaterial* const material, int index)
		{ return NewtonMaterialGetContactMaxTangentImpact(material, index); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonMaterialGetContactPenetration (const NewtonMaterial* const material)
		{ return NewtonMaterialGetContactPenetration(material); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactSoftness (const NewtonMaterial* const material, dFloat softness)
		{ NewtonMaterialSetContactSoftness(material, softness); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactElasticity (const NewtonMaterial* const material, dFloat restitution)
		{ NewtonMaterialSetContactElasticity(material, restitution); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactFrictionState (const NewtonMaterial* const material, int state, int index)
		{ NewtonMaterialSetContactFrictionState(material, state, index); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactFrictionCoef (const NewtonMaterial* const material, dFloat staticFrictionCoef, dFloat kineticFrictionCoef, int index)
		{ NewtonMaterialSetContactFrictionCoef(material, staticFrictionCoef, kineticFrictionCoef, index); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactNormalAcceleration (const NewtonMaterial* const material, dFloat accel)
		{ NewtonMaterialSetContactNormalAcceleration(material, accel); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactNormalDirection (const NewtonMaterial* const material, const dFloat* const directionVector)
		{ NewtonMaterialSetContactNormalDirection(material, directionVector); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactPosition (const NewtonMaterial* const material, const dFloat* const position)
		{ NewtonMaterialSetContactPosition(material, position); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactTangentFriction (const NewtonMaterial* const material, dFloat friction, int index)
		{ NewtonMaterialSetContactTangentFriction(material, friction, index); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialSetContactTangentAcceleration (const NewtonMaterial* const material, dFloat accel, int index)
		{ NewtonMaterialSetContactTangentAcceleration(material, accel, index); }
	NEWTONWRAPPER_API void WRAP_NewtonMaterialContactRotateTangentDirections (const NewtonMaterial* const material, const dFloat* const directionVector)
		{ NewtonMaterialContactRotateTangentDirections(material, directionVector); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateNull (const NewtonWorld* const newtonWorld)
		{ return NewtonCreateNull(newtonWorld); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateSphere (const NewtonWorld* const newtonWorld, dFloat radius, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateSphere(newtonWorld, radius, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateBox (const NewtonWorld* const newtonWorld, dFloat dx, dFloat dy, dFloat dz, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateBox(newtonWorld, dx, dy, dz, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCone (const NewtonWorld* const newtonWorld, dFloat radius, dFloat height, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateCone(newtonWorld, radius, height, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCapsule (const NewtonWorld* const newtonWorld, dFloat radius0, dFloat radius1, dFloat height, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateCapsule(newtonWorld, radius0, radius1, height, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCylinder (const NewtonWorld* const newtonWorld, dFloat radio0, dFloat radio1, dFloat height, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateCylinder(newtonWorld, radio0, radio1, height, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateChamferCylinder (const NewtonWorld* const newtonWorld, dFloat radius, dFloat height, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateChamferCylinder(newtonWorld, radius, height, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateConvexHull (const NewtonWorld* const newtonWorld, int count, const dFloat* const vertexCloud, int strideInBytes, dFloat tolerance, int shapeID, const dFloat* const offsetMatrix)
		{ return NewtonCreateConvexHull(newtonWorld, count, vertexCloud, strideInBytes, tolerance, shapeID, offsetMatrix); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateConvexHullFromMesh (const NewtonWorld* const newtonWorld, const NewtonMesh* const mesh, dFloat tolerance, int shapeID)
		{ return NewtonCreateConvexHullFromMesh(newtonWorld, mesh, tolerance, shapeID); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionGetMode(const NewtonCollision* const convexCollision)
		{ return NewtonCollisionGetMode(convexCollision); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetMode (const NewtonCollision* const convexCollision, int mode)
		{ NewtonCollisionSetMode(convexCollision, mode); }
	NEWTONWRAPPER_API int WRAP_NewtonConvexHullGetFaceIndices (const NewtonCollision* const convexHullCollision, int face, int* const faceIndices)
		{ return NewtonConvexHullGetFaceIndices(convexHullCollision, face, faceIndices); }
	NEWTONWRAPPER_API int WRAP_NewtonConvexHullGetVertexData (const NewtonCollision* const convexHullCollision, dFloat** const vertexData, int* strideInBytes)
		{ return NewtonConvexHullGetVertexData(convexHullCollision, vertexData, strideInBytes); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonConvexCollisionCalculateVolume (const NewtonCollision* const convexCollision)
		{ return NewtonConvexCollisionCalculateVolume(convexCollision); }
	NEWTONWRAPPER_API void WRAP_NewtonConvexCollisionCalculateInertialMatrix (const NewtonCollision* convexCollision, dFloat* const inertia, dFloat* const origin)
		{ NewtonConvexCollisionCalculateInertialMatrix(convexCollision, inertia, origin); }
	NEWTONWRAPPER_API void WRAP_NewtonConvexCollisionCalculateBuoyancyAcceleration (const NewtonCollision* const convexCollision, const dFloat* const matrix, const dFloat* const shapeOrigin, const dFloat* const gravityVector, const dFloat* const fluidPlane, dFloat fluidDensity, dFloat fluidViscosity, dFloat* const accel, dFloat* const alpha)
		{ NewtonConvexCollisionCalculateBuoyancyAcceleration(convexCollision, matrix, shapeOrigin, gravityVector, fluidPlane, fluidDensity, fluidViscosity, accel, alpha); }
	NEWTONWRAPPER_API const void* WRAP_NewtonCollisionDataPointer (const NewtonCollision* const convexCollision)
		{ return NewtonCollisionDataPointer(convexCollision); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCompoundCollision (const NewtonWorld* const newtonWorld, int shapeID)
		{ return NewtonCreateCompoundCollision(newtonWorld, shapeID); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCompoundCollisionFromMesh (const NewtonWorld* const newtonWorld, const NewtonMesh* const mesh, dFloat hullTolerance, int shapeID, int subShapeID)
		{ return NewtonCreateCompoundCollisionFromMesh(newtonWorld, mesh, hullTolerance, shapeID, subShapeID); }
	NEWTONWRAPPER_API void WRAP_NewtonCompoundCollisionBeginAddRemove (NewtonCollision* const compoundCollision)
		{ NewtonCompoundCollisionBeginAddRemove(compoundCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonCompoundCollisionAddSubCollision (NewtonCollision* const compoundCollision, const NewtonCollision* const convexCollision)
		{ return NewtonCompoundCollisionAddSubCollision(compoundCollision, convexCollision); }
	NEWTONWRAPPER_API void WRAP_NewtonCompoundCollisionRemoveSubCollision (NewtonCollision* const compoundCollision, const void* const collisionNode)
		{ NewtonCompoundCollisionRemoveSubCollision(compoundCollision, collisionNode); }
	NEWTONWRAPPER_API void WRAP_NewtonCompoundCollisionRemoveSubCollisionByIndex (NewtonCollision* const compoundCollision, int nodeIndex)
		{ NewtonCompoundCollisionRemoveSubCollisionByIndex(compoundCollision, nodeIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonCompoundCollisionSetSubCollisionMatrix (NewtonCollision* const compoundCollision, const void* const collisionNode, const dFloat* const matrix)
		{ NewtonCompoundCollisionSetSubCollisionMatrix(compoundCollision, collisionNode, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonCompoundCollisionEndAddRemove (NewtonCollision* const compoundCollision)
		{ NewtonCompoundCollisionEndAddRemove(compoundCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonCompoundCollisionGetFirstNode (NewtonCollision* const compoundCollision)
		{ return NewtonCompoundCollisionGetFirstNode(compoundCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonCompoundCollisionGetNextNode (NewtonCollision* const compoundCollision, const void* const collisionNode)
		{ return NewtonCompoundCollisionGetNextNode(compoundCollision, collisionNode); }
	NEWTONWRAPPER_API void* WRAP_NewtonCompoundCollisionGetNodeByIndex (NewtonCollision* const compoundCollision, int index)
		{ return NewtonCompoundCollisionGetNodeByIndex(compoundCollision, index); }
	NEWTONWRAPPER_API int WRAP_NewtonCompoundCollisionGetNodeIndex (NewtonCollision* const compoundCollision, const void* const collisionNode)
		{ return NewtonCompoundCollisionGetNodeIndex(compoundCollision, collisionNode); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCompoundCollisionGetCollisionFromNode (NewtonCollision* const compoundCollision, const void* const collisionNode)
		{ return NewtonCompoundCollisionGetCollisionFromNode(compoundCollision, collisionNode); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateFracturedCompoundCollision (const NewtonWorld* const newtonWorld, const NewtonMesh* const solidMesh, int shapeID, int fracturePhysicsMaterialID, int pointcloudCount, const dFloat* const vertexCloud, int strideInBytes, int materialID, const dFloat* const textureMatrix, NewtonFractureCompoundCollisionReconstructMainMeshCallBack regenerateMainMeshCallback, NewtonFractureCompoundCollisionOnEmitCompoundFractured emitFracturedCompound, NewtonFractureCompoundCollisionOnEmitChunk emitFracfuredChunk)
		{ return NewtonCreateFracturedCompoundCollision(newtonWorld, solidMesh, shapeID, fracturePhysicsMaterialID, pointcloudCount, vertexCloud, strideInBytes, materialID, textureMatrix, regenerateMainMeshCallback, emitFracturedCompound, emitFracfuredChunk); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonFracturedCompoundPlaneClip (const NewtonCollision* const fracturedCompound, const dFloat* const plane)
		{ return NewtonFracturedCompoundPlaneClip(fracturedCompound, plane); }
	NEWTONWRAPPER_API void WRAP_NewtonFracturedCompoundSetCallbacks (const NewtonCollision* const fracturedCompound, NewtonFractureCompoundCollisionReconstructMainMeshCallBack regenerateMainMeshCallback, NewtonFractureCompoundCollisionOnEmitCompoundFractured emitFracturedCompound, NewtonFractureCompoundCollisionOnEmitChunk emitFracfuredChunk)
		{ NewtonFracturedCompoundSetCallbacks(fracturedCompound, regenerateMainMeshCallback, emitFracturedCompound, emitFracfuredChunk); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundIsNodeFreeToDetach (const NewtonCollision* const fracturedCompound, void* const collisionNode)
		{ return NewtonFracturedCompoundIsNodeFreeToDetach(fracturedCompound, collisionNode); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundNeighborNodeList (const NewtonCollision* const fracturedCompound, void* const collisionNode, void** const list, int maxCount)
		{ return NewtonFracturedCompoundNeighborNodeList(fracturedCompound, collisionNode, list, maxCount); }
	NEWTONWRAPPER_API NewtonFracturedCompoundMeshPart* WRAP_NewtonFracturedCompoundGetMainMesh (const NewtonCollision* const fracturedCompound)
		{ return NewtonFracturedCompoundGetMainMesh(fracturedCompound); }
	NEWTONWRAPPER_API NewtonFracturedCompoundMeshPart* WRAP_NewtonFracturedCompoundGetFirstSubMesh(const NewtonCollision* const fracturedCompound)
		{ return NewtonFracturedCompoundGetFirstSubMesh(fracturedCompound); }
	NEWTONWRAPPER_API NewtonFracturedCompoundMeshPart* WRAP_NewtonFracturedCompoundGetNextSubMesh(const NewtonCollision* const fracturedCompound, NewtonFracturedCompoundMeshPart* const subMesh)
		{ return NewtonFracturedCompoundGetNextSubMesh(fracturedCompound, subMesh); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundCollisionGetVertexCount (const NewtonCollision* const fracturedCompound, const NewtonFracturedCompoundMeshPart* const meshOwner)
		{ return NewtonFracturedCompoundCollisionGetVertexCount(fracturedCompound, meshOwner); }
	NEWTONWRAPPER_API const dFloat* WRAP_NewtonFracturedCompoundCollisionGetVertexPositions (const NewtonCollision* const fracturedCompound, const NewtonFracturedCompoundMeshPart* const meshOwner)
		{ return NewtonFracturedCompoundCollisionGetVertexPositions(fracturedCompound, meshOwner); }
	NEWTONWRAPPER_API const dFloat* WRAP_NewtonFracturedCompoundCollisionGetVertexNormals (const NewtonCollision* const fracturedCompound, const NewtonFracturedCompoundMeshPart* const meshOwner)
		{ return NewtonFracturedCompoundCollisionGetVertexNormals(fracturedCompound, meshOwner); }
	NEWTONWRAPPER_API const dFloat* WRAP_NewtonFracturedCompoundCollisionGetVertexUVs (const NewtonCollision* const fracturedCompound, const NewtonFracturedCompoundMeshPart* const meshOwner)
		{ return NewtonFracturedCompoundCollisionGetVertexUVs(fracturedCompound, meshOwner); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundMeshPartGetIndexStream (const NewtonCollision* const fracturedCompound, const NewtonFracturedCompoundMeshPart* const meshOwner, const void* const segment, int* const index)
		{ return NewtonFracturedCompoundMeshPartGetIndexStream(fracturedCompound, meshOwner, segment, index); }
	NEWTONWRAPPER_API void* WRAP_NewtonFracturedCompoundMeshPartGetFirstSegment (const NewtonFracturedCompoundMeshPart* const fractureCompoundMeshPart)
		{ return NewtonFracturedCompoundMeshPartGetFirstSegment(fractureCompoundMeshPart); }
	NEWTONWRAPPER_API void* WRAP_NewtonFracturedCompoundMeshPartGetNextSegment (const void* const fractureCompoundMeshSegment)
		{ return NewtonFracturedCompoundMeshPartGetNextSegment(fractureCompoundMeshSegment); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundMeshPartGetMaterial (const void* const fractureCompoundMeshSegment)
		{ return NewtonFracturedCompoundMeshPartGetMaterial(fractureCompoundMeshSegment); }
	NEWTONWRAPPER_API int WRAP_NewtonFracturedCompoundMeshPartGetIndexCount (const void* const fractureCompoundMeshSegment)
		{ return NewtonFracturedCompoundMeshPartGetIndexCount(fractureCompoundMeshSegment); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateSceneCollision (const NewtonWorld* const newtonWorld, int shapeID)
		{ return NewtonCreateSceneCollision(newtonWorld, shapeID); }
	NEWTONWRAPPER_API void WRAP_NewtonSceneCollisionBeginAddRemove (NewtonCollision* const sceneCollision)
		{ NewtonSceneCollisionBeginAddRemove(sceneCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonSceneCollisionAddSubCollision (NewtonCollision* const sceneCollision, const NewtonCollision* const collision)
		{ return NewtonSceneCollisionAddSubCollision(sceneCollision, collision); }
	NEWTONWRAPPER_API void WRAP_NewtonSceneCollisionRemoveSubCollision (NewtonCollision* const compoundCollision, const void* const collisionNode)
		{ NewtonSceneCollisionRemoveSubCollision(compoundCollision, collisionNode); }
	NEWTONWRAPPER_API void WRAP_NewtonSceneCollisionRemoveSubCollisionByIndex (NewtonCollision* const sceneCollision, int nodeIndex)
		{ NewtonSceneCollisionRemoveSubCollisionByIndex(sceneCollision, nodeIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonSceneCollisionSetSubCollisionMatrix (NewtonCollision* const sceneCollision, const void* const collisionNode, const dFloat* const matrix)
		{ NewtonSceneCollisionSetSubCollisionMatrix(sceneCollision, collisionNode, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonSceneCollisionEndAddRemove (NewtonCollision* const sceneCollision)
		{ NewtonSceneCollisionEndAddRemove(sceneCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonSceneCollisionGetFirstNode (NewtonCollision* const sceneCollision)
		{ return NewtonSceneCollisionGetFirstNode(sceneCollision); }
	NEWTONWRAPPER_API void* WRAP_NewtonSceneCollisionGetNextNode (NewtonCollision* const sceneCollision, const void* const collisionNode)
		{ return NewtonSceneCollisionGetNextNode(sceneCollision, collisionNode); }
	NEWTONWRAPPER_API void* WRAP_NewtonSceneCollisionGetNodeByIndex (NewtonCollision* const sceneCollision, int index)
		{ return NewtonSceneCollisionGetNodeByIndex(sceneCollision, index); }
	NEWTONWRAPPER_API int WRAP_NewtonSceneCollisionGetNodeIndex (NewtonCollision* const sceneCollision, const void* const collisionNode)
		{ return NewtonSceneCollisionGetNodeIndex(sceneCollision, collisionNode); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonSceneCollisionGetCollisionFromNode (NewtonCollision* const sceneCollision, const void* const collisionNode)
		{ return NewtonSceneCollisionGetCollisionFromNode(sceneCollision, collisionNode); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateUserMeshCollision (const NewtonWorld* const newtonWorld, const dFloat* const minBox, const dFloat* const maxBox, void* const userData, NewtonUserMeshCollisionCollideCallback collideCallback, NewtonUserMeshCollisionRayHitCallback rayHitCallback, NewtonUserMeshCollisionDestroyCallback destroyCallback, NewtonUserMeshCollisionGetCollisionInfo getInfoCallback, NewtonUserMeshCollisionAABBTest getLocalAABBCallback, NewtonUserMeshCollisionGetFacesInAABB facesInAABBCallback, NewtonOnUserCollisionSerializationCallback serializeCallback, int shapeID)
		{ return NewtonCreateUserMeshCollision(newtonWorld, minBox, maxBox, userData, collideCallback, rayHitCallback, destroyCallback, getInfoCallback, getLocalAABBCallback, facesInAABBCallback, serializeCallback, shapeID); }
	NEWTONWRAPPER_API int WRAP_NewtonUserMeshCollisionContinuousOverlapTest (const NewtonUserMeshCollisionCollideDesc* const collideDescData, const void* const continueCollisionHandle, const dFloat* const minAabb, const dFloat* const maxAabb)
		{ return NewtonUserMeshCollisionContinuousOverlapTest(collideDescData, continueCollisionHandle, minAabb, maxAabb); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateCollisionFromSerialization (const NewtonWorld* const newtonWorld, NewtonDeserializeCallback deserializeFunction, void* const serializeHandle)
		{ return NewtonCreateCollisionFromSerialization(newtonWorld, deserializeFunction, serializeHandle); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSerialize (const NewtonWorld* const newtonWorld, const NewtonCollision* const collision, NewtonSerializeCallback serializeFunction, void* const serializeHandle)
		{ NewtonCollisionSerialize(newtonWorld, collision, serializeFunction, serializeHandle); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionGetInfo (const NewtonCollision* const collision, NewtonCollisionInfoRecord* const collisionInfo)
		{ NewtonCollisionGetInfo(collision, collisionInfo); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateHeightFieldCollision (const NewtonWorld* const newtonWorld, int width, int height, int gridsDiagonals, int elevationdatType, const void* const elevationMap, const char* const attributeMap, dFloat verticalScale, dFloat horizontalScale, int shapeID)
		{ return NewtonCreateHeightFieldCollision(newtonWorld, width, height, gridsDiagonals, elevationdatType, elevationMap, attributeMap, verticalScale, horizontalScale, shapeID); }
	NEWTONWRAPPER_API void WRAP_NewtonHeightFieldSetUserRayCastCallback (const NewtonCollision* const heightfieldCollision, NewtonHeightFieldRayCastCallback rayHitCallback)
		{ NewtonHeightFieldSetUserRayCastCallback(heightfieldCollision, rayHitCallback); }
	NEWTONWRAPPER_API void WRAP_NewtonHeightFieldSetHorizontalDisplacement (const NewtonCollision* const heightfieldCollision, const unsigned short* const horizontalMap, dFloat scale)
		{ NewtonHeightFieldSetHorizontalDisplacement(heightfieldCollision, horizontalMap, scale); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateTreeCollision (const NewtonWorld* const newtonWorld, int shapeID)
		{ return NewtonCreateTreeCollision(newtonWorld, shapeID); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateTreeCollisionFromMesh (const NewtonWorld* const newtonWorld, const NewtonMesh* const mesh, int shapeID)
		{ return NewtonCreateTreeCollisionFromMesh(newtonWorld, mesh, shapeID); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionSetUserRayCastCallback (const NewtonCollision* const treeCollision, NewtonCollisionTreeRayCastCallback rayHitCallback)
		{ NewtonTreeCollisionSetUserRayCastCallback(treeCollision, rayHitCallback); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionBeginBuild (const NewtonCollision* const treeCollision)
		{ NewtonTreeCollisionBeginBuild(treeCollision); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionAddFace (const NewtonCollision* const treeCollision, int vertexCount, const dFloat* const vertexPtr, int strideInBytes, int faceAttribute)
		{ NewtonTreeCollisionAddFace(treeCollision, vertexCount, vertexPtr, strideInBytes, faceAttribute); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionEndBuild (const NewtonCollision* const treeCollision, int optimize)
		{ NewtonTreeCollisionEndBuild(treeCollision, optimize); }
	NEWTONWRAPPER_API int WRAP_NewtonTreeCollisionGetFaceAttribute (const NewtonCollision* const treeCollision, const int* const faceIndexArray, int indexCount)
		{ return NewtonTreeCollisionGetFaceAttribute(treeCollision, faceIndexArray, indexCount); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionSetFaceAttribute (const NewtonCollision* const treeCollision, const int* const faceIndexArray, int indexCount, int attribute)
		{ NewtonTreeCollisionSetFaceAttribute(treeCollision, faceIndexArray, indexCount, attribute); }
	NEWTONWRAPPER_API void WRAP_NewtonTreeCollisionForEachFace (const NewtonCollision* const treeCollision, NewtonTreeCollisionFaceCallback forEachFaceCallback, void* const context)
		{ NewtonTreeCollisionForEachFace(treeCollision, forEachFaceCallback, context); }
	NEWTONWRAPPER_API int WRAP_NewtonTreeCollisionGetVertexListTriangleListInAABB (const NewtonCollision* const treeCollision, const dFloat* const p0, const dFloat* const p1, const dFloat** const vertexArray, int* const vertexCount, int* const vertexStrideInBytes, const int* const indexList, int maxIndexCount, const int* const faceAttribute)
		{ return NewtonTreeCollisionGetVertexListTriangleListInAABB(treeCollision, p0, p1, vertexArray, vertexCount, vertexStrideInBytes, indexList, maxIndexCount, faceAttribute); }
	NEWTONWRAPPER_API void WRAP_NewtonStaticCollisionSetDebugCallback (const NewtonCollision* const staticCollision, NewtonTreeCollisionCallback userCallback)
		{ NewtonStaticCollisionSetDebugCallback(staticCollision, userCallback); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCollisionCreateInstance (const NewtonCollision* const collision)
		{ return NewtonCollisionCreateInstance(collision); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionGetType (const NewtonCollision* const collision)
		{ return NewtonCollisionGetType(collision); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionIsConvexShape (const NewtonCollision* const collision)
		{ return NewtonCollisionIsConvexShape(collision); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionIsStaticShape (const NewtonCollision* const collision)
		{ return NewtonCollisionIsStaticShape(collision); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetUserData (const NewtonCollision* const collision, void* const userData)
		{ NewtonCollisionSetUserData(collision, userData); }
	NEWTONWRAPPER_API void* WRAP_NewtonCollisionGetUserData (const NewtonCollision* const collision)
		{ return NewtonCollisionGetUserData(collision); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetUserData1 (const NewtonCollision* const collision, void* const userData)
		{ NewtonCollisionSetUserData1(collision, userData); }
	NEWTONWRAPPER_API void* WRAP_NewtonCollisionGetUserData1 (const NewtonCollision* const collision)
		{ return NewtonCollisionGetUserData1(collision); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetUserID (const NewtonCollision* const collision, unsigned id)
		{ NewtonCollisionSetUserID(collision, id); }
	NEWTONWRAPPER_API unsigned WRAP_NewtonCollisionGetUserID (const NewtonCollision* const collision)
		{ return NewtonCollisionGetUserID(collision); }
	NEWTONWRAPPER_API void* WRAP_NewtonCollisionGetSubCollisionHandle (const NewtonCollision* const collision)
		{ return NewtonCollisionGetSubCollisionHandle(collision); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCollisionGetParentInstance (const NewtonCollision* const collision)
		{ return NewtonCollisionGetParentInstance(collision); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetMatrix (const NewtonCollision* const collision, const dFloat* const matrix)
		{ NewtonCollisionSetMatrix(collision, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionGetMatrix (const NewtonCollision* const collision, dFloat* const matrix)
		{ NewtonCollisionGetMatrix(collision, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSetScale (const NewtonCollision* const collision, dFloat scaleX, dFloat scaleY, dFloat scaleZ)
		{ NewtonCollisionSetScale(collision, scaleX, scaleY, scaleZ); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionGetScale (const NewtonCollision* const collision, dFloat* const scaleX, dFloat* const scaleY, dFloat* const scaleZ)
		{ NewtonCollisionGetScale(collision, scaleX, scaleY, scaleZ); }
	NEWTONWRAPPER_API void WRAP_NewtonDestroyCollision (const NewtonCollision* const collision)
		{ NewtonDestroyCollision(collision); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCollisionGetSkinThickness (const NewtonCollision* const collision)
		{ return NewtonCollisionGetSkinThickness(collision); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionIntersectionTest (const NewtonWorld* const newtonWorld, const NewtonCollision* const collisionA, const dFloat* const matrixA, const NewtonCollision* const collisionB, const dFloat* const matrixB, int threadIndex)
		{ return NewtonCollisionIntersectionTest(newtonWorld, collisionA, matrixA, collisionB, matrixB, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionPointDistance (const NewtonWorld* const newtonWorld, const dFloat* const point, const NewtonCollision* const collision, const dFloat* const matrix, dFloat* const contact, dFloat* const normal, int threadIndex)
		{ return NewtonCollisionPointDistance(newtonWorld, point, collision, matrix, contact, normal, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionClosestPoint (const NewtonWorld* const newtonWorld, const NewtonCollision* const collisionA, const dFloat* const matrixA, const NewtonCollision* const collisionB, const dFloat* const matrixB, dFloat* const contactA, dFloat* const contactB, dFloat* const normalAB, int threadIndex)
		{ return NewtonCollisionClosestPoint(newtonWorld, collisionA, matrixA, collisionB, matrixB, contactA, contactB, normalAB, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionCollide (const NewtonWorld* const newtonWorld, int maxSize, const NewtonCollision* const collisionA, const dFloat* const matrixA, const NewtonCollision* const collisionB, const dFloat* const matrixB, dFloat* const contacts, dFloat* const normals, dFloat* const penetration, dLong* const attributeA, dLong* const attributeB, int threadIndex)
		{ return NewtonCollisionCollide(newtonWorld, maxSize, collisionA, matrixA, collisionB, matrixB, contacts, normals, penetration, attributeA, attributeB, threadIndex); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionCollideContinue (const NewtonWorld* const newtonWorld, int maxSize, dFloat timestep, const NewtonCollision* const collisionA, const dFloat* const matrixA, const dFloat* const velocA, const dFloat* omegaA, const NewtonCollision* const collisionB, const dFloat* const matrixB, const dFloat* const velocB, const dFloat* const omegaB, dFloat* const timeOfImpact, dFloat* const contacts, dFloat* const normals, dFloat* const penetration, dLong* const attributeA, dLong* const attributeB, int threadIndex)
		{ return NewtonCollisionCollideContinue(newtonWorld, maxSize, timestep, collisionA, matrixA, velocA, omegaA, collisionB, matrixB, velocB, omegaB, timeOfImpact, contacts, normals, penetration, attributeA, attributeB, threadIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionSupportVertex (const NewtonCollision* const collision, const dFloat* const dir, dFloat* const vertex)
		{ NewtonCollisionSupportVertex(collision, dir, vertex); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCollisionRayCast (const NewtonCollision* const collision, const dFloat* const p0, const dFloat* const p1, dFloat* const normal, dLong* const attribute)
		{ return NewtonCollisionRayCast(collision, p0, p1, normal, attribute); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionCalculateAABB (const NewtonCollision* const collision, const dFloat* const matrix, dFloat* const p0, dFloat* const p1)
		{ NewtonCollisionCalculateAABB(collision, matrix, p0, p1); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionForEachPolygonDo (const NewtonCollision* const collision, const dFloat* const matrix, NewtonCollisionIterator callback, void* const userData)
		{ NewtonCollisionForEachPolygonDo(collision, matrix, callback, userData); }
	NEWTONWRAPPER_API void* WRAP_NewtonCollisionAggregateCreate (NewtonWorld* const world)
		{ return NewtonCollisionAggregateCreate(world); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionAggregateDestroy (void* const aggregate)
		{ NewtonCollisionAggregateDestroy(aggregate); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionAggregateAddBody (void* const aggregate, const NewtonBody* const body)
		{ NewtonCollisionAggregateAddBody(aggregate, body); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionAggregateRemoveBody (void* const aggregate, const NewtonBody* const body)
		{ NewtonCollisionAggregateRemoveBody(aggregate, body); }
	NEWTONWRAPPER_API int WRAP_NewtonCollisionAggregateGetSelfCollision (void* const aggregate)
		{ return NewtonCollisionAggregateGetSelfCollision(aggregate); }
	NEWTONWRAPPER_API void WRAP_NewtonCollisionAggregateSetSelfCollision (void* const aggregate, int state)
		{ NewtonCollisionAggregateSetSelfCollision(aggregate, state); }
	NEWTONWRAPPER_API void WRAP_NewtonSetEulerAngle (const dFloat* const eulersAngles, dFloat* const matrix)
		{ NewtonSetEulerAngle(eulersAngles, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonGetEulerAngle (const dFloat* const matrix, dFloat* const eulersAngles0, dFloat* const eulersAngles1)
		{ NewtonGetEulerAngle(matrix, eulersAngles0, eulersAngles1); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCalculateSpringDamperAcceleration (dFloat dt, dFloat ks, dFloat x, dFloat kd, dFloat s)
		{ return NewtonCalculateSpringDamperAcceleration(dt, ks, x, kd, s); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonCreateDynamicBody (const NewtonWorld* const newtonWorld, const NewtonCollision* const collision, const dFloat* const matrix)
		{ return NewtonCreateDynamicBody(newtonWorld, collision, matrix); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonCreateKinematicBody (const NewtonWorld* const newtonWorld, const NewtonCollision* const collision, const dFloat* const matrix)
		{ return NewtonCreateKinematicBody(newtonWorld, collision, matrix); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonCreateDeformableBody (const NewtonWorld* const newtonWorld, const NewtonCollision* const deformableMesh, const dFloat* const matrix)
		{ return NewtonCreateDeformableBody(newtonWorld, deformableMesh, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonDestroyBody(const NewtonBody* const body)
		{ NewtonDestroyBody(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetSimulationState(const NewtonBody* const body)
		{ return NewtonBodyGetSimulationState(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetSimulationState(const NewtonBody* const bodyPtr, const int state)
		{ NewtonBodySetSimulationState(bodyPtr, state); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetType (const NewtonBody* const body)
		{ return NewtonBodyGetType(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetCollidable (const NewtonBody* const body)
		{ return NewtonBodyGetCollidable(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetCollidable (const NewtonBody* const body, int collidableState)
		{ NewtonBodySetCollidable(body, collidableState); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyAddForce (const NewtonBody* const body, const dFloat* const force)
		{ NewtonBodyAddForce(body, force); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyAddTorque (const NewtonBody* const body, const dFloat* const torque)
		{ NewtonBodyAddTorque(body, torque); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyCalculateInverseDynamicsForce (const NewtonBody* const body, dFloat timestep, const dFloat* const desiredVeloc, dFloat* const forceOut)
		{ NewtonBodyCalculateInverseDynamicsForce(body, timestep, desiredVeloc, forceOut); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetCentreOfMass (const NewtonBody* const body, const dFloat* const com)
		{ NewtonBodySetCentreOfMass(body, com); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMassMatrix (const NewtonBody* const body, dFloat mass, dFloat Ixx, dFloat Iyy, dFloat Izz)
		{ NewtonBodySetMassMatrix(body, mass, Ixx, Iyy, Izz); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetFullMassMatrix (const NewtonBody* const body, dFloat mass, const dFloat* const inertiaMatrix)
		{ NewtonBodySetFullMassMatrix(body, mass, inertiaMatrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMassProperties (const NewtonBody* const body, dFloat mass, const NewtonCollision* const collision)
		{ NewtonBodySetMassProperties(body, mass, collision); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMatrix (const NewtonBody* const body, const dFloat* const matrix)
		{ NewtonBodySetMatrix(body, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMatrixNoSleep (const NewtonBody* const body, const dFloat* const matrix)
		{ NewtonBodySetMatrixNoSleep(body, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMatrixRecursive (const NewtonBody* const body, const dFloat* const matrix)
		{ NewtonBodySetMatrixRecursive(body, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMaterialGroupID (const NewtonBody* const body, int id)
		{ NewtonBodySetMaterialGroupID(body, id); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetContinuousCollisionMode (const NewtonBody* const body, unsigned state)
		{ NewtonBodySetContinuousCollisionMode(body, state); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetJointRecursiveCollision (const NewtonBody* const body, unsigned state)
		{ NewtonBodySetJointRecursiveCollision(body, state); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetOmega (const NewtonBody* const body, const dFloat* const omega)
		{ NewtonBodySetOmega(body, omega); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetOmegaNoSleep (const NewtonBody* const body, const dFloat* const omega)
		{ NewtonBodySetOmegaNoSleep(body, omega); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetVelocity (const NewtonBody* const body, const dFloat* const velocity)
		{ NewtonBodySetVelocity(body, velocity); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetVelocityNoSleep (const NewtonBody* const body, const dFloat* const velocity)
		{ NewtonBodySetVelocityNoSleep(body, velocity); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetForce (const NewtonBody* const body, const dFloat* const force)
		{ NewtonBodySetForce(body, force); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetTorque (const NewtonBody* const body, const dFloat* const torque)
		{ NewtonBodySetTorque(body, torque); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetLinearDamping (const NewtonBody* const body, dFloat linearDamp)
		{ NewtonBodySetLinearDamping(body, linearDamp); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetAngularDamping (const NewtonBody* const body, const dFloat* const angularDamp)
		{ NewtonBodySetAngularDamping(body, angularDamp); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetCollision (const NewtonBody* const body, const NewtonCollision* const collision)
		{ NewtonBodySetCollision(body, collision); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetCollisionScale (const NewtonBody* const body, dFloat scaleX, dFloat scaleY, dFloat scaleZ)
		{ NewtonBodySetCollisionScale(body, scaleX, scaleY, scaleZ); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonBodyGetMaxRotationPerStep (const NewtonBody* const body)
		{ return NewtonBodyGetMaxRotationPerStep(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetMaxRotationPerStep (const NewtonBody* const body, dFloat angleInRadians)
		{ NewtonBodySetMaxRotationPerStep(body, angleInRadians); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetSleepState (const NewtonBody* const body)
		{ return NewtonBodyGetSleepState(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetSleepState (const NewtonBody* const body, int state)
		{ NewtonBodySetSleepState(body, state); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetAutoSleep (const NewtonBody* const body)
		{ return NewtonBodyGetAutoSleep(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetAutoSleep (const NewtonBody* const body, int state)
		{ NewtonBodySetAutoSleep(body, state); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetFreezeState(const NewtonBody* const body)
		{ return NewtonBodyGetFreezeState(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetFreezeState (const NewtonBody* const body, int state)
		{ NewtonBodySetFreezeState(body, state); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetDestructorCallback (const NewtonBody* const body, NewtonBodyDestructor callback)
		{ NewtonBodySetDestructorCallback(body, callback); }
	NEWTONWRAPPER_API NewtonBodyDestructor WRAP_NewtonBodyGetDestructorCallback (const NewtonBody* const body)
		{ return NewtonBodyGetDestructorCallback(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetTransformCallback (const NewtonBody* const body, NewtonSetTransform callback)
		{ NewtonBodySetTransformCallback(body, callback); }
	NEWTONWRAPPER_API NewtonSetTransform WRAP_NewtonBodyGetTransformCallback (const NewtonBody* const body)
		{ return NewtonBodyGetTransformCallback(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetForceAndTorqueCallback (const NewtonBody* const body, NewtonApplyForceAndTorque callback)
		{ NewtonBodySetForceAndTorqueCallback(body, callback); }
	NEWTONWRAPPER_API NewtonApplyForceAndTorque WRAP_NewtonBodyGetForceAndTorqueCallback (const NewtonBody* const body)
		{ return NewtonBodyGetForceAndTorqueCallback(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetID (const NewtonBody* const body)
		{ return NewtonBodyGetID(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodySetUserData (const NewtonBody* const body, void* const userData)
		{ NewtonBodySetUserData(body, userData); }
	NEWTONWRAPPER_API void* WRAP_NewtonBodyGetUserData (const NewtonBody* const body)
		{ return NewtonBodyGetUserData(body); }
	NEWTONWRAPPER_API NewtonWorld* WRAP_NewtonBodyGetWorld (const NewtonBody* const body)
		{ return NewtonBodyGetWorld(body); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonBodyGetCollision (const NewtonBody* const body)
		{ return NewtonBodyGetCollision(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetMaterialGroupID (const NewtonBody* const body)
		{ return NewtonBodyGetMaterialGroupID(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetContinuousCollisionMode (const NewtonBody* const body)
		{ return NewtonBodyGetContinuousCollisionMode(body); }
	NEWTONWRAPPER_API int WRAP_NewtonBodyGetJointRecursiveCollision (const NewtonBody* const body)
		{ return NewtonBodyGetJointRecursiveCollision(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetPosition(const NewtonBody* const body, dFloat* const pos)
		{ NewtonBodyGetPosition(body, pos); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetMatrix(const NewtonBody* const body, dFloat* const matrix)
		{ NewtonBodyGetMatrix(body, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetRotation(const NewtonBody* const body, dFloat* const rotation)
		{ NewtonBodyGetRotation(body, rotation); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetMassMatrix (const NewtonBody* const body, dFloat* mass, dFloat* const Ixx, dFloat* const Iyy, dFloat* const Izz)
		{ NewtonBodyGetMassMatrix(body, mass, Ixx, Iyy, Izz); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetInvMass(const NewtonBody* const body, dFloat* const invMass, dFloat* const invIxx, dFloat* const invIyy, dFloat* const invIzz)
		{ NewtonBodyGetInvMass(body, invMass, invIxx, invIyy, invIzz); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetInertiaMatrix(const NewtonBody* const body, dFloat* const inertiaMatrix)
		{ NewtonBodyGetInertiaMatrix(body, inertiaMatrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetInvInertiaMatrix(const NewtonBody* const body, dFloat* const invInertiaMatrix)
		{ NewtonBodyGetInvInertiaMatrix(body, invInertiaMatrix); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetOmega(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetOmega(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetVelocity(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetVelocity(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetForce(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetForce(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetTorque(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetTorque(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetForceAcc(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetForceAcc(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetTorqueAcc(const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetTorqueAcc(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetCentreOfMass (const NewtonBody* const body, dFloat* const com)
		{ NewtonBodyGetCentreOfMass(body, com); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetPointVelocity (const NewtonBody* const body, const dFloat* const point, dFloat* const velocOut)
		{ NewtonBodyGetPointVelocity(body, point, velocOut); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyAddImpulse (const NewtonBody* const body, const dFloat* const pointDeltaVeloc, const dFloat* const pointPosit)
		{ NewtonBodyAddImpulse(body, pointDeltaVeloc, pointPosit); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyApplyImpulseArray (const NewtonBody* const body, int impuleCount, int strideInByte, const dFloat* const impulseArray, const dFloat* const pointArray)
		{ NewtonBodyApplyImpulseArray(body, impuleCount, strideInByte, impulseArray, pointArray); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyApplyImpulsePair (const NewtonBody* const body, dFloat* const linearImpulse, dFloat* const angularImpulse)
		{ NewtonBodyApplyImpulsePair(body, linearImpulse, angularImpulse); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyIntegrateVelocity (const NewtonBody* const body, dFloat timestep)
		{ NewtonBodyIntegrateVelocity(body, timestep); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonBodyGetLinearDamping (const NewtonBody* const body)
		{ return NewtonBodyGetLinearDamping(body); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetAngularDamping (const NewtonBody* const body, dFloat* const vector)
		{ NewtonBodyGetAngularDamping(body, vector); }
	NEWTONWRAPPER_API void WRAP_NewtonBodyGetAABB (const NewtonBody* const body, dFloat* const p0, dFloat* const p1)
		{ NewtonBodyGetAABB(body, p0, p1); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonBodyGetFirstJoint (const NewtonBody* const body)
		{ return NewtonBodyGetFirstJoint(body); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonBodyGetNextJoint (const NewtonBody* const body, const NewtonJoint* const joint)
		{ return NewtonBodyGetNextJoint(body, joint); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonBodyGetFirstContactJoint (const NewtonBody* const body)
		{ return NewtonBodyGetFirstContactJoint(body); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonBodyGetNextContactJoint (const NewtonBody* const body, const NewtonJoint* const contactJoint)
		{ return NewtonBodyGetNextContactJoint(body, contactJoint); }
	NEWTONWRAPPER_API NewtonSkeletonContainer* WRAP_NewtonBodyGetSkeleton(const NewtonBody* const body)
		{ return NewtonBodyGetSkeleton(body); }
	NEWTONWRAPPER_API void* WRAP_NewtonContactJointGetFirstContact (const NewtonJoint* const contactJoint)
		{ return NewtonContactJointGetFirstContact(contactJoint); }
	NEWTONWRAPPER_API void* WRAP_NewtonContactJointGetNextContact (const NewtonJoint* const contactJoint, void* const contact)
		{ return NewtonContactJointGetNextContact(contactJoint, contact); }
	NEWTONWRAPPER_API int WRAP_NewtonContactJointGetContactCount(const NewtonJoint* const contactJoint)
		{ return NewtonContactJointGetContactCount(contactJoint); }
	NEWTONWRAPPER_API void WRAP_NewtonContactJointRemoveContact(const NewtonJoint* const contactJoint, void* const contact)
		{ NewtonContactJointRemoveContact(contactJoint, contact); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonContactJointGetClosestDistance(const NewtonJoint* const contactJoint)
		{ return NewtonContactJointGetClosestDistance(contactJoint); }
	NEWTONWRAPPER_API NewtonMaterial* WRAP_NewtonContactGetMaterial (const void* const contact)
		{ return NewtonContactGetMaterial(contact); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonContactGetCollision0 (const void* const contact)
		{ return NewtonContactGetCollision0(contact); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonContactGetCollision1 (const void* const contact)
		{ return NewtonContactGetCollision1(contact); }
	NEWTONWRAPPER_API void* WRAP_NewtonContactGetCollisionID0 (const void* const contact)
		{ return NewtonContactGetCollisionID0(contact); }
	NEWTONWRAPPER_API void* WRAP_NewtonContactGetCollisionID1 (const void* const contact)
		{ return NewtonContactGetCollisionID1(contact); }
	NEWTONWRAPPER_API void* WRAP_NewtonJointGetUserData (const NewtonJoint* const joint)
		{ return NewtonJointGetUserData(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonJointSetUserData (const NewtonJoint* const joint, void* const userData)
		{ NewtonJointSetUserData(joint, userData); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonJointGetBody0 (const NewtonJoint* const joint)
		{ return NewtonJointGetBody0(joint); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonJointGetBody1 (const NewtonJoint* const joint)
		{ return NewtonJointGetBody1(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonJointGetInfo (const NewtonJoint* const joint, NewtonJointRecord* const info)
		{ NewtonJointGetInfo(joint, info); }
	NEWTONWRAPPER_API int WRAP_NewtonJointGetCollisionState (const NewtonJoint* const joint)
		{ return NewtonJointGetCollisionState(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonJointSetCollisionState (const NewtonJoint* const joint, int state)
		{ NewtonJointSetCollisionState(joint, state); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonJointGetStiffness (const NewtonJoint* const joint)
		{ return NewtonJointGetStiffness(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonJointSetStiffness (const NewtonJoint* const joint, dFloat state)
		{ NewtonJointSetStiffness(joint, state); }
	NEWTONWRAPPER_API void WRAP_NewtonDestroyJoint(const NewtonWorld* const newtonWorld, const NewtonJoint* const joint)
		{ NewtonDestroyJoint(newtonWorld, joint); }
	NEWTONWRAPPER_API void WRAP_NewtonJointSetDestructor (const NewtonJoint* const joint, NewtonConstraintDestructor destructor)
		{ NewtonJointSetDestructor(joint, destructor); }
	NEWTONWRAPPER_API int WRAP_NewtonJointIsActive (const NewtonJoint* const joint)
		{ return NewtonJointIsActive(joint); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateClothPatch (const NewtonWorld* const newtonWorld, NewtonMesh* const mesh, int shapeID, NewtonClothPatchMaterial* const structuralMaterial, NewtonClothPatchMaterial* const bendMaterial)
		{ return NewtonCreateClothPatch(newtonWorld, mesh, shapeID, structuralMaterial, bendMaterial); }
	NEWTONWRAPPER_API NewtonCollision* WRAP_NewtonCreateDeformableMesh (const NewtonWorld* const newtonWorld, NewtonMesh* const mesh, int shapeID)
		{ return NewtonCreateDeformableMesh(newtonWorld, mesh, shapeID); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshCreateClusters (NewtonCollision* const deformableMesh, int clusterCount, dFloat overlapingWidth)
		{ NewtonDeformableMeshCreateClusters(deformableMesh, clusterCount, overlapingWidth); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshSetDebugCallback (NewtonCollision* const deformableMesh, NewtonCollisionIterator callback)
		{ NewtonDeformableMeshSetDebugCallback(deformableMesh, callback); }
	NEWTONWRAPPER_API int WRAP_NewtonDeformableMeshGetParticleCount (const NewtonCollision* const deformableMesh)
		{ return NewtonDeformableMeshGetParticleCount(deformableMesh); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshGetParticlePosition (NewtonCollision* const deformableMesh, int particleIndex, dFloat* const posit)
		{ NewtonDeformableMeshGetParticlePosition(deformableMesh, particleIndex, posit); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshBeginConfiguration (const NewtonCollision* const deformableMesh)
		{ NewtonDeformableMeshBeginConfiguration(deformableMesh); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshUnconstraintParticle (NewtonCollision* const deformableMesh, int particleIndex)
		{ NewtonDeformableMeshUnconstraintParticle(deformableMesh, particleIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshConstraintParticle (NewtonCollision* const deformableMesh, int particleIndex, const dFloat* const posit, const NewtonBody* const body)
		{ NewtonDeformableMeshConstraintParticle(deformableMesh, particleIndex, posit, body); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshEndConfiguration (const NewtonCollision* const deformableMesh)
		{ NewtonDeformableMeshEndConfiguration(deformableMesh); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshSetSkinThickness (NewtonCollision* const deformableMesh, dFloat skinThickness)
		{ NewtonDeformableMeshSetSkinThickness(deformableMesh, skinThickness); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshUpdateRenderNormals (const NewtonCollision* const deformableMesh)
		{ NewtonDeformableMeshUpdateRenderNormals(deformableMesh); }
	NEWTONWRAPPER_API int WRAP_NewtonDeformableMeshGetVertexCount (const NewtonCollision* const deformableMesh)
		{ return NewtonDeformableMeshGetVertexCount(deformableMesh); }
	NEWTONWRAPPER_API void WRAP_NewtonDeformableMeshGetVertexStreams (const NewtonCollision* const deformableMesh, int vertexStrideInByte, dFloat* const vertex, int normalStrideInByte, dFloat* const normal, int uvStrideInByte0, dFloat* const uv0)
		{ NewtonDeformableMeshGetVertexStreams(deformableMesh, vertexStrideInByte, vertex, normalStrideInByte, normal, uvStrideInByte0, uv0); }
	NEWTONWRAPPER_API NewtonDeformableMeshSegment* WRAP_NewtonDeformableMeshGetFirstSegment (const NewtonCollision* const deformableMesh)
		{ return NewtonDeformableMeshGetFirstSegment(deformableMesh); }
	NEWTONWRAPPER_API NewtonDeformableMeshSegment* WRAP_NewtonDeformableMeshGetNextSegment (const NewtonCollision* const deformableMesh, const NewtonDeformableMeshSegment* const segment)
		{ return NewtonDeformableMeshGetNextSegment(deformableMesh, segment); }
	NEWTONWRAPPER_API int WRAP_NewtonDeformableMeshSegmentGetMaterialID (const NewtonCollision* const deformableMesh, const NewtonDeformableMeshSegment* const segment)
		{ return NewtonDeformableMeshSegmentGetMaterialID(deformableMesh, segment); }
	NEWTONWRAPPER_API int WRAP_NewtonDeformableMeshSegmentGetIndexCount (const NewtonCollision* const deformableMesh, const NewtonDeformableMeshSegment* const segment)
		{ return NewtonDeformableMeshSegmentGetIndexCount(deformableMesh, segment); }
	NEWTONWRAPPER_API const int* WRAP_NewtonDeformableMeshSegmentGetIndexList (const NewtonCollision* const deformableMesh, const NewtonDeformableMeshSegment* const segment)
		{ return NewtonDeformableMeshSegmentGetIndexList(deformableMesh, segment); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateBall (const NewtonWorld* const newtonWorld, const dFloat* pivotPoint, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateBall(newtonWorld, pivotPoint, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonBallSetUserCallback (const NewtonJoint* const ball, NewtonBallCallback callback)
		{ NewtonBallSetUserCallback(ball, callback); }
	NEWTONWRAPPER_API void WRAP_NewtonBallGetJointAngle (const NewtonJoint* const ball, dFloat* angle)
		{ NewtonBallGetJointAngle(ball, angle); }
	NEWTONWRAPPER_API void WRAP_NewtonBallGetJointOmega (const NewtonJoint* const ball, dFloat* omega)
		{ NewtonBallGetJointOmega(ball, omega); }
	NEWTONWRAPPER_API void WRAP_NewtonBallGetJointForce (const NewtonJoint* const ball, dFloat* const force)
		{ NewtonBallGetJointForce(ball, force); }
	NEWTONWRAPPER_API void WRAP_NewtonBallSetConeLimits (const NewtonJoint* const ball, const dFloat* pin, dFloat maxConeAngle, dFloat maxTwistAngle)
		{ NewtonBallSetConeLimits(ball, pin, maxConeAngle, maxTwistAngle); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateHinge (const NewtonWorld* const newtonWorld, const dFloat* pivotPoint, const dFloat* pinDir, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateHinge(newtonWorld, pivotPoint, pinDir, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonHingeSetUserCallback (const NewtonJoint* const hinge, NewtonHingeCallback callback)
		{ NewtonHingeSetUserCallback(hinge, callback); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonHingeGetJointAngle (const NewtonJoint* const hinge)
		{ return NewtonHingeGetJointAngle(hinge); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonHingeGetJointOmega (const NewtonJoint* const hinge)
		{ return NewtonHingeGetJointOmega(hinge); }
	NEWTONWRAPPER_API void WRAP_NewtonHingeGetJointForce (const NewtonJoint* const hinge, dFloat* const force)
		{ NewtonHingeGetJointForce(hinge, force); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonHingeCalculateStopAlpha (const NewtonJoint* const hinge, const NewtonHingeSliderUpdateDesc* const desc, dFloat angle)
		{ return NewtonHingeCalculateStopAlpha(hinge, desc, angle); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateSlider (const NewtonWorld* const newtonWorld, const dFloat* pivotPoint, const dFloat* pinDir, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateSlider(newtonWorld, pivotPoint, pinDir, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonSliderSetUserCallback (const NewtonJoint* const slider, NewtonSliderCallback callback)
		{ NewtonSliderSetUserCallback(slider, callback); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonSliderGetJointPosit (const NewtonJoint* slider)
		{ return NewtonSliderGetJointPosit(slider); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonSliderGetJointVeloc (const NewtonJoint* slider)
		{ return NewtonSliderGetJointVeloc(slider); }
	NEWTONWRAPPER_API void WRAP_NewtonSliderGetJointForce (const NewtonJoint* const slider, dFloat* const force)
		{ NewtonSliderGetJointForce(slider, force); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonSliderCalculateStopAccel (const NewtonJoint* const slider, const NewtonHingeSliderUpdateDesc* const desc, dFloat position)
		{ return NewtonSliderCalculateStopAccel(slider, desc, position); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateCorkscrew (const NewtonWorld* const newtonWorld, const dFloat* pivotPoint, const dFloat* pinDir, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateCorkscrew(newtonWorld, pivotPoint, pinDir, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonCorkscrewSetUserCallback (const NewtonJoint* const corkscrew, NewtonCorkscrewCallback callback)
		{ NewtonCorkscrewSetUserCallback(corkscrew, callback); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewGetJointPosit (const NewtonJoint* const corkscrew)
		{ return NewtonCorkscrewGetJointPosit(corkscrew); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewGetJointAngle (const NewtonJoint* const corkscrew)
		{ return NewtonCorkscrewGetJointAngle(corkscrew); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewGetJointVeloc (const NewtonJoint* const corkscrew)
		{ return NewtonCorkscrewGetJointVeloc(corkscrew); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewGetJointOmega (const NewtonJoint* const corkscrew)
		{ return NewtonCorkscrewGetJointOmega(corkscrew); }
	NEWTONWRAPPER_API void WRAP_NewtonCorkscrewGetJointForce (const NewtonJoint* const corkscrew, dFloat* const force)
		{ NewtonCorkscrewGetJointForce(corkscrew, force); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewCalculateStopAlpha (const NewtonJoint* const corkscrew, const NewtonHingeSliderUpdateDesc* const desc, dFloat angle)
		{ return NewtonCorkscrewCalculateStopAlpha(corkscrew, desc, angle); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonCorkscrewCalculateStopAccel (const NewtonJoint* const corkscrew, const NewtonHingeSliderUpdateDesc* const desc, dFloat position)
		{ return NewtonCorkscrewCalculateStopAccel(corkscrew, desc, position); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateUniversal (const NewtonWorld* const newtonWorld, const dFloat* pivotPoint, const dFloat* pinDir0, const dFloat* pinDir1, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateUniversal(newtonWorld, pivotPoint, pinDir0, pinDir1, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonUniversalSetUserCallback (const NewtonJoint* const universal, NewtonUniversalCallback callback)
		{ NewtonUniversalSetUserCallback(universal, callback); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalGetJointAngle0 (const NewtonJoint* const universal)
		{ return NewtonUniversalGetJointAngle0(universal); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalGetJointAngle1 (const NewtonJoint* const universal)
		{ return NewtonUniversalGetJointAngle1(universal); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalGetJointOmega0 (const NewtonJoint* const universal)
		{ return NewtonUniversalGetJointOmega0(universal); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalGetJointOmega1 (const NewtonJoint* const universal)
		{ return NewtonUniversalGetJointOmega1(universal); }
	NEWTONWRAPPER_API void WRAP_NewtonUniversalGetJointForce (const NewtonJoint* const universal, dFloat* const force)
		{ NewtonUniversalGetJointForce(universal, force); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalCalculateStopAlpha0 (const NewtonJoint* const universal, const NewtonHingeSliderUpdateDesc* const desc, dFloat angle)
		{ return NewtonUniversalCalculateStopAlpha0(universal, desc, angle); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUniversalCalculateStopAlpha1 (const NewtonJoint* const universal, const NewtonHingeSliderUpdateDesc* const desc, dFloat angle)
		{ return NewtonUniversalCalculateStopAlpha1(universal, desc, angle); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateUpVector (const NewtonWorld* const newtonWorld, const dFloat* pinDir, const NewtonBody* const body)
		{ return NewtonConstraintCreateUpVector(newtonWorld, pinDir, body); }
	NEWTONWRAPPER_API void WRAP_NewtonUpVectorGetPin (const NewtonJoint* const upVector, dFloat *pin)
		{ NewtonUpVectorGetPin(upVector, pin); }
	NEWTONWRAPPER_API void WRAP_NewtonUpVectorSetPin (const NewtonJoint* const upVector, const dFloat *pin)
		{ NewtonUpVectorSetPin(upVector, pin); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonConstraintCreateUserJoint (const NewtonWorld* const newtonWorld, int maxDOF, NewtonUserBilateralCallback callback, NewtonUserBilateralGetInfoCallback getInfo, const NewtonBody* const childBody, const NewtonBody* const parentBody)
		{ return NewtonConstraintCreateUserJoint(newtonWorld, maxDOF, callback, getInfo, childBody, parentBody); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetFeedbackCollectorCallback (const NewtonJoint* const joint, NewtonUserBilateralCallback getFeedback)
		{ NewtonUserJointSetFeedbackCollectorCallback(joint, getFeedback); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointAddLinearRow (const NewtonJoint* const joint, const dFloat* const pivot0, const dFloat* const pivot1, const dFloat* const dir)
		{ NewtonUserJointAddLinearRow(joint, pivot0, pivot1, dir); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointAddAngularRow (const NewtonJoint* const joint, dFloat relativeAngle, const dFloat* const dir)
		{ NewtonUserJointAddAngularRow(joint, relativeAngle, dir); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointAddGeneralRow (const NewtonJoint* const joint, const dFloat* const jacobian0, const dFloat* const jacobian1)
		{ NewtonUserJointAddGeneralRow(joint, jacobian0, jacobian1); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetRowMinimumFriction (const NewtonJoint* const joint, dFloat friction)
		{ NewtonUserJointSetRowMinimumFriction(joint, friction); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetRowMaximumFriction (const NewtonJoint* const joint, dFloat friction)
		{ NewtonUserJointSetRowMaximumFriction(joint, friction); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUserCalculateRowZeroAccelaration (const NewtonJoint* const joint)
		{ return NewtonUserCalculateRowZeroAccelaration(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetRowAcceleration (const NewtonJoint* const joint, dFloat acceleration)
		{ NewtonUserJointSetRowAcceleration(joint, acceleration); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetRowSpringDamperAcceleration (const NewtonJoint* const joint, dFloat spring, dFloat damper)
		{ NewtonUserJointSetRowSpringDamperAcceleration(joint, spring, damper); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointSetRowStiffness (const NewtonJoint* const joint, dFloat stiffness)
		{ NewtonUserJointSetRowStiffness(joint, stiffness); }
	NEWTONWRAPPER_API int WRAP_NewtonUserJoinRowsCount (const NewtonJoint* const joint)
		{ return NewtonUserJoinRowsCount(joint); }
	NEWTONWRAPPER_API void WRAP_NewtonUserJointGetGeneralRow (const NewtonJoint* const joint, int index, dFloat* const jacobian0, dFloat* const jacobian1)
		{ NewtonUserJointGetGeneralRow(joint, index, jacobian0, jacobian1); }
	NEWTONWRAPPER_API dFloat WRAP_NewtonUserJointGetRowForce (const NewtonJoint* const joint, int row)
		{ return NewtonUserJointGetRowForce(joint, row); }
	NEWTONWRAPPER_API NewtonSkeletonContainer* WRAP_NewtonSkeletonContainerCreate (NewtonWorld* const world, NewtonBody* const rootBone, NewtonSkeletontDestructor onDestroyCallback)
		{ return NewtonSkeletonContainerCreate(world, rootBone, onDestroyCallback); }
	NEWTONWRAPPER_API void WRAP_NewtonSkeletonContainerDelete (NewtonSkeletonContainer* const skeleton)
		{ NewtonSkeletonContainerDelete(skeleton); }
	NEWTONWRAPPER_API int WRAP_NewtonSkeletonGetSolverMode(const NewtonSkeletonContainer* const skeleton)
		{ return NewtonSkeletonGetSolverMode(skeleton); }
	NEWTONWRAPPER_API void WRAP_NewtonSkeletonSetSolverMode(NewtonSkeletonContainer* const skeleton, int hardJointMotors)
		{ NewtonSkeletonSetSolverMode(skeleton, hardJointMotors); }
	NEWTONWRAPPER_API void WRAP_NewtonSkeletonContainerAttachJointArray (NewtonSkeletonContainer* const skeleton, int jointCount, NewtonJoint** const jointArray)
		{ NewtonSkeletonContainerAttachJointArray(skeleton, jointCount, jointArray); }
	NEWTONWRAPPER_API void* WRAP_NewtonSkeletonContainerAttachBone (NewtonSkeletonContainer* const skeleton, NewtonBody* const childBone, NewtonBody* const parentBone)
		{ return NewtonSkeletonContainerAttachBone(skeleton, childBone, parentBone); }
	NEWTONWRAPPER_API void WRAP_NewtonSkeletonContainerFinalize (NewtonSkeletonContainer* const skeleton)
		{ NewtonSkeletonContainerFinalize(skeleton); }
	NEWTONWRAPPER_API void* WRAP_NewtonSkeletonContainerGetRoot (const NewtonSkeletonContainer* const skeleton)
		{ return NewtonSkeletonContainerGetRoot(skeleton); }
	NEWTONWRAPPER_API void* WRAP_NewtonSkeletonContainerGetParent (const NewtonSkeletonContainer* const skeleton, void* const node)
		{ return NewtonSkeletonContainerGetParent(skeleton, node); }
	NEWTONWRAPPER_API void* WRAP_NewtonSkeletonContainerFirstChild (const NewtonSkeletonContainer* const skeleton, void* const parent)
		{ return NewtonSkeletonContainerFirstChild(skeleton, parent); }
	NEWTONWRAPPER_API void* WRAP_NewtonSkeletonContainerNextSibling (const NewtonSkeletonContainer* const skeleton, void* const sibling)
		{ return NewtonSkeletonContainerNextSibling(skeleton, sibling); }
	NEWTONWRAPPER_API NewtonBody* WRAP_NewtonSkeletonContainerGetBodyFromNode (const NewtonSkeletonContainer* const skeleton, void* const node)
		{ return NewtonSkeletonContainerGetBodyFromNode(skeleton, node); }
	NEWTONWRAPPER_API NewtonJoint* WRAP_NewtonSkeletonContainerGetParentJointFromNode (const NewtonSkeletonContainer* const skeleton, void* const node)
		{ return NewtonSkeletonContainerGetParentJointFromNode(skeleton, node); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreate(const NewtonWorld* const newtonWorld)
		{ return NewtonMeshCreate(newtonWorld); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateFromMesh(const NewtonMesh* const mesh)
		{ return NewtonMeshCreateFromMesh(mesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateFromCollision(const NewtonCollision* const collision)
		{ return NewtonMeshCreateFromCollision(collision); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateConvexHull (const NewtonWorld* const newtonWorld, int pointCount, const dFloat* const vertexCloud, int strideInBytes, dFloat tolerance)
		{ return NewtonMeshCreateConvexHull(newtonWorld, pointCount, vertexCloud, strideInBytes, tolerance); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateDelaunayTetrahedralization (const NewtonWorld* const newtonWorld, int pointCount, const dFloat* const vertexCloud, int strideInBytes, int materialID, const dFloat* const textureMatrix)
		{ return NewtonMeshCreateDelaunayTetrahedralization(newtonWorld, pointCount, vertexCloud, strideInBytes, materialID, textureMatrix); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateVoronoiConvexDecomposition (const NewtonWorld* const newtonWorld, int pointCount, const dFloat* const vertexCloud, int strideInBytes, int materialID, const dFloat* const textureMatrix)
		{ return NewtonMeshCreateVoronoiConvexDecomposition(newtonWorld, pointCount, vertexCloud, strideInBytes, materialID, textureMatrix); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateFromSerialization (const NewtonWorld* const newtonWorld, NewtonDeserializeCallback deserializeFunction, void* const serializeHandle)
		{ return NewtonMeshCreateFromSerialization(newtonWorld, deserializeFunction, serializeHandle); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshDestroy(const NewtonMesh* const mesh)
		{ NewtonMeshDestroy(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshSerialize (const NewtonMesh* const mesh, NewtonSerializeCallback serializeFunction, void* const serializeHandle)
		{ NewtonMeshSerialize(mesh, serializeFunction, serializeHandle); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshSaveOFF(const NewtonMesh* const mesh, const char* const filename)
		{ NewtonMeshSaveOFF(mesh, filename); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshLoadOFF(const NewtonWorld* const newtonWorld, const char* const filename)
		{ return NewtonMeshLoadOFF(newtonWorld, filename); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshApplyTransform (const NewtonMesh* const mesh, const dFloat* const matrix)
		{ NewtonMeshApplyTransform(mesh, matrix); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshCalculateOOBB(const NewtonMesh* const mesh, dFloat* const matrix, dFloat* const x, dFloat* const y, dFloat* const z)
		{ NewtonMeshCalculateOOBB(mesh, matrix, x, y, z); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshCalculateVertexNormals(const NewtonMesh* const mesh, dFloat angleInRadians)
		{ NewtonMeshCalculateVertexNormals(mesh, angleInRadians); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshApplySphericalMapping(const NewtonMesh* const mesh, int material)
		{ NewtonMeshApplySphericalMapping(mesh, material); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshApplyCylindricalMapping(const NewtonMesh* const mesh, int cylinderMaterial, int capMaterial)
		{ NewtonMeshApplyCylindricalMapping(mesh, cylinderMaterial, capMaterial); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshApplyBoxMapping(const NewtonMesh* const mesh, int frontMaterial, int sideMaterial, int topMaterial)
		{ NewtonMeshApplyBoxMapping(mesh, frontMaterial, sideMaterial, topMaterial); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshApplyAngleBasedMapping(const NewtonMesh* const mesh, int material, NewtonReportProgress reportPrograssCallback, void* const reportPrgressUserData)
		{ NewtonMeshApplyAngleBasedMapping(mesh, material, reportPrograssCallback, reportPrgressUserData); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshIsOpenMesh (const NewtonMesh* const mesh)
		{ return NewtonMeshIsOpenMesh(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshFixTJoints (const NewtonMesh* const mesh)
		{ NewtonMeshFixTJoints(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshPolygonize (const NewtonMesh* const mesh)
		{ NewtonMeshPolygonize(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshTriangulate (const NewtonMesh* const mesh)
		{ NewtonMeshTriangulate(mesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshUnion (const NewtonMesh* const mesh, const NewtonMesh* const clipper, const dFloat* const clipperMatrix)
		{ return NewtonMeshUnion(mesh, clipper, clipperMatrix); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshDifference (const NewtonMesh* const mesh, const NewtonMesh* const clipper, const dFloat* const clipperMatrix)
		{ return NewtonMeshDifference(mesh, clipper, clipperMatrix); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshIntersection (const NewtonMesh* const mesh, const NewtonMesh* const clipper, const dFloat* const clipperMatrix)
		{ return NewtonMeshIntersection(mesh, clipper, clipperMatrix); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshClip (const NewtonMesh* const mesh, const NewtonMesh* const clipper, const dFloat* const clipperMatrix, NewtonMesh** const topMesh, NewtonMesh** const bottomMesh)
		{ NewtonMeshClip(mesh, clipper, clipperMatrix, topMesh, bottomMesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshConvexMeshIntersection (const NewtonMesh* const mesh, const NewtonMesh* const convexMesh)
		{ return NewtonMeshConvexMeshIntersection(mesh, convexMesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshSimplify (const NewtonMesh* const mesh, int maxVertexCount, NewtonReportProgress reportPrograssCallback, void* const reportPrgressUserData)
		{ return NewtonMeshSimplify(mesh, maxVertexCount, reportPrograssCallback, reportPrgressUserData); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshApproximateConvexDecomposition (const NewtonMesh* const mesh, dFloat maxConcavity, dFloat backFaceDistanceFactor, int maxCount, int maxVertexPerHull, NewtonReportProgress reportProgressCallback, void* const reportProgressUserData)
		{ return NewtonMeshApproximateConvexDecomposition(mesh, maxConcavity, backFaceDistanceFactor, maxCount, maxVertexPerHull, reportProgressCallback, reportProgressUserData); }
	NEWTONWRAPPER_API void WRAP_NewtonRemoveUnusedVertices(const NewtonMesh* const mesh, int* const vertexRemapTable)
		{ NewtonRemoveUnusedVertices(mesh, vertexRemapTable); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshBeginFace(const NewtonMesh* const mesh)
		{ NewtonMeshBeginFace(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshAddFace(const NewtonMesh* const mesh, int vertexCount, const dFloat* const vertex, int strideInBytes, int materialIndex)
		{ NewtonMeshAddFace(mesh, vertexCount, vertex, strideInBytes, materialIndex); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshEndFace(const NewtonMesh* const mesh)
		{ NewtonMeshEndFace(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshBuildFromVertexListIndexList(const NewtonMesh* const mesh, int faceCount, const int* const faceIndexCount, const int* const faceMaterialIndex, const dFloat* const vertex, int vertexStrideInBytes, const int* const vertexIndex, const dFloat* const normal, int normalStrideInBytes, const int* const normalIndex, const dFloat* const uv0, int uv0StrideInBytes, const int* const uv0Index, const dFloat* const uv1, int uv1StrideInBytes, const int* const uv1Index)
		{ NewtonMeshBuildFromVertexListIndexList(mesh, faceCount, faceIndexCount, faceMaterialIndex, vertex, vertexStrideInBytes, vertexIndex, normal, normalStrideInBytes, normalIndex, uv0, uv0StrideInBytes, uv0Index, uv1, uv1StrideInBytes, uv1Index); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetVertexStreams (const NewtonMesh* const mesh, int vertexStrideInByte, dFloat* const vertex, int normalStrideInByte, dFloat* const normal, int uvStrideInByte0, dFloat* const uv0, int uvStrideInByte1, dFloat* const uv1)
		{ NewtonMeshGetVertexStreams(mesh, vertexStrideInByte, vertex, normalStrideInByte, normal, uvStrideInByte0, uv0, uvStrideInByte1, uv1); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetIndirectVertexStreams(const NewtonMesh* const mesh, int vertexStrideInByte, dFloat* const vertex, int* const vertexIndices, int* const vertexCount, int normalStrideInByte, dFloat* const normal, int* const normalIndices, int* const normalCount, int uvStrideInByte0, dFloat* const uv0, int* const uvIndices0, int* const uvCount0, int uvStrideInByte1, dFloat* const uv1, int* const uvIndices1, int* const uvCount1)
		{ NewtonMeshGetIndirectVertexStreams(mesh, vertexStrideInByte, vertex, vertexIndices, vertexCount, normalStrideInByte, normal, normalIndices, normalCount, uvStrideInByte0, uv0, uvIndices0, uvCount0, uvStrideInByte1, uv1, uvIndices1, uvCount1); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshBeginHandle (const NewtonMesh* const mesh)
		{ return NewtonMeshBeginHandle(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshEndHandle (const NewtonMesh* const mesh, void* const handle)
		{ NewtonMeshEndHandle(mesh, handle); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshFirstMaterial (const NewtonMesh* const mesh, void* const handle)
		{ return NewtonMeshFirstMaterial(mesh, handle); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshNextMaterial (const NewtonMesh* const mesh, void* const handle, int materialId)
		{ return NewtonMeshNextMaterial(mesh, handle, materialId); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshMaterialGetMaterial (const NewtonMesh* const mesh, void* const handle, int materialId)
		{ return NewtonMeshMaterialGetMaterial(mesh, handle, materialId); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshMaterialGetIndexCount (const NewtonMesh* const mesh, void* const handle, int materialId)
		{ return NewtonMeshMaterialGetIndexCount(mesh, handle, materialId); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshMaterialGetIndexStream (const NewtonMesh* const mesh, void* const handle, int materialId, int* const index)
		{ NewtonMeshMaterialGetIndexStream(mesh, handle, materialId, index); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshMaterialGetIndexStreamShort (const NewtonMesh* const mesh, void* const handle, int materialId, short int* const index)
		{ NewtonMeshMaterialGetIndexStreamShort(mesh, handle, materialId, index); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateFirstSingleSegment (const NewtonMesh* const mesh)
		{ return NewtonMeshCreateFirstSingleSegment(mesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateNextSingleSegment (const NewtonMesh* const mesh, const NewtonMesh* const segment)
		{ return NewtonMeshCreateNextSingleSegment(mesh, segment); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateFirstLayer (const NewtonMesh* const mesh)
		{ return NewtonMeshCreateFirstLayer(mesh); }
	NEWTONWRAPPER_API NewtonMesh* WRAP_NewtonMeshCreateNextLayer (const NewtonMesh* const mesh, const NewtonMesh* const segment)
		{ return NewtonMeshCreateNextLayer(mesh, segment); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetTotalFaceCount (const NewtonMesh* const mesh)
		{ return NewtonMeshGetTotalFaceCount(mesh); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetTotalIndexCount (const NewtonMesh* const mesh)
		{ return NewtonMeshGetTotalIndexCount(mesh); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetFaces (const NewtonMesh* const mesh, int* const faceIndexCount, int* const faceMaterial, void** const faceIndices)
		{ NewtonMeshGetFaces(mesh, faceIndexCount, faceMaterial, faceIndices); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetPointCount (const NewtonMesh* const mesh)
		{ return NewtonMeshGetPointCount(mesh); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetPointStrideInByte (const NewtonMesh* const mesh)
		{ return NewtonMeshGetPointStrideInByte(mesh); }
	NEWTONWRAPPER_API dFloat64* WRAP_NewtonMeshGetPointArray (const NewtonMesh* const mesh)
		{ return NewtonMeshGetPointArray(mesh); }
	NEWTONWRAPPER_API dFloat64* WRAP_NewtonMeshGetNormalArray (const NewtonMesh* const mesh)
		{ return NewtonMeshGetNormalArray(mesh); }
	NEWTONWRAPPER_API dFloat64* WRAP_NewtonMeshGetUV0Array (const NewtonMesh* const mesh)
		{ return NewtonMeshGetUV0Array(mesh); }
	NEWTONWRAPPER_API dFloat64* WRAP_NewtonMeshGetUV1Array (const NewtonMesh* const mesh)
		{ return NewtonMeshGetUV1Array(mesh); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetVertexCount (const NewtonMesh* const mesh)
		{ return NewtonMeshGetVertexCount(mesh); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetVertexStrideInByte (const NewtonMesh* const mesh)
		{ return NewtonMeshGetVertexStrideInByte(mesh); }
	NEWTONWRAPPER_API dFloat64* WRAP_NewtonMeshGetVertexArray (const NewtonMesh* const mesh)
		{ return NewtonMeshGetVertexArray(mesh); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetFirstVertex (const NewtonMesh* const mesh)
		{ return NewtonMeshGetFirstVertex(mesh); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetNextVertex (const NewtonMesh* const mesh, const void* const vertex)
		{ return NewtonMeshGetNextVertex(mesh, vertex); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetVertexIndex (const NewtonMesh* const mesh, const void* const vertex)
		{ return NewtonMeshGetVertexIndex(mesh, vertex); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetFirstPoint (const NewtonMesh* const mesh)
		{ return NewtonMeshGetFirstPoint(mesh); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetNextPoint (const NewtonMesh* const mesh, const void* const point)
		{ return NewtonMeshGetNextPoint(mesh, point); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetPointIndex (const NewtonMesh* const mesh, const void* const point)
		{ return NewtonMeshGetPointIndex(mesh, point); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetVertexIndexFromPoint (const NewtonMesh* const mesh, const void* const point)
		{ return NewtonMeshGetVertexIndexFromPoint(mesh, point); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetFirstEdge (const NewtonMesh* const mesh)
		{ return NewtonMeshGetFirstEdge(mesh); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetNextEdge (const NewtonMesh* const mesh, const void* const edge)
		{ return NewtonMeshGetNextEdge(mesh, edge); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetEdgeIndices (const NewtonMesh* const mesh, const void* const edge, int* const v0, int* const v1)
		{ NewtonMeshGetEdgeIndices(mesh, edge, v0, v1); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetFirstFace (const NewtonMesh* const mesh)
		{ return NewtonMeshGetFirstFace(mesh); }
	NEWTONWRAPPER_API void* WRAP_NewtonMeshGetNextFace (const NewtonMesh* const mesh, const void* const face)
		{ return NewtonMeshGetNextFace(mesh, face); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshIsFaceOpen (const NewtonMesh* const mesh, const void* const face)
		{ return NewtonMeshIsFaceOpen(mesh, face); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetFaceMaterial (const NewtonMesh* const mesh, const void* const face)
		{ return NewtonMeshGetFaceMaterial(mesh, face); }
	NEWTONWRAPPER_API int WRAP_NewtonMeshGetFaceIndexCount (const NewtonMesh* const mesh, const void* const face)
		{ return NewtonMeshGetFaceIndexCount(mesh, face); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetFaceIndices (const NewtonMesh* const mesh, const void* const face, int* const indices)
		{ NewtonMeshGetFaceIndices(mesh, face, indices); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshGetFacePointIndices (const NewtonMesh* const mesh, const void* const face, int* const indices)
		{ NewtonMeshGetFacePointIndices(mesh, face, indices); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshCalculateFaceNormal (const NewtonMesh* const mesh, const void* const face, dFloat64* const normal)
		{ NewtonMeshCalculateFaceNormal(mesh, face, normal); }
	NEWTONWRAPPER_API void WRAP_NewtonMeshSetFaceMaterial (const NewtonMesh* const mesh, const void* const face, int matId)
		{ NewtonMeshSetFaceMaterial(mesh, face, matId); }
}
