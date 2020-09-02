using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public class Driver : IGolfClub
    {
        private readonly float speed;
        private readonly float hardness;
        private readonly float quality;

        public float HeadMass { get; }
        public float ShaftMass { get; }
        public float HeadLength { get; }
        public float ShaftLength { get; }
        public float Loft { get; }

        public Driver(float speed, float weight, float loft, float hardness, float quality)
        {
            this.speed = speed;
            HeadMass = weight;
            Loft = loft;
            this.hardness = hardness;
            this.quality = quality;
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
