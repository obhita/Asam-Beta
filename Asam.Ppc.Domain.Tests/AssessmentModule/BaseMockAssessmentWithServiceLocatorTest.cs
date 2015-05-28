using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pillar.Common.Tests;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.Tests.AssessmentModule
{
    [TestClass]
    public class BaseMockAssessmentWithServiceLocatorTest : BaseMockAssessmentTest
    {
        private ServiceLocatorFixture ServiceLocatorFixture { get; set; }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize (  );

            ServiceLocatorFixture = new ServiceLocatorFixture ( );
            SetupServiceLocatorFixture ( ServiceLocatorFixture );
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            if (ServiceLocatorFixture != null)
            {
                ServiceLocatorFixture.Dispose ( );
            }
        }

        private static void SetupServiceLocatorFixture(ServiceLocatorFixture serviceLocatorFixture)
        {
            serviceLocatorFixture.StructureMapContainer.Configure (
                c => c.For<IDomainEventService> ( ).HybridHttpOrThreadLocalScoped ( ).Use<DomainEventService> ( ) );

            serviceLocatorFixture.StructureMapContainer.Configure (
                c => c.Scan ( x =>
                    {
                        // in the scan operation, include all needed dlls (Rem.*)
                        // be cautious in the future - this could still pick up unwanted assemblies,
                        // such as the stray test project that mistakenly ends up in the bin folder.
                        // so consider those possibilities if errors pop up, and you're led here.
                        x.AssembliesFromApplicationBaseDirectory ( p => ( p.FullName == null ) ? false : p.FullName.Contains ( "Asam.Ppc.Domain" ) );
                    } ) );
        }
    }
}
