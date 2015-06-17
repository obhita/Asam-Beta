namespace Asam.Ppc.Service.Handlers.Organization
{
    #region Using Statements

    using System.Linq;
    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using global::AutoMapper;

    #endregion

    /// <summary>
    ///     Handler for removing patient from team.
    /// </summary>
    public class RemovePatientFromTeamRequestHandler : ServiceRequestHandler<RemovePatientFromTeamRequest, DtoResponse<TeamSummaryDto>>
    {
        #region Fields

        private readonly ITeamRepository _teamRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemovePatientFromTeamRequestHandler" /> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        public RemovePatientFromTeamRequestHandler ( ITeamRepository teamRepository )
        {
            _teamRepository = teamRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( RemovePatientFromTeamRequest request, DtoResponse<TeamSummaryDto> response )
        {
            var team = _teamRepository.GetByKey ( request.TeamKey );
            var patient = team.Patients.FirstOrDefault ( p => p.Key == request.PatientKey );
            if ( patient != null )
            {
                team.RemovePatient ( patient );
            }

            response.DataTransferObject = Mapper.Map<Team, TeamSummaryDto> ( team );
        }

        #endregion
    }
}