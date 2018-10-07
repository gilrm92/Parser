using CensusParser.Domain.Entity;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExportService
{
    public class ExportFrequency : ExportServiceBase
    {
        private const float _beginLimit = 0.1F;
        private const float _endLimit = 0.199F;

        public ExportFrequency(IFileService fileService)
            : base(fileService)
        {
            _fileName = "exported/census-freq10s";
        }

        protected override IList<Person> GetListToExport(IList<Person> listOfPeople)
        {
            return (from person in listOfPeople
                    where person.Frequency >= _beginLimit && person.Frequency <= _endLimit
                    select person)
                    .ToList();
        }
    }
}
