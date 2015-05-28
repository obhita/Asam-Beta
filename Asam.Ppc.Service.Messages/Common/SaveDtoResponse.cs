using Pillar.Agatha.Message;

namespace Asam.Ppc.Service.Messages.Common
{
    public class SaveDtoResponse<TDto> : SaveDtoResponse<TDto, long>, IHaveDataTransferObject
        where TDto : IKeyedDataTransferObject
    {
        public object Dto { get { return DataTransferObject; } }
    }
}
