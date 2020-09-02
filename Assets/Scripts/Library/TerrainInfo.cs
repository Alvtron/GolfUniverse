using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public enum TerrainType
    {
        Tee,
        Green,
        Fairway,
        FirmFairway,
        Rough,
        HeavyRough,
        Sand,
        Dirt,
        Gravel,
        Water,
        River,
        Swamp,
        Ice,
        Rocks,
        Mountain,
        ForestFloor,
        Wood,
        Concrete,
        Asphalt
    }

    public interface ITerrain
    {
        float Friction { get; }
        float Hardness { get; }
        float Bounciness { get;  }
        float Wetness { get; }
    }

    public class Green : ITerrain
    {
        public float Friction { get; }
        public float Hardness { get; }
        public float Bounciness { get; }
        public float Wetness { get; }
    }
}
