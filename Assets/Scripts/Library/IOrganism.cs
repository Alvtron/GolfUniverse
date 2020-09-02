using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public interface IOrganism
    {
        TimeSpan Age { get; }
        bool IsAlive { get; }
    }
}
