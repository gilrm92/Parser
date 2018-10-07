using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser.Providers
{
    /// <summary>
    /// This class is just for faking the external provider for file paths.
    /// </summary>
    public class FilePathProvider : IFilePathProvider
    {
        private const string _filePath = "census-dist-male-first";

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}
