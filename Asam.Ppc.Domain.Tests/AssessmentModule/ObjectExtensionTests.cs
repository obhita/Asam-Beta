using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asam.Ppc.Domain.Tests.AssessmentModule
{
    [TestClass]
    public class ObjectExtensionTests
    {
        [TestMethod]
        public void Object_Copy_AreEqual ( )
        {
            //TODO: revise the test when sql server db is set up.
            //var originalDocumentString = File.ReadAllText ( "AssessmentDocument_B_1.json" );

            //var originalRavenJObject = RavenJObject.Parse ( originalDocumentString );
            //var assessment = originalRavenJObject.Deserialize<Assessment> ( new DocumentConvention ( ) );
            //var assessmentCopy = assessment.Copy ( );

            //var copiedRavenJObject = Raven.Abstractions.Extensions.JsonExtensions.ToJObject ( assessmentCopy );
            //var originalDocNoSpaceLineBreak = originalDocumentString.Replace ( Environment.NewLine, "" ).Replace ( " ", "" );
            //var copiedDocNoSpaceLineBreak = copiedRavenJObject.ToString ( ).Replace ( Environment.NewLine, "" ).Replace ( " ", "" );

            //Assert.AreEqual ( originalDocNoSpaceLineBreak, copiedDocNoSpaceLineBreak );
            //Assert.AreEqual ( originalRavenJObject.ToString ( ), copiedRavenJObject.ToString ( ) );

            //assessmentCopy.UpdatedTimestamp = DateTime.UtcNow;
            //assessmentCopy.UpdatedSystemAccount = "Unit Test";
            //copiedRavenJObject = Raven.Abstractions.Extensions.JsonExtensions.ToJObject ( assessmentCopy );
            //Assert.AreNotEqual ( originalRavenJObject.ToString ( ), copiedRavenJObject.ToString ( ) );
        }
    }
}
