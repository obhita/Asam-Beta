using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory
{
    public class ContactPerson : Lookup
    {
        /// <summary>
        ///     Mother = 0.
        /// </summary>
        public static readonly ContactPerson Mother = new ContactPerson
            {
                Code = "Mother",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     Father = 1.
        /// </summary>
        public static readonly ContactPerson Father = new ContactPerson
            {
                Code = "Father",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     BrotherSister = 2.
        /// </summary>
        public static readonly ContactPerson BrotherSister = new ContactPerson
            {
                Code = "BrotherSister",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     SexualPartnerSpouse = 3.
        /// </summary>
        public static readonly ContactPerson SexualPartnerSpouse = new ContactPerson
            {
                Code = "SexualPartnerSpouse",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     Children = 4.
        /// </summary>
        public static readonly ContactPerson Children = new ContactPerson
            {
                Code = "Children",
                SortOrder = 5,
                Value = 4
            };

        /// <summary>
        ///     OtherSignificantFamily = 5.
        /// </summary>
        public static readonly ContactPerson OtherSignificantFamily = new ContactPerson
            {
                Code = "OtherSignificantFamily",
                SortOrder = 6,
                Value = 5
            };

        /// <summary>
        ///     CloseFriends = 6.
        /// </summary>
        public static readonly ContactPerson CloseFriends = new ContactPerson
            {
                Code = "CloseFriends",
                SortOrder = 7,
                Value = 6
            };

        /// <summary>
        ///     Neighbors = 7.
        /// </summary>
        public static readonly ContactPerson Neighbors = new ContactPerson
            {
                Code = "Neighbors",
                SortOrder = 8,
                Value = 7
            };

        /// <summary>
        ///     Coworkers = 8.
        /// </summary>
        public static readonly ContactPerson Coworkers = new ContactPerson
            {
                Code = "Coworkers",
                SortOrder = 9,
                Value = 8
            };

        /// <summary>
        ///     NoOne = 9.
        /// </summary>
        public static readonly ContactPerson NoOne = new ContactPerson
            {
                Code = "NoOne",
                SortOrder = 10,
                Value = 9
            };
    }
}