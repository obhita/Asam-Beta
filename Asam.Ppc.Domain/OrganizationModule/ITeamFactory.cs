namespace Asam.Ppc.Domain.OrganizationModule
{
    public interface ITeamFactory
    {
        Team Create ( Organization organization, string name );
    }
}
