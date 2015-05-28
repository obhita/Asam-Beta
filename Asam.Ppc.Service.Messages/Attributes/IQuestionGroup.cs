using System.Collections.Generic;

namespace Asam.Ppc.Service.Messages.Attributes
{
    public interface IQuestionGroup
    {
        string QuestionResourceName { get; }
        string HeaderTemplateName { get; }
        int ApplyOrder { get; }
        Dictionary<string, object> AdditionalViewData { get; }
    }
}