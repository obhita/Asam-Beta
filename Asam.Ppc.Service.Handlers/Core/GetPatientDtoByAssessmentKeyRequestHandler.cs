namespace Asam.Ppc.Service.Handlers.Core
{
    #region Using Statements

    using Common;
    using Domain.AssessmentModule;
    using Domain.PatientModule;
    using Messages.Core;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Handler for getting patient dto by assessment key.
    /// </summary>
    public class GetPatientDtoByAssessmentKeyRequestHandler : ServiceRequestHandler<GetPatientDtoByAssessmentKeyRequest, GetPatientDtoResponse>
    {
        #region Fields

        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IPatientRepository _patientRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPatientDtoByAssessmentKeyRequestHandler" /> class.
        /// </summary>
        /// <param name="assessmentRepository">The assessment repository.</param>
        /// <param name="patientRepository">The patient repository.</param>
        public GetPatientDtoByAssessmentKeyRequestHandler ( IAssessmentRepository assessmentRepository, IPatientRepository patientRepository )
        {
            _assessmentRepository = assessmentRepository;
            _patientRepository = patientRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetPatientDtoByAssessmentKeyRequest request, GetPatientDtoResponse response )
        {
            var assessment = _assessmentRepository.GetByKey ( request.AssessmentKey );
            if ( assessment != null )
            {
                var patient = _patientRepository.GetByKey ( assessment.Patient.Key );
                if ( patient != null )
                {
                    response.DataTransferObject = Mapper.Map<Patient, PatientDto> ( patient );
                }
            }
        }

        #endregion
    }
}