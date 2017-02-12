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
#include "dNewtonJoint.h"

dNewtonJoint::dNewtonJoint()
	:dAlloc()
	,m_joint(NULL)
{
}

void dNewtonJoint::SetJoint(CustomJoint* const joint)
{
	m_joint = joint;
}


void dNewtonJoint::SetStiffness(dFloat stiffness)
{
	m_joint->SetStiffness(stiffness);
}

/*
dNewtonBallAndSocket::dNewtonBallAndSocket(dNewtonWorld* const world)
	:dNewtonJoint(world)
{
}
*/


dNewtonHinge::dNewtonHinge(dFloat* const pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	dMatrix matrix(pintAndPivotMatrix);
	
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	matrix = matrix * bodyMatrix;
	SetJoint(new CustomHinge(matrix, netwonBody0, NULL));
}

dNewtonHinge::dNewtonHinge(dFloat* const pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	dMatrix matrix(pintAndPivotMatrix);
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);
	matrix = matrix * bodyMatrix;
	SetJoint(new CustomHinge(matrix, netwonBody0, netwonBody1));
}


void dNewtonHinge::SetLimits(bool enable, dFloat minVal, dFloat maxAngle)
{
	CustomHinge* const hinge = (CustomHinge*)m_joint;
	hinge->EnableLimits(enable);
	if (enable) {
		hinge->SetLimits(dMin(minVal * DEGREES_TO_RAD, 0.0f), dMax(maxAngle * DEGREES_TO_RAD, 0.0f));
	}
}

void dNewtonHinge::SetAsSpringDamper(bool enable, dFloat forceMixing, dFloat springConst, dFloat damperConst)
{
	CustomHinge* const hinge = (CustomHinge*)m_joint;
	hinge->SetAsSpringDamper(enable, dClamp(forceMixing, 0.7f, 0.99f), dAbs(springConst), dAbs(damperConst));
}


dNewtonHingeActuator::dNewtonHingeActuator(dFloat* const pintAndPivotMatrix, void* const body0)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	dMatrix matrix(pintAndPivotMatrix);

	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);

	matrix = matrix * bodyMatrix;
	CustomHingeActuator* const actuator = new CustomHingeActuator(matrix, netwonBody0, NULL);
	SetJoint(actuator);
	actuator->SetEnableFlag(true);
}

dNewtonHingeActuator::dNewtonHingeActuator(dFloat* const pintAndPivotMatrix, void* const body0, void* const body1)
	:dNewtonJoint()
{
	dMatrix bodyMatrix;
	dMatrix matrix(pintAndPivotMatrix);
	NewtonBody* const netwonBody0 = (NewtonBody*)body0;
	NewtonBody* const netwonBody1 = (NewtonBody*)body1;
	NewtonBodyGetMatrix(netwonBody0, &bodyMatrix[0][0]);
	matrix = matrix * bodyMatrix;

	CustomHingeActuator* const actuator = new CustomHingeActuator(matrix, netwonBody0, netwonBody1);
	SetJoint(actuator);
	actuator->SetEnableFlag(true);
}

dFloat dNewtonHingeActuator::GetAngle() const
{
	CustomHingeActuator* const actuator = (CustomHingeActuator*)m_joint;
	return actuator->GetActuatorAngle() * RAD_TO_DEGREES;
}

void dNewtonHingeActuator::SetMaxToque(dFloat torque)
{
	CustomHingeActuator* const actuator = (CustomHingeActuator*)m_joint;
	actuator->SetMaxForcePower(dAbs(torque));
}

void dNewtonHingeActuator::SetAngularRate(dFloat rate)
{
	CustomHingeActuator* const actuator = (CustomHingeActuator*)m_joint;
	actuator->SetAngularRate(rate * DEGREES_TO_RAD);
}

void dNewtonHingeActuator::SetTargetAngle(dFloat angle, dFloat minLimit, dFloat maxLimit)
{
	CustomHingeActuator* const actuator = (CustomHingeActuator*)m_joint;
	actuator->SetMinAngularLimit(dMin(minLimit * DEGREES_TO_RAD, dFloat(0.0f)));
	actuator->SetMaxAngularLimit(dMax(maxLimit * DEGREES_TO_RAD, dFloat(0.0f)));
	actuator->SetTargetAngle(dClamp (angle * DEGREES_TO_RAD, actuator->GetMinAngularLimit(), actuator->GetMaxAngularLimit()));
}

