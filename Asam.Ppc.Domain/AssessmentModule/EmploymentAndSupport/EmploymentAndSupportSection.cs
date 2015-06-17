using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.CommonModule.ValueObjects;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Employment and support section.
    /// </summary>
    public class EmploymentAndSupportSection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentAndSupportSection" /> class.
        /// </summary>
        protected internal EmploymentAndSupportSection()
        {
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the amount of money in past30 days from employment.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from employment.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromEmployment { get; protected set; }

        /// <summary>
        /// Gets the amount of money in past30 days from illegal means.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from illegal means.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromIllegalMeans { get; protected set; }

        /// <summary>
        /// Gets the amount of money in past30 days from mate family friends.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from mate family friends.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromMateFamilyFriends { get; protected set; }

        /// <summary>
        /// Gets the amount of money in past30 days from pension or benefits.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from pension or benefits.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromPensionOrBenefits { get; protected set; }

        /// <summary>
        /// Gets the amount of money in past30 days from public assistance.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from public assistance.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromPublicAssistance { get; protected set; }

        /// <summary>
        /// Gets the amount of money in past30 days from unemployment.
        /// </summary>
        /// <value>
        /// The amount of money in past30 days from unemployment.
        /// </value>
        public virtual Money AmountOfMoneyInPast30DaysFromUnemployment { get; protected set; }

        /// <summary>
        /// Gets the concern about employment problems in past30 days.
        /// </summary>
        /// <value>
        /// The concern about employment problems in past30 days.
        /// </value>
        public virtual LikertScale ConcernAboutEmploymentProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the education in months.
        /// </summary>
        /// <value>
        /// The education in months.
        /// </value>
        public virtual uint? EducationInMonths { get; protected set; }

        /// <summary>
        /// Gets the employment pattern in past3 years.
        /// </summary>
        /// <value>
        /// The employment pattern in past3 years.
        /// </value>
        public virtual EmploymentPattern EmploymentPatternInPast3Years { get; protected set; }

        /// <summary>
        /// Gets the has automobile available for use.
        /// </summary>
        /// <value>
        /// The has automobile available for use.
        /// </value>
        public virtual bool? HasAutomobileAvailableForUse { get; protected set; }

        /// <summary>
        /// Gets the has professional trade or skill.
        /// </summary>
        /// <value>
        /// The has professional trade or skill.
        /// </value>
        public virtual bool? HasProfessionalTradeOrSkill { get; protected set; }

        /// <summary>
        /// Gets the has valid drivers license.
        /// </summary>
        /// <value>
        /// The has valid drivers license.
        /// </value>
        public virtual bool? HasValidDriversLicense { get; protected set; }

        /// <summary>
        /// Gets the importance of counseling for employment problems.
        /// </summary>
        /// <value>
        /// The importance of counseling for employment problems.
        /// </value>
        public virtual LikertScale ImportanceOfCounselingForEmploymentProblems { get; protected set; }

        /// <summary>
        /// Gets the interviewer comments.
        /// </summary>
        /// <value>
        /// The interviewer comments.
        /// </value>
        [ColumnLength(2000)]
        public virtual string InterviewerComments { get; protected set; }

        /// <summary>
        /// Gets the interviewer rating patient need for employment counseling.
        /// </summary>
        /// <value>
        /// The interviewer rating patient need for employment counseling.
        /// </value>
        public virtual ScaleOf0To9 InterviewerRatingPatientNeedForEmploymentCounseling { get; protected set; }

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
        /// Gets the longest time without job in months.
        /// </summary>
        /// <value>
        /// The longest time without job in months.
        /// </value>
        public virtual uint? LongestTimeWithoutJobInMonths { get; protected set; }

        /// <summary>
        /// Gets the number of days with employment problems in past30 days.
        /// </summary>
        /// <value>
        /// The number of days with employment problems in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysWithEmploymentProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the number of days working in past30 days.
        /// </summary>
        /// <value>
        /// The number of days working in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysWorkingInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the number of dependents.
        /// </summary>
        /// <value>
        /// The number of dependents.
        /// </value>
        public virtual uint? NumberOfDependents { get; protected set; }

        /// <summary>
        /// Gets the professional trade or skill description.
        /// </summary>
        /// <value>
        /// The professional trade or skill description.
        /// </value>
        public virtual string ProfessionalTradeOrSkillDescription { get; protected set; }

        /// <summary>
        /// Gets the receives financial support from other person.
        /// </summary>
        /// <value>
        /// The receives financial support from other person.
        /// </value>
        public virtual bool? ReceivesFinancialSupportFromOtherPerson { get; protected set; }

        /// <summary>
        /// Gets the receives majority of financial support from other person.
        /// </summary>
        /// <value>
        /// The receives majority of financial support from other person.
        /// </value>
        public virtual bool? ReceivesMajorityOfFinancialSupportFromOtherPerson { get; protected set; }

        /// <summary>
        /// Gets the training or technical education in months.
        /// </summary>
        /// <value>
        /// The training or technical education in months.
        /// </value>
        public virtual uint? TrainingOrTechnicalEducationInMonths { get; protected set; }

        /// <summary>
        /// Gets the usual or last occupation description.
        /// </summary>
        /// <value>
        /// The usual or last occupation description.
        /// </value>
        public virtual string UsualOrLastOccupationDescription { get; protected set; }

        /// <summary>
        /// Gets the work or school affect on recovery.
        /// </summary>
        /// <value>
        /// The work or school affect on recovery.
        /// </value>
        public virtual WorkOrSchoolAffectOnRecovery WorkOrSchoolAffectOnRecovery { get; protected set; }

        #endregion
    }
}