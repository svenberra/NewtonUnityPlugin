using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Joints/Hinge Joint")]
    public class NewtonHinge : MonoBehaviour
    {

        IntPtr joint = IntPtr.Zero;

        private NewtonBody childBody = null;
        public NewtonBody ConnectedBody = null;

        public float Friction;
        public bool EnableLimits;
        public float MinAngle;
        public float MaxAngle;


        void Start()
        {
            Debug.Log("Creating hinge");

            childBody = GetComponentInParent<NewtonBody>();
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

            IntPtr parentBodyPtr = IntPtr.Zero;
            if (ConnectedBody != null)
                parentBodyPtr = ConnectedBody.pBody;

            joint = NewtonAPI.NewtonCreateHinge(ref matrix, childBody.pBody, parentBodyPtr);
            NewtonAPI.NewtonHingeEnableLimits(joint, EnableLimits);

            NewtonAPI.NewtonHingeSetLimits(joint, MinAngle * Mathf.Deg2Rad, MaxAngle * Mathf.Deg2Rad);
            NewtonAPI.NewtonHingeSetFriction(joint, Friction);

        }


        void OnDestroy()
        {
            Debug.Log("Destroying hinge");
            //NewtonPlugin.DestroyJoint(joint);
        }

    }
}