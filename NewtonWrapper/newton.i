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

%module NewtonWrapper
%{
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
	#include "dAlloc.h"
	#include "dNewtonBody.h"
	#include "dNewtonWorld.h"
	#include "dNewtonJoint.h"
	#include "dNewtonCollision.h"
	#include "dNewtonJointHinge.h"
	#include "dNewtonJointPlane.h"
	#include "dNewtonJointSlider.h"
	#include "dNewtonJointUniversal.h"
	#include "dNewtonJointRelational.h"
	#include "dNewtonJointSlidingHinge.h"
%}

/*
%rename(__dContainers_Alloc__) dContainersAlloc::operator new;  
%rename(__dContainers_Freec__) dContainersAlloc::operator delete;  

%rename(__dBezierSpline__Assigment__) dBezierSpline::operator=;  
%rename(__dBezierSpline__GetKnotArray__) dBezierSpline::GetKnotArray();
%rename(__dBezierSpline__GetKnotArray__Const) dBezierSpline::GetKnotArray() const; 
%rename(__dBezierSpline__GetControlPointArray__) dBezierSpline::GetControlPointArray();
%rename(__dBezierSpline__GetControlPointArray__Const) dBezierSpline::GetControlPointArray() const; 


// Wrap Newton callbacks
%cs_callback(NewtonAllocMemory, NewtonAllocMemoryDelegate)
%cs_callback(NewtonFreeMemory, NewtonFreeMemoryDelegate)
*/


// Wrap void* to IntPtr
%typemap(ctype)  void* "void *"
%typemap(in)     void* %{ $1 = $input; %}
%typemap(imtype) void* "global::System.IntPtr"
%typemap(cstype) void* "global::System.IntPtr"
%typemap(out)    void* %{ $result = $1; %}
%typemap(csin)   void* "$csinput"
%typemap(csout, excode=SWIGEXCODE) void* { 
    System.IntPtr cPtr = $imcall;$excode
    return cPtr;
}
%typemap(csvarout, excode=SWIGEXCODE2) void* %{ 
    get {
        System.IntPtr cPtr = $imcall;$excode 
        return cPtr; 
   } 
%} 

// Wrap dFloat* to IntPtr
%typemap(ctype)  dFloat* "dFloat *"
%typemap(in)     dFloat* %{ $1 = $input; %}
%typemap(imtype) dFloat* "global::System.IntPtr"
%typemap(cstype) dFloat* "global::System.IntPtr"
%typemap(out)    dFloat* %{ $result = $1; %}
%typemap(csin)   dFloat* "$csinput"
%typemap(csout, excode=SWIGEXCODE)  dFloat* { 
    System.IntPtr cPtr = $imcall;$excode
    return cPtr;
}
%typemap(csvarout, excode=SWIGEXCODE2) dFloat* %{ 
    get {
        System.IntPtr cPtr = $imcall;$excode 
        return cPtr; 
   } 
%} 



// Macro for wrapping C++ callbacks as C# delegates 
%define %cs_callback(TYPE, CSTYPE) 
    %typemap(ctype) TYPE, TYPE& "void*" 
    %typemap(in) TYPE  %{ $1 = ($1_type)$input; %} 
    %typemap(in) TYPE& %{ $1 = ($1_type)&$input; %} 
    %typemap(imtype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
    %typemap(cstype, out="IntPtr") TYPE, TYPE& "CSTYPE" 
    %typemap(csin) TYPE, TYPE& "$csinput" 
%enddef 
%cs_callback(OnDrawFaceCallback, OnDrawFaceCallback) 
%cs_callback(OnCollisionCallback, OnCollisionCallback)
%cs_callback(OnWorldUpdateCallback, OnWorldUpdateCallback) 

#pragma SWIG nowarn=401
%rename(__dAlloc_Alloc__) dAlloc::operator new;  
%rename(__dAlloc_Free__) dAlloc::operator delete;  

%rename(__dMatrix_multiply__) dMatrix::operator*;
%rename(__dMatrix_GetElement__) dMatrix::operator[](int i);
%rename(__dMatrix_GetElement__Const__) dMatrix::operator[] (int i) const; 

%rename(__dQuaternion_add__) dQuaternion::operator+;
%rename(__dQuaternion_sub__) dQuaternion::operator-;
%rename(__dQuaternion_multiply__) dQuaternion::operator*;

%rename(__CustomAlloc_Alloc__) CustomAlloc::operator new;
%rename(__CustomAlloc_Delete__) CustomAlloc::operator delete;

%rename(__CustomJoint_AngularIntegration_Add__) CustomAlloc::AngularIntegration::operator+;
%rename(__CustomJoint_AngularIntegration_Sub__) CustomAlloc::AngularIntegration::operator-;


// dmath sdk Glue
%include "dMathDefines.h"
%include "dVector.h"
%include "dMatrix.h"
%include "dQuaternion.h"
%include "dLinearAlgebra.h"

%include "CustomAlloc.h"
%include "dNewtonBody.h"
%include "dNewtonWorld.h"
%include "dNewtonJoint.h"
%include "dNewtonCollision.h"
%include "dNewtonJointPlane.h"
%include "dNewtonJointHinge.h"
%include "dNewtonJointSlider.h"
%include "dNewtonJointUniversal.h"
%include "dNewtonJointRelational.h"
%include "dNewtonJointSlidingHinge.h"
