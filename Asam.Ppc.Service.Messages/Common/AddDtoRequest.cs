namespace Asam.Ppc.Service.Messages.Common
{
    #region Using Statements

    using System;
    using Agatha.Common;

    #endregion

    public class AddDtoRequest<TDto> : Request
    {
        #region Public Properties

        public long AggregateKey { get; set; }
        public TDto DataTransferObject { get; set; }

        #endregion
    }
}