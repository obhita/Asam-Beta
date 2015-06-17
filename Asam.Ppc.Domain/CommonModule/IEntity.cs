namespace Asam.Ppc.Domain.Common
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }

    public interface IEntity : IEntity<string>
    {
    }
}
