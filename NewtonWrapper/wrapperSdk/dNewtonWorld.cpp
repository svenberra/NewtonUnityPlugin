/*
* This software is provided 'as-is', without any express or implied
* warranty. In no event will the authors be held liable for any damages
* arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
*/

#include "stdafx.h"
#include "dAlloc.h"
#include "dNewtonBody.h"
#include "dNewtonWorld.h"
#include "dNewtonCollision.h"

#define D_DEFAULT_FPS 120.0f


dNewtonWorld::dNewtonWorld()
	:dAlloc()
	,m_world (NewtonCreate())
	,m_collisionCache()
	,m_materialGraph()
	,m_realTimeInMicroSeconds(0)
	,m_timeStepInMicroSeconds (0)
	,m_timeStep(0.0f)
	,m_interpotationParam(0.0f)
	,m_gravity(0.0f, 0.0f, 0.0f, 0.0f)
	,m_asyncUpdateMode(true)
	,m_onUpdateCallback(NULL)
{
	// for two way communication between low and high lever, link the world with this class for 
	NewtonWorldSetUserData(m_world, this);

	// set the simplified solver mode (faster but less accurate)
	NewtonSetSolverModel (m_world, 1);

/*
	// by default runs on four micro threads
	NewtonSetThreadsCount(m_world, 4);

	// set the collision copy constructor callback
	NewtonSDKSetCollisionConstructorDestructorCallback (m_world, OnCollisionCopyConstruct, OnCollisionDestructorCallback);

	// add a hierarchical transform manage to update local transforms
	new NewtonSDKTransformManager (this);
*/

	// use default material to implement traditional "Game style" one side material system
	int defaultMaterial = NewtonMaterialGetDefaultGroupID(m_world);
	NewtonMaterialSetCallbackUserData(m_world, defaultMaterial, defaultMaterial, this);
	NewtonMaterialSetCompoundCollisionCallback(m_world, defaultMaterial, defaultMaterial, OnSubShapeAABBOverlapTest);
	NewtonMaterialSetCollisionCallback(m_world, defaultMaterial, defaultMaterial, OnBodiesAABBOverlap, OnContactCollision);

	// set joint serialization call back
	CustomJoint::Initalize(m_world);
	SetFrameRate(D_DEFAULT_FPS);
}

dNewtonWorld::~dNewtonWorld()
{
	NewtonWaitForUpdateToFinish (m_world);

	dList<dNewtonCollision*>::dListNode* next;
	for (dList<dNewtonCollision*>::dListNode* node = m_collisionCache.GetFirst(); node; node = next) {
		next = node->GetNext();
		node->GetInfo()->DeleteShape();
	}
	NewtonDestroy (m_world);
}

long long dNewtonWorld::GetMaterialKey(int materialID0, int materialID1) const
{
	if (materialID0 > materialID1) {
		dSwap(materialID0, materialID1);
	}
	return (long long (materialID1) << 32) + long long(materialID0);
}

void dNewtonWorld::SetCallbacks(OnWorldUpdateCallback forceCallback, OnWorldBodyTransfromUpdateCallback tranformCallback)
{
	m_onUpdateCallback = forceCallback;
	m_onTransformCallback = tranformCallback;
}

const dNewtonWorld::dMaterialProperties& dNewtonWorld::FindMaterial(int id0, int id1) const
{
	long long key = GetMaterialKey(id0, id1);
	dTree<dMaterialProperties, long long>::dTreeNode* const node = m_materialGraph.Find(key);
	if (node) {
		return node->GetInfo();
	}
	return m_defaultMaterial;
}

void dNewtonWorld::SetDefaultMaterial(float restitution, float staticFriction, float kineticFriction, bool collisionEnable)
{
	m_defaultMaterial.m_restitution = restitution;
	m_defaultMaterial.m_staticFriction = staticFriction;
	m_defaultMaterial.m_kineticFriction = kineticFriction;
	m_defaultMaterial.m_collisionEnable = collisionEnable;
}

void dNewtonWorld::SetMaterialInteraction(int materialID0, int materialID1, float restitution, float staticFriction, float kineticFriction, bool collisionEnable)
{
	long long key = GetMaterialKey(materialID0, materialID1);
	dTree<dMaterialProperties, long long>::dTreeNode* node = m_materialGraph.Find(key);
	if (!node) {
		node = m_materialGraph.Insert(key);
	}
	dMaterialProperties& material = node->GetInfo();
	material.m_restitution = restitution;
	material.m_staticFriction = staticFriction;
	material.m_kineticFriction = kineticFriction;
	material.m_collisionEnable = collisionEnable;
}

void dNewtonWorld::SetFrameRate(dFloat frameRate)
{
	m_timeStep = 1.0f / frameRate;
	m_realTimeInMicroSeconds = 0;
	m_timeStepInMicroSeconds = (dLong)(1000000.0 / double(frameRate));
}

