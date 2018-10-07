using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Providers
{
    public class AliasProvider : IAliasProvider
    {
        public IDictionary<string, int> GetAlias()
        {
            return new Dictionary<string, int>() 
            {
                {"Name", 0},
                {"Frequency", 1},
                {"CumulativeFrequency", 2},
                {"Rank", 3}
            };
        }
    }
}
