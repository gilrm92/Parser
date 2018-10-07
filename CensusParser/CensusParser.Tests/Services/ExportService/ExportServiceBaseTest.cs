using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CensusParser.Services.ExportService;
using Moq;
using CensusParser.Services.File.Interface;
using System.Collections.Generic;
using CensusParser.Domain.Entity;

namespace CensusParser.Tests.Services.ExportService
{
    [TestClass]
    public class ExportServiceBaseTest
    {
        private string _fileName = "exported/census-az";
        private IList<Person> _listOfPeople = new List<Person>()
        {
            new Person()
            {
                Name = "Gilberto",
                Frequency = 2.330F,
                CumulativeFrequency = 2.330F,
                Rank = 2
            }
        };

        [TestMethod]
        public void ExportServiceBase_WhenPassListOfPeopleOk_ShouldExport()
        {
            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(a => a.ExportPeopleToFile(It.IsAny<IList<Person>>(), _fileName));
            
            var target = new ExportAlphabeticalOrder(fileServiceMock.Object);
            target.ExportData(_listOfPeople);

            fileServiceMock.Verify(a => a.ExportPeopleToFile(It.IsAny<IList<Person>>(), _fileName), Times.Once);
        }

        [TestMethod]
        public void ExportServiceBase_WhenPassEmptyList_ShouldExport()
        {
            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(a => a.ExportPeopleToFile(It.IsAny<IList<Person>>(), _fileName));

            var target = new ExportAlphabeticalOrder(fileServiceMock.Object);
            target.ExportData(new List<Person>());

            fileServiceMock.Verify(a => a.ExportPeopleToFile(It.IsAny<IList<Person>>(), _fileName), Times.Once);
        }
    }
}
