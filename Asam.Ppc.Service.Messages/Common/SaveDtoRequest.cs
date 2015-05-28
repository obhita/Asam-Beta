using Pillar.Agatha.Message;

namespace Asam.Ppc.Service.Messages.Common
{
    public class SaveDtoRequest<TDto> : SaveDtoRequest<TDto, long>, IHaveDataTransferObject
        where TDto : IKeyedDataTransferObject
    {
        public SaveDtoRequest()
        {

        }

        public SaveDtoRequest(TDto dto)
        {
            DataTransferObject = dto;
        }

        public object Dto { get { return DataTransferObject; } }
    }
}
