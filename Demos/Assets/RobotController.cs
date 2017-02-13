using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    NewtonBody baseBody = null;
    NewtonBody armBody = null;
    NewtonBody handBody = null;
    NewtonHingeActuator baseActuator = null;
    NewtonHingeActuator armActuator = null;
    NewtonHingeActuator handActuator = null;

    private float baseAngle = 0.0f;
    private float armAngle = 0.0f;
    private float handAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
        baseBody = transform.Find("RobotBase").GetComponent<NewtonBody>();
        baseActuator = transform.Find("RobotBase").GetComponent<NewtonHingeActuator>();

        armBody = transform.Find("RobotArm").GetComponent<NewtonBody>();
        armActuator = transform.Find("RobotArm").GetComponent<NewtonHingeActuator>();

        handBody = transform.Find("RobotHand").GetComponent<NewtonBody>();
        handActuator = transform.Find("RobotHand").GetComponent<NewtonHingeActuator>();

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
        baseAngle = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), baseAngle, 0.0F, 359.0F);
        if(oldBaseAngle != baseAngle)
        {
            baseActuator.TargetAngle = baseAngle;
            baseBody.SleepState = false;
        }

        var oldArmAngle = armAngle;
        armAngle = GUI.HorizontalSlider(new Rect(25, 25 + 40, 100, 30), armAngle, 0.0F, 359.0F);
        if (oldArmAngle != armAngle)
        {
            armActuator.TargetAngle = armAngle;
            armBody.SleepState = false;
        }

        var oldHandAngle = handAngle;
        handAngle = GUI.HorizontalSlider(new Rect(25, 25 + 80, 100, 30), handAngle, 0.0F, 359.0F);
        if (oldHandAngle != handAngle)
        {
            handActuator.TargetAngle = handAngle;
            handBody.SleepState = false;
        }

    }

}
