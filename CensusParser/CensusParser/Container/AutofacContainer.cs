using Autofac;
using CensusParser.Builders;
using CensusParser.Domain.Entity;
using CensusParser.Providers;
using CensusParser.Services.ExportService.Interface;
using CensusParser.Services.ExtractService;
using CensusParser.Services.ExtractService.Interface;
using CensusParser.Services.File;
using CensusParser.Services.File.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CensusParser.Container
{
    public class AutofacContainer : Module
    {
        private IContainer _container;

        public AutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FilePathProvider>()
                .As<IFilePathProvider>()
                .SingleInstance();

            builder.RegisterType<AliasProvider>()
                .As<IAliasProvider>()
                .SingleInstance();

            builder.RegisterType<FileService>()
                .As<IFileService>()
                .SingleInstance();

            builder.RegisterType<PersonBuilder>()
                .As<IPersonBuilder>()
                .SingleInstance();

            builder.RegisterTypes(GetTypes())
                .Where(type => type.IsAssignableTo<IExportService>())
                .As<IExportService>()
                .SingleInstance();
            
            builder.RegisterType<ExtractDataFromFile>()
                .As<IExtractDataFromFile>()
                .SingleInstance();

            _container = builder.Build();
        }

        private Type[] GetTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(s => s.GetTypes())
                 .ToArray();
        }

        public void Start() 
        {
            if (_container != null)
            {
                IFileService fileReader = _container.Resolve<IFileService>();
                IList<string> readLines = fileReader.ReadFile();

                IExtractDataFromFile extractor = _container.Resolve<IExtractDataFromFile>();
                IList<Person> peopleExtracted = extractor.ExtractPeople(readLines);

                IList<IExportService> exporters = _container.Resolve<IList<IExportService>>();
                
                foreach (IExportService exporter in exporters)
                {
                    exporter.ExportData(peopleExtracted);
                }

                Console.WriteLine("The operation is finished. Thanks for using it. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
