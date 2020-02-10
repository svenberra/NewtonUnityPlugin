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

#ifndef _D_NEWTON_VEHICLE_H_
#define _D_NEWTON_VEHICLE_H_

#include "stdafx.h"
#include "dAlloc.h"
#include "dNewtonBody.h"

#if 0
class dNewtonVehicle;

class dTireData
{
	public:
	dMatrix matrix;
	dFloat mass;
	void* m_owner;
};

class dNewtonWheel: public dAlloc
{
	public:
	dNewtonWheel(dNewtonVehicle* const owner, dTireData tire);
	~dNewtonWheel();

	void* GetUserData();
	
	private:
//	dCustomVehicleController::dBodyPartTire* m_wheel;
	void* m_owner;
};

class dNewtonVehicle: public dNewtonDynamicBody
{
	public:

	dNewtonVehicle(dNewtonWorld* const world, dNewtonCollision* const collision, dMatrix matrix, dFloat mass);
	~dNewtonVehicle();

//	dCustomVehicleController::dBodyPartTire* AddTire(dTireData tire);

//	dCustomVehicleController* m_controller;
};
#endif

#endif
