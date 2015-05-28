namespace Asam.Ppc.Service.Messages.Assessment.GeneralInformation
{
    #region Using Statements

    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using Common;
    using Common.Lookups;

    #endregion

    public class GeneralInformationSectionDto : SectionDtoBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the assessment class.
        /// </summary>
        /// <value>
        /// The assessment class.
        /// </value>
        [Display ( Order = 1 )]
        [Question ( QuestionType.GeneralQuestion )]
        [DataType ( "FooBar" )]
        public LookupDto AssessmentClass { get; set; }

        /// <summary>
        /// Gets or sets the controlled environment other description.
        /// </summary>
        /// <value>
        /// The controlled environment other description.
        /// </value>
        [Display ( Order = 11 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public string ControlledEnvironmentOtherDescription { get; set; }

        /// <summary>
        /// Gets or sets the in penal or chronic care setting recently.
        /// </summary>
        /// <value>
        /// The in penal or chronic care setting recently.
        /// </value>
        [Display ( Order = 12 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public bool? InPenalOrChronicCareSettingRecently { get; set; }

        /// <summary>
        /// Gets or sets the interview circumstances.
        /// </summary>
        /// <value>
        /// The interview circumstances.
        /// </value>
        [Display ( Order = 4 )]
        [Question ( QuestionType.InterviewerQuestion )]
        public LookupDto InterviewCircumstances { get; set; }

        /// <summary>
        /// Gets or sets the interview method.
        /// </summary>
        /// <value>
        /// The interview method.
        /// </value>
        [Display ( Order = 2 )]
        [Question ( QuestionType.GeneralQuestion )]
        public LookupDto InterviewMethod { get; set; }

        /// <summary>
        /// Gets or sets the is residence owned by patient or family.
        /// </summary>
        /// <value>
        /// The is residence owned by patient or family.
        /// </value>
        [Display ( Order = 6 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public bool? IsResidenceOwnedByPatientOrFamily { get; set; }

        /// <summary>
        /// Gets or sets the number of days in controlled environment in past30 days.
        /// </summary>
        /// <value>
        /// The number of days in controlled environment in past30 days.
        /// </value>
        [Display ( Order = 10 )]
        [Question ( QuestionType.InterviewerQuestion )]
        [Range ( 1, 30 )]
        public uint? NumberOfDaysInControlledEnvironmentInPast30Days { get; set; }

        /// <summary>
        /// Gets or sets the number of months at current address.
        /// </summary>
        /// <value>
        /// The number of months at current address.
        /// </value>
        [Display ( Order = 5 )]
        [Question ( QuestionType.ScriptedQuestion )]
        public TimeSpanPicker NumberOfMonthsAtCurrentAddress { get; set; }

        /// <summary>
        /// Gets or sets the patient in controlled environment last30 days.
        /// </summary>
        /// <value>
        /// The patient in controlled environment last30 days.
        /// </value>
        [Display ( Order = 9 )]
        [Question ( QuestionType.ScriptedQuestion )]
        [LookupCategory ( "ControlledEnvironment" )]
        public LookupDto PatientInControlledEnvironmentLast30Days { get; set; }

        /// <summary>
        /// Gets or sets the intake notes.
        /// </summary>
        /// <value>
        /// The intake notes.
        /// </value>
        [Display(Order = 13)]
        public string IntakeNotes { get; set; }

        #endregion
    }
}