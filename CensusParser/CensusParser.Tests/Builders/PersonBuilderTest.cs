using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CensusParser.Builders;
using Moq;
using CensusParser.Providers;
using System.Globalization;

namespace CensusParser.Tests.Builders
{
    [TestClass]
    public class PersonBuilderTest
    {
        private Mock<IAliasProvider> _aliasProviderMock;
        private IDictionary<string, int> _aliasReturn = new Dictionary<string, int>() 
            {
                {"Name", 0},
                {"Frequency", 1},
                {"CumulativeFrequency", 2},
                {"Rank", 3}
            };

        public PersonBuilderTest()
        {
            _aliasProviderMock = new Mock<IAliasProvider>();
            _aliasProviderMock.Setup(a => a.GetAlias()).Returns(_aliasReturn);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenNameIsBlank_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "",
                "2.330",
                "2.330",
                "2"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenFrequencyIsBlank_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "",
                "2.330",
                "2"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenCumulativeFrequencyIsBlank_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "2.330",
                "",
                "2"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenRankIsBlank_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "2.330",
                "2.330",
                ""
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenNumberOfItemsAreMoreThanFour_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "2.330",
                "2.330",
                "2",
                "Another one"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void PersonBuilder_WhenNumberOfItemsAreLessThanFour_ShouldNotCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "2.330",
                "2.330"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            target.Build(listOfItems);
        }

        [TestMethod]
        public void PersonBuilder_IfAllParametersAreCorrect_ShouldCreatePerson()
        {
            var listOfItems = new List<string>()
            {
                "Gilberto",
                "2.330",
                "2.330",
                "2"
            };

            var target = new PersonBuilder(_aliasProviderMock.Object);
            var personCreated = target.Build(listOfItems);

            Assert.AreEqual(listOfItems[0], personCreated.Name);
            Assert.AreEqual(listOfItems[1], personCreated.Frequency.ToString("0.000", CultureInfo.InvariantCulture));
            Assert.AreEqual(listOfItems[2], personCreated.CumulativeFrequency.ToString("0.000", CultureInfo.InvariantCulture));
            Assert.AreEqual(listOfItems[3], personCreated.Rank.ToString());
        }
    }
}
