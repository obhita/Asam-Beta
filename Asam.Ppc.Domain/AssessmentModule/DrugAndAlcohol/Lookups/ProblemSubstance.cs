using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol.Lookups
{
    /// <summary>
    /// Problem Substance
    /// </summary>
    public class ProblemSubstance : Lookup
    {
        /// <summary>
        ///     NoProblem = 0.
        /// </summary>
        public static readonly ProblemSubstance NoProblem = new ProblemSubstance
            {
                Code = "NoProblem",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Alcohol = 1.
        /// </summary>
        public static readonly ProblemSubstance Alcohol = new ProblemSubstance
            {
                Code = "Alcohol",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     Heroin = 3.
        /// </summary>
        public static readonly ProblemSubstance Heroin = new ProblemSubstance
            {
                Code = "Heroin",
                SortOrder = 3,
                Value = 3
            };

        /// <summary>
        ///     Methadone = 4.
        /// </summary>
        public static readonly ProblemSubstance Methadone = new ProblemSubstance
            {
                Code = "Methadone",
                SortOrder = 4,
                Value = 4
            };

        /// <summary>
        ///     OtherOpiateAnalgesic = 5.
        /// </summary>
        public static readonly ProblemSubstance OtherOpiateAnalgesic = new ProblemSubstance
            {
                Code = "OtherOpiateAnalgesic",
                SortOrder = 5,
                Value = 5
            };

        /// <summary>
        ///     Barbiturates = 6.
        /// </summary>
        public static readonly ProblemSubstance Barbiturates = new ProblemSubstance
            {
                Code = "Barbiturates",
                SortOrder = 6,
                Value = 6
            };

        /// <summary>
        ///     OtherSedativesHypnotics = 7.
        /// </summary>
        public static readonly ProblemSubstance OtherSedativesHypnotics = new ProblemSubstance
            {
                Code = "OtherSedativesHypnotics",
                SortOrder = 7,
                Value = 7
            };

        /// <summary>
        ///     Cocaine = 8.
        /// </summary>
        public static readonly ProblemSubstance Cocaine = new ProblemSubstance
            {
                Code = "Cocaine",
                SortOrder = 8,
                Value = 8
            };

        /// <summary>
        ///     Stimulants = 9.
        /// </summary>
        public static readonly ProblemSubstance Stimulants = new ProblemSubstance
            {
                Code = "Stimulants",
                SortOrder = 9,
                Value = 9
            };

        /// <summary>
        ///     Cannabis = 10.
        /// </summary>
        public static readonly ProblemSubstance Cannabis = new ProblemSubstance
            {
                Code = "Cannabis",
                SortOrder = 10,
                Value = 10
            };

        /// <summary>
        ///     HallucinogensPcp = 11.
        /// </summary>
        public static readonly ProblemSubstance HallucinogensPcp = new ProblemSubstance
            {
                Code = "HallucinogensPcp",
                SortOrder = 11,
                Value = 11
            };

        /// <summary>
        ///     SolventInhalants = 12.
        /// </summary>
        public static readonly ProblemSubstance SolventInhalants = new ProblemSubstance
            {
                Code = "SolventInhalants",
                SortOrder = 12,
                Value = 12
            };

        /// <summary>
        ///     NicotineTobacco = 14.
        /// </summary>
        public static readonly ProblemSubstance NicotineTobacco = new ProblemSubstance
            {
                Code = "NicotineTobacco",
                SortOrder = 13,
                Value = 14
            };

        /// <summary>
        ///     OtherSubstance = 15.
        /// </summary>
        public static readonly ProblemSubstance OtherSubstance = new ProblemSubstance
            {
                Code = "OtherSubstance",
                SortOrder = 14,
                Value = 15
            };

        /// <summary>
        ///     AlcoholOnly = 100.
        /// </summary>
        public static readonly ProblemSubstance AlcoholOnly = new ProblemSubstance
            {
                Code = "AlcoholOnly",
                SortOrder = 15,
                Value = 100
            };

        /// <summary>
        ///     AlcoholAndDrug = 101.
        /// </summary>
        public static readonly ProblemSubstance AlcoholAndDrug = new ProblemSubstance
            {
                Code = "AlcoholAndDrug",
                SortOrder = 16,
                Value = 101
            };

        /// <summary>
        ///     Polydrug = 102.
        /// </summary>
        public static readonly ProblemSubstance Polydrug = new ProblemSubstance
            {
                Code = "Polydrug",
                SortOrder = 17,
                Value = 102
            };
    }
}