using UnityEngine;

namespace GolfUniverse.Library
{
    public interface IGolfClub
    {
        /// <summary>
        /// Head mass (kg), M_C_head
        /// </summary>
        float HeadMass { get; }
        /// <summary>
        /// Shaft mass (kg), M_C_shaft
        /// </summary>
        float ShaftMass { get; }
        /// <summary>
        /// Head length(m), L_C_head
        /// </summary>
        float HeadLength { get; }
        /// <summary>
        /// Shaft length (m), L_C_shaft
        /// </summary>
        float ShaftLength { get; }
        /// <summary>
        /// Loft angle of clubhead (degree)
        /// </summary>
        float Loft { get; }

        Vector3 GetDirection(GolferSkillSet golferSkillSet, Vector3 surfaceAngle);
        Vector3 GetVelocity(GolferSkillSet golferSkillSet, float friction);
    }
}
