using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Common
{
    public class GetSectionDtoByKeyRequest : Request
    {
        public string Section { get; set; }
        public string SubSection { get; set; }
        public long Key { get; set; }
    }
}
