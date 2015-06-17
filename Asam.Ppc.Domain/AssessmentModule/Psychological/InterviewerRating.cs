using System.Collections.Generic;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Interviewer rating related information.
    /// </summary>
    public class InterviewerRating : RevisionBase
    {
        private IList<PsychiatricDiagnosis> _activePsychiatricDiagnosesOtherThanSubstanceAbuse;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InterviewerRating" /> class.
        /// </summary>
        protected internal InterviewerRating()
        {
            _activePsychiatricDiagnosesOtherThanSubstanceAbuse = new List<PsychiatricDiagnosis>();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the active psychiatric diagnoses other than substance abuse.
        /// </summary>
        /// <value>
        /// The active psychiatric diagnoses other than substance abuse.
        /// </value>
        public virtual IEnumerable<PsychiatricDiagnosis> ActivePsychiatricDiagnosesOtherThanSubstanceAbuse
        {
            get { return _activePsychiatricDiagnosesOtherThanSubstanceAbuse; }

            protected set
            {
                _activePsychiatricDiagnosesOtherThanSubstanceAbuse.Clear();
                if (value != null)
                {
                    _activePsychiatricDiagnosesOtherThanSubstanceAbuse.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the addiction only treatment accessible to patient.
        /// </summary>
        /// <value>
        /// The addiction only treatment accessible to patient.
        /// </value>
        public virtual YesNoNotSure AddictionOnlyTreatmentAccessibleToPatient { get; protected set; }

        /// <summary>
        /// Gets the appearance of anxiety nervousness.
        /// </summary>
        /// <value>
        /// The appearance of anxiety nervousness.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfAnxietyNervousness { get; protected set; }

        /// <summary>
        /// Gets the appearance of depression withdrawal.
        /// </summary>
        /// <value>
        /// The appearance of depression withdrawal.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfDepressionWithdrawal { get; protected set; }

        /// <summary>
        /// Gets the appearance of fluctuating orientation in last24 hours.
        /// </summary>
        /// <value>
        /// The appearance of fluctuating orientation in last24 hours.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfFluctuatingOrientationInLast24Hours { get; protected set; }

        /// <summary>
        /// Gets the appearance of hostility.
        /// </summary>
        /// <value>
        /// The appearance of hostility.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfHostility { get; protected set; }

        /// <summary>
        /// Gets the appearance of lethargy.
        /// </summary>
        /// <value>
        /// The appearance of lethargy.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfLethargy { get; protected set; }

        /// <summary>
        /// Gets the appearance of paranoia or impaired thinking.
        /// </summary>
        /// <value>
        /// The appearance of paranoia or impaired thinking.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfParanoiaOrImpairedThinking { get; protected set; }

        /// <summary>
        /// Gets the appearance of speech impairment bad posture.
        /// </summary>
        /// <value>
        /// The appearance of speech impairment bad posture.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfSpeechImpairmentBadPosture { get; protected set; }

        /// <summary>
        /// Gets the appearance of trouble concentrating or remembering.
        /// </summary>
        /// <value>
        /// The appearance of trouble concentrating or remembering.
        /// </value>
        public virtual ScaleOf0To8 AppearanceOfTroubleConcentratingOrRemembering { get; protected set; }

        /// <summary>
        /// Gets the appearanceof agitation.
        /// </summary>
        /// <value>
        /// The appearanceof agitation.
        /// </value>
        public virtual ScaleOf0To8 AppearanceofAgitation { get; protected set; }

        /// <summary>
        /// Gets the current behavior inconsistent with self care.
        /// </summary>
        /// <value>
        /// The current behavior inconsistent with self care.
        /// </value>
        public virtual YesNoNotSure CurrentBehaviorInconsistentWithSelfCare { get; protected set; }

        /// <summary>
        /// Gets the current problem behaviors require continuous interventions.
        /// </summary>
        /// <value>
        /// The current problem behaviors require continuous interventions.
        /// </value>
        public virtual YesNoNotSure CurrentProblemBehaviorsRequireContinuousInterventions { get; protected set; }

        /// <summary>
        /// Gets the demonstrating danger to self or others.
        /// </summary>
        /// <value>
        /// The demonstrating danger to self or others.
        /// </value>
        public virtual ScaleOf0To8 DemonstratingDangerToSelfOrOthers { get; protected set; }

        /// <summary>
        /// Gets the does patient carry psychiatric diagnosis.
        /// </summary>
        /// <value>
        /// The does patient carry psychiatric diagnosis.
        /// </value>
        public virtual PatientCarriesPsychiatricDiagnosis DoesPatientCarryPsychiatricDiagnosis { get; protected set; }

        /// <summary>
        /// Gets the evidence of chronic organic mental disability.
        /// </summary>
        /// <value>
        /// The evidence of chronic organic mental disability.
        /// </value>
        public virtual YesNoNotSure EvidenceOfChronicOrganicMentalDisability { get; protected set; }

        /// <summary>
        /// Gets the global assessment of functioning score.
        /// </summary>
        /// <value>
        /// The global assessment of functioning score.
        /// </value>
        public virtual uint? GlobalAssessmentOfFunctioningScore { get; protected set; }

        /// <summary>
        /// Gets the has suicidal thoughts.
        /// </summary>
        /// <value>
        /// The has suicidal thoughts.
        /// </value>
        public virtual ScaleOf0To8 HasSuicidalThoughts { get; protected set; }

        /// <summary>
        /// Gets the indicating risk of harm to others.
        /// </summary>
        /// <value>
        /// The indicating risk of harm to others.
        /// </value>
        public virtual ScaleOf0To8 IndicatingRiskOfHarmToOthers { get; protected set; }

        /// <summary>
        /// Gets the indicating risk of harm to self or victimization by others.
        /// </summary>
        /// <value>
        /// The indicating risk of harm to self or victimization by others.
        /// </value>
        public virtual ScaleOf0To8 IndicatingRiskOfHarmToSelfOrVictimizationByOthers { get; protected set; }

        /// <summary>
        /// Gets the intensive case management accessible to patient.
        /// </summary>
        /// <value>
        /// The intensive case management accessible to patient.
        /// </value>
        public virtual YesNoNotSure IntensiveCaseManagementAccessibleToPatient { get; protected set; }

        /// <summary>
        /// Gets the interviewer comments.
        /// </summary>
        /// <value>
        /// The interviewer comments.
        /// </value>
        [ColumnLength(2000)]
        public virtual string InterviewerComments { get; protected set; }

        /// <summary>
        /// Gets the is patient misrepresenting information.
        /// </summary>
        /// <value>
        /// The is patient misrepresenting information.
        /// </value>
        public virtual YesNoNotSure IsPatientMisrepresentingInformation { get; protected set; }

        /// <summary>
        /// Gets the is patient unable to understand.
        /// </summary>
        /// <value>
        /// The is patient unable to understand.
        /// </value>
        public virtual YesNoNotSure IsPatientUnableToUnderstand { get; protected set; }

        /// <summary>
        /// Gets the level of supervision needed for protection from self harm.
        /// </summary>
        /// <value>
        /// The level of supervision needed for protection from self harm.
        /// </value>
        public virtual ScaleOf0To8 LevelOfSupervisionNeededForProtectionFromSelfHarm { get; protected set; }

        /// <summary>
        /// Gets the likelihood of recurrence of psychiatric decompensation.
        /// </summary>
        /// <value>
        /// The likelihood of recurrence of psychiatric decompensation.
        /// </value>
        public virtual ScaleOf0To8 LikelihoodOfRecurrenceOfPsychiatricDecompensation { get; protected set; }

        /// <summary>
        /// Gets the limited in ability to contract for safety if risk of harm to self or others.
        /// </summary>
        /// <value>
        /// The limited in ability to contract for safety if risk of harm to self or others.
        /// </value>
        public virtual ScaleOf0To8 LimitedInAbilityToContractForSafetyIfRiskOfHarmToSelfOrOthers { get; protected set; }

        /// <summary>
        /// Gets the patient able to safely access needed resources.
        /// </summary>
        /// <value>
        /// The patient able to safely access needed resources.
        /// </value>
        public virtual bool? PatientAbleToSafelyAccessNeededResources { get; protected set; }

        /// <summary>
        /// Gets the patient need for psychiatric psychological treatment rating.
        /// </summary>
        /// <value>
        /// The patient need for psychiatric psychological treatment rating.
        /// </value>
        public virtual ScaleOf0To8 PatientNeedForPsychiatricPsychologicalTreatmentRating { get; protected set; }

        /// <summary>
        /// Gets the patient requires24 hour controlled supervised environment.
        /// </summary>
        /// <value>
        /// The patient requires24 hour controlled supervised environment.
        /// </value>
        public virtual YesNoNotSure PatientRequires24HourControlledSupervisedEnvironment { get; protected set; }

        /// <summary>
        /// Gets the psychiatric evaluation and services accessible to patient.
        /// </summary>
        /// <value>
        /// The psychiatric evaluation and services accessible to patient.
        /// </value>
        public virtual YesNoNotSure PsychiatricEvaluationAndServicesAccessibleToPatient { get; protected set; }

        /// <summary>
        /// Gets the risk of harm to self or others is higher with substance use.
        /// </summary>
        /// <value>
        /// The risk of harm to self or others is higher with substance use.
        /// </value>
        public virtual RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse { get; protected set; }

        #endregion
    }
}