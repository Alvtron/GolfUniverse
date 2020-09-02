using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public static class NumericExtensions
    {
        #region Squared
        public static int Squared(this sbyte value) => value * value;
        public static int Squared(this byte value) => value * value;
        public static int Squared(this short value) => value * value;
        public static int Squared(this ushort value) => value * value;
        public static int Squared(this int value) => value * value;
        public static uint Squared(this uint value) => value * value;
        public static long Squared(this long value) => value * value;
        public static ulong Squared(this ulong value) => value * value;
        public static float Squared(this float value) => value * value;
        public static decimal Squared(this decimal value) => value * value;
        #endregion
        #region Cubed
        public static int Cubed(this sbyte value) => value * value * value;
        public static int Cubed(this byte value) => value * value * value;
        public static int Cubed(this short value) => value * value * value;
        public static int Cubed(this ushort value) => value * value * value;
        public static int Cubed(this int value) => value * value * value;
        public static uint Cubed(this uint value) => value * value * value;
        public static long Cubed(this long value) => value * value * value;
        public static ulong Cubed(this ulong value) => value * value * value;
        public static float Cubed(this float value) => value * value * value;
        public static decimal Cubed(this decimal value) => value * value * value;
        #endregion

        public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
        {
            var fromAbs = from - fromMin;
            var fromMaxAbs = fromMax - fromMin;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = toMax - toMin;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + toMin;

            return to;
        }
    }
}
