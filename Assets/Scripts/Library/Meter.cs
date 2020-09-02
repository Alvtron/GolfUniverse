using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public struct Meter
    {
        public float Value { get; private set; }

        public Meter(float meters)
        {
            Value = meters;
        }

        public static Meter FromKilometers(float kilometers)
        {
            return new Meter(kilometers * 1000F);
        }

        public static Meter FromMiles(float miles)
        {
            return new Meter(miles * 1000000F);
        }

        public static Meter operator +(Meter a, Meter b)
        {
            return new Meter(a.Value + b.Value);
        }

        public static Meter operator -(Meter a, Meter b)
        {
            return new Meter(a.Value - b.Value);
        }

        public static Meter operator *(Meter a, Meter b)
        {
            return new Meter(a.Value * b.Value);
        }

        public static Meter operator /(Meter a, Meter b)
        {
            return new Meter(a.Value / b.Value);
        }

        public static Meter operator +(Meter a, float b)
        {
            return new Meter(a.Value + b);
        }

        public static Meter operator -(Meter a, float b)
        {
            return new Meter(a.Value - b);
        }

        public static Meter operator *(Meter a, float b)
        {
            return new Meter(a.Value * b);
        }

        public static Meter operator /(Meter a, float b)
        {
            return new Meter(a.Value / b);
        }

        public static Meter operator +(float a, Meter b) => b + a;
        public static Meter operator -(float a, Meter b) => b - a;
        public static Meter operator *(float a, Meter b) => b * a;
        public static Meter operator /(float a, Meter b) => b / a;
    }
}
