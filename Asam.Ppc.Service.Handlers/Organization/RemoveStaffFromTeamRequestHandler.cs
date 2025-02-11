﻿namespace Asam.Ppc.Service.Handlers.Organization
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
    ///     Handler for removing staff from team.
    /// </summary>
    public class RemoveStaffFromTeamRequestHandler : ServiceRequestHandler<RemoveStaffFromTeamRequest, DtoResponse<TeamSummaryDto>>
    {
        #region Fields

        private readonly ITeamRepository _teamRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoveStaffFromTeamRequestHandler" /> class.
        /// </summary>
        /// <param name="teamRepository">The team repository.</param>
        public RemoveStaffFromTeamRequestHandler ( ITeamRepository teamRepository )
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
        protected override void Handle ( RemoveStaffFromTeamRequest request, DtoResponse<TeamSummaryDto> response )
        {
            var team = _teamRepository.GetByKey ( request.TeamKey );
            var staff = team.Staff.FirstOrDefault ( s => s.Key == request.StaffKey );
            if ( staff != null )
            {
                team.RemoveStaff ( staff );
            }
            response.DataTransferObject = Mapper.Map<Team, TeamSummaryDto> ( team );
        }

        #endregion
    }
}