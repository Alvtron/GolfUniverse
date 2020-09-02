using System;
using System.Collections.Generic;
using System.Text;

namespace GolfUniverse.Library
{
    public interface IPerson : IOrganism
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime Birthday { get; set; }
        Mood Mood { get; }
        Gender Gender { get; }
        float Weight { get; }
    }
}
