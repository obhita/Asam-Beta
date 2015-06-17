namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    /// <summary>
    /// Drug And Alcohol Section
    /// </summary>
    public class DrugAndAlcoholSection : RevisionBase
    {
        #region Constructors and Destructors

        protected internal DrugAndAlcoholSection()
        {
            UsedSubstances = new UsedSubstances();
            AddictionTreatmentHistory = new AddictionTreatmentHistory();
            AdditionalAddictionAndTreatmentItems = new AdditionalAddictionAndTreatmentItems();
            AlcoholAndDrugInterviewerRating = new AlcoholAndDrugInterviewerRating();
            AlcoholUse = new AlcoholUse();
            BarbiturateUse = new BarbiturateUse();
            CannabisUse = new CannabisUse();
            CinaScale = new CinaScale();
            CiwaScale = new CiwaScale();
            CocaineUse = new CocaineUse();
            DrugConsequences = new DrugConsequences();
            HallucinogenUse = new HallucinogenUse();
            HeroinUse = new HeroinUse();
            InterviewerEvaluation = new InterviewerEvaluation();
            MethadoneUse = new MethadoneUse();
            MultipleSubstanceUsePerDay = new MultipleSubstanceUsePerDay();
            NicotineUse = new NicotineUse();
            OtherOpiateUse = new OtherOpiateUse();
            OpiatesInControlledEnvironment = new OpiatesInControlledEnvironment();
            OpioidMaintenanceTherapy = new OpioidMaintenanceTherapy();
            OtherSedativeUse = new OtherSedativeUse();
            OtherSubstanceUse = new OtherSubstanceUse();
            SolventAndInhalantUse = new SolventAndInhalantUse();
            StimulantUse = new StimulantUse();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the used substances.
        /// </summary>
        /// <value>
        /// The used substances.
        /// </value>
        public virtual UsedSubstances UsedSubstances { get; protected set; }

        /// <summary>
        /// Gets the addiction treatment history.
        /// </summary>
        /// <value>
        /// The addiction treatment history.
        /// </value>
        public virtual AddictionTreatmentHistory AddictionTreatmentHistory { get; protected set; }

        /// <summary>
        /// Gets the additional addiction and treatment items.
        /// </summary>
        /// <value>
        /// The additional addiction and treatment items.
        /// </value>
        public virtual AdditionalAddictionAndTreatmentItems AdditionalAddictionAndTreatmentItems { get; protected set; }

        /// <summary>
        /// Gets the alcohol and drug interviewer rating.
        /// </summary>
        /// <value>
        /// The alcohol and drug interviewer rating.
        /// </value>
        public virtual AlcoholAndDrugInterviewerRating AlcoholAndDrugInterviewerRating { get; protected set; }

        /// <summary>
        /// Gets the alcohol use.
        /// </summary>
        /// <value>
        /// The alcohol use.
        /// </value>
        public virtual AlcoholUse AlcoholUse { get; protected set; }

        /// <summary>
        /// Gets the barbiturate use.
        /// </summary>
        /// <value>
        /// The barbiturate use.
        /// </value>
        public virtual BarbiturateUse BarbiturateUse { get; protected set; }

        /// <summary>
        /// Gets the cannabis use.
        /// </summary>
        /// <value>
        /// The cannabis use.
        /// </value>
        public virtual CannabisUse CannabisUse { get; protected set; }

        /// <summary>
        /// Gets the cina scale.
        /// </summary>
        /// <value>
        /// The cina scale.
        /// </value>
        public virtual CinaScale CinaScale { get; protected set; }

        /// <summary>
        /// Gets the ciwa scale.
        /// </summary>
        /// <value>
        /// The ciwa scale.
        /// </value>
        public virtual CiwaScale CiwaScale { get; protected set; }

        /// <summary>
        /// Gets the cocaine use.
        /// </summary>
        /// <value>
        /// The cocaine use.
        /// </value>
        public virtual CocaineUse CocaineUse { get; protected set; }

        /// <summary>
        /// Gets the drug consequences.
        /// </summary>
        /// <value>
        /// The drug consequences.
        /// </value>
        public virtual DrugConsequences DrugConsequences { get; protected set; }

        /// <summary>
        /// Gets the hallucinogen use.
        /// </summary>
        /// <value>
        /// The hallucinogen use.
        /// </value>
        public virtual HallucinogenUse HallucinogenUse { get; protected set; }

        /// <summary>
        /// Gets the heroin use.
        /// </summary>
        /// <value>
        /// The heroin use.
        /// </value>
        public virtual HeroinUse HeroinUse { get; protected set; }

        /// <summary>
        /// Gets the interviewer evaluation.
        /// </summary>
        /// <value>
        /// The interviewer evaluation.
        /// </value>
        public virtual InterviewerEvaluation InterviewerEvaluation { get; protected set; }

        /// <summary>
        /// Gets the methadone use.
        /// </summary>
        /// <value>
        /// The methadone use.
        /// </value>
        public virtual MethadoneUse MethadoneUse { get; protected set; }

        /// <summary>
        /// Gets the multiple substance use per day.
        /// </summary>
        /// <value>
        /// The multiple substance use per day.
        /// </value>
        public virtual MultipleSubstanceUsePerDay MultipleSubstanceUsePerDay { get; protected set; }

        /// <summary>
        /// Gets the nicotine use.
        /// </summary>
        /// <value>
        /// The nicotine use.
        /// </value>
        public virtual NicotineUse NicotineUse { get; protected set; }

        /// <summary>
        /// Gets the other opiate use.
        /// </summary>
        /// <value>
        /// The other opiate use.
        /// </value>
        public virtual OtherOpiateUse OtherOpiateUse { get; protected set; }

        /// <summary>
        /// Gets the opiates in controlled environment.
        /// </summary>
        /// <value>
        /// The opiates in controlled environment.
        /// </value>
        public virtual OpiatesInControlledEnvironment OpiatesInControlledEnvironment { get; protected set; }

        /// <summary>
        /// Gets the opioid maintenance therapy.
        /// </summary>
        /// <value>
        /// The opioid maintenance therapy.
        /// </value>
        public virtual OpioidMaintenanceTherapy OpioidMaintenanceTherapy { get; protected set; }

        /// <summary>
        /// Gets the other sedative use.
        /// </summary>
        /// <value>
        /// The other sedative use.
        /// </value>
        public virtual OtherSedativeUse OtherSedativeUse { get; protected set; }

        /// <summary>
        /// Gets the other substance use.
        /// </summary>
        /// <value>
        /// The other substance use.
        /// </value>
        public virtual OtherSubstanceUse OtherSubstanceUse { get; protected set; }

        /// <summary>
        /// Gets the solvent and inhalant use.
        /// </summary>
        /// <value>
        /// The solvent and inhalant use.
        /// </value>
        public virtual SolventAndInhalantUse SolventAndInhalantUse { get; protected set; }

        /// <summary>
        /// Gets the stimulant use.
        /// </summary>
        /// <value>
        /// The stimulant use.
        /// </value>
        public virtual StimulantUse StimulantUse { get; protected set; }

        #endregion

    }
}