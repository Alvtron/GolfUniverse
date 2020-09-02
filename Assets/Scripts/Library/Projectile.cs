using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GolfUniverse.Library
{
    public struct Projectile : IProjectile
    {
        public Vector3 Position { get; }
        public Vector3 Velocity { get; }
        public Vector3 Rotation { get; }

        public Projectile(Vector3 position, Vector3 velocity, Vector3 rotation)
        {
            Position = position;
            Velocity = velocity;
            Rotation = rotation;
        }
    }
}