void dNewtonWorld::SetSubSteps(int subSteps)
{
	NewtonSetNumberOfSubsteps(m_world, dClamp(subSteps, 1, 4));
}

void dNewtonWorld::SetSolverMode(int mode)
{
	NewtonSetSolverModel(m_world, dClamp (mode, 1, 1000));
}

void dNewtonWorld::SetThreadsCount(int threads)
{
	NewtonSetThreadsCount(m_world, dClamp (threads, 0, 8));
}

void dNewtonWorld::SetBroadPhase(int broadphase)
{
	NewtonSelectBroadphaseAlgorithm(m_world, broadphase ? 0 : 1);
}

const dVector& dNewtonWorld::GetGravity() const
{
	return m_gravity;
}

void dNewtonWorld::SetGravity(const dVector& gravity)
{
	m_gravity = gravity;
	m_gravity.m_w = 0.0f;
}

void dNewtonWorld::SetGravity(dFloat x, dFloat y, dFloat z)
{
	SetGravity(dVector(x, y, z, 0.0f));
}

void dNewtonWorld::SetAsyncUpdate(bool updateMode)
{
	m_asyncUpdateMode = updateMode;
}

void dNewtonWorld::UpdateWorld()
{
//	NewtonWaitForUpdateToFinish(m_world);

	for (NewtonBody* bodyPtr = NewtonWorldGetFirstBody(m_world); bodyPtr; bodyPtr = NewtonWorldGetNextBody(m_world, bodyPtr)) {
		dNewtonBody* const body = (dNewtonBody*)NewtonBodyGetUserData(bodyPtr);
		body->InitForceAccumulators();
	}

	// every rigid body update
//	m_onUpdateCallback(m_timeStep);

static int xxx = 0;
if (!xxx)
{
	xxx = 1;
	NewtonSerializeToFile(m_world, "xxxxxxx.bin", NULL, NULL);
}

	if (m_asyncUpdateMode) {
//		NewtonUpdateAsync(m_world, m_timeStep);
	} else {
//		NewtonUpdate(m_world, m_timeStep);
	}
	NewtonUpdate(m_world, m_timeStep);
}

void dNewtonWorld::Update(dFloat timestepInSeconds)
{
	int maxInterations = 1;
	dLong timestepMicroSeconds = dClamp((dLong)(double(timestepInSeconds) * 1000000.0f), dLong(0), m_timeStepInMicroSeconds);
	m_realTimeInMicroSeconds += timestepMicroSeconds * maxInterations;

	for (int doUpate = maxInterations; m_realTimeInMicroSeconds >= m_timeStepInMicroSeconds; doUpate --) {
		if (doUpate) {
			//UpdateWorld(forceCallback);
			UpdateWorld();
		}
		m_realTimeInMicroSeconds -= m_timeStepInMicroSeconds;
		dAssert(m_realTimeInMicroSeconds >= 0);
	}
	dAssert(m_realTimeInMicroSeconds >= 0);
	dAssert(m_realTimeInMicroSeconds < m_timeStepInMicroSeconds);

	// call every frame update
	m_interpotationParam = dFloat (double(m_realTimeInMicroSeconds) / double(m_timeStepInMicroSeconds));
	m_onTransformCallback();
}

dNewtonBody* dNewtonWorld::GetFirstBody() const
{
	NewtonBody* const body = NewtonWorldGetFirstBody(m_world);
	return body ? (dNewtonBody*)NewtonBodyGetUserData(body) : NULL;
}

dNewtonBody* dNewtonWorld::GetNextBody(dNewtonBody* const body) const
{
	NewtonBody* const nextBody = NewtonWorldGetNextBody(m_world, body->m_body);
	return nextBody ? (dNewtonBody*)NewtonBodyGetUserData(nextBody) : NULL;
}


void* dNewtonWorld::GetNextContactJoint(dNewtonBody* const body, void* const contact) const
{
	NewtonBody* const newtonBody = body->m_body;
	for (NewtonJoint* contactJoint = NewtonBodyGetNextContactJoint(newtonBody, (NewtonJoint*)contact); contactJoint; contactJoint = NewtonBodyGetNextContactJoint(newtonBody, contactJoint)) {
		if (NewtonJointIsActive(contactJoint)) {
			return contactJoint;
		}
	}
	return NULL;
}

void* dNewtonWorld::GetFirstContactJoint(dNewtonBody* const body) const
{
	NewtonBody* const newtonBody = body->m_body;
	for (NewtonJoint* contactJoint = NewtonBodyGetFirstContactJoint(body->m_body); contactJoint; contactJoint = NewtonBodyGetNextContactJoint(newtonBody, contactJoint)) {
		if (NewtonJointIsActive(contactJoint)) {
			return contactJoint;
		}
	}
	return NULL;
}

