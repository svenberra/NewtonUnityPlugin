// NewtonWrapper.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "NewtonWrapper.h"
#include "Newton.h"
#include "dMatrix.h"
#include "dQuaternion.h"

class BodyTransformState
{
public:
	float prevPos[3];
	float prevRot[4];
	float currPos[3];
	float currRot[4];
};

extern "C"
{
	NEWTONWRAPPER_API BodyTransformState* WRAP_NewtonCreateBodyTransformState(float* pos, float* rot)
	{
		BodyTransformState* bts = new BodyTransformState();
		bts->prevPos[0] = pos[0];
		bts->prevPos[1] = pos[1];
		bts->prevPos[2] = pos[2];
		bts->currPos[0] = pos[0];
		bts->currPos[1] = pos[1];
		bts->currPos[2] = pos[2];

		bts->prevRot[0] = rot[0];
		bts->prevRot[1] = rot[1];
		bts->prevRot[2] = rot[2];
		bts->prevRot[3] = rot[3];
		bts->currRot[0] = rot[0];
		bts->currRot[1] = rot[1];
		bts->currRot[2] = rot[2];
		bts->currRot[3] = rot[3];

		return bts;
	}

	NEWTONWRAPPER_API void WRAP_NewtonDestroyBodyTransformState(BodyTransformState* bts)
	{
		delete bts;
	}

	NEWTONWRAPPER_API void WRAP_NewtonSaveBodyStates(const NewtonWorld* world)
	{
		NewtonBody* b = NewtonWorldGetFirstBody(world);
		while (b != 0)
		{
			BodyTransformState* bts = (BodyTransformState*)NewtonBodyGetUserData(b);

			if (bts != 0)
			{
				bts->prevPos[0] = bts->currPos[0];
				bts->prevPos[1] = bts->currPos[1];
				bts->prevPos[2] = bts->currPos[2];

				bts->prevRot[0] = bts->currRot[0];
				bts->prevRot[1] = bts->currRot[1];
				bts->prevRot[2] = bts->currRot[2];
				bts->prevRot[3] = bts->currRot[3];
			}

			b = NewtonWorldGetNextBody(world, b);
		}

	}

	NEWTONWRAPPER_API void WRAP_NewtonUpdateBodyStates(const NewtonWorld* world)
	{
		NewtonBody* b = NewtonWorldGetFirstBody(world);
		while (b != 0)
		{
			BodyTransformState* bts = (BodyTransformState*)NewtonBodyGetUserData(b);

			if (bts != 0)
			{
				float pos[4];
				float rot[4];

				NewtonBodyGetPosition(b, &pos[0]);
				NewtonBodyGetRotation(b, &rot[0]);

				bts->currPos[0] = pos[0];
				bts->currPos[1] = pos[1];
				bts->currPos[2] = pos[2];

				bts->currRot[0] = rot[1];
				bts->currRot[1] = rot[2];
				bts->currRot[2] = rot[3];
				bts->currRot[3] = rot[0];
			}

			b = NewtonWorldGetNextBody(world, b);
		}

	}



	NEWTONWRAPPER_API void WRAP_NewtonBodyGetPositionAndRotation(const NewtonBody* body, float* pos, float* rot)
	{
		float myrot[4];
		float mypos[4];

		NewtonBodyGetPosition(body, &mypos[0]);
		NewtonBodyGetRotation(body, &myrot[0]);

		rot[0] = myrot[1];
		rot[1] = myrot[2];
		rot[2] = myrot[3];
		rot[3] = myrot[0];

		pos[0] = mypos[0];
		pos[1] = mypos[1];
		pos[2] = mypos[2];

	}

}

