//using UnityEngine;
//using System;

//namespace NewtonPlugin
//{

//    [AddComponentMenu("Newton Physics/Joints/Rolling Friction Joint")]
//    public class NewtonRollingFriction : MonoBehaviour
//    {

//        public float Radius;
//        public float Friction;

//        IntPtr joint = IntPtr.Zero;

//        private NewtonBody childBody = null;

//        void Start()
//        {
//            Debug.Log("Creating rolling friction");

//            childBody = GetComponentInParent<NewtonBody>();
//            joint = NewtonAPI.NewtonCreateRollingFriction(childBody.pBody, Radius, Friction);
//        }


//        void OnDestroy()
//        {
//            Debug.Log("Destroying rolling friction");
//            //NewtonPlugin.DestroyJoint(joint);
//        }

//    }

//}
