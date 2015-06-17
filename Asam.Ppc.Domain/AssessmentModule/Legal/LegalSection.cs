using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.AssessmentModule.Legal
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Legal section class.
    /// </summary>
    public class LegalSection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalSection" /> class.
        /// </summary>
        protected internal LegalSection()
        {
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the currently awaiting charges trial sentence for legal charge.
        /// </summary>
        /// <value>
        /// The currently awaiting charges trial sentence for legal charge.
        /// </value>
        public virtual LegalCharge CurrentlyAwaitingChargesTrialSentenceForLegalCharge { get; protected set; }

        /// <summary>
        /// Gets the desire and external factors driving treatment.
        /// </summary>
        /// <value>
        /// The desire and external factors driving treatment.
        /// </value>
        public virtual DesireAndExternalFactorsDrivingTreatment DesireAndExternalFactorsDrivingTreatment { get; protected set; }

        /// <summary>
        /// Gets the importance of counseling for current legal problems.
        /// </summary>
        /// <value>
        /// The importance of counseling for current legal problems.
        /// </value>
        public virtual LikertScale ImportanceOfCounselingForCurrentLegalProblems { get; protected set; }

        /// <summary>
        /// Gets the interviewer comments.
        /// </summary>
        /// <value>
        /// The interviewer comments.
        /// </value>
        [ColumnLength(2000)]
        public virtual string InterviewerComments { get; protected set; }

        /// <summary>
        /// Gets the interviewer rating patient need for legal service counseling.
        /// </summary>
        /// <value>
        /// The interviewer rating patient need for legal service counseling.
        /// </value>
        public virtual ScaleOf0To9 InterviewerRatingPatientNeedForLegalServiceCounseling { get; protected set; }

        /// <summary>
        /// Gets the is currently awaiting charges trial sentence.
        /// </summary>
        /// <value>
        /// The is currently awaiting charges trial sentence.
        /// </value>
        public virtual bool? IsCurrentlyAwaitingChargesTrialSentence { get; protected set; }

        /// <summary>
        /// Gets the is on probation or parole.
        /// </summary>
        /// <value>
        /// The is on probation or parole.
        /// </value>
        public virtual bool? IsOnProbationOrParole { get; protected set; }

        /// <summary>
        /// Gets the is patient misrepresenting information.
        /// </summary>
        /// <value>
        /// The is patient misrepresenting information.
        /// </value>
        public virtual bool? IsPatientMisrepresentingInformation { get; protected set; }

        /// <summary>
        /// Gets the is patient unable to understand.
        /// </summary>
        /// <value>
        /// The is patient unable to understand.
        /// </value>
        public virtual bool? IsPatientUnableToUnderstand { get; protected set; }

        /// <summary>
        /// Gets the last incarceration reason.
        /// </summary>
        /// <value>
        /// The last incarceration reason.
        /// </value>
        public virtual LegalCharge LastIncarcerationReason { get; protected set; }

        /// <summary>
        /// Gets the length in months of last incarceration.
        /// </summary>
        /// <value>
        /// The length in months of last incarceration.
        /// </value>
        public virtual uint? LengthInMonthsOfLastIncarceration { get; protected set; }

        /// <summary>
        /// Gets the number of days commiting crimes for profit in past30 days.
        /// </summary>
        /// <value>
        /// The number of days commiting crimes for profit in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysCommitingCrimesForProfitInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the number of days incarcerated in past30 days.
        /// </summary>
        /// <value>
        /// The number of days incarcerated in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysIncarceratedInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the number of months incarcerated in life.
        /// </summary>
        /// <value>
        /// The number of months incarcerated in life.
        /// </value>
        public virtual uint? NumberOfMonthsIncarceratedInLife { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for arson.
        /// </summary>
        /// <value>
        /// The number of times arrested for arson.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForArson { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for assault.
        /// </summary>
        /// <value>
        /// The number of times arrested for assault.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForAssault { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for burglary larceny.
        /// </summary>
        /// <value>
        /// The number of times arrested for burglary larceny.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForBurglaryLarceny { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for contempt of court.
        /// </summary>
        /// <value>
        /// The number of times arrested for contempt of court.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForContemptOfCourt { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for drug charges.
        /// </summary>
        /// <value>
        /// The number of times arrested for drug charges.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForDrugCharges { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for forgery.
        /// </summary>
        /// <value>
        /// The number of times arrested for forgery.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForForgery { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for homicide.
        /// </summary>
        /// <value>
        /// The number of times arrested for homicide.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForHomicide { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for other arrest.
        /// </summary>
        /// <value>
        /// The number of times arrested for other arrest.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForOtherArrest { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for parole probation violation.
        /// </summary>
        /// <value>
        /// The number of times arrested for parole probation violation.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForParoleProbationViolation { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for prostitution.
        /// </summary>
        /// <value>
        /// The number of times arrested for prostitution.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForProstitution { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for rape.
        /// </summary>
        /// <value>
        /// The number of times arrested for rape.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForRape { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for robbery.
        /// </summary>
        /// <value>
        /// The number of times arrested for robbery.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForRobbery { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for shoplifting vandalism.
        /// </summary>
        /// <value>
        /// The number of times arrested for shoplifting vandalism.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForShopliftingVandalism { get; protected set; }

        /// <summary>
        /// Gets the number of times arrested for weapons offense.
        /// </summary>
        /// <value>
        /// The number of times arrested for weapons offense.
        /// </value>
        public virtual uint? NumberOfTimesArrestedForWeaponsOffense { get; protected set; }

        /// <summary>
        /// Gets the number of times charged with disorderly conduct vagrancy intoxication.
        /// </summary>
        /// <value>
        /// The number of times charged with disorderly conduct vagrancy intoxication.
        /// </value>
        public virtual uint? NumberOfTimesChargedWithDisorderlyConductVagrancyIntoxication { get; protected set; }

        /// <summary>
        /// Gets the number of times charged with driving while intoxicated.
        /// </summary>
        /// <value>
        /// The number of times charged with driving while intoxicated.
        /// </value>
        public virtual uint? NumberOfTimesChargedWithDrivingWhileIntoxicated { get; protected set; }

        /// <summary>
        /// Gets the number of times charged with major driving violations.
        /// </summary>
        /// <value>
        /// The number of times charged with major driving violations.
        /// </value>
        public virtual uint? NumberOfTimesChargedWithMajorDrivingViolations { get; protected set; }

        /// <summary>
        /// Gets the number of times convicted.
        /// </summary>
        /// <value>
        /// The number of times convicted.
        /// </value>
        public virtual uint? NumberOfTimesConvicted { get; protected set; }

        /// <summary>
        /// Gets the severity of current legal problems.
        /// </summary>
        /// <value>
        /// The severity of current legal problems.
        /// </value>
        public virtual LikertScale SeverityOfCurrentLegalProblems { get; protected set; }

        /// <summary>
        /// Gets the was visit prompted by criminal justice system.
        /// </summary>
        /// <value>
        /// The was visit prompted by criminal justice system.
        /// </value>
        public virtual bool? WasVisitPromptedByCriminalJusticeSystem { get; protected set; }

        #endregion
    }
}