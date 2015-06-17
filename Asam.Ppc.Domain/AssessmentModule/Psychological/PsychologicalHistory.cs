using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Pillar.Common.Utility;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    /// <summary>
    /// Psychological history class.
    /// </summary>
    public class PsychologicalHistory : RevisionBase
    {
        private IList<PsychologicalOrEmotionalProblems> _pastPsychologicalOrEmotionalProblems;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PsychologicalHistory" /> class.
        /// </summary>
        protected internal PsychologicalHistory()
        {
            _pastPsychologicalOrEmotionalProblems = new List<PsychologicalOrEmotionalProblems>();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the anxiety attack chest pains in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack chest pains in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackChestPainsInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chest pains in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack chest pains in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackChestPainsInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chest pains in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack chest pains in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackChestPainsInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chest pains related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack chest pains related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackChestPainsRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chills hot flashes in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack chills hot flashes in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackChillsHotFlashesInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chills hot flashes in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack chills hot flashes in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackChillsHotFlashesInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chills hot flashes in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack chills hot flashes in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackChillsHotFlashesInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack chills hot flashes related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack chills hot flashes related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackChillsHotFlashesRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack choking in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack choking in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackChokingInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack choking in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack choking in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackChokingInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack choking in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack choking in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackChokingInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack choking related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack choking related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackChokingRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack distorted reality in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack distorted reality in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackDistortedRealityInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack distorted reality in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack distorted reality in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackDistortedRealityInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack distorted reality in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack distorted reality in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackDistortedRealityInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack distorted reality related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack distorted reality related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackDistortedRealityRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dizziness faintness in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack dizziness faintness in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackDizzinessFaintnessInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dizziness faintness in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack dizziness faintness in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackDizzinessFaintnessInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dizziness faintness in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack dizziness faintness in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackDizzinessFaintnessInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dizziness faintness related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack dizziness faintness related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackDizzinessFaintnessRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dying sensation in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack dying sensation in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackDyingSensationInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dying sensation in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack dying sensation in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackDyingSensationInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dying sensation in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack dying sensation in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackDyingSensationInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack dying sensation related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack dying sensation related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackDyingSensationRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack lose control in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack lose control in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackLoseControlInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack lose control in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack lose control in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackLoseControlInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack lose control in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack lose control in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackLoseControlInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack lose control related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack lose control related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackLoseControlRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack more than once in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack more than once in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackMoreThanOnceInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack more than once in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack more than once in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackMoreThanOnceInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack more than once in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack more than once in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackMoreThanOnceInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack more than once related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack more than once related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackMoreThanOnceRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack nausea diarrhea in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack nausea diarrhea in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackNauseaDiarrheaInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack nausea diarrhea in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack nausea diarrhea in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackNauseaDiarrheaInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack nausea diarrhea in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack nausea diarrhea in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackNauseaDiarrheaInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack nausea diarrhea related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack nausea diarrhea related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackNauseaDiarrheaRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack numbness in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack numbness in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackNumbnessInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack numbness in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack numbness in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackNumbnessInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack numbness in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack numbness in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackNumbnessInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack numbness related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack numbness related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackNumbnessRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack palpitations in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack palpitations in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackPalpitationsInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack palpitations in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack palpitations in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackPalpitationsInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack palpitations in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack palpitations in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackPalpitationsInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack palpitations related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack palpitations related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackPalpitationsRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack random in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack random in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackRandomInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack random in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack random in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackRandomInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack random in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack random in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackRandomInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack random related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack random related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackRandomRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack shortness breath in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack shortness breath in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackShortnessBreathInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack shortness breath in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack shortness breath in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackShortnessBreathInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack shortness breath in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack shortness breath in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackShortnessBreathInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack shortness breath related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack shortness breath related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackShortnessBreathRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack sweaty in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack sweaty in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackSweatyInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack sweaty in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack sweaty in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackSweatyInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack sweaty in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack sweaty in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackSweatyInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack sweaty related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack sweaty related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackSweatyRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack trembling in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety attack trembling in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyAttackTremblingInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack trembling in last month.
        /// </summary>
        /// <value>
        /// The anxiety attack trembling in last month.
        /// </value>
        public virtual LikertScale AnxietyAttackTremblingInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack trembling in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety attack trembling in lifetime.
        /// </value>
        public virtual LikertScale AnxietyAttackTremblingInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack trembling related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack trembling related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackTremblingRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety attack within24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety attack within24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyAttackWithin24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the anxiety tension worry in last24 hours.
        /// </summary>
        /// <value>
        /// The anxiety tension worry in last24 hours.
        /// </value>
        public virtual LikertScale AnxietyTensionWorryInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the anxiety tension worry in last month.
        /// </summary>
        /// <value>
        /// The anxiety tension worry in last month.
        /// </value>
        public virtual LikertScale AnxietyTensionWorryInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the anxiety tension worry in lifetime.
        /// </summary>
        /// <value>
        /// The anxiety tension worry in lifetime.
        /// </value>
        public virtual LikertScale AnxietyTensionWorryInLifetime { get; protected set; }

        /// <summary>
        /// Gets the anxiety tension worry within24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The anxiety tension worry within24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse AnxietyTensionWorryWithin24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the cant wait for things wanted badly.
        /// </summary>
        /// <value>
        /// The cant wait for things wanted badly.
        /// </value>
        public virtual bool? CantWaitForThingsWantedBadly { get; protected set; }

        /// <summary>
        /// Gets the depression within24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The depression within24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse DepressionWithin24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the difficult to work now for future gain.
        /// </summary>
        /// <value>
        /// The difficult to work now for future gain.
        /// </value>
        public virtual bool? DifficultToWorkNowForFutureGain { get; protected set; }

        /// <summary>
        /// Gets the emotional problems correlation with substance use.
        /// </summary>
        /// <value>
        /// The emotional problems correlation with substance use.
        /// </value>
        public virtual EmotionalProblemsCorrelationWithSubstanceUse EmotionalProblemsCorrelationWithSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the feel like failure in last24 hours.
        /// </summary>
        /// <value>
        /// The feel like failure in last24 hours.
        /// </value>
        public virtual LikertScale FeelLikeFailureInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the feel like failure in last24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The feel like failure in last24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse FeelLikeFailureInLast24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the feel like failure in last month.
        /// </summary>
        /// <value>
        /// The feel like failure in last month.
        /// </value>
        public virtual LikertScale FeelLikeFailureInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the feel like failure in lifetime.
        /// </summary>
        /// <value>
        /// The feel like failure in lifetime.
        /// </value>
        public virtual LikertScale FeelLikeFailureInLifetime { get; protected set; }

        /// <summary>
        /// Gets the how difficult problems for work home and social interaction.
        /// </summary>
        /// <value>
        /// The how difficult problems for work home and social interaction.
        /// </value>
        public virtual ProblemsForWorkHomeAndSocialInteractionScale HowDifficultProblemsForWorkHomeAndSocialInteraction { get; protected set; }

        /// <summary>
        /// Gets the how difficult to self manage emotional problems.
        /// </summary>
        /// <value>
        /// The how difficult to self manage emotional problems.
        /// </value>
        public virtual SelfManageEmotionalProblemsScale HowDifficultToSelfManageEmotionalProblems { get; protected set; }

        /// <summary>
        /// Gets the how emotional problems impact recovery efforts.
        /// </summary>
        /// <value>
        /// The how emotional problems impact recovery efforts.
        /// </value>
        public virtual EmotionalProblemsImpactRecoveryEffortsScale HowEmotionalProblemsImpactRecoveryEfforts { get; protected set; }

        /// <summary>
        /// Gets the how important psychological emotional counseling.
        /// </summary>
        /// <value>
        /// The how important psychological emotional counseling.
        /// </value>
        public virtual PsychologicalEmotionalCounselingImportanceScale HowImportantPsychologicalEmotionalCounseling { get; protected set; }

        /// <summary>
        /// Gets the how troubled by psychological emotional problems last30 days.
        /// </summary>
        /// <value>
        /// The how troubled by psychological emotional problems last30 days.
        /// </value>
        public virtual LikertScale HowTroubledByPsychologicalEmotionalProblemsLast30Days { get; protected set; }

        /// <summary>
        /// Gets the inability to feel pleasure from activities in last24 hours.
        /// </summary>
        /// <value>
        /// The inability to feel pleasure from activities in last24 hours.
        /// </value>
        public virtual LikertScale InabilityToFeelPleasureFromActivitiesInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the inability to feel pleasure from activities in last month.
        /// </summary>
        /// <value>
        /// The inability to feel pleasure from activities in last month.
        /// </value>
        public virtual LikertScale InabilityToFeelPleasureFromActivitiesInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the inability to feel pleasure from activities in lifetime.
        /// </summary>
        /// <value>
        /// The inability to feel pleasure from activities in lifetime.
        /// </value>
        public virtual LikertScale InabilityToFeelPleasureFromActivitiesInLifetime { get; protected set; }

        /// <summary>
        /// Gets the inability to feel pleasure from activities related to substance use.
        /// </summary>
        /// <value>
        /// The inability to feel pleasure from activities related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the is receiving needed care.
        /// </summary>
        /// <value>
        /// The is receiving needed care.
        /// </value>
        public virtual YesNoNotApplicable IsReceivingNeededCare { get; protected set; }

        /// <summary>
        /// Gets the medicated for psychological emotional problem in last24 hours.
        /// </summary>
        /// <value>
        /// The medicated for psychological emotional problem in last24 hours.
        /// </value>
        public virtual bool? MedicatedForPsychologicalEmotionalProblemInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the medicated for psychological emotional problem in last month.
        /// </summary>
        /// <value>
        /// The medicated for psychological emotional problem in last month.
        /// </value>
        public virtual bool? MedicatedForPsychologicalEmotionalProblemInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the medicated for psychological emotional problem in lifetime.
        /// </summary>
        /// <value>
        /// The medicated for psychological emotional problem in lifetime.
        /// </value>
        public virtual bool? MedicatedForPsychologicalEmotionalProblemInLifetime { get; protected set; }

        /// <summary>
        /// Gets the moving speaking slowly in last24 hours.
        /// </summary>
        /// <value>
        /// The moving speaking slowly in last24 hours.
        /// </value>
        public virtual LikertScale MovingSpeakingSlowlyInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the moving speaking slowly in last month.
        /// </summary>
        /// <value>
        /// The moving speaking slowly in last month.
        /// </value>
        public virtual LikertScale MovingSpeakingSlowlyInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the moving speaking slowly in lifetime.
        /// </summary>
        /// <value>
        /// The moving speaking slowly in lifetime.
        /// </value>
        public virtual LikertScale MovingSpeakingSlowlyInLifetime { get; protected set; }

        /// <summary>
        /// Gets the moving speaking slowly within24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The moving speaking slowly within24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse MovingSpeakingSlowlyWithin24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the number of days experienced psychological emotional problems in last30 days.
        /// </summary>
        /// <value>
        /// The number of days experienced psychological emotional problems in last30 days.
        /// </value>
        public virtual uint? NumberOfDaysExperiencedPsychologicalEmotionalProblemsInLast30Days { get; protected set; }

        /// <summary>
        /// Gets the past psychological or emotional problems.
        /// </summary>
        /// <value>
        /// The past psychological or emotional problems.
        /// </value>
        public virtual IEnumerable<PsychologicalOrEmotionalProblems> PastPsychologicalOrEmotionalProblems
        {
            get { return _pastPsychologicalOrEmotionalProblems; }

            protected set
            {
                _pastPsychologicalOrEmotionalProblems.Clear();
                if (value != null)
                {
                    _pastPsychologicalOrEmotionalProblems.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the poor appetite or overeating in last24 hours.
        /// </summary>
        /// <value>
        /// The poor appetite or overeating in last24 hours.
        /// </value>
        public virtual LikertScale PoorAppetiteOrOvereatingInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the poor appetite or overeating in last24 hours related to substance use.
        /// </summary>
        /// <value>
        /// The poor appetite or overeating in last24 hours related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse PoorAppetiteOrOvereatingInLast24HoursRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the poor appetite or overeating in last month.
        /// </summary>
        /// <value>
        /// The poor appetite or overeating in last month.
        /// </value>
        public virtual LikertScale PoorAppetiteOrOvereatingInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the poor appetite or overeating in lifetime.
        /// </summary>
        /// <value>
        /// The poor appetite or overeating in lifetime.
        /// </value>
        public virtual LikertScale PoorAppetiteOrOvereatingInLifetime { get; protected set; }

        /// <summary>
        /// Gets the receives pension for psychiatric disability.
        /// </summary>
        /// <value>
        /// The receives pension for psychiatric disability.
        /// </value>
        public virtual bool? ReceivesPensionForPsychiatricDisability { get; protected set; }

        /// <summary>
        /// Gets the significant period attempted suicide in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period attempted suicide in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodAttemptedSuicideInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period attempted suicide in last month.
        /// </summary>
        /// <value>
        /// The significant period attempted suicide in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodAttemptedSuicideInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period attempted suicide in lifetime.
        /// </summary>
        /// <value>
        /// The significant period attempted suicide in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodAttemptedSuicideInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period attempted suicide related to substance use.
        /// </summary>
        /// <value>
        /// The significant period attempted suicide related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodAttemptedSuicideRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period curbing violent behavior in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period curbing violent behavior in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodCurbingViolentBehaviorInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period curbing violent behavior in last month.
        /// </summary>
        /// <value>
        /// The significant period curbing violent behavior in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodCurbingViolentBehaviorInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period curbing violent behavior in lifetime.
        /// </summary>
        /// <value>
        /// The significant period curbing violent behavior in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodCurbingViolentBehaviorInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period curbing violent behavior related to substance use.
        /// </summary>
        /// <value>
        /// The significant period curbing violent behavior related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period excessive behavior in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period excessive behavior in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodExcessiveBehaviorInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period excessive behavior in last month.
        /// </summary>
        /// <value>
        /// The significant period excessive behavior in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodExcessiveBehaviorInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period excessive behavior in lifetime.
        /// </summary>
        /// <value>
        /// The significant period excessive behavior in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodExcessiveBehaviorInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period excessive behavior related to substance use.
        /// </summary>
        /// <value>
        /// The significant period excessive behavior related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodExcessiveBehaviorRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period fidgeting in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period fidgeting in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodFidgetingInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period fidgeting in last month.
        /// </summary>
        /// <value>
        /// The significant period fidgeting in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodFidgetingInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period fidgeting in lifetime.
        /// </summary>
        /// <value>
        /// The significant period fidgeting in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodFidgetingInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period fidgeting related to substance use.
        /// </summary>
        /// <value>
        /// The significant period fidgeting related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodFidgetingRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period flashbacks in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period flashbacks in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodFlashbacksInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period flashbacks in last month.
        /// </summary>
        /// <value>
        /// The significant period flashbacks in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodFlashbacksInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period flashbacks in lifetime.
        /// </summary>
        /// <value>
        /// The significant period flashbacks in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodFlashbacksInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period flashbacks related to substance use.
        /// </summary>
        /// <value>
        /// The significant period flashbacks related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodFlashbacksRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period hallucinations in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period hallucinations in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodHallucinationsInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period hallucinations in last month.
        /// </summary>
        /// <value>
        /// The significant period hallucinations in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodHallucinationsInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period hallucinations in lifetime.
        /// </summary>
        /// <value>
        /// The significant period hallucinations in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodHallucinationsInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period hallucinations related to substance use.
        /// </summary>
        /// <value>
        /// The significant period hallucinations related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodHallucinationsRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period impaired thought in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period impaired thought in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodImpairedThoughtInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period impaired thought in last month.
        /// </summary>
        /// <value>
        /// The significant period impaired thought in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodImpairedThoughtInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period impaired thought in lifetime.
        /// </summary>
        /// <value>
        /// The significant period impaired thought in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodImpairedThoughtInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period impaired thought related to substance use.
        /// </summary>
        /// <value>
        /// The significant period impaired thought related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodImpairedThoughtRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period irritability in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period irritability in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodIrritabilityInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period irritability in last month.
        /// </summary>
        /// <value>
        /// The significant period irritability in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodIrritabilityInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period irritability in lifetime.
        /// </summary>
        /// <value>
        /// The significant period irritability in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodIrritabilityInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period irritability related to substance use.
        /// </summary>
        /// <value>
        /// The significant period irritability related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodIrritabilityRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period lethargy in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period lethargy in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodLethargyInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period lethargy in last month.
        /// </summary>
        /// <value>
        /// The significant period lethargy in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodLethargyInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period lethargy in lifetime.
        /// </summary>
        /// <value>
        /// The significant period lethargy in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodLethargyInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period lethargy related to substance use.
        /// </summary>
        /// <value>
        /// The significant period lethargy related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodLethargyRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period muscle tension in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period muscle tension in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodMuscleTensionInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period muscle tension in last month.
        /// </summary>
        /// <value>
        /// The significant period muscle tension in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodMuscleTensionInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period muscle tension in lifetime.
        /// </summary>
        /// <value>
        /// The significant period muscle tension in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodMuscleTensionInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period muscle tension related to substance use.
        /// </summary>
        /// <value>
        /// The significant period muscle tension related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodMuscleTensionRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period negative thoughts in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period negative thoughts in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodNegativeThoughtsInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period negative thoughts in last month.
        /// </summary>
        /// <value>
        /// The significant period negative thoughts in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodNegativeThoughtsInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period negative thoughts in lifetime.
        /// </summary>
        /// <value>
        /// The significant period negative thoughts in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodNegativeThoughtsInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period negative thoughts related to substance use.
        /// </summary>
        /// <value>
        /// The significant period negative thoughts related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodNegativeThoughtsRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period of serious depression in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period of serious depression in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodOfSeriousDepressionInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period of serious depression in last month.
        /// </summary>
        /// <value>
        /// The significant period of serious depression in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodOfSeriousDepressionInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period of serious depression in lifetime.
        /// </summary>
        /// <value>
        /// The significant period of serious depression in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodOfSeriousDepressionInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period paranoia in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period paranoia in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodParanoiaInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period paranoia in last month.
        /// </summary>
        /// <value>
        /// The significant period paranoia in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodParanoiaInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period paranoia in lifetime.
        /// </summary>
        /// <value>
        /// The significant period paranoia in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodParanoiaInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period paranoia related to substance use.
        /// </summary>
        /// <value>
        /// The significant period paranoia related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodParanoiaRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period sleep disorder in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period sleep disorder in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodSleepDisorderInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period sleep disorder in last month.
        /// </summary>
        /// <value>
        /// The significant period sleep disorder in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodSleepDisorderInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period sleep disorder in lifetime.
        /// </summary>
        /// <value>
        /// The significant period sleep disorder in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodSleepDisorderInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period sleep disorder related to substance use.
        /// </summary>
        /// <value>
        /// The significant period sleep disorder related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodSleepDisorderRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period suicidal thoughts in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period suicidal thoughts in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodSuicidalThoughtsInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period suicidal thoughts in last month.
        /// </summary>
        /// <value>
        /// The significant period suicidal thoughts in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodSuicidalThoughtsInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period suicidal thoughts in lifetime.
        /// </summary>
        /// <value>
        /// The significant period suicidal thoughts in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodSuicidalThoughtsInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period suicidal thoughts related to substance use.
        /// </summary>
        /// <value>
        /// The significant period suicidal thoughts related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period thoughts of self injury in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period thoughts of self injury in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodThoughtsOfSelfInjuryInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period thoughts of self injury in last month.
        /// </summary>
        /// <value>
        /// The significant period thoughts of self injury in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodThoughtsOfSelfInjuryInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period thoughts of self injury in lifetime.
        /// </summary>
        /// <value>
        /// The significant period thoughts of self injury in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodThoughtsOfSelfInjuryInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period thoughts of self injury related to substance use.
        /// </summary>
        /// <value>
        /// The significant period thoughts of self injury related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodThoughtsOfSelfInjuryRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period trouble with attitude toward others in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period trouble with attitude toward others in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period trouble with attitude toward others in last month.
        /// </summary>
        /// <value>
        /// The significant period trouble with attitude toward others in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period trouble with attitude toward others in lifetime.
        /// </summary>
        /// <value>
        /// The significant period trouble with attitude toward others in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period trouble with attitude toward others related to substance use.
        /// </summary>
        /// <value>
        /// The significant period trouble with attitude toward others related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodTroubleWithAttitudeTowardOthersRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period untrue perception in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period untrue perception in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodUntruePerceptionInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period untrue perception in last month.
        /// </summary>
        /// <value>
        /// The significant period untrue perception in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodUntruePerceptionInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period untrue perception in lifetime.
        /// </summary>
        /// <value>
        /// The significant period untrue perception in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodUntruePerceptionInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period untrue perception related to substance use.
        /// </summary>
        /// <value>
        /// The significant period untrue perception related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodUntruePerceptionRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the significant period violent urges in last24 hours.
        /// </summary>
        /// <value>
        /// The significant period violent urges in last24 hours.
        /// </value>
        public virtual LikertScale SignificantPeriodViolentUrgesInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the significant period violent urges in last month.
        /// </summary>
        /// <value>
        /// The significant period violent urges in last month.
        /// </value>
        public virtual LikertScale SignificantPeriodViolentUrgesInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the significant period violent urges in lifetime.
        /// </summary>
        /// <value>
        /// The significant period violent urges in lifetime.
        /// </value>
        public virtual LikertScale SignificantPeriodViolentUrgesInLifetime { get; protected set; }

        /// <summary>
        /// Gets the significant period violent urges related to substance use.
        /// </summary>
        /// <value>
        /// The significant period violent urges related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse SignificantPeriodViolentUrgesRelatedToSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the times treated for psychological or emotional problems as outpatient.
        /// </summary>
        /// <value>
        /// The times treated for psychological or emotional problems as outpatient.
        /// </value>
        public virtual uint? TimesTreatedForPsychologicalOrEmotionalProblemsAsOutpatient { get; protected set; }

        /// <summary>
        /// Gets the times treated for psychological or emotional problems in hospital.
        /// </summary>
        /// <value>
        /// The times treated for psychological or emotional problems in hospital.
        /// </value>
        public virtual uint? TimesTreatedForPsychologicalOrEmotionalProblemsInHospital { get; protected set; }

        /// <summary>
        /// Gets the worried about anxiety attack in last24 hours.
        /// </summary>
        /// <value>
        /// The worried about anxiety attack in last24 hours.
        /// </value>
        public virtual LikertScale WorriedAboutAnxietyAttackInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the worried about anxiety attack in last month.
        /// </summary>
        /// <value>
        /// The worried about anxiety attack in last month.
        /// </value>
        public virtual LikertScale WorriedAboutAnxietyAttackInLastMonth { get; protected set; }

        /// <summary>
        /// Gets the worried about anxiety attack in lifetime.
        /// </summary>
        /// <value>
        /// The worried about anxiety attack in lifetime.
        /// </value>
        public virtual LikertScale WorriedAboutAnxietyAttackInLifetime { get; protected set; }

        /// <summary>
        /// Gets the worried about anxiety attack related to substance use.
        /// </summary>
        /// <value>
        /// The worried about anxiety attack related to substance use.
        /// </value>
        public virtual RelationToSubstanceUse WorriedAboutAnxietyAttackRelatedToSubstanceUse { get; protected set; }

        #endregion
    }
}