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
/*
class dNewtonBody;
class dNewtonWorld;
class CustomJoint;

class dNewtonJoint: public dAlloc
{
	public:
	dNewtonJoint(dNewtonWorld* const world);
	virtual ~dNewtonJoint();

//	virtual void DebugRender(OnDrawFaceCallback callback, const dFloat* const eyePoint);

	protected:
//	static void DebugRenderCallback (void* userData, int vertexCount, const dFloat* faceVertec, int id);
	CustomJoint* m_joint;
	dNewtonWorld* m_myWorld;

	friend class dNewtonBody;
	friend class dNewtonWorld;
	friend class dNewtonDynamicBody;
};

/*
class dNewtonBallAndSocket: public dNewtonJoint
{
	public:
	dNewtonBallAndSocket(dNewtonWorld* const world);
};


class dNewtonHinge: public dNewtonJoint
{
	public:
	dNewtonBallAndSocket(dNewtonWorld* const world);
};
*/
#endif
