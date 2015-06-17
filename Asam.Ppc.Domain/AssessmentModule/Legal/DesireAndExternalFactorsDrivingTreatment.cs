using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Legal
{
    public class DesireAndExternalFactorsDrivingTreatment : Lookup
    {
        /// <summary>
        ///     CommittedNoExternalPressures = 0.
        /// </summary>
        public static readonly DesireAndExternalFactorsDrivingTreatment CommittedNoExternalPressures = new DesireAndExternalFactorsDrivingTreatment
            {
                Code = "CommittedNoExternalPressures",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     WantsRecoveryButSomePressure = 1.
        /// </summary>
        public static readonly DesireAndExternalFactorsDrivingTreatment WantsRecoveryButSomePressure = new DesireAndExternalFactorsDrivingTreatment
            {
                Code = "WantsRecoveryButSomePressure",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     AmbivalentAndExternallyPersuaded = 2.
        /// </summary>
        public static readonly DesireAndExternalFactorsDrivingTreatment AmbivalentAndExternallyPersuaded = new DesireAndExternalFactorsDrivingTreatment
            {
                Code = "AmbivalentAndExternallyPersuaded",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     OnlyInTreatmentByCoercion = 3.
        /// </summary>
        public static readonly DesireAndExternalFactorsDrivingTreatment OnlyInTreatmentByCoercion = new DesireAndExternalFactorsDrivingTreatment
            {
                Code = "OnlyInTreatmentByCoercion",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     ResentfulAndWishesToRejectTreatmentDespiteCoercion = 4.
        /// </summary>
        public static readonly DesireAndExternalFactorsDrivingTreatment
            ResentfulAndWishesToRejectTreatmentDespiteCoercion = new DesireAndExternalFactorsDrivingTreatment
                {
                    Code = "ResentfulAndWishesToRejectTreatmentDespiteCoercion",
                    SortOrder = 5,
                    Value = 4
                };
    }
}