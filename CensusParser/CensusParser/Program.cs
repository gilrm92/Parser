using CensusParser.Container;
using CensusParser.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusParser
{
    class Program
    {
        static void Main(string[] args)
        {
            AutofacContainer autofacContainer = new AutofacContainer();
            autofacContainer.Start();
        }
    }
}
