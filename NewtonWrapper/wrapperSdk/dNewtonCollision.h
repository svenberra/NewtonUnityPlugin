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

#ifndef _D_NEWTON_COLLISION_H_
#define _D_NEWTON_COLLISION_H_

#include "stdafx.h"
#include "dAlloc.h"


//#include "dNewtonMaterial.h"
class dNewtonBody;
class dNewtonWorld;

struct dPoints
{
	float m_x;
	float m_y;
	float m_z;
};


typedef void(*OnDrawFaceCallback)(const dPoints* const points, int vertexCount);

//class dNewtonCollision: virtual public dNewtonAlloc, public dNewtonMaterial
class dNewtonCollision: public dAlloc
{
	public:
	dNewtonCollision (dNewtonWorld* const world, dLong collisionMask);
	virtual ~dNewtonCollision();

	virtual bool IsValid();
	virtual void SetScale(dFloat x, dFloat y, dFloat z);
	virtual void SetMatrix(const void* const matrix);
	virtual void DebugRender(OnDrawFaceCallback callback);
	
	

/*
	dCollsionType GetType() const {return m_type;}
	NewtonCollision* GetShape() const;
	virtual dNewtonCollision* Clone (NewtonCollision* const shape) const = 0; 
	void* GetUserData() const;
	void SetUserData(void* const userData);
	dFloat GetVolume () const;
	
	void GetScale(dFloat& x, dFloat& y, dFloat& z) const;
	void SetMatrix (const dFloat* const matrix);
	void GetMatrix (dFloat* const matrix) const;
	void CalculateAABB (const dFloat* const matrix, dFloat* const p0, dFloat* const p1) const;
	void CalculateBuoyancyAcceleration (const dFloat* const matrix, const dFloat* const shapeOrigin, const dFloat* const gravityVector, const dFloat* const fluidPlane, dFloat fluidDensity, dFloat fluidViscosity, dFloat* const accel, dFloat* const alpha);
*/
	protected:
	void SetShape(NewtonCollision* const shape);
	void DeleteShape();

	static void DebugRenderCallback (void* userData, int vertexCount, const dFloat* faceVertec, int id);

	static dMatrix m_primitiveAligment;
	NewtonCollision* m_shape;
	dNewtonWorld* m_myWorld;
	dList<dNewtonCollision*>::dListNode* m_collisionCacheNode;
	friend class dNewtonBody;
	friend class dNewtonWorld;
	friend class dNewtonDynamicBody;
};

