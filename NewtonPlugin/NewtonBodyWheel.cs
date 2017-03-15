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

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;


[DisallowMultipleComponent]
class NewtonWheelCollider: NewtonChamferedCylinderCollider
{
    public override dNewtonCollision Create(NewtonWorld world)
    {
        dNewtonCollision shape = base.Create(world);
        m_scale.y = 1.0f;
        return shape;
    }
}

[DisallowMultipleComponent]
[RequireComponent(typeof(NewtonWheelCollider))]
[AddComponentMenu("Newton Physics/Vehicle/Rigid Body Wheel")]
class NewtonBodyWheel: NewtonBody
{
    void Start()
    {
        m_isScene = false;
        m_shape = GetComponent<NewtonWheelCollider>();
        m_shape.m_scale= new Vector3(1.0f, 1.0f, 1.0f);
    }
/*
    protected override void CreateBodyAndCollision()
    {
        Debug.Log("create actual wheel");
        m_collision = new NewtonBodyCollision(this);
        m_body = new dNewtonDynamicBody(m_world.GetWorld(), m_collision.GetShape(), Utils.ToMatrix(transform.position, transform.rotation), m_mass);
    }
*/

    public void InitWheel ()
    {
        Debug.Log("xxxx0 create actual wheel");
    }

    public override void InitRigidBody()
    {
        if (m_owner == null)
        {
            // if the tire is not attached to a vehicle the this is simple rigid body 
            base.InitRigidBody();
        }
    }

    [Header ("wheel data")]
    public NewtonBodyVehicle m_owner = null;
    public float m_pivotOffset = 0.0f;
    [Range(0.0f, 45.0f)]
    public float m_maxSteeringAngle = 20.0f;
    public float m_suspesionDamping = 1000.0f;
    public float m_suspesionSpring = 100.0f;
    public float m_suspesionlenght = 0.3f;
    [Range(0.0f, 1.0f)]
    public float m_lateralStiffness = 0.5f;
    [Range(0.0f, 1.0f)]
    public float m_longitudialStiffness = 0.5f;
    [Range(0.0f, 1.0f)]
    public float m_aligningMomentTrail = 0.5f;
    [Range(0, 2)]
    public int m_suspentionType = 1;
    public bool m_hasFender = false;
    //  void* m_userData;
    NewtonWheelCollider m_shape;
}

