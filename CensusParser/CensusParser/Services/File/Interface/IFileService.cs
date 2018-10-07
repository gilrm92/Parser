using CensusParser.Domain.Entity;
using System.Collections.Generic;

namespace CensusParser.Services.File.Interface
{
    public interface IFileService
    {
        IList<string> ReadFile();
        void ExportPeopleToFile(IList<Person> listToExport, string fileName);
    }
}
