using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NewtonPlugin
{
    class Helpers
    {

        public static NewtonCollider[] GetAllColliders(GameObject GO)
        {
            List<NewtonCollider> colliders = new List<NewtonCollider>();

            TraverseColliders(GO, GO, colliders);

            return colliders.ToArray();
        }

        public static void TraverseColliders(GameObject obj, GameObject rootGO, List<NewtonCollider> colliders)
        {
            // Don't fetch colliders from children with NewtonBodies
            if (obj != rootGO && obj.GetComponent<NewtonBody>() != null)
                return;

            //Fetch all colliders
            foreach (NewtonCollider coll in obj.GetComponents<NewtonCollider>())
                colliders.Add(coll);

            foreach (Transform child in obj.transform)
                TraverseColliders(child.gameObject, rootGO, colliders);

        }


    }
}
