using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public class Putter : IGolfClub
    {
        private readonly float hardness;
        private readonly float quality;

        public float HeadMass { get; }
        public float ShaftMass { get; }
        public float HeadLength { get; }
        public float ShaftLength { get; }
        public float Loft { get; }

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
