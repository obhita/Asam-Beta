using System.Linq;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.EhrModule;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Assessment;

namespace Asam.Ppc.Service.Handlers.Assessment
{
    public class CreateAssessmentRequestHandler : ServiceRequestHandler<CreateAssessmentRequest,CreateAssessmentResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAssessmentMetaDataRepository _assessmentMetaDataRepository;

        public CreateAssessmentRequestHandler (
            IAssessmentRepository assessmentRepository, 
            IPatientRepository patientRepository,
            IAssessmentMetaDataRepository assessmentMetaDataRepository)
        {
            _assessmentRepository = assessmentRepository;
            _patientRepository = patientRepository;
            _assessmentMetaDataRepository = assessmentMetaDataRepository;
        }

        protected override void Handle ( CreateAssessmentRequest request, CreateAssessmentResponse response )
        {
            var patient = _patientRepository.GetByKey ( request.PatientId );
            if (patient == null) return;
            var assessment = new AssessmentFactory().Create(patient);
            if (assessment == null) return;

            _assessmentRepository.MakePersistent(assessment);
            response.AssessmentId = assessment.Key;

            if (request.AssessmentMetaData == null) return;

            var assessmentKey = assessment.Key;
            foreach (var assessmentMetaData in request.AssessmentMetaData.Select(metaData => new AssessmentMetaData(assessmentKey, metaData.Key, metaData.Value)))
            {
                _assessmentMetaDataRepository.MakePersistent(assessmentMetaData);
            }
        }
    }
}
