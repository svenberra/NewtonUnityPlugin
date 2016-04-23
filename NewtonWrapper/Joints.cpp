#include "stdafx.h"
#include "NewtonWrapper.h"

void NewtonDestroyCustomJoint(CustomJoint* joint)
{
	delete joint;
}

CustomBallAndSocket* NewtonCreateBallAndSocket(float* matrix, NewtonBody* child, NewtonBody* parent)
{
	return new CustomBallAndSocket(matrix, child, parent);
}

CustomBallAndSocketWithFriction* NewtonCreateBallAndSocketWithFriction(float* matrix, NewtonBody* child, NewtonBody* parent, float friction)
{
	return new CustomBallAndSocketWithFriction(matrix, child, parent, friction);
}

CustomHinge* NewtonCreateHinge(float* matrix, NewtonBody* child, NewtonBody* parent)
{
	return new CustomHinge(matrix, child, parent);
}

void NewtonHingeEnableLimits(CustomHinge* hinge, bool state)
{
	hinge->EnableLimits(state);
}

void NewtonHingeSetLimits(CustomHinge* hinge, float minAngle, float maxAngle)
{
	hinge->SetLimits(minAngle, maxAngle);
}

void NewtonHingeSetFriction(CustomHinge* hinge, float friction)
{
	hinge->SetFriction(friction);
}

CustomDryRollingFriction* NewtonCreateRollingFriction(NewtonBody* child, float radius, float coeff)
{
	return new CustomDryRollingFriction(child, radius, coeff);
}



