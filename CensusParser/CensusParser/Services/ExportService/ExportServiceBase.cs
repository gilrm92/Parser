using CensusParser.Domain.Entity;
using CensusParser.Services.ExportService.Interface;
using CensusParser.Services.File.Interface;
using System;
using System.Collections.Generic;

namespace CensusParser.Services.ExportService
{
    public abstract class ExportServiceBase : IExportService
    {
        protected string _fileName = "standard-name";
        private readonly IFileService _fileService;

        public ExportServiceBase(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void ExportData(IList<Person> listOfPeople)
        {
            Console.WriteLine(string.Format("Starting to export {0}", _fileName));

            IList<Person> listToExport = GetListToExport(listOfPeople);
            _fileService.ExportPeopleToFile(listToExport, _fileName);
        }

        protected virtual IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return listOfPeople;
        }

    }
}
