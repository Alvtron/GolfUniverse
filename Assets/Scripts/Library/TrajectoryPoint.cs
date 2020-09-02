using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public interface IProjectile
    {
        Vector3 Position { get; }
        Vector3 Velocity { get; }
        Vector3 Rotation { get; }
    }
}
