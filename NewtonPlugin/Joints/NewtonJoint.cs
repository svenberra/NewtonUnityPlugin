using UnityEngine;
using System;
using NewtonAPI;

namespace NewtonPlugin
{

    [RequireComponent(typeof(NewtonBody))]
    abstract public class NewtonJoint : MonoBehaviour
    {
        protected NewtonBody mainBody = null;
        protected NewtonBody otherBody = null;

        protected IntPtr mainBodyPtr = IntPtr.Zero;
        protected IntPtr otherBodyPtr = IntPtr.Zero;
        protected IntPtr jointPtr = IntPtr.Zero;
        private bool disposed = false;

        public void Awake()
        {
            // Get main body
            mainBody = GetComponent<NewtonBody>();
            if(mainBody == null)
            {
                Debug.LogError("[NewtonJoint]Something went bad, can't find NewtonBody component.");
                return;
            }

            mainBodyPtr = mainBody.GetBodyPointer();
            if (mainBodyPtr == IntPtr.Zero)
            {
                Debug.LogError("[NewtonJoint]Something went bad, NewtonBody pointer is null.");
                return;
            }

            otherBodyPtr = IntPtr.Zero;
            if(otherBody != null)
            {
                otherBodyPtr = otherBody.GetBodyPointer();
                if (otherBodyPtr == IntPtr.Zero)
                {
                    Debug.LogError("[NewtonJoint]Something went bad, connected NewtonBody pointer is null.");
                    return;
                }
            }

            // Ok, if we got here it's time to create the joint.
            jointPtr = CreateJoint();
            if (jointPtr == IntPtr.Zero)
            {
                Debug.LogError("[NewtonJoint]Something went bad, Joint pointer is null.");
                return;
            }

            // Finally, setup an event listener to the connected bodies.
            // If any of them are destroyed, the joint must be destroyed before
            mainBody.OnBodyDestroy += OnBodyDestroy;
            if (otherBody)
                otherBody.OnBodyDestroy += OnBodyDestroy;
            
        }

        public void OnDestroy()
        {
            Dispose();
        }

        // Event handler for OnBodyDestroy
        private void OnBodyDestroy()
        {
            Debug.Log("[NewtonJoint] connected body about to be destroyed");

            // One of the connected bodies was destroyed before this Joint, therefore the joint must go.
            Dispose();

            // We also need to destroy the component here since it was a body that triggered this and not the Joint itself.
            // This will trigger OnDestroy above which will trigger Dispose again, but it's safe to call multiple times.
            Destroy(this);
        }

        // This isn't an IDisposible implementation.
        private void Dispose()
        {
            if (!disposed)
            {
                // First remove the event handlers.
                if (mainBody)
                    mainBody.OnBodyDestroy -= OnBodyDestroy;

                if (otherBody)
                    otherBody.OnBodyDestroy -= OnBodyDestroy;

                mainBody = null;
                otherBody = null;

                // Next delete the unmanaged joint
                if (jointPtr != IntPtr.Zero)
                {
                    NewtonInvoke.NewtonDestroyCustomJoint(jointPtr);
                    jointPtr = IntPtr.Zero;
                    Debug.Log("[NewtonJoint] Deleted unmanaged joint ptr attached to " + this.gameObject.name);
                }
            }

            disposed = true;

        }

        abstract public IntPtr CreateJoint();

    }

}


