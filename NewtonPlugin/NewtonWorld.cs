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
            if (!m_isMemoryEnable)
            {
                m_isMemoryEnable = true;
                cpp.NewtonSetMemorySystem(m_alloc, m_free);
            }

            m_world = cpp.NewtonCreate();


            // link the work with this user data
            // !!!!no sure how to call this in teh wraper
            //cpp.NewtonWorldSetUserData(m_world, this);

            // set the simplified solver mode (faster but less accurate)
            cpp.NewtonSetSolverModel(m_world, 4);

            // set joint serialization call back
            // !!!!no sure how to call this in teh wraper
            // CustomJoint::Initalize(m_world);


            //Debug.Log("Newton World created(" + m_world.ToString() + ")");
        }

        ~NewtonWorld()
        {
            //Debug.Log("Newton World destroyed(" + m_world.ToString() + ")");
            cpp.NewtonDestroy(m_world);
        }

        protected SWIGTYPE_p_NewtonWorld m_world;
        static private bool m_isMemoryEnable = false;
        static private NewtonAllocMemory m_alloc = new NewtonAllocMemory();
        static private NewtonFreeMemory m_free = new NewtonFreeMemory();
    }
}

