﻿/*
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
[AddComponentMenu("Newton Physics/Rigid Body")]
public class NewtonBody : MonoBehaviour
{
    //public bool Kinematic = false;
    //public bool KinematicCollidable = false;

    void Start()
    {
        m_actions = GetComponents<NewtonBodyForceAction>();
    }

    void OnDestroy()
    {
        DestroyRigidBody();
        m_actions = null;
    }

    // Update is called once per frame
    void Update()
    {
        IntPtr positionPtr = m_body.GetPosition();
        IntPtr rotationPtr = m_body.GetRotation();

        Marshal.Copy(positionPtr, m_positionPtr, 0, 3);
        Marshal.Copy(rotationPtr, m_rotationPtr, 0, 4);
        transform.position = new Vector3(m_positionPtr[0], m_positionPtr[1], m_positionPtr[2]);
        transform.rotation = new Quaternion(m_rotationPtr[1], m_rotationPtr[2], m_rotationPtr[3], m_rotationPtr[0]);
    }

    public void InitRigidBody()
    {
        m_collision = new NewtonBodyCollision(this);
        m_body = new dNewtonDynamicBody(m_world.GetWorld(), m_collision.GetShape(), Utils.ToMatrix(transform.position, transform.rotation), m_mass);
    }

    public void DestroyRigidBody()
    {
        if (m_body != null)
        {
            m_body.Dispose();
            m_body = null;
        }

        if (m_collision != null)
        {
            m_collision.Destroy();
            m_collision = null;
        }
    }

    public void OnApplyForceAndTorque(float timestep)
    {
        if (m_body != null)
        {
            if (m_actions.Length >= 1)
            {
                m_forceAcc = Vector3.zero;
                m_torqueAcc = Vector3.zero;
                foreach (NewtonBodyForceAction action in m_actions)
                {
                    action.ApplyForceAction(this, timestep);
                }
                m_body.AddForce(new dVector(m_forceAcc.x, m_forceAcc.y, m_forceAcc.z, 0.0f));
                m_body.AddTorque(new dVector(m_torqueAcc.x, m_torqueAcc.y, m_torqueAcc.z, 0.0f));
            }
        }
    }

    //  I do not know howo to get a NetwonBody from a dNetwonBody, ideally a reference can be save with the NewtonBody 
    //  public void OnCollision(NewtonBody otherBody)
    public void OnCollision(dNewtonBody otherBody)
    {
        Debug.Log("collision xxxxxx");
    }


    public dNewtonBody GetBody()
    {
        return m_body;
    }

    public bool SleepState
    {
        get
        {
            if(m_body != null)
                return m_body.GetSleepState();

            return false;
        }
        set
        {
            if (m_body != null)
            {
                m_body.SetSleepState(value);
            }
        }
    }

    public float m_mass;
    public bool m_needsCollisionNotification = false;

    public NewtonWorld m_world;
    public Vector3 m_forceAcc { get; set; }
    public Vector3 m_torqueAcc { get; set; }
    public bool m_isScene { get; set; }

    private dNewtonBody m_body = null;
    private NewtonBodyCollision m_collision = null;
    private float[] m_positionPtr = new float[3];
    private float[] m_rotationPtr = new float[4];
    private NewtonBodyForceAction[] m_actions;
}




