using System;
using System.Web.Mvc;

namespace Asam.Ppc.Service.Messages.Attributes
{
    public class LookupCategoryAttribute : Attribute, IMetadataAware
    {
        public string Category { get; private set; }
        public const string LookupCategory = "LookupCategory";

        public LookupCategoryAttribute(string category)
        {
            Category = category;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[LookupCategory] = Category;
        }
    }

    public class CheckAllAttribute : Attribute, IMetadataAware
    {
        public const string CheckAll = "CheckAll";

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[CheckAll] = true;
        }
    }
}
