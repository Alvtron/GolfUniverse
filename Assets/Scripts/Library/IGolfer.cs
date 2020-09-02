using UnityEngine;

namespace GolfUniverse.Library
{
    public interface IGolfer : IPerson
    {
        /// <summary>
        /// Shoulder radious (m), R_S
        /// </summary>
        float ShoulderRadius { get; }
        /// <summary>
        /// Arm length (m), R_A
        /// </summary>
        float ArmLength { get; }
        GolferSkillSet GolferSkillSet { get; }
    }
}
