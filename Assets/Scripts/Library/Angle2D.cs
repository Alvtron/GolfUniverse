using System;

namespace GolfUniverse.Library
{
    public struct Angle2D
    {
        public Angle X { get; private set; }

        public Angle Y { get; private set; }

        public Angle2D(Angle x, Angle y)
        {
            X = x;
            Y = y;
        }

        public static Angle2D FromDegrees(float x, float y) 
            => new Angle2D(Angle.FromDegrees(x), Angle.FromDegrees(y));

        public static Angle2D FromRadians(float x, float y)
            => new Angle2D(Angle.FromRadians(x), Angle.FromRadians(y));
    }
}
