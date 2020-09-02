using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public class Course
    {
        public IList<Hole> Holes { get; set; }

        public Course()
        {
            Holes = new List<Hole>();
        }

        public Course(IList<Hole> holes)
        {
            Holes = holes ?? throw new ArgumentNullException(nameof(holes));
        }

        public Scorecard CreateScorecard()
        {
            throw new NotImplementedException();
        }
    }
}
