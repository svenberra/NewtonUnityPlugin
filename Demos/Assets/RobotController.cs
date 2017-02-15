using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    NewtonBody baseNB = null;
    NewtonBody bodyNB = null;
    NewtonBody armNB = null;
    NewtonBody handANB = null;
    NewtonBody handBNB = null;
    NewtonHingeActuator baseActuator = null;
    NewtonHingeActuator bodyActuator = null;
    NewtonHingeActuator armActuator = null;
    NewtonSliderActuator handAActuator = null;
    NewtonSliderActuator handBActuator = null;

    private float baseAngle = 0.0f;
    private float bodyAngle = 0.0f;
    private float armAngle = 0.0f;
    private float gripperPos = 0.0f;

    // Use this for initialization
    void Start()
    {
        baseNB = transform.Find("RobotBase").GetComponent<NewtonBody>();
        baseActuator = transform.Find("RobotBase").GetComponent<NewtonHingeActuator>();

        bodyNB = transform.Find("RobotBody").GetComponent<NewtonBody>();
        bodyActuator = transform.Find("RobotBody").GetComponent<NewtonHingeActuator>();

        armNB = transform.Find("RobotArm").GetComponent<NewtonBody>();
        armActuator = transform.Find("RobotArm").GetComponent<NewtonHingeActuator>();

        handANB = transform.Find("RobotHandA").GetComponent<NewtonBody>();
        handAActuator = transform.Find("RobotHandA").GetComponent<NewtonSliderActuator>();

        handBNB = transform.Find("RobotHandB").GetComponent<NewtonBody>();
        handBActuator = transform.Find("RobotHandB").GetComponent<NewtonSliderActuator>();

    }

    // Update is called once per frame
    void Update()
    {
        //if(body)
        //{
        //    Debug.Log(body.SleepState);
        //}
    }

    void OnGUI()
    {        
        var oldBaseAngle = baseAngle;
        baseAngle = GUI.HorizontalSlider(new Rect(25, 20, 100, 30), baseAngle, -180.0F, 180.0F);
        if(oldBaseAngle != baseAngle)
        {
            baseActuator.TargetAngle = baseAngle;
            baseNB.SleepState = false;
        }

        var oldbodyAngle = bodyAngle;
        bodyAngle = GUI.HorizontalSlider(new Rect(25, 50, 100, 30), bodyAngle, -45.0F, 45.0F);
        if (oldbodyAngle != bodyAngle)
        {
            bodyActuator.TargetAngle = bodyAngle;
            bodyNB.SleepState = false;
        }

        var oldArmAngle = armAngle;
        armAngle = GUI.HorizontalSlider(new Rect(25, 80, 100, 30), armAngle, -60.0F, 60.0F);
        if (oldArmAngle != armAngle)
        {
            armActuator.TargetAngle = armAngle;
            armNB.SleepState = false;
        }

        var oldgripperPos = gripperPos;
        gripperPos = GUI.HorizontalSlider(new Rect(25, 110, 100, 30), gripperPos, 0.0F, 0.25F);
        if (oldgripperPos != gripperPos)
        {
            handAActuator.TargetPosition = gripperPos;
            handANB.SleepState = false;
            handBActuator.TargetPosition = gripperPos;
            handBNB.SleepState = false;
        }

    }

}
