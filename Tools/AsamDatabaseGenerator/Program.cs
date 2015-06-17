using System.Configuration;
using Asam.Ppc.Mvc.Infrastructure.Bootstrapper;
using Pillar.Common.Configuration;
using Pillar.Nhibernate.Generation;

namespace AsamDatabaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfig = new AppSettingsConfiguration ( ConfigurationManager.AppSettings );
            var databaseGenerator = new DatabaseGenerator ( appConfig, new SchemaGenerator ( appConfig, new AssemblyLocator ()  ) );

            databaseGenerator.GenerateDatabase ();
        }
    }
}
