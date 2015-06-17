using Agatha.Common;

namespace Asam.Ppc.Service.Messages.Common
{
    public class SaveSectionDtoRequest : Request
    {
        public string Section { get; set; }
        public string SubSection { get; set; }
        public IKeyedDataTransferObject DataTransferObject { get; set; }
    }
}
