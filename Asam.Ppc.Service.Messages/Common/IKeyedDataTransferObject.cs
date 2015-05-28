using Pillar.Common.DataTransferObject;

namespace Asam.Ppc.Service.Messages.Common
{
    public interface IKeyedDataTransferObject : IKeyedDataTransferObject<long>, IDataTransferObject
    {
    }
}
