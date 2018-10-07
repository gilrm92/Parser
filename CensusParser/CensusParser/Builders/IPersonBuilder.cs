using CensusParser.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusParser.Builders
{
    public interface IPersonBuilder
    {
        Person Build(IList<string> splitedData);
    }
}
