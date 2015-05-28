using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Legal
{
    public class LegalCharge : Lookup
    {
        /// <summary>
        ///     ContemptOfCourt = 3.
        /// </summary>
        public static readonly LegalCharge ContemptOfCourt = new LegalCharge
            {
                Code = "ContemptOfCourt",
                SortOrder = 1,
                Value = 3
            };

        /// <summary>
        ///     ShopliftingVandalism = 4.
        /// </summary>
        public static readonly LegalCharge ShopliftingVandalism = new LegalCharge
            {
                Code = "ShopliftingVandalism",
                SortOrder = 2,
                Value = 4
            };

        /// <summary>
        ///     ParoleProbationViolation = 5.
        /// </summary>
        public static readonly LegalCharge ParoleProbationViolation = new LegalCharge
            {
                Code = "ParoleProbationViolation",
                SortOrder = 3,
                Value = 5
            };

        /// <summary>
        ///     MajorDrivingViolations = 8.
        /// </summary>
        public static readonly LegalCharge MajorDrivingViolations = new LegalCharge
            {
                Code = "MajorDrivingViolations",
                SortOrder = 4,
                Value = 8
            };

        /// <summary>
        ///     DrivingWhileIntoxicated = 9.
        /// </summary>
        public static readonly LegalCharge DrivingWhileIntoxicated = new LegalCharge
            {
                Code = "DrivingWhileIntoxicated",
                SortOrder = 5,
                Value = 9
            };

        /// <summary>
        ///     Forgery = 10.
        /// </summary>
        public static readonly LegalCharge Forgery = new LegalCharge
            {
                Code = "Forgery",
                SortOrder = 6,
                Value = 10
            };

        /// <summary>
        ///     WeaponsOffense = 11.
        /// </summary>
        public static readonly LegalCharge WeaponsOffense = new LegalCharge
            {
                Code = "WeaponsOffense",
                SortOrder = 7,
                Value = 11
            };

        /// <summary>
        ///     BurglaryLarcenyBreakingAndEntering = 12.
        /// </summary>
        public static readonly LegalCharge BurglaryLarcenyBreakingAndEntering = new LegalCharge
            {
                Code = "BurglaryLarcenyBreakingAndEntering",
                SortOrder = 8,
                Value = 12
            };

        /// <summary>
        ///     Robbery = 13.
        /// </summary>
        public static readonly LegalCharge Robbery = new LegalCharge
            {
                Code = "Robbery",
                SortOrder = 9,
                Value = 13
            };

        /// <summary>
        ///     Assault = 14.
        /// </summary>
        public static readonly LegalCharge Assault = new LegalCharge
            {
                Code = "Assault",
                SortOrder = 10,
                Value = 14
            };

        /// <summary>
        ///     Arson = 15.
        /// </summary>
        public static readonly LegalCharge Arson = new LegalCharge
            {
                Code = "Arson",
                SortOrder = 11,
                Value = 15
            };

        /// <summary>
        ///     OtherArrestAndCharge = 1.
        /// </summary>
        public static readonly LegalCharge OtherArrestAndCharge = new LegalCharge
            {
                Code = "OtherArrestAndCharge",
                SortOrder = 12,
                Value = 1
            };

        /// <summary>
        ///     DisorderlyConductVagrancyPublicIntoxication = 2.
        /// </summary>
        public static readonly LegalCharge DisorderlyConductVagrancyPublicIntoxication = new LegalCharge
            {
                Code = "DisorderlyConductVagrancyPublicIntoxication",
                SortOrder = 13,
                Value = 2
            };

        /// <summary>
        ///     DrugCharges = 7.
        /// </summary>
        public static readonly LegalCharge DrugCharges = new LegalCharge
            {
                Code = "DrugCharges",
                SortOrder = 14,
                Value = 7
            };

        /// <summary>
        ///     Prostitution = 6.
        /// </summary>
        public static readonly LegalCharge Prostitution = new LegalCharge
            {
                Code = "Prostitution",
                SortOrder = 15,
                Value = 6
            };

        /// <summary>
        ///     Rape = 16.
        /// </summary>
        public static readonly LegalCharge Rape = new LegalCharge
            {
                Code = "Rape",
                SortOrder = 16,
                Value = 16
            };

        /// <summary>
        ///     HomicideManslaughter = 17.
        /// </summary>
        public static readonly LegalCharge HomicideManslaughter = new LegalCharge
            {
                Code = "HomicideManslaughter",
                SortOrder = 17,
                Value = 17
            };
    }
}