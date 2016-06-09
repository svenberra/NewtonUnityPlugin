using UnityEngine;
using System;

namespace NewtonPlugin
{

    [AddComponentMenu("Newton Physics/Joints/BallAndSocket Joint")]
    public class NewtonBallAndSocket : MonoBehaviour
    {

        IntPtr joint = IntPtr.Zero;

        private NewtonBody childBody = null;
        public NewtonBody ConnectedBody = null;

        public bool useFriction = false;
        public float friction;

        void Start()
        {
            Debug.Log("Creating ballandsocket");

            childBody = GetComponentInParent<NewtonBody>();
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix.SetTRS(transform.position, transform.rotation, Vector3.one);

            Debug.Log("ChildBodyPtr:" + childBody.pBody.ToString());

            IntPtr parentBodyPtr = IntPtr.Zero;
            if (ConnectedBody != null)
            {
                parentBodyPtr = ConnectedBody.pBody;
                Debug.Log("ParentBodyPtr:" + parentBodyPtr.ToString());
            }

            if (useFriction)
                joint = NewtonAPI.NewtonCreateBallAndSocketWithFriction(ref matrix, childBody.pBody, parentBodyPtr, friction);
            else
                joint = NewtonAPI.NewtonCreateBallAndSocket(ref matrix, childBody.pBody, parentBodyPtr);

            Debug.Log("Created Joint(" + joint.ToString() + ")");


        }


        void OnDestroy()
        {
            Debug.Log("Destroying ballandsocket");
            //NewtonPlugin.DestroyJoint(joint);
        }

    }

}
