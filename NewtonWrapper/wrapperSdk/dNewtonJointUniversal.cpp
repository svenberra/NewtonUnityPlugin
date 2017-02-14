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
#include "dNewtonJointUniversal.h"

dNewtonJointUniversal::dNewtonJointUniversal(const dMatrix pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomUniversal* const joint = new CustomUniversal(matrix, netwonBody0, NULL);
	SetJoint(joint);
}

dNewtonJointUniversal::dNewtonJointUniversal(const dMatrix pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;

	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomUniversal* const joint = new CustomUniversal(matrix, netwonBody0, netwonBody1);
	SetJoint(joint);
}

void dNewtonJointUniversal::SetLimits_0(bool enable, dFloat minVal, dFloat maxAngle)
{
	CustomUniversal* const joint = (CustomUniversal*)m_joint;
	joint->EnableLimit_0(enable);
	if (enable) {
		joint->SetLimits_0(dMin(minVal * DEGREES_TO_RAD, 0.0f), dMax(maxAngle * DEGREES_TO_RAD, 0.0f));
	}
}

void dNewtonJointUniversal::SetLimits_1(bool enable, dFloat minVal, dFloat maxAngle)
{
	CustomUniversal* const joint = (CustomUniversal*)m_joint;
	joint->EnableLimit_1(enable);
	if (enable) {
		joint->SetLimits_1(dMin(minVal * DEGREES_TO_RAD, 0.0f), dMax(maxAngle * DEGREES_TO_RAD, 0.0f));
	}
}


dNewtonJointUniversalActuator::dNewtonJointUniversalActuator(const dMatrix pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);
	
	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomUniversalActuator* const joint = new CustomUniversalActuator(matrix, netwonBody0, NULL);
	SetJoint(joint);
	dAssert(0);
//	joint->SetEnableFlag(true);
}

dNewtonJointUniversalActuator::dNewtonJointUniversalActuator(const dMatrix pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomUniversalActuator* const joint = new CustomUniversalActuator(matrix, netwonBody0, netwonBody1);
	SetJoint(joint);
	dAssert(0);
	//joint->SetEnableFlag(true);
}

dFloat dNewtonJointUniversalActuator::GetAngle() const
{
	CustomUniversalActuator* const joint = (CustomUniversalActuator*) m_joint;
	dAssert(0);
	return 0;
//	return joint->GetActuatorAngle() * RAD_TO_DEGREES;
}

void dNewtonJointUniversalActuator::SetMaxToque(dFloat torque)
{
	CustomUniversalActuator* const joint = (CustomUniversalActuator*) m_joint;
	dAssert(0);
//	joint->SetMaxForcePower(dAbs(torque));
}

void dNewtonJointUniversalActuator::SetAngularRate(dFloat rate)
{
	CustomUniversalActuator* const joint = (CustomUniversalActuator*) m_joint;
	dAssert(0);
//	joint->SetAngularRate(rate * DEGREES_TO_RAD);
}

void dNewtonJointUniversalActuator::SetTargetAngle(dFloat angle, dFloat minLimit, dFloat maxLimit)
{
	CustomUniversalActuator* const joint = (CustomUniversalActuator*) m_joint;
	dAssert(0);
//	joint->SetMinAngularLimit(dMin(minLimit * DEGREES_TO_RAD, dFloat(0.0f)));
//	joint->SetMaxAngularLimit(dMax(maxLimit * DEGREES_TO_RAD, dFloat(0.0f)));
//	joint->SetTargetAngle(dClamp (angle * DEGREES_TO_RAD, joint->GetMinAngularLimit(), joint->GetMaxAngularLimit()));
}

