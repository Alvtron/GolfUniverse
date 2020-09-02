using System;
using UnityEngine;

namespace GolfUniverse.Library
{
    public static class Vector2Extensions
    {
        public static Vector2 Unit(this Vector2 vector) => vector / vector.magnitude;
        public static Vector2 Absolute(this Vector2 vector) => new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        public static Vector2 Squared(this Vector2 vector) => new Vector2(Mathf.Sqrt(vector.x), Mathf.Sqrt(vector.y));
        public static Vector2 Negative(this Vector2 vector) => new Vector2(
            vector.x < 0F ? vector.x * (-1F) : vector.x,
            vector.y < 0F ? vector.y * (-1F) : vector.y);
    }
}
