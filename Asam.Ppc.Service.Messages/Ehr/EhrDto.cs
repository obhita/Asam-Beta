namespace Asam.Ppc.Service.Messages.Ehr
{
    #region Using Statements

    using Common;

    #endregion

    public class EhrDto : KeyedDataTransferObject
    {
        #region Public Properties

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string SigningCertName { get; set; }

        #endregion
    }
}