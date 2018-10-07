using CensusParser.Domain.Entity;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExportService
{
    public class ExportTopLessPopular : ExportServiceBase
    {
        private const int _limit = 50;

        public ExportTopLessPopular(IFileService fileService)
            : base(fileService)
        {
            _fileName = "exported/census-bottom50";
        }

        protected override IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return (from person in listOfPeople
                    orderby person.Rank descending
                    select person)
                    .Take(_limit)
                    .ToList();
        }
    }
}
