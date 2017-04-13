using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavatorControl : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // get the element form main body
        m_baseBody = transform.Find("ExcavatorBody").GetComponent<NewtonBody>();
        m_excavatorBoom = transform.Find("ExcavatorBoom").GetComponent<NewtonBody>();

        m_baseRotator = transform.Find("ExcavatorBody").GetComponent<NewtonHingeActuator>();
        m_excavatorBoomRotator = transform.Find("ExcavatorBoom").GetComponent<NewtonHingeActuator>();
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

        var oldBoomAngle = m_boomAngle;
        GUI.Label(new Rect(25, 54, 100, 30), "Boom rotation");
        m_boomAngle = GUI.HorizontalSlider(new Rect(120, 60, 250, 30), m_boomAngle, -20.0F, 20.0F);
        if (oldBoomAngle != m_boomAngle)
        {
            m_excavatorBoom.SleepState = false;
            m_excavatorBoomRotator.TargetAngle = m_boomAngle;
        }
    }

    NewtonBody m_baseBody = null;
    NewtonBody m_excavatorBoom = null;
    NewtonHingeActuator m_baseRotator = null;
    NewtonHingeActuator m_excavatorBoomRotator = null;

    private float m_baseAngle = 0.0f;
    private float m_boomAngle = 0.0f;
}





