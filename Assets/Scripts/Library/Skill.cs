using System;

namespace GolfUniverse.Library
{
    public struct Skill
    {
        private readonly double min;

        private readonly double max;

        public double Value { get; private set; }

        public Skill(double min, double max, double value)
        {
            if (max <= 0.0)
            {
                throw new ArgumentException("the maximum cannot be zero or negative", nameof(max));
            }
            if (min < 0.0)
            {
                throw new ArgumentException("the minimum cannot be negative", nameof(min));
            }
            if (min > max)
            {
                throw new ArgumentException("the minimum cannot be higher than the maximum", nameof(min));
            }
            if (value < min && max < value)
            {
                throw new ArgumentException("the value must be within range of the minimum and maximum", nameof(value));
            }
            this.min = min;
            this.max = max;
            Value = value;
        }

        public bool InRange(double value)
        {
            return min <= value && value <= max;
        }

        public static bool EqualRange(Skill a, Skill b)
        {
            return a.min == b.min && a.max == b.max;
        }

        public static Skill operator +(Skill skill, double value)
        {
            return new Skill(skill.min, skill.max, skill.Value + value);
        }

        public static Skill operator -(Skill skill, double value)
        {
            return new Skill(skill.min, skill.max, skill.Value - value);
        }

        public static Skill operator *(Skill skill, double value)
        {
            return new Skill(skill.min, skill.max, skill.Value * value);
        }

        public static Skill operator /(Skill skill, double value)
        {
            return new Skill(skill.min, skill.max, skill.Value / value);
        }


        public static Skill operator -(double value, Skill skill) => skill - value;
        public static Skill operator *(double value, Skill skill) => skill * value;
        public static Skill operator +(double value, Skill skill) => skill + value;
        public static Skill operator /(double value, Skill skill) => skill / value;
    }
}
