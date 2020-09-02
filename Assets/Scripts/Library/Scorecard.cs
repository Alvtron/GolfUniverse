using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public enum GolfScore
    {
        QuadrupleBogey,
        TripleBogey,
        DoubleBogey,
        Bogey,
        Par,
        Birdie,
        Eagle,
        DoubleEagle,
        HoleInOne
    }

    public class Scorecard
    {
        public GolfScore GetScore()
        {
            throw new NotImplementedException();
        }

        public void SetScore(int hole, GolfScore score)
        {
            throw new NotImplementedException();
        }
    }
}
