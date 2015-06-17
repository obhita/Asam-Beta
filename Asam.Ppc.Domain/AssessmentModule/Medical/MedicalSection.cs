using System.Collections.Generic;
using System.Linq;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Primitives;
using Pillar.Common.Utility;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    using Pillar.Domain.Attributes;

    /// <summary>
    /// Medical Section class.
    /// </summary>
    public class MedicalSection : RevisionBase
    {
        private IList<MedicalProblemCategory> _medicalProblems;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalSection" /> class.
        /// </summary>
        protected internal MedicalSection()
        {
            _medicalProblems = new List<MedicalProblemCategory>();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the auditory disturbance level.
        /// </summary>
        /// <value>
        /// The auditory disturbance level.
        /// </value>
        public virtual AuditoryDisturbanceLevel AuditoryDisturbanceLevel { get; protected set; }

        /// <summary>
        /// Gets the blood pressure.
        /// </summary>
        /// <value>
        /// The blood pressure.
        /// </value>
        public virtual BloodPressure BloodPressure { get; protected set; }

        /// <summary>
        /// Gets the chronic medical problems that interfere with life description.
        /// </summary>
        /// <value>
        /// The chronic medical problems that interfere with life description.
        /// </value>
        public virtual string ChronicMedicalProblemsThatInterfereWithLifeDescription { get; protected set; }

        /// <summary>
        /// Gets the description of medical problems in past30 days.
        /// </summary>
        /// <value>
        /// The description of medical problems in past30 days.
        /// </value>
        public virtual string DescriptionOfMedicalProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the description of physical disability pension.
        /// </summary>
        /// <value>
        /// The description of physical disability pension.
        /// </value>
        public virtual string DescriptionOfPhysicalDisabilityPension { get; protected set; }

        /// <summary>
        /// Gets the description of reemergent symptoms.
        /// </summary>
        /// <value>
        /// The description of reemergent symptoms.
        /// </value>
        public virtual string DescriptionOfReemergentSymptoms { get; protected set; }

        /// <summary>
        /// Gets the experienced acute alcohol disulfiram reaction in past24 hours status.
        /// </summary>
        /// <value>
        /// The experienced acute alcohol disulfiram reaction in past24 hours status.
        /// </value>
        public virtual YesNoNotSure ExperiencedAcuteAlcoholDisulfiramReactionInPast24HoursStatus { get; protected set; }

        /// <summary>
        /// Gets the fever of102 degrees or more in past24 hours.
        /// </summary>
        /// <value>
        /// The fever of102 degrees or more in past24 hours.
        /// </value>
        public virtual YesNoNotSure FeverOf102DegreesOrMoreInPast24Hours { get; protected set; }

        /// <summary>
        /// Gets the has chronic medical problems that interfere with life.
        /// </summary>
        /// <value>
        /// The has chronic medical problems that interfere with life.
        /// </value>
        public virtual bool? HasChronicMedicalProblemsThatInterfereWithLife { get; protected set; }

        /// <summary>
        /// Gets the heart rate.
        /// </summary>
        /// <value>
        /// The heart rate.
        /// </value>
        public virtual HeartRate HeartRate { get; protected set; }

        /// <summary>
        /// Gets the high risk pregnancy status.
        /// </summary>
        /// <value>
        /// The high risk pregnancy status.
        /// </value>
        public virtual HighRiskPregnancyStatus HighRiskPregnancyStatus { get; protected set; }

        /// <summary>
        /// Gets the hiv aids medical treatment status.
        /// </summary>
        /// <value>
        /// The hiv aids medical treatment status.
        /// </value>
        public virtual YesNoNotSure HivAidsMedicalTreatmentStatus { get; protected set; }

        /// <summary>
        /// Gets the importance of treatment for medical problems.
        /// </summary>
        /// <value>
        /// The importance of treatment for medical problems.
        /// </value>
        public virtual LikertScale ImportanceOfTreatmentForMedicalProblems { get; protected set; }

        /// <summary>
        /// Gets the interviewer comments.
        /// </summary>
        /// <value>
        /// The interviewer comments.
        /// </value>
        [ColumnLength(2000)]
        public virtual string InterviewerComments { get; protected set; }

        /// <summary>
        /// Gets the interviewer observation of patient agitation level.
        /// </summary>
        /// <value>
        /// The interviewer observation of patient agitation level.
        /// </value>
        public virtual ScaleOf0To7 InterviewerObservationOfPatientAgitationLevel { get; protected set; }

        /// <summary>
        /// Gets the interviewer observation of patient sense of awareness.
        /// </summary>
        /// <value>
        /// The interviewer observation of patient sense of awareness.
        /// </value>
        public virtual SenseOfAwareness InterviewerObservationOfPatientSenseOfAwareness { get; protected set; }

        /// <summary>
        /// Gets the interviewer rating of patient need for medical treatment.
        /// </summary>
        /// <value>
        /// The interviewer rating of patient need for medical treatment.
        /// </value>
        public virtual ScaleOf0To8 InterviewerRatingOfPatientNeedForMedicalTreatment { get; protected set; }

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
        /// Gets the is taking prescription medicine.
        /// </summary>
        /// <value>
        /// The is taking prescription medicine.
        /// </value>
        public virtual bool? IsTakingPrescriptionMedicine { get; protected set; }

        /// <summary>
        /// Gets the level of concern in past30 days about medical problems.
        /// </summary>
        /// <value>
        /// The level of concern in past30 days about medical problems.
        /// </value>
        public virtual LikertScale LevelOfConcernInPast30DaysAboutMedicalProblems { get; protected set; }

        /// <summary>
        /// Gets the lost consciousness from head trauma in past24 hours.
        /// </summary>
        /// <value>
        /// The lost consciousness from head trauma in past24 hours.
        /// </value>
        public virtual YesNoNotSure LostConsciousnessFromHeadTraumaInPast24Hours { get; protected set; }

        /// <summary>
        /// Gets the may require inpatient acute pancreatitis treatment.
        /// </summary>
        /// <value>
        /// The may require inpatient acute pancreatitis treatment.
        /// </value>
        public virtual YesNoNotSure MayRequireInpatientAcutePancreatitisTreatment { get; protected set; }

        /// <summary>
        /// Gets the may require inpatient gastrointestinal bleeding treatment.
        /// </summary>
        /// <value>
        /// The may require inpatient gastrointestinal bleeding treatment.
        /// </value>
        public virtual YesNoNotSure MayRequireInpatientGastrointestinalBleedingTreatment { get; protected set; }

        /// <summary>
        /// Gets the may require inpatient liver treatment.
        /// </summary>
        /// <value>
        /// The may require inpatient liver treatment.
        /// </value>
        public virtual YesNoNotSure MayRequireInpatientLiverTreatment { get; protected set; }

        /// <summary>
        /// Gets the medical problems.
        /// </summary>
        /// <value>
        /// The medical problems.
        /// </value>
        public virtual IEnumerable<MedicalProblemCategory> MedicalProblems
        {
            get { return _medicalProblems; }

            protected set
            {
                _medicalProblems.Clear();
                if (value != null)
                {
                    _medicalProblems.AddRange(value);
                }
            }
        }

        /// <summary>
        /// Gets the medical problem description.
        /// </summary>
        /// <value>
        /// The medical problem description.
        /// </value>
        public virtual string MedicalProblemDescription { get; protected set; }

        /// <summary>
        /// Gets the medical problem that would complicate detoxification status.
        /// </summary>
        /// <value>
        /// The medical problem that would complicate detoxification status.
        /// </value>
        public virtual YesNoNotSure MedicalProblemThatWouldComplicateDetoxificationStatus { get; protected set; }

        /// <summary>
        /// Gets the mobility problems may affect treatment attendance.
        /// </summary>
        /// <value>
        /// The mobility problems may affect treatment attendance.
        /// </value>
        public virtual YesNoNotSure MobilityProblemsMayAffectTreatmentAttendance { get; protected set; }

        /// <summary>
        /// Gets the months since last hospitalization for physical problem.
        /// </summary>
        /// <value>
        /// The months since last hospitalization for physical problem.
        /// </value>
        public virtual uint? MonthsSinceLastHospitalizationForPhysicalProblem { get; protected set; }

        /// <summary>
        /// Gets the multiple seizures in past24 hours.
        /// </summary>
        /// <value>
        /// The multiple seizures in past24 hours.
        /// </value>
        public virtual YesNoNotSure MultipleSeizuresInPast24Hours { get; protected set; }

        /// <summary>
        /// Gets the multiple serious medical problems exist.
        /// </summary>
        /// <value>
        /// The multiple serious medical problems exist.
        /// </value>
        public virtual YesNoNotSure MultipleSeriousMedicalProblemsExist { get; protected set; }

        /// <summary>
        /// Gets the need for medical or physical rehabilitation.
        /// </summary>
        /// <value>
        /// The need for medical or physical rehabilitation.
        /// </value>
        public virtual TreatmentNeedLevel NeedForMedicalOrPhysicalRehabilitation { get; protected set; }

        /// <summary>
        /// Gets the number of days with medical problems in past30 days.
        /// </summary>
        /// <value>
        /// The number of days with medical problems in past30 days.
        /// </value>
        public virtual uint? NumberOfDaysWithMedicalProblemsInPast30Days { get; protected set; }

        /// <summary>
        /// Gets the physical healths effect on substance problems.
        /// </summary>
        /// <value>
        /// The physical healths effect on substance problems.
        /// </value>
        public virtual PhysicalHealthsEffectOnSubstanceProblems PhysicalHealthsEffectOnSubstanceProblems { get; protected set; }

        /// <summary>
        /// Gets the pregnant status.
        /// </summary>
        /// <value>
        /// The pregnant status.
        /// </value>
        public virtual YesNoNotSure PregnantStatus { get; protected set; }

        /// <summary>
        /// Gets the prescription medicine description.
        /// </summary>
        /// <value>
        /// The prescription medicine description.
        /// </value>
        public virtual string PrescriptionMedicineDescription { get; protected set; }

        /// <summary>
        /// Gets the receives pension for physical disability.
        /// </summary>
        /// <value>
        /// The receives pension for physical disability.
        /// </value>
        public virtual bool? ReceivesPensionForPhysicalDisability { get; protected set; }

        /// <summary>
        /// Gets the requires inpatient cardiac monitoring.
        /// </summary>
        /// <value>
        /// The requires inpatient cardiac monitoring.
        /// </value>
        public virtual YesNoNotSure RequiresInpatientCardiacMonitoring { get; protected set; }

        /// <summary>
        /// Gets the requires medical monitoring for reemergence of symptoms.
        /// </summary>
        /// <value>
        /// The requires medical monitoring for reemergence of symptoms.
        /// </value>
        public virtual bool? RequiresMedicalMonitoringForReemergenceOfSymptoms { get; protected set; }

        /// <summary>
        /// Gets the seizure in past24 hours.
        /// </summary>
        /// <value>
        /// The seizure in past24 hours.
        /// </value>
        public virtual YesNoNotSure SeizureInPast24Hours { get; protected set; }

        /// <summary>
        /// Gets the sexually transmitted disease status.
        /// </summary>
        /// <value>
        /// The sexually transmitted disease status.
        /// </value>
        public virtual YesNoNotSure SexuallyTransmittedDiseaseStatus { get; protected set; }

        /// <summary>
        /// Gets the signs of intoxication exist.
        /// </summary>
        /// <value>
        /// The signs of intoxication exist.
        /// </value>
        public virtual YesNoNotSure SignsOfIntoxicationExist { get; protected set; }

        /// <summary>
        /// Gets the signs of toxic psychosis exist.
        /// </summary>
        /// <value>
        /// The signs of toxic psychosis exist.
        /// </value>
        public virtual YesNoNotSure SignsOfToxicPsychosisExist { get; protected set; }

        /// <summary>
        /// Gets the suffered head trauma in past48 hours.
        /// </summary>
        /// <value>
        /// The suffered head trauma in past48 hours.
        /// </value>
        public virtual YesNoNotSure SufferedHeadTraumaInPast48Hours { get; protected set; }

        /// <summary>
        /// Gets the suffered serious impairment from overdose in past24 hours.
        /// </summary>
        /// <value>
        /// The suffered serious impairment from overdose in past24 hours.
        /// </value>
        public virtual YesNoNotSure SufferedSeriousImpairmentFromOverdoseInPast24Hours { get; protected set; }

        /// <summary>
        /// Gets the times hospitalized for medical problems.
        /// </summary>
        /// <value>
        /// The times hospitalized for medical problems.
        /// </value>
        public virtual uint? TimesHospitalizedForMedicalProblems { get; protected set; }

        /// <summary>
        /// Gets the tuberculosis infection status.
        /// </summary>
        /// <value>
        /// The tuberculosis infection status.
        /// </value>
        public virtual TuberculosisInfectionStatus TuberculosisInfectionStatus { get; protected set; }

        /// <summary>
        /// Gets the unsteadiness or loss of balance.
        /// </summary>
        /// <value>
        /// The unsteadiness or loss of balance.
        /// </value>
        public virtual YesNoNotSure UnsteadinessOrLossOfBalance { get; protected set; }

        /// <summary>
        /// Gets the visual disturbance level.
        /// </summary>
        /// <value>
        /// The visual disturbance level.
        /// </value>
        public virtual VisualDisturbanceLevel VisualDisturbanceLevel { get; protected set; }

        #endregion
    }
}