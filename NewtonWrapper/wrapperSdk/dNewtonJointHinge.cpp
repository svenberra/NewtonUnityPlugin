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
#include "dNewtonJointHinge.h"

dNewtonJointHinge::dNewtonJointHinge(const dMatrix pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix (pintAndPivotMatrix * bodyMatrix);

	CustomHinge* const joint = new CustomHinge(matrix, netwonBody0, NULL);
	SetJoint(joint);
}

dNewtonJointHinge::dNewtonJointHinge(const dMatrix pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomHinge* const joint = new CustomHinge(matrix, netwonBody0, netwonBody1);
	SetJoint(joint);
}


void dNewtonJointHinge::SetLimits(bool enable, dFloat minAngle, dFloat maxAngle)
{
	CustomHinge* const joint = (CustomHinge*)m_joint;
	joint->EnableLimits(enable);
	if (enable) {
		joint->SetLimits(dMin(minAngle * DEGREES_TO_RAD, 0.0f), dMax(maxAngle * DEGREES_TO_RAD, 0.0f));
	}
}

void dNewtonJointHinge::SetAsSpringDamper(bool enable, dFloat forceMixing, dFloat springConst, dFloat damperConst)
{
	CustomHinge* const joint = (CustomHinge*)m_joint;
	joint->SetAsSpringDamper(enable, dClamp(forceMixing, 0.7f, 0.99f), dAbs(springConst), dAbs(damperConst));
}


dNewtonJointHingeActuator::dNewtonJointHingeActuator(const dMatrix pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix (pintAndPivotMatrix * bodyMatrix);
	CustomHingeActuator* const joint = new CustomHingeActuator(matrix, netwonBody0, NULL);
	SetJoint(joint);
	joint->SetEnableFlag(true);
}

dNewtonJointHingeActuator::dNewtonJointHingeActuator(const dMatrix pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	dMatrix matrix(pintAndPivotMatrix * bodyMatrix);
	CustomHingeActuator* const joint = new CustomHingeActuator(matrix, netwonBody0, netwonBody1);
	SetJoint(joint);
	joint->SetEnableFlag(true);
}

dFloat dNewtonJointHingeActuator::GetAngle() const
{
	CustomHingeActuator* const joint = (CustomHingeActuator*)m_joint;
	return joint->GetActuatorAngle() * RAD_TO_DEGREES;
}

void dNewtonJointHingeActuator::SetMaxToque(dFloat torque)
{
	CustomHingeActuator* const joint = (CustomHingeActuator*)m_joint;
	joint->SetMaxForcePower(dAbs(torque));
}

void dNewtonJointHingeActuator::SetAngularRate(dFloat rate)
{
	CustomHingeActuator* const joint = (CustomHingeActuator*)m_joint;
	joint->SetAngularRate(dAbs(rate) * DEGREES_TO_RAD);
}

void dNewtonJointHingeActuator::SetTargetAngle(dFloat angle, dFloat minLimit, dFloat maxLimit)
{
	CustomHingeActuator* const joint = (CustomHingeActuator*)m_joint;
	joint->SetMinAngularLimit(dMin(minLimit * DEGREES_TO_RAD, dFloat(0.0f)));
	joint->SetMaxAngularLimit(dMax(maxLimit * DEGREES_TO_RAD, dFloat(0.0f)));
	joint->SetTargetAngle(dClamp (angle * DEGREES_TO_RAD, joint->GetMinAngularLimit(), joint->GetMaxAngularLimit()));
}

