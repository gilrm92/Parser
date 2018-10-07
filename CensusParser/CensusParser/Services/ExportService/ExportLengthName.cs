using CensusParser.Domain.Entity;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExportService
{
    public class ExportLengthName : ExportServiceBase
    {
        public ExportLengthName(IFileService fileService) : base(fileService)
        {
            _fileName = "exported/census-short-to-long";
        }

        protected override IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return listOfPeople
                    .OrderBy(l => l.Name.Length)
                    .ToList();
        }
    }
}
