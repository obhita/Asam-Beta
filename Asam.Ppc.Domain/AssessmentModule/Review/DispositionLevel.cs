namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule;

    #endregion

    /// <summary>
    ///     Disposition Level
    /// </summary>
    public class DispositionLevel : Lookup
    {
        #region Static Fields

        /// <summary>
        ///     5=Conflict with job/family responsibilities
        /// </summary>
        public static readonly DispositionLevel ConflictJobFamily = new DispositionLevel
            {
                Code = "ConflictJobFamily",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     2=Different treatment selected due to patient choice
        /// </summary>
        public static readonly DispositionLevel DifferentPatientChoice = new DispositionLevel
            {
                Code = "DifferentPatientChoice",
                SortOrder = 2,
                Value = 2
            };

        /// <summary>
        ///     7=Patient has insurance but insurance will not approve recommended treatment
        /// </summary>
        public static readonly DispositionLevel InsuranceWillNotApproveRecomendation = new DispositionLevel
            {
                Code = "InsuranceWillNotApproveRecomendation",
                SortOrder = 7,
                Value = 7
            };

        /// <summary>
        ///     4=Lack of physical access (e.g. transportation, mobility)
        /// </summary>
        public static readonly DispositionLevel LackOfPhysicalAccess = new DispositionLevel
            {
                Code = "LackOfPhysicalAccess",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     8=Program available but lacks opening or wait list too long
        /// </summary>
        public static readonly DispositionLevel LacksOpeningOrWaitTooLong = new DispositionLevel
            {
                Code = "LacksOpeningOrWaitTooLong",
                SortOrder = 8,
                Value = 8
            };

        /// <summary>
        ///     10=Court or other mandated treatment is different or blocks PPC-2R recommendation
        /// </summary>
        public static readonly DispositionLevel MandatedDifferent = new DispositionLevel
            {
                Code = "MandatedDifferent",
                SortOrder = 10,
                Value = 10
            };

        /// <summary>
        ///     0=No answer
        /// </summary>
        public static readonly DispositionLevel NoAnswer = new DispositionLevel
            {
                Code = "NoAnswer",
                SortOrder = 0,
                Value = 0
            };

        /// <summary>
        ///     99=Not known
        /// </summary>
        public static readonly DispositionLevel NotKnown = new DispositionLevel
            {
                Code = "NotKnown",
                SortOrder = 13,
                Value = 99
            };

        /// <summary>
        ///     12=Patient eloped
        /// </summary>
        public static readonly DispositionLevel PatientEloped = new DispositionLevel
            {
                Code = "PatientEloped",
                SortOrder = 12,
                Value = 12
            };

        /// <summary>
        ///     6=Patient lacks insurance
        /// </summary>
        public static readonly DispositionLevel PatientLacksInsurance = new DispositionLevel
            {
                Code = "PatientLacksInsurance",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     11=Patient rejects any treatment at this time
        /// </summary>
        public static readonly DispositionLevel PatientRejectsAnyTreatment = new DispositionLevel
            {
                Code = "PatientRejectsAnyTreatment",
                SortOrder = 11,
                Value = 11
            };

        /// <summary>
        ///     9=Program available but rejects patient due to patient characteristic(s), e.g. attitude, behavior, clinical status
        /// </summary>
        public static readonly DispositionLevel RejectedPatientCharacteristics = new DispositionLevel
            {
                Code = "RejectedPatientCharacteristics",
                SortOrder = 9,
                Value = 9
            };

        /// <summary>
        ///     1=Final disposition is, or is expected to be, same as recommended by PPC-2R
        /// </summary>
        public static readonly DispositionLevel SameAsRecommended = new DispositionLevel
            {
                Code = "SameAsRecommended",
                SortOrder = 1,
                Value = 1
            };

        /// <summary>
        ///     3= Recommended program is unavailable in geographic region
        /// </summary>
        public static readonly DispositionLevel UnavailableInGeographicRegion = new DispositionLevel
            {
                Code = "UnavailableInGeographicRegion",
                SortOrder = 3,
                Value = 3
            };

        #endregion
    }
}