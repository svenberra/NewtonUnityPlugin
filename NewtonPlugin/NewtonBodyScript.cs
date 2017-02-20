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

[AddComponentMenu("Newton Physics/Newton Body Script")]
public class NewtonBodyScript : MonoBehaviour
{
    //  I do not know how to get a NetwonBody from a dNetwonBody, ideally a reference can be save with the NewtonBody 
    //  public void OnCollision(NewtonBody otherBody)
    virtual public void OnCollision(dNewtonBody otherBody)
    {
        // do nothing
        //Debug.Log("do nothing");
    }

    virtual public void OnApplyForceAndTorque(float timestep)
    {
        // do nothing
        // example how to apply force to a game object
        //NewtonBody body = GetComponent<NewtonBody>();
        //Vector3 force = new Vector3 (0.0f, 1o.0f, 0.0f);
        //Vector3 torque = new Vector3 (0.0f, 0.0f, 0.0f);
        //body.GetBody().AddForce(new dVector(force.x, force.y, force.z, 0.0f));
        //body.GetBody().AddTorque(new dVector(torque.x, torque.y, torque.z, 0.0f));
    }

    public bool m_enableForceAndTorque = true;
    public bool m_collisionNotification = true;
}

