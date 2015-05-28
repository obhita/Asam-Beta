namespace Asam.Ppc.Service.Handlers.Organization
{
    using Common;
    using Domain.OrganizationModule;
    using Messages.Common;
    using Messages.Organization;
    using Pillar.Agatha.Message;
    using global::AutoMapper;

    public class GetTeamDtoByKeyRequestHandler : ServiceRequestHandler<GetDtoByKeyRequest<TeamDto, long>, DtoResponse<TeamDto>>
    {
        private readonly ITeamRepository _teamRepository;

        #region Constructors and Destructors

        public GetTeamDtoByKeyRequestHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        #endregion

        #region Methods

        protected override void Handle(GetDtoByKeyRequest<TeamDto, long> request, DtoResponse<TeamDto> response)
        {
            var team = _teamRepository.GetByKey ( request.Key );
            response.DataTransferObject = Mapper.Map<Team, TeamDto> ( team );
        }

        #endregion
    }
}