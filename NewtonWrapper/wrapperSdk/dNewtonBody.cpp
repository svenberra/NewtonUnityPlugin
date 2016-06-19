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
#include "dNewtonBody.h"
#include "dNewtonWorld.h"
#include "dNewtonCollision.h"

#if 0
dNewtonBody::dNewtonBody(dBodyType type, dNewtonBody* const parent)
	:dNewtonAlloc()
	,dNewtonTransformLerp()
	,m_body(NULL)
	,m_child(NULL) 
	,m_sibling(NULL) 
	,m_parent(parent) 
	,m_boneArticulation(NULL)
	,m_userData(NULL)
	,m_bodyType(type)
{
}



NewtonBody* dNewtonBody::GetNewtonBody () const
{
	return m_body;
}

bool dNewtonBody::GetSleepState() const
{
	return NewtonBodyGetSleepState(m_body) ? true : false;
}

void dNewtonBody::SetSleepState(bool state) const
{
	NewtonBodySetSleepState(m_body, state ? 1 : 0);
}

bool dNewtonBody::GetAutoSleepMode() const
{
	return NewtonBodyGetSleepState(m_body) ? true : false;
}

void dNewtonBody::SetAutoSleepMode(bool mode)
{
	NewtonBodySetAutoSleep(m_body, mode ? 1 : 0);
}



void dNewtonBody::SetUserData(void* const userData)
{
	m_userData = userData;
}

void* dNewtonBody::GetUserData() const
{
	return m_userData;
}

void dNewtonBody::SetMatrix (const dFloat* const matrix)
{
	NewtonBodySetMatrix(m_body, matrix);
}

void dNewtonBody::GetMatrix (dFloat* const matrix) const
{
	NewtonBodyGetMatrix(m_body, matrix);
}

void dNewtonBody::SetVeloc (const dFloat* const veloc)
{
	NewtonBodySetVelocity(m_body, veloc);
}

void dNewtonBody::GetVeloc (dFloat* const veloc) const
{
	NewtonBodyGetVelocity(m_body, veloc);
}

void dNewtonBody::SetOmega (const dFloat* const omega)
{
	NewtonBodySetOmega(m_body, omega);
}

void dNewtonBody::GetOmega (dFloat* const omega) const
{
	NewtonBodyGetOmega(m_body, omega);
}

void dNewtonBody::SetForce (const dFloat* const force)
{
	NewtonBodySetForce(m_body, force);
}

void dNewtonBody::SetTorque (const dFloat* const torque)
{
	NewtonBodySetTorque(m_body, torque);
}

void dNewtonBody::AddForce (const dFloat* const force)
{
	NewtonBodyAddForce(m_body, force);
}

void dNewtonBody::AddTorque (const dFloat* const torque)
{
	NewtonBodyAddTorque(m_body, torque);
}


void dNewtonBody::GetCenterOfMass (dFloat* const com) const
{
	NewtonBodyGetCentreOfMass (m_body, com);
}

void dNewtonBody::SetCenterOfMass (const dFloat* const com)
{
	NewtonBodySetCentreOfMass (m_body, com);
}

dFloat dNewtonBody::GetLinearDrag () const
{
	return NewtonBodyGetLinearDamping (m_body);
}

void dNewtonBody::SetLinearDrag (const dFloat drag)
{
	NewtonBodySetLinearDamping (m_body, drag);
}

void dNewtonBody::GetAngularDrag (dFloat* const drag) const
{
	NewtonBodyGetAngularDamping (m_body, drag);
}

void dNewtonBody::SetAngularDrag (const dFloat* const drag)
{
	NewtonBodySetAngularDamping (m_body, drag);
}


void dNewtonBody::SetCCDMode (bool mode)
{
	NewtonBodySetContinuousCollisionMode(m_body, mode ? 1 : 0);
}

bool dNewtonBody::GetCCDMode () const
{
	return NewtonBodyGetContinuousCollisionMode(m_body) ? true : false;
}

void dNewtonBody::SetMassAndInertia (dFloat mass, const dNewtonCollision* const collision)
{
	NewtonCollision* const shape = collision->GetShape();
	NewtonBodySetMassProperties(m_body, mass, shape);
}

void dNewtonBody::SetMassAndInertia (dFloat mass, dFloat Ixx, dFloat Iyy, dFloat Izz)
{
    NewtonBodySetMassMatrix(m_body, mass, Ixx, Iyy, Izz);
}

void dNewtonBody::GetMassAndInertia (dFloat& mass, dFloat& Ixx, dFloat& Iyy, dFloat& Izz) const
{
	NewtonBodyGetMassMatrix(m_body, &mass, &Ixx, &Iyy, &Izz);
}

dNewton* dNewtonBody::GetNewton () const
{
	return (dNewton*) NewtonWorldGetUserData(NewtonBodyGetWorld(m_body));
}

void dNewtonBody::SetBody (NewtonBody* const body)
{
	if (body) {
		NewtonBodySetUserData(body, this);
		//NewtonBodySetTransformCallback (body, OnBodyTransform);
		NewtonBodySetDestructorCallback (body, OnBodyDestroy);
	} else if (m_body) {
		NewtonBodySetUserData(m_body, NULL);
		//NewtonBodySetTransformCallback (m_body, NULL);
		NewtonBodySetDestructorCallback (m_body, NULL);
	}
	m_body = body;
}



