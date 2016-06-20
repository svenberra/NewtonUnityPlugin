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
	,m_realTimeInMicrosecunds(0)
	,m_timeStepInMicrosecunds (0)
	,m_timeStep(0.0f)
	,m_interpotationParam(0.0f)
	,m_gravity(0.0f, 0.0f, 0.0f, 0.0f)
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

	// use default material to implement traditional "Game style" one side material system
	int defaultMaterial = NewtonMaterialGetDefaultGroupID (m_world);
	NewtonMaterialSetCallbackUserData (m_world, defaultMaterial, defaultMaterial, m_world);
	NewtonMaterialSetCompoundCollisionCallback(m_world, defaultMaterial, defaultMaterial, OnCompoundSubCollisionAABBOverlap);
	NewtonMaterialSetCollisionCallback (m_world, defaultMaterial, defaultMaterial, OnBodiesAABBOverlap, OnContactProcess);

	// add a hierarchical transform manage to update local transforms
	new NewtonSDKTransformManager (this);
*/

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

void dNewtonWorld::SetFrameRate(dFloat frameRate)
{
	m_timeStep = 1.0f / frameRate;
	m_realTimeInMicrosecunds = 0;
	m_timeStepInMicrosecunds = (dLong)(1000000.0 / double(frameRate));
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

void dNewtonWorld::UpdateWorld(OnApplyForceAndTorqueCallback forceCallback)
{
	NewtonWaitForUpdateToFinish(m_world);

	for (NewtonBody* bodyPtr = NewtonWorldGetFirstBody(m_world); bodyPtr; bodyPtr = NewtonWorldGetNextBody(m_world, bodyPtr)) {
		dNewtonBody* const body = (dNewtonBody*)NewtonBodyGetUserData(bodyPtr);
		body->InitForceAccumulators();
	}

	forceCallback(m_timeStep);
	NewtonUpdate(m_world, m_timeStep);
}

void dNewtonWorld::Update(dFloat timestepInSecunds, OnApplyForceAndTorqueCallback forceCallback)
{
	dLong timestepMicrosecunds = dClamp((dLong)(double(timestepInSecunds) * 1000000.0f), dLong(0), m_timeStepInMicrosecunds);
	m_realTimeInMicrosecunds += timestepMicrosecunds;

	for (bool doUpate = true; m_realTimeInMicrosecunds >= m_timeStepInMicrosecunds; doUpate = false) {
		if (doUpate) {
			UpdateWorld(forceCallback);
		}
		m_realTimeInMicrosecunds -= m_timeStepInMicrosecunds;
		dAssert(m_realTimeInMicrosecunds >= 0);
	}
	dAssert(m_realTimeInMicrosecunds >= 0);
	dAssert(m_realTimeInMicrosecunds < m_timeStepInMicrosecunds);

	m_interpotationParam = dFloat (double(m_realTimeInMicrosecunds) / double(m_timeStepInMicrosecunds));
}
