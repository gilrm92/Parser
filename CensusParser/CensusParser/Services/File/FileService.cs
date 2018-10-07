using CensusParser.Domain.Entity;
using CensusParser.Providers;
using CensusParser.Services.File.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusParser.Services.File
{
    public class FileService : IFileService
    {
        private string _filepPath;

        public FileService(IFilePathProvider filePathProvider) 
        {
            _filepPath = filePathProvider.GetFilePath();
        }

        public IList<string> ReadFile()
        {
            IList<string> lines = new List<string>();

            try
            {
                Console.WriteLine(string.Format("Opening file {0} for data reading.", _filepPath));
                lines = System.IO.File.ReadAllLines(_filepPath).ToList();

                Console.WriteLine(string.Format("Data readed. {0} lines", lines.Count));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Woops. Some problem when reding the data.");
                Console.WriteLine(string.Format("Exception: {0}, Message: {1}, Stacktrace: {2}", ex.InnerException, ex.Message, ex.StackTrace));
                throw ex;
            }

            return lines;
        }

        public void ExportPeopleToFile(IList<Person> listToExport, string fileName)
        {
            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                foreach (Person person in listToExport)
                {
                    writetext.WriteLine(person.Name);
                }
            }
        }
    }
}