void dNewtonBody::GetVisualMatrix (dFloat param, dFloat* const matrix) const
{
	InterpolateMatrix (param, matrix);
}


dNewtonCollision* dNewtonBody::GetCollision() const
{
	return (dNewtonCollision*) NewtonCollisionGetUserData(NewtonBodyGetCollision (m_body));
}

void dNewtonBody::SetCollision(const dNewtonCollision* const collision) const
{
	NewtonBodySetCollision (m_body, collision->GetShape());
}

dNewtonBody* dNewtonBody::GetParent() const 
{	
	return m_parent;
}

dNewtonBody* dNewtonBody::GetChild() const 
{
	return m_child;
}

dNewtonBody* dNewtonBody::GetSibling() const 
{
	return m_sibling;
}

void* dNewtonBody::GetBoneArticulation() const
{
	return m_boneArticulation;
}

void dNewtonBody::SetBoneArticulation(void* const boneArticulation)
{
	m_boneArticulation = boneArticulation;
}


void dNewtonBody::AttachChild(dNewtonBody* const child)
{
	dAssert (!child->m_parent);
	child->m_parent = this;

	if (!m_child) {
		m_child = child;
	} else {
		child->m_sibling = m_child;
		m_child = child;
	}
}

#endif



dNewtonBody::ScopeLock::ScopeLock (unsigned int* const lock)
	:m_atomicLock(lock)
{
	const int maxCount = 1024 * 32;
	for (int i = 0; (i < maxCount) && NewtonAtomicSwap((int*)m_atomicLock, 1); i++) {
		NewtonYield();
	}
}

dNewtonBody::ScopeLock::~ScopeLock()
{
	NewtonAtomicSwap((int*)m_atomicLock, 0);
}


dNewtonBody::dNewtonBody(const dMatrix* const matrix)
	:dAlloc()
	,m_body(NULL)
	,m_posit0(matrix->m_posit)
	,m_posit1(matrix->m_posit)
	,m_interpolatedPosit(matrix->m_posit)
	,m_rotation0(*matrix)
	,m_rotation1(m_rotation0)
	,m_interpolatedRotation(m_rotation0)
	,m_lock(0)
{
}

dNewtonBody::~dNewtonBody()
{
	Destroy();
}

void* dNewtonBody::GetPosition()
{
	const dNewtonWorld* const world = (dNewtonWorld*)NewtonWorldGetUserData(NewtonBodyGetWorld(m_body));
	ScopeLock scopelock(&m_lock);
	m_interpolatedPosit = m_posit0 + (m_posit1 - m_posit0).Scale(world->m_interpotationParam);
	return &m_interpolatedPosit.m_x;
}

void* dNewtonBody::GetRotation()
{
	const dNewtonWorld* const world = (dNewtonWorld*) NewtonWorldGetUserData(NewtonBodyGetWorld(m_body));
	ScopeLock scopelock(&m_lock);
	m_interpolatedRotation = m_rotation0.Slerp(m_rotation1, world->m_interpotationParam);
	return &m_interpolatedRotation.m_q0;
}

void dNewtonBody::OnBodyTransform(const dFloat* const matrixPtr, int threadIndex)
{
	dMatrix matrix(matrixPtr);

	ScopeLock scopelock(&m_lock);
	m_posit0 = m_posit1;
	m_rotation0 = m_rotation1;
	m_posit1 = matrix.m_posit;
	m_rotation1 = dQuaternion(matrix);
	dFloat angle = m_rotation0.DotProduct(m_rotation1);
	if (angle < 0.0f) {
		m_rotation1.Scale(-1.0f);
	}
}


void dNewtonBody::OnBodyTransform(const NewtonBody* const body, const dFloat* const matrix, int threadIndex)
{
	dNewtonBody* const me = (dNewtonBody*)NewtonBodyGetUserData(body);
	dAssert(me);
	me->OnBodyTransform(matrix, threadIndex);
}


void dNewtonBody::Destroy()
{
//	if (m_body && NewtonBodyGetDestructorCallback(m_body)) {
	if (m_body) {
		NewtonBodySetDestructorCallback(m_body, NULL);
		NewtonDestroyBody(m_body);
		m_body = NULL;
	}
}

void dNewtonBody::OnBodyDestroy(const NewtonBody* const body)
{
	dAssert(0);
/*
	dNewtonBody* const me = (dNewtonBody*)NewtonBodyGetUserData(body);
	if (me) {
		NewtonBodySetDestructorCallback(me->m_body, NULL);
		delete me;
	}
*/
}


dNewtonDynamicBody::dNewtonDynamicBody(dNewtonWorld* const world, dNewtonCollision* const collision, const void* const matrixPtr)
	:dNewtonBody((dMatrix*)matrixPtr)
{
	dMatrix matrix (m_rotation0, m_posit0);
	NewtonWorld* const newton = world->m_world;
	m_body = NewtonCreateDynamicBody(newton, collision->m_shape, &matrix[0][0]);
	collision->DeleteShape();
	collision->SetShape(NewtonBodyGetCollision(m_body));

	NewtonBodySetUserData(m_body, this);
	NewtonBodySetTransformCallback(m_body, OnBodyTransform);

//dVector v(0.0f, 5.0f, 0.0f, 0.0f);
//NewtonBodySetVelocity(m_body, &v[0]);
NewtonBodySetMassProperties(m_body, 10, NewtonBodyGetCollision(m_body));
}