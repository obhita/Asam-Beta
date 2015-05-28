namespace Asam.Ppc.Domain.EhrModule
{
    public class EhrFactory : IEhrFactory
    {
        private readonly IEhrRepository _ehrRepository;

        public EhrFactory (IEhrRepository ehrRepository)
        {
            _ehrRepository = ehrRepository;
        }

        public Ehr Create(string name, string signingCertName, string emailAddress)
        {
            var ehr = new Ehr ( name, signingCertName, emailAddress );
            _ehrRepository.MakePersistent(ehr);
            return ehr;
        }
    }
}
