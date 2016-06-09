//using UnityEngine;
//using System;

//[AddComponentMenu("Newton Physics/Vehicle/Vehicle Tire")]
//public class NewtonVehicleTire : MonoBehaviour
//{
//    public NewtonPlugin.TireParameters tireParameters;

//    public Transform tireTransform;

//    public Vector3 rotationOffset = Vector3.zero;

//    public IntPtr _tirePtr;

//    public void UpdateTransform()
//    {
//        IntPtr body = NewtonPlugin.VehicleTireGetBody(_tirePtr);

//        Matrix4x4 mat = Matrix4x4.identity;
//        NewtonPlugin.BodyGetMatrix(body, ref mat);

//        Quaternion q = new Quaternion();
//        q.w = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] + mat[1, 1] + mat[2, 2])) / 2;
//        q.x = Mathf.Sqrt(Mathf.Max(0, 1 + mat[0, 0] - mat[1, 1] - mat[2, 2])) / 2;
//        q.y = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] + mat[1, 1] - mat[2, 2])) / 2;
//        q.z = Mathf.Sqrt(Mathf.Max(0, 1 - mat[0, 0] - mat[1, 1] + mat[2, 2])) / 2;
//        q.x *= Mathf.Sign(q.x * (mat[2, 1] - mat[1, 2]));
//        q.y *= Mathf.Sign(q.y * (mat[0, 2] - mat[2, 0]));
//        q.z *= Mathf.Sign(q.z * (mat[1, 0] - mat[0, 1]));

//        tireTransform.position = new Vector3(mat.m03, mat.m13, mat.m23);

//        Quaternion offsetRot = Quaternion.Euler(rotationOffset);
//        tireTransform.rotation = q * offsetRot;

//    }

//}
