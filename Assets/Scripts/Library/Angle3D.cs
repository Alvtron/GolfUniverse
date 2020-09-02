using System;

namespace GolfUniverse.Library
{
    public struct Angle3D
    {
        public Angle X { get; private set; }

        public Angle Y { get; private set; }

        public Angle Z { get; private set; }

        public Angle3D(Angle x, Angle y, Angle z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Angle3D FromDegrees(float x, float y, float z)
        {
            return new Angle3D(
                Angle.FromDegrees(x),
                Angle.FromDegrees(y),
                Angle.FromDegrees(z));
        }

        public static Angle3D FromRadians(float x, float y, float z)
        {
            return new Angle3D(
                Angle.FromRadians(x),
                Angle.FromRadians(y),
                Angle.FromRadians(z));
        }
    }
}
