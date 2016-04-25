using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewtonPlugin
{
    // This compiles but I do no think is correct, I do not see any funtion to return the allocated memory
    class NewtonAllocMemory: SWIGTYPE_p_f_int__p_void
    {
        static NewtonAllocMemory()
        {
        }
    }

    class NewtonFreeMemory : SWIGTYPE_p_f_q_const__p_void_int__void
    {
        static NewtonFreeMemory()
        {
        }
    }


    class NewtonWorld
    {
        protected NewtonWorld()
        {
            // create the static memory alloction glue code. (I am no sur eif this is right)
            m_alloc = new NewtonAllocMemory();
            m_free = new NewtonFreeMemory();

            cpp.NewtonSetMemorySystem(m_alloc, m_free);

            m_world = cpp.NewtonCreate();
            
            Debug.Log("Newton World created(" + m_world.ToString() + ")");
        }

        ~NewtonWorld()
        {
            Debug.Log("Newton World destroyed(" + m_world.ToString() + ")");
            cpp.NewtonDestroy(m_world);
        }

        protected SWIGTYPE_p_NewtonWorld m_world;
        static private NewtonAllocMemory m_alloc;
        static private NewtonFreeMemory m_free;
    }
}

