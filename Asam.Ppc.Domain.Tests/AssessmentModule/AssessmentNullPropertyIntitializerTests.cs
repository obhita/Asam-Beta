using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Domain.Scoring;
using Asam.Ppc.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pillar.Common.Utility;

namespace Asam.Ppc.Domain.Tests.AssessmentModule
{
    using OrganizationModule;

    [TestClass]
    public class AssessmentNullPropertyIntitializerTests
    {
        [TestMethod]
        public void InitializeNulls_EmptyAssessment_NoPropertyNull()
        {
            var intializer = new AssessmentNullPropertyInitializer ();
            var assessment =
                new Assessment(new Patient(new Organization("Test"), new PersonName("Fred", "Smith"), null, Gender.Male));
            intializer.InitializeNulls (assessment );

            var propertyNames = new List<string> ();

            RecurseHelper ( assessment, propertyNames );

            propertyNames.Remove(PropertyUtil.ExtractPropertyName(() => assessment.Key));
            propertyNames.Remove(PropertyUtil.ExtractPropertyName(() => assessment.CreatedSystemAccount));
            propertyNames.Remove(PropertyUtil.ExtractPropertyName(() => assessment.UpdatedSystemAccount));

            Assert.IsFalse ( propertyNames.Any() );
        }

        private void RecurseHelper(object entity, List<string> propertyNames)
        {
            var entityProperties = entity.GetType().GetProperties();
            foreach (var entityProperty in entityProperties)
            {
                if (typeof(RevisionBase).IsAssignableFrom(entityProperty.PropertyType))
                {
                    var revisionBase = entityProperty.GetValue(entity) as RevisionBase;

                    RecurseHelper(revisionBase, propertyNames);
                }
                else
                {
                    var propertyValue = entityProperty.GetValue(entity);
                    if (propertyValue == null)
                    {
                        propertyNames.Add ( entityProperty.Name );
                    }
                }
            }
        }
    }
}
