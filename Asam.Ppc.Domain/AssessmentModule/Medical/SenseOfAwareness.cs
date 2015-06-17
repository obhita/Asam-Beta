using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class SenseOfAwareness : Lookup
    {
        /// <summary>
        ///     OrientedAndCanDoSerialAdditions = 0.
        /// </summary>
        public static readonly SenseOfAwareness OrientedAndCanDoSerialAdditions = new SenseOfAwareness
            {
                Code = "OrientedAndCanDoSerialAdditions",
                SortOrder = 1,
                Value = 0
            };

        /// <summary>
        ///     CannotDoSerialAdditionsOrIsUncertainAboutDate = 1.
        /// </summary>
        public static readonly SenseOfAwareness CannotDoSerialAdditionsOrIsUncertainAboutDate = new SenseOfAwareness
            {
                Code = "CannotDoSerialAdditionsOrIsUncertainAboutDate",
                SortOrder = 2,
                Value = 1
            };

        /// <summary>
        ///     DisorientedForDateByNoMoreThan2CalendarDays = 2.
        /// </summary>
        public static readonly SenseOfAwareness DisorientedForDateByNoMoreThan2CalendarDays = new SenseOfAwareness
            {
                Code = "DisorientedForDateByNoMoreThan2CalendarDays",
                SortOrder = 3,
                Value = 2
            };

        /// <summary>
        ///     DisorientedForDateByMoreThan2CalendarDays = 3.
        /// </summary>
        public static readonly SenseOfAwareness DisorientedForDateByMoreThan2CalendarDays = new SenseOfAwareness
            {
                Code = "DisorientedForDateByMoreThan2CalendarDays",
                SortOrder = 4,
                Value = 3
            };

        /// <summary>
        ///     DisorientedToPlaceAndOrPerson = 4.
        /// </summary>
        public static readonly SenseOfAwareness DisorientedToPlaceAndOrPerson = new SenseOfAwareness
            {
                Code = "DisorientedToPlaceAndOrPerson",
                SortOrder = 5,
                Value = 4
            };
    }
}