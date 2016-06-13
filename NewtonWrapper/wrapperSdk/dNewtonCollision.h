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

class NewtonCollision;
class dNewtonBody;
//class dNewtonMesh;

typedef void(*TestingCallbacks____)();
//typedef void(*NewtonUserMeshCollisionCollideCallback) (NewtonUserMeshCollisionCollideDesc* const collideDescData, const void* const continueCollisionHandle);

//class dNewtonCollision: virtual public dNewtonAlloc, public dNewtonMaterial
class dNewtonCollision: public dAlloc
{
	public:
//		typedef void(*DebugDisplayCallback_xxxxxxxxxxx)(char* const xxx, int size);

/*
	class dDebugRenderer
	{
		public:
		dDebugRenderer (dNewtonCollision* const me)
			:m_collision(me)
		{
		}
		
		virtual void OnDrawFace (int vertexCount, const dFloat* const faceVertex, int faceId) = 0;

		dNewtonCollision* m_collision;
	};
*/

	dNewtonCollision (dLong collisionMask);
	virtual ~dNewtonCollision();


	void DebugRender(TestingCallbacks____ callback);
//	virtual void DebugRender(const void* const matrix, * const renderer) const;
/*
	dCollsionType GetType() const {return m_type;}
	NewtonCollision* GetShape() const;
	virtual dNewtonCollision* Clone (NewtonCollision* const shape) const = 0; 

	void* GetUserData() const;
	void SetUserData(void* const userData);

	dFloat GetVolume () const;

	void SetScale(dFloat x, dFloat y, dFloat z);
	void GetScale(dFloat& x, dFloat& y, dFloat& z) const;

	void SetMatrix (const dFloat* const matrix);
	void GetMatrix (dFloat* const matrix) const;

	void CalculateAABB (const dFloat* const matrix, dFloat* const p0, dFloat* const p1) const;
	

	void CalculateBuoyancyAcceleration (const dFloat* const matrix, const dFloat* const shapeOrigin, const dFloat* const gravityVector, const dFloat* const fluidPlane, dFloat fluidDensity, dFloat fluidViscosity, dFloat* const accel, dFloat* const alpha);
*/
	protected:
	void SetShape(NewtonCollision* const shape);

//	dNewtonCollision (const dNewtonCollision& srcCollision, NewtonCollision* const shape);
	static void DebugRender (void* userData, int vertexCount, const dFloat* faceVertec, int id);
	
//	void* m_userData;
//	dCollsionType m_type;
//	friend class dNewton;

	NewtonCollision* m_shape;
	friend class dNewtonBody;
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


class dNewtonCollisionNull: public dNewtonCollision
{
	public: 
	dNewtonCollisionNull (dNewton* const world)
		:dNewtonCollision(m_null, 0)
	{
		SetShape (NewtonCreateNull(world->GetNewton()));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionNull (*this, shape);
	}

	protected:
	dNewtonCollisionNull (const dNewtonCollisionNull& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};




class dNewtonCollisionSphere: public dNewtonCollision
{
	public: 
	dNewtonCollisionSphere (dNewton* const world, dFloat radio, dLong collisionMask)
		:dNewtonCollision(m_sphere, collisionMask)
	{
		SetShape (NewtonCreateSphere(world->GetNewton(), radio, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionSphere (*this, shape);
	}

	protected:
	dNewtonCollisionSphere (const dNewtonCollisionSphere& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionCapsule: public dNewtonCollision
{
	public: 
	dNewtonCollisionCapsule (NewtonCollision* const shape, dLong collisionMask)
		:dNewtonCollision(m_capsule, collisionMask)
	{
		SetShape (shape);
	}

	dNewtonCollisionCapsule (dNewton* const world, dFloat radio0, dFloat radio1, dFloat height, dLong collisionMask)
		:dNewtonCollision(m_capsule, collisionMask)
	{
		SetShape (NewtonCreateCapsule (world->GetNewton(), radio0, radio1, height, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionCapsule (*this, shape);
	}

	protected:
	dNewtonCollisionCapsule (const dNewtonCollisionCapsule& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionCone: public dNewtonCollision
{
	public: 
	dNewtonCollisionCone (dNewton* const world, dFloat radio, dFloat height, dLong collisionMask)
		:dNewtonCollision(m_cone, collisionMask)
	{
		SetShape (NewtonCreateCone (world->GetNewton(), radio, height, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionCone (*this, shape);
	}

	protected:
	dNewtonCollisionCone (const dNewtonCollisionCone& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};


class dNewtonCollisionCylinder: public dNewtonCollision
{
	public: 
	dNewtonCollisionCylinder (NewtonCollision* const shape, dLong collisionMask)
		:dNewtonCollision(m_cylinder, collisionMask)
	{
		SetShape (shape);
	}

	dNewtonCollisionCylinder (dNewton* const world, dFloat radio0, dFloat radio1, dFloat height, dLong collisionMask)
		:dNewtonCollision(m_cylinder, collisionMask)
	{
		SetShape (NewtonCreateCylinder (world->GetNewton(), radio0, radio1, height, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionCylinder (*this, shape);
	}

	protected:
	dNewtonCollisionCylinder (const dNewtonCollisionCylinder& srcCollision, NewtonCollision* const shape)
		:dNewtonCollision (srcCollision, shape)
	{
	}
};



class dNewtonCollisionChamferedCylinder: public dNewtonCollision
{
	public: 
	dNewtonCollisionChamferedCylinder (dNewton* const world, dFloat radio, dFloat height, dLong collisionMask)
		:dNewtonCollision(m_chamferedCylinder, collisionMask)
	{
		SetShape (NewtonCreateChamferCylinder (world->GetNewton(), radio, height, 0, NULL));
	}

	dNewtonCollision* Clone(NewtonCollision* const shape) const 
	{
		return new dNewtonCollisionChamferedCylinder (*this, shape);
	}

	protected:
	dNewtonCollisionChamferedCylinder (const dNewtonCollisionChamferedCylinder& srcCollision, NewtonCollision* const shape)
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


#endif
