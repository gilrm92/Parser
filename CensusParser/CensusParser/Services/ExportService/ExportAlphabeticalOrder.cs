using CensusParser.Domain.Entity;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExportService
{
    public class ExportAlphabeticalOrder : ExportServiceBase
    {
        public ExportAlphabeticalOrder(IFileService fileService)
            : base(fileService)
        {
            _fileName = "exported/census-az";
        }

        protected override IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return listOfPeople.OrderBy(p => p.Name).ToList();
        }
   }
}
