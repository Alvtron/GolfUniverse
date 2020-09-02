using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GolfUniverse.Library
{
    public static class Vector3Extensions
    {
        public static Vector3 Unit(this Vector3 vector) => vector / vector.magnitude;
        public static Vector3 Absolute(this Vector3 vector) => new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        public static Vector3 Squared(this Vector3 vector) => new Vector3(Mathf.Sqrt(vector.x), Mathf.Sqrt(vector.y));
        public static Vector3 Negative(this Vector3 vector) => new Vector3(
            vector.x < 0F ? vector.x * (-1F) : vector.x,
            vector.y < 0F ? vector.y * (-1F) : vector.y,
            vector.z < 0F ? vector.z * (-1F) : vector.z);
    }
}
