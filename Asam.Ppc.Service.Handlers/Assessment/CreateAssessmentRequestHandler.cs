using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Assessment;

namespace Asam.Ppc.Service.Handlers.Assessment
{
    public class CreateAssessmentRequestHandler : ServiceRequestHandler<CreateAssessmentRequest,CreateAssessmentResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IPatientRepository _patientRepository;

        public CreateAssessmentRequestHandler (IAssessmentRepository assessmentRepository, IPatientRepository patientRepository)
        {
            _assessmentRepository = assessmentRepository;
            _patientRepository = patientRepository;
        }

        protected override void Handle ( CreateAssessmentRequest request, CreateAssessmentResponse response )
        {
            var patient = _patientRepository.GetByKey ( request.PatientId );

            if (patient != null)
            {
                var assessment = new AssessmentFactory().Create(patient);
                if (assessment != null)
                {
                    _assessmentRepository.MakePersistent(assessment);
                    response.AssessmentId = assessment.Key;
                }
            }
        }
    }
}
