namespace Asam.Ppc.Domain.EhrModule
{
    public interface IEhrFactory
    {
        Ehr Create(string name, string signingCertName, string emailAddress);
    }
}