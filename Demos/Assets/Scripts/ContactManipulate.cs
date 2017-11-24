using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactManipulate : NewtonBodyScript
{

    float largestImpact = 0;

    void Start () {
    }

    void Update () {
	}

    override public void OnCollision(NewtonBody otherBody)
    {
        largestImpact = 0;
    }

    override public void OnContact(NewtonBody otherBody, float normalImpact)
    {
        if(normalImpact > largestImpact)
        {
            largestImpact = normalImpact;
        }
    }

    override public void OnPostCollision(NewtonBody otherBody)
    {
        if(largestImpact > 1)
        {
            Debug.Log("Bounce! (" + largestImpact + ")");
        }
    }

}
