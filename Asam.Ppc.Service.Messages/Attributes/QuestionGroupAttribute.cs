using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Asam.Ppc.Service.Messages.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class QuestionGroupAttribute : Attribute, IMetadataAware, IQuestionGroup
    {
        //this is needed to allow multiple instances of the same attribute???
        private readonly object _typeId = new object();
        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public string QuestionResourceName { get; private set; }
        public string HeaderTemplateName { get; private set; }
        public int ApplyOrder { get; private set; }
        public Dictionary<string, object> AdditionalViewData { get; private set; }
        public const string QuestionGroup = "QuestionGroup";

        public QuestionGroupAttribute(string questionResourceName, string templateName)
            : this(questionResourceName, 0, templateName)
        {
            
        }

        public QuestionGroupAttribute(string questionResourceName, int applyOrder = 0, string templateName = "DefaultQuestionGroup")
        {
            QuestionResourceName = questionResourceName;
            HeaderTemplateName = templateName;
            ApplyOrder = applyOrder;
            AdditionalViewData = new Dictionary<string, object>();

            if(HeaderTemplateName.EndsWith ( "Columns" ))
            {
                AdditionalViewData.Add ( "Columns", HeaderTemplateName.Replace ( "Columns", "" ).ToLower() );
                HeaderTemplateName = "Columns";
            }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if(!metadata.AdditionalValues.ContainsKey ( QuestionGroup ))
            {
                metadata.AdditionalValues[QuestionGroup] = new List<IQuestionGroup>();
            }
            (metadata.AdditionalValues[QuestionGroup] as IList<IQuestionGroup>).Add ( this );
        }
    }
}
