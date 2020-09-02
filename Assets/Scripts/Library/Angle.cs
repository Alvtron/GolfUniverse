using System;
using UnityEngine;

namespace GolfUniverse.Library
{
    public struct Angle
    {
        public float Radians { get; }
        public float Degrees
        {
            get => Radians * (180F / Mathf.PI);
        }

        private Angle(float radians)
        {
            Radians = radians;
        }

        public static Angle FromDegrees(float degrees)
        {
            var radians = degrees * (Mathf.PI / 180F);
            return new Angle(radians);
        }

        public static Angle FromRadians(float radians)
        {
            return new Angle(radians);
        }
    }
}
