using Pillar.Domain;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Domain.CommonModule.Services
{
    public interface IIdentityProvider
    {
        Entity Generate(Entity entity);
    }
}