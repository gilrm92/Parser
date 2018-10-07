using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Domain.Entity
{
    public class Person
    {
        public string Name { get; set; }
        public float Frequency { get; set; }
        public float CumulativeFrequency { get; set; }
        public int Rank { get; set; }
    }
}
