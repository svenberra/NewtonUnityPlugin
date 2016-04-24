/////////////////////////////////////////////////////////////////////////////
// Name:        NewtonWraper.i
// Purpose:     
// Author:      Julio Jerez
// Copyright:   Copyright (c) <2010> <Newton Game Dynamics>
// License:     
// This software is provided 'as-is', without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely
/////////////////////////////////////////////////////////////////////////////

%module cpp
%{
	#include "stdafx.h"
	#include "Newton.h"

	#include "dMathDefines.h"
	#include "dVector.h"
	#include "dMatrix.h"
	#include "dQuaternion.h"
	#include "dLinearAlgebra.h"
%}

%rename(__dMatrix_multiply__) dMatrix::operator*;
%rename(__dMatrix_GetElement__) dMatrix::operator[](int i);
%rename(__dMatrix_Const_GetElement__) dMatrix::operator[] (int i) const; 

%rename(__dQuaternion_add__) dQuaternion::operator+;
%rename(__dQuaternion_sub__) dQuaternion::operator-;
%rename(__dQuaternion_multiply__) dQuaternion::operator*;

//%rename(__CustomAlloc_Delete__) CustomAlloc::operator delete;
//%rename(__CustomJoint_AngularIntegration_Add__) CustomAlloc::AngularIntegration::operator+;
//%rename(__CustomJoint_AngularIntegration_Sub__) CustomAlloc::AngularIntegration::operator-;


#pragma SWIG nowarn=401
%include "newton.h"
%include "dMathDefines.h"
%include "dVector.h"
%include "dMatrix.h"
%include "dQuaternion.h"
%include "dLinearAlgebra.h"
