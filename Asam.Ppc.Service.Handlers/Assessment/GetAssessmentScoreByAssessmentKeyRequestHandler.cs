using System.Linq;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.PatientModule;
using Asam.Ppc.Domain.Scoring.ScoringModule;
using Asam.Ppc.Infrastructure.Domain;
using Asam.Ppc.Service.Handlers.Common;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.Core;
using AutoMapper;
using NHibernate;
using Pillar.Domain;

namespace Asam.Ppc.Service.Handlers.Assessment
{
    public class GetAssessmentScoreByAssessmentKeyRequestHandler :
        ServiceRequestHandler<GetAssessmentScoreByAssessmentKeyRequest, GetAssessmentScoreResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentScoreRepository _assessmentScoreRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ISession _session;

        public GetAssessmentScoreByAssessmentKeyRequestHandler(
            IAssessmentRepository assessmentRepository,
            IAssessmentScoreRepository assessmentScoreRepository,
            IPatientRepository patientRepository,
            ISessionProvider sessionProvider
            )
        {
            _assessmentRepository = assessmentRepository;
            _assessmentScoreRepository = assessmentScoreRepository;
            _patientRepository = patientRepository;
            _session = sessionProvider.GetSession();
        }

        protected override void Handle(
            GetAssessmentScoreByAssessmentKeyRequest request,
            GetAssessmentScoreResponse response)
        {
            
            var assessment = _assessmentRepository.GetByKey(request.AssessmentKey);
            if (assessment == null) return;
            var patient = _patientRepository.GetByKey(assessment.Patient.Key);
            var assessmentScore = _assessmentScoreRepository.GetAssessmentScoreByAssessment(assessment);
            if (assessmentScore == null) return;
            assessmentScore = (AssessmentScore)_session.GetSessionImplementation().PersistenceContext.Unproxy(assessmentScore);
            RecurseHelper(assessmentScore);
            response.DataTransferObject = Mapper.Map<AssessmentScore, AssessmentScoreDto>(assessmentScore);
            response.DataTransferObject.Patient = Mapper.Map<Patient, PatientDto>(patient);
        }

        private void RecurseHelper(object entity)
        {
            if (entity == null)
            {
                return;
            }
            var entityProperties = entity.GetType().GetProperties().OrderBy(p => typeof(Entity).IsAssignableFrom(p.PropertyType) ? 1 : 0);
            foreach (var entityProperty in entityProperties)
            {
                if (typeof (Entity).IsAssignableFrom(entityProperty.PropertyType))
                {
                    var revisionBase = entityProperty.GetValue(entity);
                    if (!NHibernateUtil.IsInitialized(revisionBase))
                    {
                        NHibernateUtil.Initialize(revisionBase);
                    }
                    revisionBase = _session.GetSessionImplementation().PersistenceContext.Unproxy(revisionBase);
                    RecurseHelper(revisionBase);
                }
            }
        }
    }
}
