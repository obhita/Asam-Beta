namespace Asam.Ppc.Service.Messages.Organization
{
    #region Using Statements

    using System.Collections.Generic;
    using Common;

    #endregion

    public class OrganizationApiKeyDto : KeyedDataTransferObject
    {
        #region Public Properties

        public long EhrId { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }

        #endregion
    }
}