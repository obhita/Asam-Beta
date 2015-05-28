using System;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Asam.Ppc.Domain.Tests.AssessmentModule
{
    using OrganizationModule;

    [TestClass]
    public class BaseMockAssessmentTest
    {
        public Mock<Assessment> AssessmentMock { get; set; }
            
        [TestInitialize]
        public virtual void TestInitialize()
        {
            var patient = new Patient(new Organization("Test"), new PersonName(), DateTime.Parse("1, 1, 1980"), Gender.Male);
            AssessmentMock = new Mock<Assessment>(patient);
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {

        }
    }
}
