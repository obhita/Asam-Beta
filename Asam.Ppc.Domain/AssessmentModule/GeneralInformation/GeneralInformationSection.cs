namespace Asam.Ppc.Domain.AssessmentModule.GeneralInformation
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// General information section.
    /// </summary>
    public class GeneralInformationSection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralInformationSection" /> class.
        /// </summary>
        protected internal GeneralInformationSection()
        {
        }
        
        #endregion

        #region public Properties

        //Required
        /// <summary>
        /// Gets the assessment class.
        /// </summary>
        /// <value>
        /// The assessment class.
        /// </value>
        public virtual AssessmentClass AssessmentClass { get; protected set; }

        /// <summary>
        /// Gets the patient in controlled environment last30 days.
        /// </summary>
        /// <value>
        /// The patient in controlled environment last30 days.
        /// </value>
        public virtual ControlledEnvironment PatientInControlledEnvironmentLast30Days { get; protected set; }

        /// <summary>
        /// Gets the in penal or chronic care setting recently.
        /// </summary>
        /// <value>
        /// The in penal or chronic care setting recently.
        /// </value>
        public virtual bool? InPenalOrChronicCareSettingRecently { get; protected set; }

        /// <summary>
        /// Gets the interview circumstances.
        /// </summary>
        /// <value>
        /// The interview circumstances.
        /// </value>
        public virtual InterviewCircumstances InterviewCircumstances { get; protected set; }

        //Required
        /// <summary>
        /// Gets the interview method.
        /// </summary>
        /// <value>
        /// The interview method.
        /// </value>
        public virtual InterviewMethod InterviewMethod { get; protected set; }

        /// <summary>
        /// Gets the is residence owned by patient or family.
        /// </summary>
        /// <value>
        /// The is residence owned by patient or family.
        /// </value>
        public virtual bool? IsResidenceOwnedByPatientOrFamily { get; protected set; }

        /// <summary>
        /// Gets the number of days in controlled environment in past30 days.
        /// </summary>
        /// <value>
        /// The number of days in controlled environment in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysInControlledEnvironmentInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the number of months at current address.
        /// </summary>
        /// <value>
        /// The number of months at current address.
        /// </value>
        public virtual uint? NumberOfMonthsAtCurrentAddress { get; protected set; }

        /// <summary>
        /// Gets the controlled environment other description.
        /// </summary>
        /// <value>
        /// The controlled environment other description.
        /// </value>
        public virtual string ControlledEnvironmentOtherDescription { get; protected set; }

        /// <summary>
        /// Gets or sets the intake notes.
        /// </summary>
        /// <value>
        /// The intake notes.
        /// </value>
        [ColumnLength(2000)]
        public virtual string IntakeNotes { get; protected set; }

        #endregion

        #region public virtual Methods

        /// <summary>
        /// Revises the assessment class.
        /// </summary>
        /// <param name="assessmentClass">The assessment class.</param>
        public virtual void ReviseAssessmentClass(AssessmentClass assessmentClass)
        {
            AssessmentClass = assessmentClass;
        }

        /// <summary>
        /// Revises the patient in controlled environment last thirty days.
        /// </summary>
        /// <param name="controlledEnvironment">The controlled environment.</param>
        public virtual void RevisePatientInControlledEnvironmentLastThirtyDays(
            ControlledEnvironment controlledEnvironment)
        {
            PatientInControlledEnvironmentLast30Days = controlledEnvironment;
        }

        /// <summary>
        /// Revises the in penal or chronic care setting recently.
        /// </summary>
        /// <param name="inPenalOrChronicCareSettingRecently">The in penal or chronic care setting recently.</param>
        public virtual void ReviseInPenalOrChronicCareSettingRecently(bool? inPenalOrChronicCareSettingRecently)
        {
            InPenalOrChronicCareSettingRecently = inPenalOrChronicCareSettingRecently;
        }

        /// <summary>
        /// Revises the interview circumstances.
        /// </summary>
        /// <param name="interviewCircumstances">The interview circumstances.</param>
        public virtual void ReviseInterviewCircumstances(InterviewCircumstances interviewCircumstances)
        {
            InterviewCircumstances = interviewCircumstances;
        }

        /// <summary>
        /// Revises the interview method.
        /// </summary>
        /// <param name="interviewMethod">The interview method.</param>
        public virtual void ReviseInterviewMethod(InterviewMethod interviewMethod)
        {
            InterviewMethod = interviewMethod;
        }

        /// <summary>
        /// Revises the is residence owned by patient or family.
        /// </summary>
        /// <param name="isResidenceOwnedByPatientOrFamily">The is residence owned by patient or family.</param>
        public virtual void ReviseIsResidenceOwnedByPatientOrFamily(bool? isResidenceOwnedByPatientOrFamily)
        {
            IsResidenceOwnedByPatientOrFamily = isResidenceOwnedByPatientOrFamily;
        }

        /// <summary>
        /// Revises the number of days in controlled environment in past30 days.
        /// </summary>
        /// <param name="numberOfDaysInControlledEnvironmentInPast30Days">The number of days in controlled environment in past30 days.</param>
        public virtual void ReviseNumberOfDaysInControlledEnvironmentInPast30Days(
            uint? numberOfDaysInControlledEnvironmentInPast30Days)
        {
            NumberOfDaysInControlledEnvironmentInPast30Days = numberOfDaysInControlledEnvironmentInPast30Days;
        }

        /// <summary>
        /// Revises the number of months at current address.
        /// </summary>
        /// <param name="numberOfMonthsAtCurrentAddress">The number of months at current address.</param>
        public virtual void ReviseNumberOfMonthsAtCurrentAddress(uint? numberOfMonthsAtCurrentAddress)
        {
            NumberOfMonthsAtCurrentAddress = numberOfMonthsAtCurrentAddress;
        }

        /// <summary>
        /// Revises the controlled environment other description.
        /// </summary>
        /// <param name="controlledEnvironmentOtherDescription">The controlled environment other description.</param>
        public virtual void ReviseControlledEnvironmentOtherDescription(string controlledEnvironmentOtherDescription)
        {
            ControlledEnvironmentOtherDescription = controlledEnvironmentOtherDescription;
        }

        #endregion
    }
}