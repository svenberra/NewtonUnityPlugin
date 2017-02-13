using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    NewtonBody body = null;
    NewtonHingeActuator RobotBase = null;

    private float BaseAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
        RobotBase = GetComponent<NewtonHingeActuator>();
        body = GetComponent<NewtonBody>();
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
        var oldBaseAngle = BaseAngle;
        BaseAngle = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), BaseAngle, 0.0F, 359.0F);
        if(oldBaseAngle != BaseAngle)
        {
            RobotBase.TargetAngle = BaseAngle;
            body.SleepState = false;
        }

    }

}
