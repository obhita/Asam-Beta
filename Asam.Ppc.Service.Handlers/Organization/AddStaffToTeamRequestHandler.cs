namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using NLog;

    #endregion

    /// <summary>
    ///     Handler for adding staff to team.
    /// </summary>
    public class AddStaffToTeamRequestHandler : ServiceRequestHandler<AddDtoRequest<TeamStaffDto>, DtoResponse<TeamStaffDto>>
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Fields

        private readonly ITeamRepository _teamRepository;
        private readonly IStaffRepository _staffRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddStaffToTeamRequestHandler" /> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        /// <param name="staffRepository">The staff repository.</param>
        public AddStaffToTeamRequestHandler ( ITeamRepository teamRepository, IStaffRepository staffRepository )
        {
            _teamRepository = teamRepository;
            _staffRepository = staffRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( AddDtoRequest<TeamStaffDto> request, DtoResponse<TeamStaffDto> response )
        {
            var team = _teamRepository.GetByKey ( request.AggregateKey );
            var staff = _staffRepository.GetByKey ( request.DataTransferObject.Key );
            if ( staff != null )
            {
                team.AddStaff ( staff );
            }
            else
            {
                Logger.Error(string.Format("Tried adding invalid staff {0} to team {1}", request.DataTransferObject.Key, team.Key));
                response.DataTransferObject.AddDataErrorInfo(new DataErrorInfo("Invalid staff key.", ErrorLevel.Error));
            }

            response.DataTransferObject = request.DataTransferObject;
        }

        #endregion
    }
}