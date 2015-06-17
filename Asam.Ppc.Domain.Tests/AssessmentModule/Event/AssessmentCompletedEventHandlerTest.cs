using System;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.AssessmentModule.Events;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Event
{
    using OrganizationModule;

    [TestClass]
    public class AssessmentCompletedEventHandlerTest : BaseMockAssessmentWithServiceLocatorTest
    {
        [TestMethod]
        public void AssessmentCompletedEventIsRaised()
        {
            var assessment = new Assessment(new Patient(new Organization("Test"), new PersonName("Fed","Savage"), new DateTime(), Gender.Male  ));

            var eventRaised = false;
            DomainEvent.Register<AssessmentCompletedEvent> ( p => eventRaised = true );

            // Exercise
            assessment.SubmitAssessment();

            // Verify
            Assert.IsTrue ( eventRaised );
        }
    }
}
