using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CensusParser.Providers;
using CensusParser.Builders;
using CensusParser.Services.ExtractService;
using System.IO;
using System.Collections.Generic;
using CensusParser.Domain.Entity;

namespace CensusParser.Tests.Services.ExtractService
{
    [TestClass]
    public class ExtractDataFromFileTest
    {
        private Mock<IPersonBuilder> _personBuilderMock;
        private IList<string> _listOfPeople = new List<string>()
            {
                "",
                "2.330",
                "2.330",
                "2"
            };

        private Person _person = new Person()
            {
                Name = "Gilberto",
                Frequency = 2.330F,
                CumulativeFrequency = 2.330F,
                Rank = 2
            };

        public ExtractDataFromFileTest()
        {
            _personBuilderMock = new Mock<IPersonBuilder>();
            _personBuilderMock.Setup(a => a.Build(It.IsAny<IList<string>>())).Returns(_person);
        }

        [TestMethod]
        public void ExtractDataFromFile_WhenPassingListOk_ShouldParse()
        {
            var target = new ExtractDataFromFile(_personBuilderMock.Object);
            var listOfPerson = target.ExtractPeople(_listOfPeople);

            Assert.IsTrue(listOfPerson.Any());
        }

        [TestMethod]
        public void ExtractDataFromFile_WhenPassingEmptyList_ShouldGetEmptyList()
        {
            var target = new ExtractDataFromFile(_personBuilderMock.Object);
            var listOfPerson = target.ExtractPeople(new List<string>());

            Assert.IsFalse(listOfPerson.Any());
        }
    }
}
