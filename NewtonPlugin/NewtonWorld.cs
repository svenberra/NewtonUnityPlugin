using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewtonPlugin
{
    class NewtonWorld
    {
        protected NewtonWorld()
        {
            pWorld = cpp.NewtonCreate();
            Debug.Log("Newton World created(" + pWorld.ToString() + ")");
        }

        ~NewtonWorld()
        {
            cpp.NewtonDestroy(pWorld);
            Debug.Log("Newton World destroyed(" + pWorld.ToString() + ")");
        }

        protected SWIGTYPE_p_NewtonWorld pWorld;
    }
}

