using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavatorControl : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // get the element form main body
        //m_baseBody = transform.GetComponent<NewtonBody>();
        //m_baseRotator = transform.GetComponent<NewtonHingeActuator>();

        m_baseBody = transform.Find("ExcavatorBody").GetComponent<NewtonBody>();
        m_baseRotator = transform.Find("ExcavatorBody").GetComponent<NewtonHingeActuator>();
    }

    void OnGUI()
    {
        var oldBaseAngle = m_baseAngle;
        GUI.Label(new Rect(25, 14, 100, 30), "Base rotation");
        m_baseAngle = GUI.HorizontalSlider(new Rect(120, 20, 250, 30), m_baseAngle, -360.0F, 360.0F);
        if (oldBaseAngle != m_baseAngle)
        {
            m_baseBody.SleepState = false;
            m_baseRotator.TargetAngle = m_baseAngle;
        }
    }

    NewtonBody m_baseBody = null;
    NewtonHingeActuator m_baseRotator = null;

    private float m_baseAngle = 0.0f;
}





