using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Helpfulness Of Treatment
    /// </summary>
    public class HelpfulnessOfTreatment : Lookup
    {
        /// <summary>
        ///     UnderstandsRoleOfTreatmentVersusNeedForPersonalEfforts = 0.
        /// </summary>
        public static readonly HelpfulnessOfTreatment UnderstandsRoleOfTreatmentVersusNeedForPersonalEfforts = new HelpfulnessOfTreatment
            {
                Code = "UnderstandsRoleOfTreatmentVersusNeedForPersonalEfforts",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     ThoughtfulAndCommittedToRecoveryEfforts = 1.
        /// </summary>
        public static readonly HelpfulnessOfTreatment ThoughtfulAndCommittedToRecoveryEfforts = new HelpfulnessOfTreatment
            {
                Code = "ThoughtfulAndCommittedToRecoveryEfforts",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     LimitedSenseOfPersonalResponsibilityForRecovery = 2.
        /// </summary>
        public static readonly HelpfulnessOfTreatment LimitedSenseOfPersonalResponsibilityForRecovery = new HelpfulnessOfTreatment
            {
                Code = "LimitedSenseOfPersonalResponsibilityForRecovery",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     OverconfidentOrTooReliantOnProgramRatherThanSelf = 3.
        /// </summary>
        public static readonly HelpfulnessOfTreatment OverconfidentOrTooReliantOnProgramRatherThanSelf = new HelpfulnessOfTreatment
            {
                Code = "OverconfidentOrTooReliantOnProgramRatherThanSelf",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     HoldsOthersOrProgramAsResponsibleForPatientsSuccess = 4.
        /// </summary>
        public static readonly HelpfulnessOfTreatment HoldsOthersOrProgramAsResponsibleForPatientsSuccess = new HelpfulnessOfTreatment
            {
                Code = "HoldsOthersOrProgramAsResponsibleForPatientsSuccess",
                SortOrder = 5,
                Value = 4
            };
    }
}