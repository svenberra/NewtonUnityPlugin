using UnityEngine;
using System;

namespace NewtonPlugin
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Newton Physics/Newton World")]
    public class NewtonWorld : MonoBehaviour
    {
        private NewtonSDK m_sdk;

        void Start()
        {
            m_sdk = new NewtonSDK();
        }

        void OnDestroy()
        {
            m_sdk.Dispose();
        }
    }
}

