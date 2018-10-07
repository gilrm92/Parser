using CensusParser.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Services.ExportService.Interface
{
    public interface IExportService
    {
        void ExportData(IList<Person> listOfPeople);
    }
}
