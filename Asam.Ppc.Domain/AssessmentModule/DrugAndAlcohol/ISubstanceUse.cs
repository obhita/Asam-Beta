using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    public interface ISubstanceUse
    {
        // bool? HasEverUsed { get; }
        /// <summary>
        ///     (ASID03E)
        /// </summary>
        /// <summary>
        ///     (ASID03Rn/u --> UseFrequency)
        /// </summary>
        TimeMeasure LastUsed { get; }

        /// <summary>
        ///     (ASId03F)
        /// </summary>
        uint? NumberOfDaysUsedInPast30Days { get; }

        /// <summary>
        ///     (ASId03Dy/m --> Month)
        /// </summary>
        uint? NumberOfMonthsUsedInLifetime { get; }

        //RouteOfIntake RouteOfIntake { get;  }

        /// <summary>
        ///     (CUAD03_01)
        /// </summary>
        bool? IncreasedDoseRequiredToGetSameEffect { get; }

        /// <summary>
        ///     (CUAD03_02)
        /// </summary>
        bool? ExperiencesWithdrawalSickness { get; }

        /// <summary>
        ///     (CUAD03_03)
        /// </summary>
        bool? UseSubstanceToPreventWithdrawalSickness { get; }

        /// <summary>
        ///     (CUAD03_04)
        /// </summary>
        bool? UnableToStopUsingSubstance { get; }

        /// <summary>
        ///     (CUAD03_05)
        /// </summary>
        bool? SubstanceUseReductionAttempted { get; }

        /// <summary>
        ///     (CUAD03_06)
        /// </summary>
        bool? UseOfSubstanceTakesUpALotOfTime { get; }

        /// <summary>
        ///     (CUAD03_07)
        /// </summary>
        bool? FrequentlyHighAtWork { get; }

        /// <summary>
        ///     (CUAD03_08)
        /// </summary>
        bool? FrequentlyHighAtSchool { get; }

        /// <summary>
        ///     (CUAD03_09)
        /// </summary>
        bool? FrequentlyHighAtHome { get; }

        /// <summary>
        ///     (CUAD03_10)
        /// </summary>
        bool? FrequentlyHighInDangerousSituations { get; }

        /// <summary>
        ///     (CUAD03_11)
        /// </summary>
        bool? SubstanceUseReductionInSocialActivities { get; }

        /// <summary>
        ///     (CUAD03_12)
        /// </summary>
        bool? SubstanceUseReductionInOccupationalActivities { get; }

        /// <summary>
        ///     (CUAD03_13)
        /// </summary>
        bool? SubstanceUseReductionInRecreationalActivities { get; }

        /// <summary>
        ///     (CUAD03_14)
        /// </summary>
        bool? SubstanceUseRecurrentProblemsWithFamilyFriends { get; }

        /// <summary>
        ///     (CUAD03_15)
        /// </summary>
        bool? SubstanceUseRecurrentProblemsWithHealth { get; }

        /// <summary>
        ///     (CUAD03_16)
        /// </summary>
        bool? SubstanceUseRecurrentProblemsWithEmotions { get; }

        /// <summary>
        ///     (CUAD03_17)
        /// </summary>
        bool? SubstanceUseRecurrentProblemsWithJob { get; }

        /// <summary>
        ///     (CUAD03_18)
        /// </summary>
        bool? SubstanceUseRecurrentProblemsWithLegalSystem { get; }

        /// <summary>
        ///     (CUAD03_19)
        /// </summary>
        bool? HasUsedSubstanceKnowingProblemsWorsened { get; }

        /// <summary>
        ///     (CUAD03_20)
        /// </summary>
        bool? HasStrongUrges { get; }
    }
}