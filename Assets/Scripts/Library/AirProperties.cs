using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    // https://apps.dtic.mil/dtic/tr/fulltext/u2/a588839.pdf
    public struct AirProperties
    {
        public float Temperature { get; private set; }
        public float Humidty { get; private set; }
        public float Pressure(float altitude) => Atmosphere.Pressure(altitude);
        public float Density(float altitude) => Atmosphere.AirDensity(altitude, Temperature);

        public AirProperties(float temperature, float humidty)
        {
            Temperature = temperature;
            Humidty = humidty;
        }
    }
}
