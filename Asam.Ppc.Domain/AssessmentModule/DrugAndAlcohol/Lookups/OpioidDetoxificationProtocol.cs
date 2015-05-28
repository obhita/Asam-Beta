using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Opiod Detoxification Protocol
    /// </summary>
    public class OpioidDetoxificationProtocol : Lookup
    {
        /// <summary>
        ///     No = 0.
        /// </summary>
        public static readonly OpioidDetoxificationProtocol No = new OpioidDetoxificationProtocol
            {
                Code = "No",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     OpioidAntagonist = 3.
        /// </summary>
        public static readonly OpioidDetoxificationProtocol OpioidAntagonist = new OpioidDetoxificationProtocol
            {
                Code = "OpioidAntagonist",
                SortOrder = 2,
                Value = 3
            };

        /// <summary>
        ///     OpioidAntagonistRapidDetoxification = 4.
        /// </summary>
        public static readonly OpioidDetoxificationProtocol OpioidAntagonistRapidDetoxification = new OpioidDetoxificationProtocol
            {
                Code = "OpioidAntagonistRapidDetoxification",
                SortOrder = 3,
                Value = 4
            };

        /// <summary>
        ///     NonopioidSubstitution = 1.
        /// </summary>
        public static readonly OpioidDetoxificationProtocol NonopioidSubstitution = new OpioidDetoxificationProtocol
            {
                Code = "NonopioidSubstitution",
                SortOrder = 4,
                Value = 1
            };

        /// <summary>
        ///     OpioidSubstitution = 2.
        /// </summary>
        public static readonly OpioidDetoxificationProtocol OpioidSubstitution = new OpioidDetoxificationProtocol
            {
                Code = "OpioidSubstitution",
                SortOrder = 5,
                Value = 2
            };
    }
}