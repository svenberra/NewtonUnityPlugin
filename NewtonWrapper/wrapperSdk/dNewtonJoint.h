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

#ifndef _D_NEWTON_JOINT_H_
#define _D_NEWTON_JOINT_H_

#include "stdafx.h"
#include "dAlloc.h"
#include <CustomJoint.h>

class dNewtonJoint: public dAlloc
{
	public:
	dNewtonJoint()
		:dAlloc()
		,m_joint(NULL)
	{
	}

	protected:
	void SetJoint(CustomJoint* const joint)
	{
		m_joint = joint;
	}

	CustomJoint* m_joint;
};

/*
class dNewtonBallAndSocket: public dNewtonJoint
{
	public:
	dNewtonBallAndSocket(dNewtonWorld* const world);
};
*/


class dNewtonHinge: public dNewtonJoint
{
	public:
	dNewtonHinge(dFloat* const pintAndPivotMatrix, void* const body0);
	dNewtonHinge(dFloat* const pintAndPivotMatrix, void* const body0, void* const body1);
};

class dNewtonHingeActuator : public dNewtonJoint
{
	public:
	dNewtonHingeActuator(dFloat* const pintAndPivotMatrix, void* const body0);
	dNewtonHingeActuator(dFloat* const pintAndPivotMatrix, void* const body0, void* const body1);
};


#endif