dNewtonBody* dNewtonWorld::GetBody0(void* const contact) const
{
	NewtonJoint* const contactJoint = (NewtonJoint*)contact;
	NewtonBody* const body = NewtonJointGetBody0(contactJoint);
	return (dNewtonBody*)NewtonBodyGetUserData(body);
}

dNewtonBody* dNewtonWorld::GetBody1(void* const contact) const
{
	NewtonJoint* const contactJoint = (NewtonJoint*)contact;
	NewtonBody* const body = NewtonJointGetBody1(contactJoint);
	return (dNewtonBody*)NewtonBodyGetUserData(body);
}

void* dNewtonWorld::GetBody0UserData(void* const contact) const
{
	NewtonJoint* const contactJoint = (NewtonJoint*)contact;
	NewtonBody* const body = NewtonJointGetBody0(contactJoint);
	dNewtonBody* const dBody = (dNewtonBody*)NewtonBodyGetUserData(body);
	return dBody->GetUserData();
}

void* dNewtonWorld::GetBody1UserData(void* const contact) const
{
	NewtonJoint* const contactJoint = (NewtonJoint*)contact;
	NewtonBody* const body = NewtonJointGetBody1(contactJoint);
	dNewtonBody* const dBody = (dNewtonBody*)NewtonBodyGetUserData(body);
	return dBody->GetUserData();
}


int dNewtonWorld::OnSubShapeAABBOverlapTest(const NewtonMaterial* const material, const NewtonBody* const body0, const void* const collisionNode0, const NewtonBody* const body1, const void* const collisionNode1, int threadIndex)
{
	return 1;
}

int dNewtonWorld::OnBodiesAABBOverlap(const NewtonMaterial* const material, const NewtonBody* const bodyPtr0, const NewtonBody* const bodyPtr1, int threadIndex)
{
	dNewtonWorld* const world = (dNewtonWorld*)NewtonMaterialGetMaterialPairUserData(material);
	NewtonCollision* const newtonCollision0 = (NewtonCollision*)NewtonBodyGetCollision(bodyPtr0);
	NewtonCollision* const newtonCollision1 = (NewtonCollision*)NewtonBodyGetCollision(bodyPtr1);
	dNewtonCollision* const collision0 = (dNewtonCollision*)NewtonCollisionGetUserData(newtonCollision0);
	dNewtonCollision* const collision1 = (dNewtonCollision*)NewtonCollisionGetUserData(newtonCollision1);
	const dMaterialProperties materialProp = world->FindMaterial(collision0->m_materialID, collision1->m_materialID);
	return materialProp.m_collisionEnable ? 1 : 0;
}

void dNewtonWorld::OnContactCollision(const NewtonJoint* contactJoint, dFloat timestep, int threadIndex)
{
	NewtonBody* const body0 = NewtonJointGetBody0(contactJoint);
//	NewtonBody* const body1 = NewtonJointGetBody1(contactJoint);
//	dNewtonBody* const dbody0 = (dNewtonBody*)NewtonBodyGetUserData(body0);
//	dNewtonBody* const dbody1 = (dNewtonBody*)NewtonBodyGetUserData(body1);
//	dbody0->m_onCollision(dbody1);
//	dbody1->m_onCollision(dbody0);

	dNewtonWorld* const world = (dNewtonWorld*)NewtonWorldGetUserData(NewtonBodyGetWorld(body0));

	const dMaterialProperties* lastMaterialProp = NULL;
	for (void* contact = NewtonContactJointGetFirstContact(contactJoint); contact; contact = NewtonContactJointGetNextContact(contactJoint, contact)) {
		NewtonMaterial* const material = NewtonContactGetMaterial(contact);

		NewtonCollision* const newtonCollision0 = (NewtonCollision*)NewtonContactGetCollision0(contact);
		NewtonCollision* const newtonCollision1 = (NewtonCollision*)NewtonContactGetCollision1(contact);
		dNewtonCollision* const collision0 = (dNewtonCollision*)NewtonCollisionGetUserData(newtonCollision0);
		dNewtonCollision* const collision1 = (dNewtonCollision*)NewtonCollisionGetUserData(newtonCollision1);
		const dMaterialProperties* const currentMaterialProp = &world->FindMaterial(collision0->m_materialID, collision1->m_materialID);
		dMaterialProperties materialProp(*currentMaterialProp);
		if (currentMaterialProp != lastMaterialProp) {
			lastMaterialProp = currentMaterialProp;
			// do a material callback here is needed
		}

		NewtonMaterialSetContactElasticity(material, materialProp.m_restitution);
		NewtonMaterialSetContactFrictionCoef(material, materialProp.m_staticFriction, materialProp.m_kineticFriction, 0);
		NewtonMaterialSetContactFrictionCoef(material, materialProp.m_staticFriction, materialProp.m_kineticFriction, 1);
	}
}
