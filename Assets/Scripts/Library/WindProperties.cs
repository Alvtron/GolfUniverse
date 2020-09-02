using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public struct WindProperties
    {

        /// <summary>
        /// Wind speed (absolute value) (m/sec), v_wind
        /// </summary>
        public float Speed { get; private set; }
        /// <summary>
        /// Wind elevation angle (degree), wind_theta
        /// </summary>
        public float ElevationRadians { get; private set; }
        /// <summary>
        /// Wind elevation angle (degree), wind_theta
        /// </summary>
        public float ElevationDegrees => ElevationRadians * 180F / Mathf.PI;
        /// <summary>
        /// Wind direction angle (degree), wind_phi
        /// </summary>
        public float DirectionRadians { get; private set; }
        /// <summary>
        /// Wind direction angle (degree), wind_phi
        /// </summary>
        public float DirectionDegrees => DirectionRadians * 180F / Mathf.PI;

        public Vector3 Velocity() => new Vector3(
            x: Speed * Mathf.Cos(ElevationRadians) * Mathf.Cos(DirectionRadians),
            y: Speed * Mathf.Cos(ElevationRadians) * Mathf.Sin(DirectionRadians),
            z: Speed * Mathf.Sin(ElevationRadians));

        private WindProperties(float speed, float elevation, float direction)
        {
            Speed = speed;
            ElevationRadians = elevation;
            DirectionRadians = direction;
        }

        public static WindProperties FromDegrees(float velocity, float elevation, float direction)
        {
            var elevationInRadians = elevation* Mathf.PI / 180F;
            var directionInRadians = direction * Mathf.PI / 180F;
            return new WindProperties(velocity, elevationInRadians, directionInRadians);
        }

        public static WindProperties FromRadians(float velocity, float elevation, float direction)
        {
            return new WindProperties(velocity, elevation, direction);
        }
    }
}
