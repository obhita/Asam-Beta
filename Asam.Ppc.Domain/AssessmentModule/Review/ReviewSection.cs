namespace Asam.Ppc.Domain.AssessmentModule.Review
{
    #region Using Statements

    using CommonModule.Lookups;

    #endregion

    /// <summary>
    ///     Review Section
    /// </summary>
    public class ReviewSection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewSection" /> class.
        /// </summary>
        public ReviewSection ()
        {}

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the agrees with treatment referred to.
        /// </summary>
        /// <value>
        ///     The agrees with treatment referred to.
        /// </value>
        public virtual AgreementRating AgreesWithTreatmentReferredTo { get; protected set; }

        /// <summary>
        ///     Gets or sets the category of final disposition.
        /// </summary>
        /// <value>
        ///     The category of final disposition.
        /// </value>
        public virtual CareLevel CategoryOfFinalDisposition { get; protected set; }

        /// <summary>
        ///     Gets or sets the disagrees with PPC thinks needs different treatment rating.
        /// </summary>
        /// <value>
        ///     The disagrees with PPC thinks needs different treatment rating.
        /// </value>
        public virtual TreatmentRating DisagreesWithPpcThinksNeedsDifferentTreatmentRating { get; protected set; }

        /// <summary>
        ///     Gets or sets the has interviewer differed from PPC final recommendation.
        /// </summary>
        /// <value>
        ///     The has interviewer differed from PPC final recommendation.
        /// </value>
        public virtual LevelsOfDisparity HasInterviewerDifferedFromPpcFinalRecommendation { get; protected set; }

        /// <summary>
        ///     Gets or sets the intention to follow through with referral within30 days.
        /// </summary>
        /// <value>
        ///     The intention to follow through with referral within30 days.
        /// </value>
        public virtual AgreementRating IntentionToFollowThroughWithReferralWithin30Days { get; protected set; }

        /// <summary>
        ///     Gets or sets the involvement of maintaining total abstinance in ninety days.
        /// </summary>
        /// <value>
        ///     The involvement of maintaining total abstinance in ninety days.
        /// </value>
        public virtual QualityRating InvolvementOfMaintainingTotalAbstinanceInNinetyDays { get; protected set; }

        /// <summary>
        ///     Gets or sets the maintain total abstinence in ninety day.
        /// </summary>
        /// <value>
        ///     The maintain total abstinence in ninety day.
        /// </value>
        public virtual QualityRating MaintainTotalAbstinenceInNinetyDay { get; protected set; }

        /// <summary>
        ///     Gets or sets the motivation for recovery at this time.
        /// </summary>
        /// <value>
        ///     The motivation for recovery at this time.
        /// </value>
        public virtual QualityRating MotivationForRecoveryAtThisTime { get; protected set; }

        /// <summary>
        ///     Gets or sets the probability of being treated in next90 days.
        /// </summary>
        /// <value>
        ///     The probability of being treated in next90 days.
        /// </value>
        public virtual AgreementRating ProbabilityOfBeingTreatedInNext90Days { get; protected set; }

        /// <summary>
        ///     Gets or sets the quality of intake process.
        /// </summary>
        /// <value>
        ///     The quality of intake process.
        /// </value>
        public virtual QualityRating QualityOfIntakeProcess { get; protected set; }

        /// <summary>
        ///     Gets or sets the quality of service received.
        /// </summary>
        /// <value>
        ///     The quality of service received.
        /// </value>
        public virtual QualityRating QualityOfServiceReceived { get; protected set; }

        /// <summary>
        ///     Gets or sets the reason for final disposition.
        /// </summary>
        /// <value>
        ///     The reason for final disposition.
        /// </value>
        public virtual DispositionLevel ReasonForFinalDisposition { get; protected set; }

        /// <summary>
        ///     Gets or sets the referral follow through in next30 days.
        /// </summary>
        /// <value>
        ///     The referral follow through in next30 days.
        /// </value>
        public virtual QualityRating ReferralFollowThroughInNext30Days { get; protected set; }

        /// <summary>
        ///     Gets or sets the referred to biomedically enhanced program.
        /// </summary>
        /// <value>
        ///     The referred to biomedically enhanced program.
        /// </value>
        public virtual bool? ReferredToBiomedicallyEnhancedProgram { get; protected set; }

        /// <summary>
        ///     Gets or sets the satification with time to complete interview.
        /// </summary>
        /// <value>
        ///     The satification with time to complete interview.
        /// </value>
        public virtual InterviewTimeRating SatificationWithTimeToCompleteInterview { get; protected set; }

        /// <summary>
        ///     Gets or sets the sub category of final disposition.
        /// </summary>
        /// <value>
        ///     The sub category of final disposition.
        /// </value>
        public virtual CareLevelSubCategory SubCategoryOfFinalDisposition { get; protected set; }

        /// <summary>
        ///     Gets or sets the willingness to recommend friend to program.
        /// </summary>
        /// <value>
        ///     The willingness to recommend friend to program.
        /// </value>
        public virtual AgreementRating WillingnessToRecommendFriendToProgram { get; protected set; }

        #endregion
    }
}