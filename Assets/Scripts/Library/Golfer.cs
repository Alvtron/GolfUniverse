using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public class Golfer : IGolfer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Mood Mood { get; }
        public Gender Gender { get; }
        public float Weight { get; }
        public TimeSpan Age => DateTime.Now - Birthday;
        public bool IsAlive => true;

        public float ShoulderRadius { get; }
        public float ArmLength { get; }
        public GolferSkillSet GolferSkillSet { get; }

        public Golfer(string firstName, string middleName, string lastName, DateTime birthday, Gender gender, float weight, float shoulderRadius, float armLength)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Birthday = birthday;
            Mood = Mood.Neutral;
            Gender = gender;
            Weight = weight;
            ShoulderRadius = shoulderRadius;
            ArmLength = armLength;
            GolferSkillSet = new GolferSkillSet();
        }
    }
}
