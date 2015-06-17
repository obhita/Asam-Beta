using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    public class RangeOfGuilt : Lookup
    {
        /// <summary>
        ///     Absent = 0.
        /// </summary>
        public static readonly RangeOfGuilt Absent = new RangeOfGuilt
            {
                Code = "Absent",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     SelfReproachFeelsHeSheHasLetPeopleDown = 1.
        /// </summary>
        public static readonly RangeOfGuilt SelfReproachFeelsHeSheHasLetPeopleDown = new RangeOfGuilt
            {
                Code = "SelfReproachFeelsHeSheHasLetPeopleDown",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     IdeasOfGuiltOrRuminationsOverPastErrorsOrSinfulDeeds = 2.
        /// </summary>
        public static readonly RangeOfGuilt IdeasOfGuiltOrRuminationsOverPastErrorsOrSinfulDeeds = new RangeOfGuilt
            {
                Code = "IdeasOfGuiltOrRuminationsOverPastErrorsOrSinfulDeeds",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     PresentIllnessIsAPunishmentDelusionsOfGuilt = 3.
        /// </summary>
        public static readonly RangeOfGuilt PresentIllnessIsAPunishmentDelusionsOfGuilt = new RangeOfGuilt
            {
                Code = "PresentIllnessIsAPunishmentDelusionsOfGuilt",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     HearsAccusatoryOrDenunciatoryVoicesAndOrExperiencesThreateningVisualHallucinations = 4.
        /// </summary>
        public static readonly RangeOfGuilt
            HearsAccusatoryOrDenunciatoryVoicesAndOrExperiencesThreateningVisualHallucinations = new RangeOfGuilt
                {
                    Code = "HearsAccusatoryOrDenunciatoryVoicesAndOrExperiencesThreateningVisualHallucinations",
                    SortOrder = 5,
                    Value = 4
                };
    }
}