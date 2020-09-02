using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public class Tee
    {

    }

    public class Hole
    {
        public Tee[] Tees { get; private set; }
        public int Par { get; private set; }

        public Hole()
        {

        }
    }
}
