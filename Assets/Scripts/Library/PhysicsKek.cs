using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public static class PhysicsKek
    {
        /// <summary>
        /// The nominal average acceleration of objects on Earth's surface is by definition 9.80665 meters per second squared;
        /// </summary>
        public const float Gravity = 9.80665F;

        /// <summary>
        /// The universal gravitation constant measured in Nm2/kg2.
        /// </summary>
        public const float UniversialGravitationalConstant = 6.673F * 10E-11F;

        /// <summary>
        /// The distance from the surface of the earth to the center (in meters).
        /// </summary>
        public const float EarthRadius = 6.38F * 10E+6F;

        public static float ViscosityCoefficient
        {
            get
            {
                // Sutherland's law coefficients
                // https://www.cfd-online.com/Wiki/Sutherland%27s_law

                const float SUTHERLAND_MU = 0.00001716F;
                const float SUTHERLAND_T0 = 273.15F;
                const float SUTHERLAND_T = 110.4F;
                const float SUTHERLAND_C = 0.000001458F;

                return SUTHERLAND_MU * ((0.555F * SUTHERLAND_T0 + SUTHERLAND_C) / (0.555F * SUTHERLAND_T + SUTHERLAND_C)) * Mathf.Pow(SUTHERLAND_T / SUTHERLAND_T0, 3F / 2F);
            }
        }

        /// <summary>
        /// The viscosity, which enters the Reynolds number, measures how thick the fluid is.
        /// </summary>
        /// <param name="density"></param>
        /// <returns></returns>
        private static float Viscocity(float density)
        {
            return density / ViscosityCoefficient;
        }

        public static float StoppingDistance(float velocity, float frictionCoefficient, float gravitation = Gravity)
        {
            return velocity / (2F * frictionCoefficient * gravitation);
        }

        public static float ReynoldsNumber(float diameter, float density, float velocity)
        {
            return (diameter * velocity) / Viscocity(density);
        }
    }
}
