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

#ifndef _D_NEWTON_WORLD_H_
#define _D_NEWTON_WORLD_H_

#include "stdafx.h"
#include "dAlloc.h"

class NewtonWorld;
class dNewtonBody;
class dNewtonCollision;
class dNewtonCollisionBox;


typedef void(*OnWorldUpdateCallback)(dFloat timestep);

class dNewtonWorld: public dAlloc
{
	public:
	class dMaterialProperties
	{
		public:
		float m_restitution;
		float m_staticFriction;
		float m_kineticFriction;
		bool m_collisionEnable;
	};

	dNewtonWorld();
	virtual ~dNewtonWorld();
	void Update(dFloat timestepInSeconds, OnWorldUpdateCallback forceCallback);

	void SetSolverMode(int mode);
	void SetFrameRate(dFloat frameRate);
	const dVector& GetGravity() const;
	void SetGravity(const dVector& gravity);
	void SetGravity(dFloat x, dFloat y, dFloat z);
	void SetAsyncUpdate(bool updateMode);
	void SetThreadsCount(int threads);
	void SetBroadPhase(int broadphase);
	void SetSubSteps(int subSteps);

	long long GetMaterialKey(int materialID0, int materialID1) const;
	void SetDefaultMaterial(float restitution, float staticFriction, float kineticFriction, bool collisionEnable);
	void SetMaterialInteraction(int materialID0, int materialID1, float restitution, float staticFriction, float kineticFriction, bool collisionEnable);

	private:
	void UpdateWorld(OnWorldUpdateCallback forceCallback);

	const dMaterialProperties& FindMaterial(int id0, int id1) const;
	static void OnContactCollision(const NewtonJoint* contactJoint, dFloat timestep, int threadIndex);
	static int OnBodiesAABBOverlap(const NewtonMaterial* const material, const NewtonBody* const body0, const NewtonBody* const body1, int threadIndex);
	static int OnSubShapeAABBOverlapTest(const NewtonMaterial* const material, const NewtonBody* const body0, const void* const collisionNode0, const NewtonBody* const body1, const void* const collisionNode1, int threadIndex);

	NewtonWorld* m_world;
	dList<dNewtonCollision*> m_collisionCache;
	dTree<dMaterialProperties, long long> m_materialGraph;
	dLong m_realTimeInMicroSeconds;
	dLong m_timeStepInMicroSeconds;
	
	dFloat m_timeStep;
	dFloat m_interpotationParam;

	dVector  m_gravity;
	bool m_asyncUpdateMode;

	dMaterialProperties m_defaultMaterial;

	friend class dNewtonBody;
	friend class dNewtonCollision;
	friend class dNewtonDynamicBody;
	friend class dNewtonCollisionBox;
	friend class dNewtonCollisionMesh;
	friend class dNewtonCollisionNull;
	friend class dNewtonCollisionCone;
	friend class dNewtonCollisionSphere;
	friend class dNewtonCollisionCapsule;
	friend class dNewtonCollisionCylinder;
	friend class dNewtonCollisionCompound;
	friend class dNewtonCollisionConvexHull;
	
	friend class dNewtonCollisionChamferedCylinder;
};

#endif
