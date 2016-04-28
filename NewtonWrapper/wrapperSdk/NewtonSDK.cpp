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
#include "Newton.h"
#include "NewtonSDK.h"
#include "MemoryAlloc.h"

NewtonSDK::NewtonSDK()
	:MemoryAlloc()
{
	// create a newton world
	m_world = NewtonCreate();

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

	// set the timer
	ResetTimer();
*/
}

NewtonSDK::~NewtonSDK()
{
	NewtonWaitForUpdateToFinish (m_world);
	NewtonDestroy (m_world);
}

