// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <new>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <Newton.h>
#include <dMathDefines.h>
#include <dVector.h>
#include <dMatrix.h>
#include <dQuaternion.h>
#include <dLinearAlgebra.h>

#include <dContainersAlloc.h>
#include <dList.h>
#include <dTree.h>

#include <CustomJointLibraryStdAfx.h>
#include <CustomAlloc.h>
#include <CustomJoint.h>
#include <CustomBallAndSocket.h>
#include <CustomGear.h>
#include <CustomPlane.h>
#include <CustomHinge.h>
#include <CustomSlider.h>
#include <CustomUniversal.h>
#include <CustomHingeActuator.h>
#include <CustomSlidingContact.h>
#include <CustomSliderActuator.h>
#include <CustomUniversalActuator.h>

#define RAD_TO_DEGREES	(180.0f / 3.141592f)
#define DEGREES_TO_RAD	(3.141592f / 180.0f)


