using CensusParser.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Services.ExtractService.Interface
{
    public interface IExtractDataFromFile
    {
        IList<Person> ExtractPeople(IList<string> lines);
    }
}
