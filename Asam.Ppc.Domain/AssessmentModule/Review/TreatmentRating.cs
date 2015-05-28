namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Treatment Rating
    /// </summary>
    public class TreatmentRating : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     1=Less intensive treatment
        /// </summary>
        public static readonly TreatmentRating LessIntensiveTreatment = new TreatmentRating
            {
                Code = "LessIntensiveTreatment",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     2=More intensive treatment
        /// </summary>
        public static readonly TreatmentRating MoreIntensiveTreatment = new TreatmentRating
            {
                Code = "MoreIntensiveTreatment",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     0=No answer
        /// </summary>
        public static readonly TreatmentRating NoAnswer = new TreatmentRating
            {
                Code = "NoAnswer",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     99=Not applicable because patient agrees with PPC-2R LOC recommendation
        /// </summary>
        public static readonly TreatmentRating NotApplicablePatientAgreesWithRecommendation = new TreatmentRating
            {
                Code = "NotApplicablePatientAgreesWithRecommendation",
                SortOrder = 3,
                Value = 99
            };

        #endregion
    }
}