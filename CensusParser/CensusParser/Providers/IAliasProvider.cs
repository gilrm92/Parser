using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusParser.Providers
{
    public interface IAliasProvider
    {
        IDictionary<string, int> GetAlias();
    }
}
