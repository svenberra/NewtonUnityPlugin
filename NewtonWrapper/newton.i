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
	#include "stdafx.h"

	#include "dAlloc.h"
	#include "dNewtonBody.h"
	#include "dNewtonWorld.h"
	#include "dNewtonCollision.h"
%}

/*
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
%typemap(csout, excode=SWIGEXCODE)  void* { 
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


// dmath sdk Glue
%include "dMathDefines.h"
%include "dVector.h"
%include "dMatrix.h"
%include "dQuaternion.h"
%include "dLinearAlgebra.h"

%include "dNewtonBody.h"
%include "dNewtonWorld.h"
%include "dNewtonCollision.h"

