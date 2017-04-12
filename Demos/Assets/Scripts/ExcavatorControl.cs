using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavatorControl : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // get the element form main body
        m_baseBody = transform.GetComponent<NewtonBody>();
        m_baseRotator = transform.GetComponent<NewtonHingeActuator>();
        
        //m_baseBody = transform.Find("Excavator").GetComponent<NewtonBody>();
        //m_baseRotator = transform.Find("Excavator").GetComponent<NewtonHingeActuator>();
    }

    void OnGUI()
    {
        var oldBaseAngle = m_baseAngle;
        m_baseAngle = GUI.HorizontalSlider(new Rect(25, 20, 250, 30), m_baseAngle, -360.0F, 360.0F);
        if (oldBaseAngle != m_baseAngle)
        {
            m_baseRotator.TargetAngle = m_baseAngle;
            m_baseBody.SleepState = false;
        }
    }

    NewtonBody m_baseBody = null;
    NewtonHingeActuator m_baseRotator = null;

    private float m_baseAngle = 0.0f;
}





