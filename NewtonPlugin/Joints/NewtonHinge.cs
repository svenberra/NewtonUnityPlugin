using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Joints/Hinge Joint")]
    public class NewtonHinge : NewtonJoint
    {

        public NewtonBody ConnectedBody = null;

        public Vector3 Anchor;
        public Vector3 Axis = Vector3.right;

        public new void Awake()
        {
            otherBody = ConnectedBody;
            base.Awake();
        }

        public void OnDrawGizmosSelected()
        {
            Vector3 worldAnchorPos = transform.TransformPoint(Anchor);
            Quaternion worldRot = transform.rotation;
            Quaternion axisRot = Quaternion.FromToRotation(Vector3.right, Axis);
            worldRot *= axisRot;

            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(worldAnchorPos, worldRot, Vector3.one);

            Gizmos.matrix = matrix;
            Vector3 boxVector = new Vector3(0.5f, 0.05f, 0.05f);

            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(Vector3.zero, 0.05f);
            Gizmos.DrawCube(Vector3.zero, boxVector);

            Gizmos.matrix = Matrix4x4.identity;

        }

        public unsafe override IntPtr CreateJoint()
        {
            Debug.Log("Creating HingeJoint");

            // Health check
            if (mainBodyPtr == IntPtr.Zero)
            {
                Debug.LogError("[NewtonHinge]Something went bad, NewtonBody pointer is null.");
                return IntPtr.Zero;
            }

            Vector3 worldAnchorPos = transform.TransformPoint(Anchor);
            Quaternion worldRot = transform.rotation;
            Quaternion axisRot = Quaternion.FromToRotation(Vector3.right, Axis);
            worldRot *= axisRot;

            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(worldAnchorPos, worldRot, Vector3.one);

            return NewtonInvoke.NewtonCreateHinge((float*)&matrix, mainBodyPtr, otherBodyPtr);

        }

    }
}