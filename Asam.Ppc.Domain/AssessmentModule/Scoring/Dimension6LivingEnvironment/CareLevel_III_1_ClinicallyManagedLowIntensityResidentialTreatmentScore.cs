namespace Asam.Ppc.Domain.AssessmentModule.Scoring.Dimension6LivingEnvironment
{
    /// <summary>
    /// CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore class.
    /// </summary>
    public class CareLevel_III_1_ClinicallyManagedLowIntensityResidentialTreatmentScore : CareLevelScoreBase
    {
        /// <summary>
        /// Gets the Living In Moderately High Risk Environment Impact To Recovery. ( D6LIII.1-a )
        /// </summary>
        /// <remarks>
        /// The resident has been living in an environment that is characterized by a moderately high risk of initiation
        ///  or repetition of physical, sexual or emotional abuse, or substance use so endemic that the resident is assessed
        ///  as being unable to achieve or maintain recovery at a less intensive level of care; 
        /// </remarks>
        public bool? LivingInModeratelyHighRiskEnvironmentImpactToRecovery { get; internal set; }

        /// <summary>
        /// Gets the Insufficient Or Inappropriate Social Contacts Or Social Isolation Impacts Recovery. ( D6LIII.1-bc )
        /// </summary>
        /// <remarks>
        ///  The resident lacks social contacts or has inappropriate social contacts that jeopardize his or her recovery,
        ///  or the resident’s social network is characterized by significant social isolation and withdrawal.  The resident’s
        ///  social network includes few friends who are not regular users of alcohol or other drugs, leading recovery goals to
        ///  be assessed as unachievable outside of a 24-hour supportive setting; 
        /// </remarks>
        public bool? InsufficientOrInappropriateSocialContactsOrSocialIsolationImpactsRecovery { get; internal set; }

        /// <summary>
        /// Gets the Continued Exposure To Current School Work Living Needs24 Hour Support. ( D6LIII.1-d )
        /// </summary>
        /// <remarks>
        ///  Continued exposure to the resident’s school, work or living environment makes recovery unlikely, and the resident
        ///  has insufficient resources and skills to maintain an adequate level of functioning outside of a 24-hour supportive environment; 
        /// </remarks>
        public bool? ContinuedExposureToCurrentSchoolWorkLivingNeeds24HourSupport { get; internal set; }

        /// <summary>
        /// Gets the Danger Of Victimization By Another Requires24 Hour Supervision. ( D6LIII.1-e )
        /// </summary>
        /// <remarks>
        /// (e)  The resident is in danger of victimization by another and thus requires 24-hour supervision; 
        /// </remarks>
        public bool? DangerOfVictimizationByAnotherRequires24HourSupervision { get; internal set; }

        /// <summary>
        /// Gets the Able To Cope Limited Periods Time Outside24 Hour Structure. ( D6LIII.1-f )
        /// </summary>
        /// <remarks>
        ///  The resident is able to cope, for limited periods of time, outside the 24-hour structure of a Level III.1 program
        ///  in order to pursue clinical, vocational, educational and community activities.
        /// </remarks>
        public bool? AbleToCopeLimitedPeriodsTimeOutside24HourStructure { get; internal set; }

        /// <summary>
        /// Gets the Has Severe Mental Illness Needs Structure Of Level31 Dual Diagnosis Enhanced. ( D6LIII.1dde )
        /// </summary>
        /// <remarks>
        ///  The resident’s status in Dimension 6 is characterized by severe and persistent mental illness.  He or she may be too ill
        ///  to benefit from skills training to learn to cope with problems in the recovery environment.  Such a resident requires planning
        ///  for assertive community treatment, intensive case management or other community outreach and support services. The resident’s
        ///  living, working, social and/or community environment is not supportive of good mental health functioning.  He or she has insufficient
        ///  resources and skills to deal with this situation.  For example, the resident may be unable to cope with the continuing stress of homelessness,
        ///  or hostile or alcoholic family members, and thus exhibits increasing anxiety and depression.  Such a resident needs the support and structure
        ///  of a Level III.1 Dual Diagnosis Enhanced program to achieve stabilization and prevent further deterioration.
        /// </remarks>
        public bool? HasSevereMentalIllnessNeedsStructureOfLevel31DualDiagnosisEnhanced { get; internal set; }

        /// <summary>
        /// Is Dual Diagnosis Enhanced.
        /// </summary>
        public bool? IsDualDiagnosisEnhanced { get; internal set; }
    }
}
