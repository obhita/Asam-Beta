using Pillar.Common.DataTransferObject;

namespace TestEHR.Models
{
    public interface IKeyedDataTransferObject : IKeyedDataTransferObject<long>, IDataTransferObject
    {
    }
}
