namespace Asam.Ppc.Service.Messages.Organization
{
    using System.Collections.Generic;
    using Agatha.Common;

    public class DtoCollectionResponse<TDto> : Response
    {
        public IEnumerable<TDto> Dtos { get; set; }
    }
}