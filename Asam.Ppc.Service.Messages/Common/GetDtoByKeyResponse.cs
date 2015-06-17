using Pillar.Agatha.Message;

namespace Asam.Ppc.Service.Messages.Common
{
    public class GetDtoByKeyResponse<TDto> : GetDtoByKeyResponse<TDto, long>, IHaveDataTransferObject
        where TDto : IKeyedDataTransferObject
    {
        public object Dto { get { return DataTransferObject; } }
    }
}
