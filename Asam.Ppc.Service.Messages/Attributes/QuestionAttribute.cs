using System;
using System.Web.Mvc;
using Asam.Ppc.Service.Messages.Common;

namespace Asam.Ppc.Service.Messages.Attributes
{
    public class QuestionAttribute : Attribute, IMetadataAware
    {
        public QuestionType Type { get; private set; }
        public const string Question = "Question";

        public QuestionAttribute(QuestionType type)
        {
            Type = type;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[Question] = Type;
        }
    }
}
