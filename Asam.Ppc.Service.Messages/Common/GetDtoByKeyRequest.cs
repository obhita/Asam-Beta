using Pillar.Agatha.Message;

namespace Asam.Ppc.Service.Messages.Common
{
    public class GetDtoByKeyRequest<TDto> : GetDtoByKeyRequest<TDto, long>
        where TDto : IDataTransferObject
    {
        public GetDtoByKeyRequest()
        {
            
        }

        public GetDtoByKeyRequest(long key)
        {
            Key = key;
        }
    }
}
