namespace Asam.Ppc.Domain.OrganizationModule
{
    using System;

    public class TeamFactory : ITeamFactory
    {
        private readonly ITeamRepository _teamRepository;

        public TeamFactory (ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team Create ( Organization organization, string name )
        {
            var team = new Team(organization, name);
            _teamRepository.MakePersistent ( team );
            return team;
        }
    }
}