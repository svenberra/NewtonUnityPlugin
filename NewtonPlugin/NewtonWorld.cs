using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewtonPlugin
{

    //internal class NewtonWorld
    //{
    //    private static NewtonWorld _instance = null;
    //    private static readonly object _lock = new object();

    //    public static NewtonWorld Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                lock (_lock)
    //                {
    //                    if (_instance == null)
    //                    {
    //                        _instance = new NewtonWorld();
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }

    //    public IntPtr pWorld;

    //    private NewtonWorld()
    //    {
    //        pWorld = NewtonAPI.NewtonCreate();

    //        //Debug.Log("Newton World created(" + pWorld.ToString() +")");

    //        string log = DateTime.Now.ToUniversalTime() + ":" + "Newton World created(" + pWorld.ToString() +")\n";
    //        System.IO.File.AppendAllText("D:\\worldlog.txt", log);

    //    }

    //    ~NewtonWorld()
    //    {
    //        NewtonAPI.NewtonDestroy(pWorld);
    //        //Debug.Log("Newton World destroyed(" + pWorld.ToString() + ")");
    //        string log = DateTime.Now.ToUniversalTime() + ":" + "Newton World destroyed(" + pWorld.ToString() + ")\n";
    //        System.IO.File.AppendAllText("D:\\worldlog.txt", log);

    //        pWorld = IntPtr.Zero;
    //    }

    //}

    //   internal class NewtonWorld : Singleton<NewtonWorld>
    class NewtonWorld: IDisposable
    {
        protected NewtonWorld()
        {
            //pWorld = NewtonAPI.NewtonCreate();
            pWorld = cpp.NewtonCreate();
            Debug.Log("Newton World created(" + pWorld.ToString() + ")");
        }

        public void Dispose()
        {
            cpp.NewtonDestroy(pWorld);
            Debug.Log("Newton World destroyed(" + pWorld.ToString() + ")");
            Debug.Log("Newton World destroyed(" + pWorld.ToString() + ")");
//          pWorld = pWorld..Zero;
        }

        protected SWIGTYPE_p_NewtonWorld pWorld;
    }
}

