using CensusParser.Domain.Entity;
using CensusParser.Providers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Builders
{
    public class PersonBuilder : IPersonBuilder
    {
        private const int _numberOfItems = 4;
        private Person _person;
        private IDictionary<string, int> _aliases;

        public PersonBuilder(IAliasProvider aliasProvider)
        {
            _aliases = aliasProvider.GetAlias();
        }

        public Person Build(IList<string> splitedData)
        {
            _person = new Person();
            
            try
            {
                if (splitedData.Count == _numberOfItems)
                {
                    _person.Name = GetName(splitedData);
                    _person.Frequency = GetFrequency(splitedData);
                    _person.CumulativeFrequency = GetCumulativeFrequency(splitedData);
                    _person.Rank = GetRank(splitedData);
                }
                else 
                {
                    throw new FormatException("Data doesn't match the number of items.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Woops! Error when parsing the person information.");
                Console.WriteLine(string.Format("Message: {0}", ex.Message));
                
                throw ex;
            }

            return _person;
        }

        private string GetName(IList<string> splitedData)
        {
            if (string.IsNullOrWhiteSpace(splitedData[_aliases["Name"]]))
            {
                throw new FormatException("Empty name.");
            }

            return splitedData[_aliases["Name"]];
        }

        private float GetFrequency(IList<string> splitedData)
        {
            float frequency = 0;
            bool success = float.TryParse(splitedData[_aliases["Frequency"]].ToString(), NumberStyles.Any ,CultureInfo.InvariantCulture, out frequency);
            if (!success)
            {
                throw new FormatException(string.Format("Couldn't parse the frequency. {0}", splitedData[_aliases["Frequency"]]));
            }

            return frequency;
        }

        private float GetCumulativeFrequency(IList<string> splitedData)
        {
            float cumulativeFrequency = 0;
            bool success = float.TryParse(splitedData[_aliases["CumulativeFrequency"]].ToString(), NumberStyles.Any ,CultureInfo.InvariantCulture, out cumulativeFrequency);

            if (!success)
            {
                throw new FormatException(string.Format("Couldn't parse the Cumulative frequency. {0}", splitedData[_aliases["CumulativeFrequency"]]));
            }

            return cumulativeFrequency;
        }

        private int GetRank(IList<string> splitedData)
        {
            int rank = 0;
            bool success = int.TryParse(splitedData[_aliases["Rank"]].ToString(), out rank);

            if (!success)
            {
                throw new FormatException(string.Format("Couldn't parse the Rank. {0}", splitedData[_aliases["Rank"]]));
            }

            return rank;
        }
    }
}
