namespace Asam.Ppc.Domain.AssessmentModule
{
    #region Using Statements

    using PatientModule;

    #endregion

    /// <summary>
    /// Assessment Factory
    /// </summary>
    public class AssessmentFactory : IAssessmentFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Creates the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        public Assessment Create ( Patient patient )
        {
            var assessment = new Assessment ( patient );
            return assessment;
        }

        #endregion
    }
}