using System;
using Asam.Ppc.Domain.Scoring.ScoringModule.Diagnosis;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension1Withdrawal;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension2Biomedical;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension3EmotionalBehavioral;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension4ReadinessToChange;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension5RelapsePotential;
using Asam.Ppc.Domain.Scoring.ScoringModule.Dimension6LivingEnvironment;
using Asam.Ppc.Domain.Scoring.ScoringModule.DimensionalAdmissionCriteria;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;
//using Review;

namespace Asam.Ppc.Service.Messages.Assessment
{
    public class AssessmentScoreDto : KeyedDataTransferObject
    {
        public PatientDto Patient { get; set; }

        public long AssessmentKey { get; set; }

        public string UserName { get; set; }

        public DiagnosisResults DiagnosisResults { get; set; }

        //public Dimension1WithdrawalScores Dimension1WithdrawalScores { get; set; }

        //public Dimension2BiomedicalScores Dimension2BiomedicalScores { get; set; }

        //public Dimension3EmotionalBehavioralScores Dimension3EmotionalBehavioralScores { get; set; }

        //public Dimension4ReadinessToChangeScores Dimension4ReadinessToChangeScores { get; set; }

        //public Dimension5RelapsePotentialScores Dimension5RelapsePotentialScores { get; set; }

        //public Dimension6LivingEnvironmentScores Dimension6LivingEnvironmentScores { get; set; }

        //public DimensionalAdmissionCriteriaResults DimensionalAdmissionCriteriaResults { get; set; }

    }
}
