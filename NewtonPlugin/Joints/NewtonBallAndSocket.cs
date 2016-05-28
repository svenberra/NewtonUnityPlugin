using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Joints/BallAndSocket Joint")]
    public class NewtonBallAndSocket : NewtonJoint
    {
        public NewtonBody ConnectedBody = null;

        public Vector3 Anchor;

        public bool useFriction = false;
        public float friction;

        public new void Awake()
        {
            otherBody = ConnectedBody;
            base.Awake();
        }

        public void OnDrawGizmosSelected()
        {
            Vector3 worldAnchorPos = transform.TransformPoint(Anchor);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(worldAnchorPos, 0.05f);
        }

        public unsafe override IntPtr CreateJoint()
        {
            Debug.Log("Creating BallAndSocketJoint");

            // Health check
            if(mainBodyPtr == IntPtr.Zero)
            {
                Debug.LogError("[NewtonBallAndSocket]Something went bad, NewtonBody pointer is null.");
                return IntPtr.Zero;
            }

            Vector3 worldAnchorPos = transform.TransformPoint(Anchor);
            Quaternion worldRotation = transform.rotation;

            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(worldAnchorPos, worldRotation, Vector3.one);

            if (useFriction)
                return NewtonInvoke.NewtonCreateBallAndSocketWithFriction((float*)&matrix, mainBodyPtr, otherBodyPtr, friction);
            else
                return NewtonInvoke.NewtonCreateBallAndSocket((float*)&matrix, mainBodyPtr, otherBodyPtr);

        }

    }

}
