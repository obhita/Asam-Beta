namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Domain.OrganizationModule;
    using Domain.PatientModule;
    using Messages.Common;
    using Messages.Organization;
    using NLog;

    #endregion

    /// <summary>
    ///     Handler for adding patient to team.
    /// </summary>
    public class AddPatientToTeamRequestHandler : ServiceRequestHandler<AddDtoRequest<TeamPatientDto>, DtoResponse<TeamPatientDto>>
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Fields

        private readonly ITeamRepository _teamRepository;
        private readonly IPatientRepository _patientRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddPatientToTeamRequestHandler" /> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        /// <param name="patientRepository"></param>
        public AddPatientToTeamRequestHandler ( ITeamRepository teamRepository, IPatientRepository patientRepository )
        {
            _teamRepository = teamRepository;
            _patientRepository = patientRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( AddDtoRequest<TeamPatientDto> request, DtoResponse<TeamPatientDto> response )
        {
            var team = _teamRepository.GetByKey ( request.AggregateKey );
            var patient = _patientRepository.GetByKey(request.DataTransferObject.Key);
            response.DataTransferObject = request.DataTransferObject;
            if ( patient != null )
            {
                team.AddPatient ( patient );
            }
            else
            {
                Logger.Error ( string.Format("Tried adding invalid patient {0} to team {1}", request.DataTransferObject.Key, team.Key) );
                response.DataTransferObject.AddDataErrorInfo ( new DataErrorInfo ( "Invalid patient key.", ErrorLevel.Error ) );
            }
        }

        #endregion
    }
}