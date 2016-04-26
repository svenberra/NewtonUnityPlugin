using UnityEngine;
using System.Runtime.InteropServices;
using System;

public delegate IntPtr NewtonAllocMemoryDelegate(int sizeInBytes);
public delegate void NewtonFreeMemoryDelegate(System.IntPtr ptr, int sizeInBytes);

namespace NewtonPlugin
{

    public class NewtonWorld : MonoBehaviour
    {
        protected SWIGTYPE_p_NewtonWorld m_world;
        private GCHandle gch_this;

        static private bool m_isMemoryEnable = false;
        static private System.Collections.Generic.Dictionary<IntPtr, int> _allocated = null;
        static private NewtonAllocMemoryDelegate m_alloc = new NewtonAllocMemoryDelegate(AllocMemory);
        static private NewtonFreeMemoryDelegate m_free = new NewtonFreeMemoryDelegate(FreeMemory);

        static IntPtr AllocMemory(int sizeInBytes)
        {
            IntPtr newMemPtr = Marshal.AllocHGlobal(sizeInBytes);
            _allocated.Add(newMemPtr, sizeInBytes);
            Debug.Log("Allocated " + sizeInBytes.ToString() + " bytes at address " + newMemPtr.ToString());
            return newMemPtr;
        }
        
        static void FreeMemory(IntPtr ptr, int sizeInBytes)
        {
            Marshal.FreeHGlobal(ptr);
            _allocated.Remove(ptr);
            Debug.Log("Freed " + sizeInBytes.ToString() + " bytes at address " + ptr.ToString());
        }

        void Awake()
        {

            // Enable custom memory allocation
            if (!m_isMemoryEnable)
            {
                m_isMemoryEnable = true;
                _allocated = new System.Collections.Generic.Dictionary<IntPtr, int>();
                NewtonWrapper.NewtonSetMemorySystem(m_alloc, m_free);
            }

            m_world = NewtonWrapper.NewtonCreate();


            // link the world with this user data
            // !!!!no sure how to call this in teh wraper

            gch_this = GCHandle.Alloc(this, GCHandleType.Normal);

            NewtonWrapper.NewtonWorldSetUserData(m_world, GCHandle.ToIntPtr(gch_this));
            Debug.Log("Passed this to NewtonWorld as Userdata");
            //cpp.NewtonWorldSetUserData(m_world, this);

            // set the simplified solver mode (faster but less accurate)
            NewtonWrapper.NewtonSetSolverModel(m_world, 4);

            // set joint serialization call back
            // !!!!no sure how to call this in teh wraper
            // CustomJoint::Initalize(m_world);

            //Debug.Log("Newton World created");
        }

        void OnDestroy()
        {
            gch_this.Free();

            NewtonWrapper.NewtonDestroy(m_world);

            Debug.Log("Unallocated memory addresses:" + _allocated.Count.ToString());

            //Debug.Log("Newton World destroyed");
        }

    }
}

