namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using Common;
    using Domain.OrganizationModule;
    using Infrastructure;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Handler for creating a <see cref="Team" />.
    /// </summary>
    public class CreateTeamRequestHandler : ServiceRequestHandler<CreateTeamRequest, DtoResponse<TeamSummaryDto>>
    {
        #region Fields

        private readonly ITeamFactory _teamFactory;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamRequestHandler" /> class.
        /// </summary>
        /// <param name="teamFactory">The team factory.</param>
        /// <param name="organizationRepository">The organization repository.</param>
        public CreateTeamRequestHandler ( ITeamFactory teamFactory, IOrganizationRepository organizationRepository )
        {
            _teamFactory = teamFactory;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( CreateTeamRequest request, DtoResponse<TeamSummaryDto> response )
        {
            var organization = _organizationRepository.GetByKey ( UserContext.OrganizationKey );
            var team = _teamFactory.Create ( organization, request.Name );
            if ( team != null )
            {
                response.DataTransferObject = Mapper.Map<Team, TeamSummaryDto> ( team );
            }
        }

        #endregion
    }
}