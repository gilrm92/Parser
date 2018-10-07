using CensusParser.Builders;
using CensusParser.Domain.Entity;
using CensusParser.Services.ExtractService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Services.ExtractService
{
    public class ExtractDataFromFile : IExtractDataFromFile
    {
        private IList<Person> _listOfPeople = new List<Person>();
        private readonly IPersonBuilder _personBuilder;

        public ExtractDataFromFile(IPersonBuilder personBuilder)
        {
            _personBuilder = personBuilder;
        }
        public IList<Person> ExtractPeople(IList<string> lines)
        {
            Console.WriteLine("Starting to parse people. ");
            foreach (string line in lines)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        Console.WriteLine("Parsing:");
                        Console.WriteLine(line);

                        IList<string> splitedLine = line.Split(' ')
                                                        .Where(part => !string.IsNullOrWhiteSpace(part))
                                                        .ToList();

                        Person person = _personBuilder.Build(splitedLine);
                        Console.WriteLine(string.Format("People extracted. Name: {0}", person.Name));

                        _listOfPeople.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when extracting and parsing data. Press any key to cancel the program.");
                    Console.ReadKey();

                    Environment.Exit(0);
                }
            }

            return _listOfPeople;
        }
    }
}
