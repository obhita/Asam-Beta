namespace Asam.Ppc.Service.Messages.Assessment.Review
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class ReviewSectionDto : SectionDtoBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the agrees with treatment referred to.
        /// </summary>
        /// <value>
        ///     The agrees with treatment referred to.
        /// </value>
        [Display ( Order = 4 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "AgreementRating" )]
        public LookupDto AgreesWithTreatmentReferredTo { get; set; }

        /// <summary>
        ///     Gets or sets the category of final disposition.
        /// </summary>
        /// <value>
        ///     The category of final disposition.
        /// </value>
        [Display ( Order = 14 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "CareLevel" )]
        public LookupDto CategoryOfFinalDisposition { get; set; }

        /// <summary>
        ///     Gets or sets the disagrees with PPC thinks needs different treatment rating.
        /// </summary>
        /// <value>
        ///     The disagrees with PPC thinks needs different treatment rating.
        /// </value>
        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "TreatmentRating" )]
        public LookupDto DisagreesWithPpcThinksNeedsDifferentTreatmentRating { get; set; }

        /// <summary>
        ///     Gets or sets the has interviewer differed from PPC final recommendation.
        /// </summary>
        /// <value>
        ///     The has interviewer differed from PPC final recommendation.
        /// </value>
        [Display ( Order = 1 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "LevelsOfDisparity" )]
        public LookupDto HasInterviewerDifferedFromPpcFinalRecommendation { get; set; }

        /// <summary>
        ///     Gets or sets the intention to follow through with referral within30 days.
        /// </summary>
        /// <value>
        ///     The intention to follow through with referral within30 days.
        /// </value>
        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "AgreementRating" )]
        public LookupDto IntentionToFollowThroughWithReferralWithin30Days { get; set; }

        /// <summary>
        ///     Gets or sets the involvement of maintaining total abstinance in ninety days.
        /// </summary>
        /// <value>
        ///     The involvement of maintaining total abstinance in ninety days.
        /// </value>
        [Display ( Order = 13 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto InvolvementOfMaintainingTotalAbstinanceInNinetyDays { get; set; }

        /// <summary>
        ///     Gets or sets the maintain total abstinence in ninety day.
        /// </summary>
        /// <value>
        ///     The maintain total abstinence in ninety day.
        /// </value>
        [Display ( Order = 12 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto MaintainTotalAbstinenceInNinetyDay { get; set; }

        /// <summary>
        ///     Gets or sets the motivation for recovery at this time.
        /// </summary>
        /// <value>
        ///     The motivation for recovery at this time.
        /// </value>
        [Display ( Order = 11 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto MotivationForRecoveryAtThisTime { get; set; }

        /// <summary>
        ///     Gets or sets the probability of being treated in next90 days.
        /// </summary>
        /// <value>
        ///     The probability of being treated in next90 days.
        /// </value>
        [Display ( Order = 7 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "AgreementRating" )]
        public LookupDto ProbabilityOfBeingTreatedInNext90Days { get; set; }

        /// <summary>
        ///     Gets or sets the quality of intake process.
        /// </summary>
        /// <value>
        ///     The quality of intake process.
        /// </value>
        [Display ( Order = 9 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto QualityOfIntakeProcess { get; set; }

        /// <summary>
        ///     Gets or sets the quality of service received.
        /// </summary>
        /// <value>
        ///     The quality of service received.
        /// </value>
        [Display ( Order = 2 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto QualityOfServiceReceived { get; set; }

        /// <summary>
        ///     Gets or sets the reason for final disposition.
        /// </summary>
        /// <value>
        ///     The reason for final disposition.
        /// </value>
        [Display ( Order = 16 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "DispositionLevel" )]
        public LookupDto ReasonForFinalDisposition { get; set; }

        /// <summary>
        ///     Gets or sets the referral follow through in next30 days.
        /// </summary>
        /// <value>
        ///     The referral follow through in next30 days.
        /// </value>
        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "QualityRating" )]
        public LookupDto ReferralFollowThroughInNext30Days { get; set; }

        /// <summary>
        ///     Gets or sets the referred to biomedically enhanced program.
        /// </summary>
        /// <value>
        ///     The referred to biomedically enhanced program.
        /// </value>
        [Display ( Order = 17 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? ReferredToBiomedicallyEnhancedProgram { get; set; }

        /// <summary>
        ///     Gets or sets the satification with time to complete interview.
        /// </summary>
        /// <value>
        ///     The satification with time to complete interview.
        /// </value>
        [Display ( Order = 8 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "InterviewTimeRating" )]
        public LookupDto SatificationWithTimeToCompleteInterview { get; set; }

        /// <summary>
        ///     Gets or sets the sub category of final disposition.
        /// </summary>
        /// <value>
        ///     The sub category of final disposition.
        /// </value>
        [Display ( Order = 15 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [LookupCategory ( "CareLevelSubCategory" )]
        public LookupDto SubCategoryOfFinalDisposition { get; set; }

        /// <summary>
        ///     Gets or sets the willingness to recommend friend to program.
        /// </summary>
        /// <value>
        ///     The willingness to recommend friend to program.
        /// </value>
        [Display ( Order = 3 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "AgreementRating" )]
        public LookupDto WillingnessToRecommendFriendToProgram { get; set; }

        #endregion
    }
}