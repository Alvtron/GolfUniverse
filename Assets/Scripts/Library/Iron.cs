using System;
using UnityEngine;

namespace GolfUniverse.Library
{
    public class Iron : IGolfClub
    {
        private readonly int number;
        private readonly float speed;
        private readonly float quality;

        public float HeadMass { get; }
        public float ShaftMass { get; }
        public float HeadLength { get; }
        public float ShaftLength { get; }
        public float Loft { get; }

        public Iron(int number, float speed, float quality, float headMass, float shaftMass, float headLength, float shaftLength, float loft)
        {
            this.number = number;
            this.speed = speed;
            this.quality = quality;
            HeadMass = headMass;
            ShaftMass = shaftMass;
            HeadLength = headLength;
            ShaftLength = shaftLength;
            Loft = loft;
        }

        public Vector3 GetDirection(GolferSkillSet golferSkillSet, Vector3 surfaceAngle)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetVelocity(GolferSkillSet golferSkillSet, float friction)
        {
            throw new NotImplementedException();
        }
    }
}
