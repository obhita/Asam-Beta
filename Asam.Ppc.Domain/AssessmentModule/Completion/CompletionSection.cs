using System.Collections.Generic;
using Asam.Ppc.Domain.CommonModule.Lookups;

namespace Asam.Ppc.Domain.AssessmentModule.Completion
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Completion Section
    /// </summary>
    public class CompletionSection : RevisionBase
    {
        private IList<CareLevel> _acceptableLevelsOfCare;
        private IList<CareLevel> _recommendedCareLevels;
        private IList<CareLevel> _unacceptableCareLevels;
        private IList<CareLevel> _unavailableCareLevels;

        #region Constructors and Destructors

        protected internal CompletionSection()
        {
            _acceptableLevelsOfCare = new List<CareLevel>();
            _unacceptableCareLevels = new List<CareLevel>();
            _unavailableCareLevels = new List<CareLevel>();
            _recommendedCareLevels = new List<CareLevel>();
        }

        #endregion

        #region public  Properties

        /// <summary>
        /// Gets the acceptable levels of care.
        /// </summary>
        /// <value>
        /// The acceptable levels of care.
        /// </value>
        public virtual IEnumerable<CareLevel> AcceptableLevelsOfCare
        {
            get { return _acceptableLevelsOfCare; }

            protected set
            {
                _acceptableLevelsOfCare.Clear();
                if (value != null)
                {
                    _acceptableLevelsOfCare.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the detoxification required more than hourly monitoring.
        /// </summary>
        /// <value>
        /// The detoxification required more than hourly monitoring.
        /// </value>
        public virtual bool? DetoxificationRequiredMoreThanHourlyMonitoring { get; protected set; }

        /// <summary>
        /// Gets the is able to self administer medication.
        /// </summary>
        /// <value>
        /// The is able to self administer medication.
        /// </value>
        public virtual YesNoNotApplicable IsAbleToSelfAdministerMedication { get; protected set; }

        /// <summary>
        /// Gets the is currently residing in care level_ II i_1.
        /// </summary>
        /// <value>
        /// The is currently residing in care level_ II i_1.
        /// </value>
        public virtual bool? IsCurrentlyResidingInCareLevel_III_1 { get; protected set; }

        /// <summary>
        /// Gets the medical condition endangered by continued substance use.
        /// </summary>
        /// <value>
        /// The medical condition endangered by continued substance use.
        /// </value>
        public virtual YesNoNotSure MedicalConditionEndangeredByContinuedSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the medical condition exacerbated by continued substance use.
        /// </summary>
        /// <value>
        /// The medical condition exacerbated by continued substance use.
        /// </value>
        public virtual YesNoNotSure MedicalConditionExacerbatedByContinuedSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the medical condition makes abstinence vital.
        /// </summary>
        /// <value>
        /// The medical condition makes abstinence vital.
        /// </value>
        public virtual YesNoNotSure MedicalConditionMakesAbstinenceVital { get; protected set; }

        /// <summary>
        /// Gets the medical condition stabilized in past24 hours permitting treatment.
        /// </summary>
        /// <value>
        /// The medical condition stabilized in past24 hours permitting treatment.
        /// </value>
        public virtual YesNoNotApplicableNotSure MedicalConditionStabilizedInPast24HoursPermittingTreatment { get; protected set; }

        /// <summary>
        /// Gets the medical problems caused by substance use.
        /// </summary>
        /// <value>
        /// The medical problems caused by substance use.
        /// </value>
        public virtual bool? MedicalProblemsCausedBySubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the PRN hourly monitoring sufficient to determine detox service level.
        /// </summary>
        /// <value>
        /// The PRN hourly monitoring sufficient to determine detox service level.
        /// </value>
        public virtual bool? PrnHourlyMonitoringSufficientToDetermineDetoxServiceLevel { get; protected set; }

        /// <summary>
        /// Gets the recommended care level sub category.
        /// </summary>
        /// <value>
        /// The recommended care level sub category.
        /// </value>
        public virtual CareLevelSubCategory RecommendedCareLevelSubCategory { get; protected set; }

        /// <summary>
        /// Gets the recommended care levels.
        /// </summary>
        /// <value>
        /// The recommended care levels.
        /// </value>
        public virtual IEnumerable<CareLevel> RecommendedCareLevels
        {
            get { return _recommendedCareLevels; }

            protected set
            {
                _recommendedCareLevels.Clear();
                if (value != null)
                {
                    _recommendedCareLevels.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the requires treatment mode only available in care level_ II i_7.
        /// </summary>
        /// <value>
        /// The requires treatment mode only available in care level_ II i_7.
        /// </value>
        public virtual bool? RequiresTreatmentModeOnlyAvailableInCareLevel_III_7 { get; protected set; }

        /// <summary>
        /// Gets the responded positively to emotional support during interview.
        /// </summary>
        /// <value>
        /// The responded positively to emotional support during interview.
        /// </value>
        public virtual bool? RespondedPositivelyToEmotionalSupportDuringInterview { get; protected set; }

        /// <summary>
        /// Gets the symptoms life threatening because of substance use.
        /// </summary>
        /// <value>
        /// The symptoms life threatening because of substance use.
        /// </value>
        public virtual YesNoNotSure SymptomsLifeThreateningBecauseOfSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the symptoms stabalized during treatment day.
        /// </summary>
        /// <value>
        /// The symptoms stabalized during treatment day.
        /// </value>
        public virtual bool? SymptomsStabalizedDuringTreatmentDay { get; protected set; }

        /// <summary>
        /// Gets the timing of positive response to detoxification care.
        /// </summary>
        /// <value>
        /// The timing of positive response to detoxification care.
        /// </value>
        public virtual WithdrawalManagementCareResponseTiming TimingOfPositiveResponseToWithdrawalManagementCare { get; protected set; }

        /// <summary>
        /// Gets the unacceptable care levels.
        /// </summary>
        /// <value>
        /// The unacceptable care levels.
        /// </value>
        public virtual IEnumerable<CareLevel> UnacceptableCareLevels
        {
            get { return _unacceptableCareLevels; }

            protected set
            {
                _unacceptableCareLevels.Clear();
                if (value != null)
                {
                    _unacceptableCareLevels.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the unavailable care levels.
        /// </summary>
        /// <value>
        /// The unavailable care levels.
        /// </value>
        public virtual IEnumerable<CareLevel> UnavailableCareLevels
        {
            get { return _unavailableCareLevels; }

            protected set
            {
                _unavailableCareLevels.Clear();
                if (value != null)
                {
                    _unavailableCareLevels.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the would recommend program to friend.
        /// </summary>
        /// <value>
        /// The would recommend program to friend.
        /// </value>
        public virtual WouldRecommendProgramToFriend WouldRecommendProgramToFriend { get; protected set; }

        /// <summary>
        /// Gets or sets the clinical summary notes.
        /// </summary>
        /// <value>
        /// The clinical summary notes.
        /// </value>
        [ColumnLength(2000)]
        public virtual string ClinicalSummaryNotes { get; protected set; }

        #endregion
    }
}