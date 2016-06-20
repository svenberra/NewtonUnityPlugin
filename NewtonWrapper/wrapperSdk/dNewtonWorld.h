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


typedef void(*OnApplyForceAndTorqueCallback)(dFloat timestep);

class dNewtonWorld: public dAlloc
{
	public:
	dNewtonWorld();
	virtual ~dNewtonWorld();
	void Update(dFloat timestepInSecunds, OnApplyForceAndTorqueCallback forceCallback);

	void SetFrameRate(dFloat frameRate);
	const dVector& GetGravity() const;
	void SetGravity(const dVector& gravity);
	void SetGravity(dFloat x, dFloat y, dFloat z);
	void SetAsyncUpdate(bool updateMode);

	private:
	void UpdateWorld(OnApplyForceAndTorqueCallback forceCallback);

	NewtonWorld* m_world;
	dList<dNewtonCollision*> m_collisionCache;
	dLong m_realTimeInMicrosecunds;
	dLong m_timeStepInMicrosecunds;
	
	dFloat m_timeStep;
	dFloat m_interpotationParam;

	dVector  m_gravity;
	bool m_asyncUpdateMode;

	friend class dNewtonBody;
	friend class dNewtonCollision;
	friend class dNewtonDynamicBody;
	friend class dNewtonCollisionBox;
	friend class dNewtonCollisionNull;
	friend class dNewtonCollisionCone;
	friend class dNewtonCollisionSphere;
	friend class dNewtonCollisionCapsule;
	friend class dNewtonCollisionCylinder;
	friend class dNewtonCollisionChamferedCylinder;
};

#endif
