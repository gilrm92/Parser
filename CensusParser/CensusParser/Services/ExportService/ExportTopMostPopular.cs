using CensusParser.Domain.Entity;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExportService
{
    public class ExportTopMostPopular : ExportServiceBase
    {
        private const int _limit = 20;

        public ExportTopMostPopular(IFileService fileService)
            : base(fileService)
        {
            _fileName = "exported/census-top20";
        }

        protected override IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return (from person in listOfPeople
                    orderby person.Rank
                    select person)
                    .Take(_limit)
                    .ToList();
        }
    }
}
