using System;
using Asam.Ppc.Service.Messages.Assessment.Completion;
using Asam.Ppc.Service.Messages.Assessment.DrugAndAlcohol;
using Asam.Ppc.Service.Messages.Assessment.EmploymentAndSupport;
using Asam.Ppc.Service.Messages.Assessment.FamilyAndSocialHistory;
using Asam.Ppc.Service.Messages.Assessment.GeneralInformation;
using Asam.Ppc.Service.Messages.Assessment.Legal;
using Asam.Ppc.Service.Messages.Assessment.Medical;
using Asam.Ppc.Service.Messages.Assessment.Psychological;
using Asam.Ppc.Service.Messages.Common;
using Asam.Ppc.Service.Messages.Core;

namespace Asam.Ppc.Service.Messages.Assessment
{
    using Review;

    public class AssessmentDto : KeyedDataTransferObject
    {
        public PatientDto Patient { get; private set; }

        public bool AllVisited { get; private set; }

        public DateTime CreatedTimestamp { get; set; }

        public string CreatedSystemAccount { get; set; }

        public DateTime UpdatedTimestamp { get; set; }

        public string UpdatedSystemAccount { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CompletedTimestamp { get; set; }

        public GeneralInformationSectionDto GeneralInformationSection { get; set; }

        public MedicalSectionDto MedicalSection { get; set; }

        public EmploymentAndSupportSectionDto EmploymentAndSupportSection { get; set; }

        public DrugAndAlcoholSectionDto DrugAndAlcoholSection { get; set; }

        public FamilyAndSocialHistorySectionDto FamilyAndSocialHistorySection { get; set; }

        public LegalSectionDto LegalSection { get; set; }

        public PsychologicalSectionDto PsychologicalSection { get; set; }

        public CompletionSectionDto CompletionSection { get; set; }

        public ReviewSectionDto ReviewSection { get; set; }

    }
}
