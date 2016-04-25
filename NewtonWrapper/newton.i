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
	// minimal standard library support
	#include "new"
	#include "stdio.h"
	#include "stdlib.h"

	// newton SDK
	#include "Newton.h"

	// dmath sdk
	#include "dMathDefines.h"
	#include "dVector.h"
	#include "dMatrix.h"
	#include "dQuaternion.h"
	#include "dLinearAlgebra.h"

	// dContainers SDK
	#include "dContainersStdAfx.h"
	#include "dCRC.h"
	#include "dRtti.h"
	#include "dTree.h"
	#include "dList.h"
	#include "dHeap.h"
	#include "dClassInfo.h"
	#include "dRefCounter.h"
	#include "dBezierSpline.h"

	// Custom Joints SDK
	#include "CustomJointLibraryStdAfx.h"
	#include "CustomAlloc.h"
	#include "CustomJoint.h"
	#include "CustomBallAndSocket.h"
%}

%rename(__dMatrix_multiply__) dMatrix::operator*;
%rename(__dMatrix_GetElement__) dMatrix::operator[](int i);
%rename(__dMatrix_GetElement__Const__) dMatrix::operator[] (int i) const; 

%rename(__dQuaternion_add__) dQuaternion::operator+;
%rename(__dQuaternion_sub__) dQuaternion::operator-;
%rename(__dQuaternion_multiply__) dQuaternion::operator*;

%rename(__dContainers_Alloc__) dContainersAlloc::operator new;  
%rename(__dContainers_Freec__) dContainersAlloc::operator delete;  

%rename(__dBezierSpline__Assigment__) dBezierSpline::operator=;  
%rename(__dBezierSpline__GetKnotArray__) dBezierSpline::GetKnotArray();
%rename(__dBezierSpline__GetKnotArray__Const) dBezierSpline::GetKnotArray() const; 
%rename(__dBezierSpline__GetControlPointArray__) dBezierSpline::GetControlPointArray();
%rename(__dBezierSpline__GetControlPointArray__Const) dBezierSpline::GetControlPointArray() const; 

%rename(__CustomAlloc_Alloc__) CustomAlloc::operator new;
%rename(__CustomAlloc_Delete__) CustomAlloc::operator delete;
%rename(__CustomJoint_AngularIntegration_Add__) CustomAlloc::AngularIntegration::operator+;
%rename(__CustomJoint_AngularIntegration_Sub__) CustomAlloc::AngularIntegration::operator-;


#pragma SWIG nowarn=401

// Newton SDK Glue
%include "newton.h"

// dmath sdk Glue
%include "dMathDefines.h"
%include "dVector.h"
%include "dMatrix.h"
%include "dQuaternion.h"
%include "dLinearAlgebra.h"

// dContainers SDK Glue
%include "dContainersStdAfx.h"
%include "dContainersAlloc.h"
%include "dBezierSpline.h"

// Custom Joints SDK Glue
%include "CustomAlloc.h"
%include "CustomJoint.h"
%include "CustomBallAndSocket.h"
