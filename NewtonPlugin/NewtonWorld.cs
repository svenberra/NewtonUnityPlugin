using UnityEngine;
using System.Runtime.InteropServices;
using System;

public delegate IntPtr NewtonAllocMemoryDelegate(int sizeInBytes);
public delegate void NewtonFreeMemoryDelegate(System.IntPtr ptr, int sizeInBytes);

namespace NewtonPlugin
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Rigid Body")]
    public class NewtonWorld : MonoBehaviour
    {
        protected NewtonSDK m_world;

        void Awake()
        {
            m_world = new NewtonSDK();
            // link the world with this user data
            Debug.Log("Passed this to NewtonWorld as Userdata");
        }

        void OnDestroy()
        {
            //NewtonWrapper.NewtonDestroy(m_world);
            //Debug.Log("Unallocated memory addresses:" + _allocated.Count.ToString());
            //Debug.Log("Newton World destroyed");
        }
    }
}