/*
class dNewtonCollisionMesh: public dNewtonCollision
{
	public: 
	dNewtonCollisionMesh (dNewton* const world, dLong collisionMask);
	dNewtonCollisionMesh (dNewton* const world, const dNewtonMesh& mesh, dLong collisionMask);

	dNewtonCollision* Clone (NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionMesh (*this, shape);
	}

	virtual void BeginFace();
	virtual void AddFace(int vertexCount, const dFloat* const vertexPtr, int strideInBytes, int faceAttribute);
	virtual void EndFace();

	protected:
	dNewtonCollisionMesh (const dNewtonCollisionMesh& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionScene: public dNewtonCollision
{
	public: 
	dNewtonCollisionScene (dNewton* const world, dLong collisionMask);
	dNewtonCollision* Clone (NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionScene (*this, shape);
	}

	virtual void BeginAddRemoveCollision();
	virtual void* AddCollision(const dNewtonCollision* const collision);
	virtual void RemoveCollision (void* const handle);
	virtual void EndAddRemoveCollision();

	void* GetFirstNode () const;;
	void* GetNextNode (void* const collisionNode) const;
	dNewtonCollision* GetChildFromNode(void* const collisionNode) const; 

	protected:
	dNewtonCollisionScene (const dNewtonCollisionScene& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionHeightField: public dNewtonCollision
{
	public: 
	dNewtonCollisionHeightField (dNewton* const world, int width, int height, int gridsDiagonals, int elevationdataType, dFloat vertcalScale, dFloat horizontalScale, const void* const elevationMap, const char* const attributeMap, dLong collisionMask)
		:dNewtonCollision(m_heighfield, collisionMask)
	{
		SetShape (NewtonCreateHeightFieldCollision (world->GetNewton(), width, height, gridsDiagonals, elevationdataType, elevationMap, attributeMap, vertcalScale, horizontalScale, 0));
	}

	dNewtonCollision* Clone (NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionHeightField (*this, shape);
	}

	protected:
	dNewtonCollisionHeightField (const dNewtonCollisionHeightField& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};

class dNewtonCollisionConvexHull: public dNewtonCollision
{
	public: 
	dNewtonCollisionConvexHull (NewtonCollision* const shape, dLong collisionMask)
		:dNewtonCollision(m_convex, collisionMask)
	{
		SetShape (shape);
	}

	dNewtonCollisionConvexHull (dNewton* const world, const dNewtonMesh& mesh, dLong collisionMask);

	dNewtonCollisionConvexHull (dNewton* const world, int vertexCount, const dFloat* const vertexCloud, int strideInBytes, dFloat tolerance, dLong collisionMask)
		:dNewtonCollision(m_convex, collisionMask)
	{
		SetShape (NewtonCreateConvexHull (world->GetNewton(), vertexCount, vertexCloud, strideInBytes, tolerance, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionConvexHull (*this, shape);
	}

	protected:
	dNewtonCollisionConvexHull (const dNewtonCollisionConvexHull& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionCompound: public dNewtonCollision
{
	public: 
	dNewtonCollisionCompound (NewtonCollision* const shape, dLong collisionMask)
		:dNewtonCollision(m_compound, collisionMask)
	{
		SetShape (shape);
	}

	dNewtonCollisionCompound (dNewton* const world, dLong collisionMask)
		:dNewtonCollision(m_compound, collisionMask)
	{
		SetShape (NewtonCreateCompoundCollision (world->GetNewton(), 0));
	}

	dNewtonCollisionCompound (dNewton* const world, const dNewtonMesh& mesh, dLong collisionMask);


	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionCompound (*this, shape);
	}

	virtual void BeginAddRemoveCollision();
	virtual void* AddCollision(const dNewtonCollision* const collision);
	virtual void RemoveCollision (void* const handle);
	virtual void EndAddRemoveCollision();

	void* GetFirstNode () const;;
	void* GetNextNode (void* const collisionNode) const;
	dNewtonCollision* GetChildFromNode(void* const collisionNode) const; 

	protected:
	dNewtonCollisionCompound (const dNewtonCollisionCompound& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};
*/


class dNewtonCollisionNull : public dNewtonCollision
{
	public:
	dNewtonCollisionNull(dNewtonWorld* const world);
};


class dNewtonCollisionSphere : public dNewtonCollision
{
	public:
	dNewtonCollisionSphere(dNewtonWorld* const world, dFloat r);
};

class dNewtonCollisionBox : public dNewtonCollision
{
	public:
	dNewtonCollisionBox(dNewtonWorld* const world, dFloat x, dFloat y, dFloat z);
};


class dNewtonAlignedShapes : public dNewtonCollision
{
	public:
	dNewtonAlignedShapes(dNewtonWorld* const world, dLong collisionMask);
	void SetMatrix(const void* const matrix);
	void SetScale(dFloat x, dFloat y, dFloat z);
};

class dNewtonCollisionCapsule: public dNewtonAlignedShapes
{
	public:
	dNewtonCollisionCapsule(dNewtonWorld* const world, dFloat radio0, dFloat radio1, dFloat height);
};

class dNewtonCollisionCylinder : public dNewtonAlignedShapes
{
	public:
	dNewtonCollisionCylinder(dNewtonWorld* const world, dFloat radio0, dFloat radio1, dFloat height);
};

class dNewtonCollisionCone : public dNewtonAlignedShapes
{
	public:
	dNewtonCollisionCone(dNewtonWorld* const world, dFloat radio, dFloat height);
};

class dNewtonCollisionChamferedCylinder : public dNewtonAlignedShapes
{
	public:
	dNewtonCollisionChamferedCylinder(dNewtonWorld* const world, dFloat radio, dFloat height);
};


class dNewtonCollisionConvexHull : public dNewtonCollision
{
	public:
		dNewtonCollisionConvexHull(dNewtonWorld* const world, int vertexCount, const dFloat* const vertexCloud, dFloat tolerance);
};


#endif
