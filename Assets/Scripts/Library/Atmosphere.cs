using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public struct AtmosphereProperties
    {
        public float Altitude { get; private set; }
        public float StandardTemperatureLapseRate  { get; private set; }
        public float Temperature { get; private set; }
        public float Pressure { get; private set; }

        public AtmosphereProperties(float altitude, float standardTemperatureLapseRate, float temperature, float pressure)
        {
            Altitude = altitude;
            StandardTemperatureLapseRate  = standardTemperatureLapseRate;
            Temperature = temperature;
            Pressure = pressure;
        }
    }

    public static class Atmosphere
    {
        const float GRAVITY = 9.80665F; // meters per second^2
        const float GAS_CONSTANT = 8.3144598F; // Joules per mole per Kelvin
        const float DRY_AIR_MOLAR_MASS = 0.0289644F; // kilograms per mole

        /// <summary>
        /// The universal gas constant, R^*, in m/(kmol K)
        /// </summary>
        public const float UniversalGasConstant = 8314.32F;

        /// <summary>
        /// The effective radius of the earth, r_0, in meters.
        /// </summary>
        public const float EarthRadius = 6356766F;

        /// <summary>
        /// The specific heat ratio, y.
        /// </summary>
        public const float HeatRatio = 1.400F;

        /// <summary>
        /// The standard temperature at sea level, T_0, in kelvin.
        /// </summary>
        public const float StandardTeamperatureAtSeaLevel = 288.15F;

        /// <summary>
        /// The geopotential constant, g'_0 in m^2 / (s^2m').
        /// </summary>
        public const float GeopotentialConstant = GRAVITY;

        /// <summary>
        /// The gravitational-field strength at sea level, g_0, in m / s^2.
        /// </summary>
        public const float GravitationalFieldStrengthAtSeaLevel = GRAVITY;

        /// <summary>
        /// The unit-converting constant, Γ, in m' / m.
        /// </summary>
        public const float UnitConvertingConstant = 1F;

        /// <summary>
        /// The mean molecular weight of air, M_0, in kg / kmol.
        /// </summary>
        public const float MolecularWeightOfAir = 28.9644F;

        /// <summary>
        /// The standard pressure at sea level, P_0, in Pa.
        /// </summary>
        public const float StandardPressureAtSeaLevel = 101325F;

        public static readonly AtmosphereProperties Properties = new AtmosphereProperties(0F, -0.0065F, 288.150F, 101325F);


        /// <summary>
        /// Calculate the gravitational-field strength.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The gravitational-field strength, g.</returns>
        public static float GravitationalFieldStrength(float altitude)
        {
            return GravitationalFieldStrengthAtSeaLevel * (EarthRadius / (EarthRadius + altitude)).Squared();
        }

        /// <summary>
        /// Calculate the geopotential height.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The geopotential height, H.</returns>
        public static float GeopotentialHeight(float altitude)
        {
            return (UnitConvertingConstant * EarthRadius * altitude) / (EarthRadius + altitude);
        }

        /// <summary>
        /// Calculate the molecular-scale temperature.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The molecular-scale temperature, T_M.</returns>
        public static float MolecularScaleTemperature(float altitude)
        {
            throw new NotImplementedException();
        }


        public static float Temperature(float altitude)
        {
            var H = GeopotentialHeight(altitude);
            return Properties.Temperature + Properties.StandardTemperatureLapseRate  * (H - Properties.Altitude);
        }

        /// <summary>
        /// Calculate the pressure.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The pressure, P.</returns>
        public static float Pressure(float altitude)
        {
            float power = GRAVITY * DRY_AIR_MOLAR_MASS / (GAS_CONSTANT * Properties.StandardTemperatureLapseRate);
            return Properties.Pressure * Mathf.Pow(Properties.Temperature / (Properties.Temperature + Properties.StandardTemperatureLapseRate * (altitude - Properties.Altitude)), power);
        }

        /// <summary>
        /// Calculate the air density.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The air density, p.</returns>
        public static float AirDensity(float altitude, float temperature)
        {
            var p = Pressure(altitude);
            return p * 0.00348367635597379F / temperature;
        }

        /// <summary>
        /// Calculate the speed of sound.
        /// </summary>
        /// <param name="altitude">The altitude</param>
        /// <returns>The speed of sound, c_sound.</returns>
        public static float SpeedOfSound(float altitude)
        {
            var t = Temperature(altitude);
            return Mathf.Sqrt(401.87430086589F * t);
        }

        public static float Gravity(float altitude)
        {
            return GravitationalFieldStrengthAtSeaLevel * Mathf.Pow(1F + altitude / EarthRadius, -2F);
        }
    }
}
