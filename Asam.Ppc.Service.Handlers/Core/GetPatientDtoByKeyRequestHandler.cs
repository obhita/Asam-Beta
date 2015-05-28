namespace Asam.Ppc.Service.Handlers.Core
{
    #region Using Statements

    using Common;
    using Domain.PatientModule;
    using Messages.Core;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Handler for getting patient dto by key.
    /// </summary>
    public class GetPatientDtoByKeyRequestHandler : ServiceRequestHandler<GetPatientDtoByKeyRequest, GetPatientDtoResponse>
    {
        #region Fields

        private readonly IPatientRepository _patientRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPatientDtoByKeyRequestHandler" /> class.
        /// </summary>
        /// <param name="patientRepository">The patient repository.</param>
        public GetPatientDtoByKeyRequestHandler ( IPatientRepository patientRepository )
        {
            _patientRepository = patientRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetPatientDtoByKeyRequest request, GetPatientDtoResponse response )
        {
            var patient = _patientRepository.GetByKey ( request.PatientKey );

            if ( patient != null )
            {
                response.DataTransferObject = Mapper.Map<Patient, PatientDto> ( patient );
            }
        }

        #endregion
    }
}