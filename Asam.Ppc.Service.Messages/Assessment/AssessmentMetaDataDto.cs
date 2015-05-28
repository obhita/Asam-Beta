using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Service.Messages.Assessment
{
    #region Using Statements
    
    #endregion

    public class AssessmentMetaDataDto : KeyedDataTransferObject
    {
        #region Public Properties

        public long AssessmentKey { get; set; }
        public string MetaDataKey { get; set; }
        public string MetaDataValue { get; set; }

        #endregion
    }
}