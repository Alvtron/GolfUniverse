using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public class GolferSkillSet
    {
        public Skill Strength { get; private set; }
        public Skill Driver { get; private set; }
        public Skill Irons { get; private set; }
        public Skill Wegdes { get; private set; }
        public Skill Putter { get; private set; }
        public Skill DrawShot { get; private set; }
        public Skill Backspin { get; private set; }
        public Skill Recovery { get; private set; }
        public Skill Luck { get; private set; }

        public GolferSkillSet()
        {
            Strength = new Skill(0, 100, 0);
            Driver = new Skill(0, 100, 0);
            Irons = new Skill(0, 100, 0);
            Wegdes = new Skill(0, 100, 0);
            Putter = new Skill(0, 100, 0);
            DrawShot = new Skill(0, 100, 0);
            Backspin = new Skill(0, 100, 0);
            Recovery = new Skill(0, 100, 0);
            Luck = new Skill(0, 100, 0);
        }

        public void IncreaseStrength(float value) => Strength += value;
        public void DecreaseStrength(float value) => Strength -= value;

        public void IncreaseDriver(float value) => Driver += value;
        public void DecreaseDriver(float value) => Driver -= value;

        public void IncreaseIrons(float value) => Irons += value;
        public void DecreaseIrons(float value) => Irons -= value;

        public void IncreaseWegdes(float value) => Wegdes += value;
        public void DecreaseWegdes(float value) => Wegdes -= value;

        public void IncreasePutter(float value) => Putter += value;
        public void DecreasePutter(float value) => Putter -= value;

        public void IncreaseDrawShot(float value) => DrawShot += value;
        public void DecreaseDrawShot(float value) => DrawShot -= value;

        public void IncreaseBackspin(float value) => Backspin += value;
        public void DecreaseBackspin(float value) => Backspin -= value;

        public void IncreaseRecovery(float value) => Recovery += value;
        public void DecreaseRecovery(float value) => Recovery -= value;

        public void IncreaseLuck(float value) => Luck += value;
        public void DecreaseLuck(float value) => Luck -= value;
    }
}
