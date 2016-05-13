using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{


    //TODO: Make this a NewtonBody as well

    [AddComponentMenu("Newton Physics/Vehicle/Vehicle Tire")]
    public class NewtonVehicleTire : MonoBehaviour
    {
        public NewtonTireParameters tireParameters;

        public Vector3 rotationOffset = Vector3.zero;
        public bool Steering;
        public bool Brakes;
        public bool HandBrakes;

        //public Transform tireTransform;

        internal IntPtr tirePtr;
        internal IntPtr bodyPtr;
        internal IntPtr btsPtr;

        public unsafe void UpdateTransform()
        {
            if (btsPtr != IntPtr.Zero)
            {
                BodyTransformState* bts = (BodyTransformState*)btsPtr;

                Quaternion offsetRot = Quaternion.Euler(rotationOffset);
                transform.position = bts->GetInterpolatedPosition(NewtonManager.TimeAlpha);
                transform.rotation = bts->GetInterpolatedRotation(NewtonManager.TimeAlpha) * offsetRot;

            }

            //IntPtr bodyPtr = NewtonInvoke.NewtonVehicleTireGetBody(tirePtr);

            //Vector3 pos = new Vector3();
            //Quaternion rot = new Quaternion();
            //NewtonInvoke.NewtonBodyGetPositionAndRotation(bodyPtr, (float*)&pos, (float*)&rot);

            //transform.position = pos;

            //Quaternion offsetRot = Quaternion.Euler(rotationOffset);
            //transform.rotation = rot * offsetRot;
        }

    }

}
