using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    using System.Web.Mvc;
    using Pillar.Common.Metadata;
    using Ppc.Infrastructure.Services;

    public class CompletenessModelValidator : ModelValidator
    {
        private readonly string _completenessCategory;

        public CompletenessModelValidator ( ModelMetadata metadata, ControllerContext controllerContext, string completenessCategory )
            : base ( metadata, controllerContext )
        {
            _completenessCategory = completenessCategory;
        }

        public override IEnumerable<ModelValidationResult> Validate ( object container )
        {
            return Enumerable.Empty<ModelValidationResult>();
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule ()
                    {
                        ValidationType = "completeness"
                    };
                rule.ValidationParameters.Add ( new KeyValuePair<string, object> (_completenessCategory.ToLower(),null) );
                return new List<ModelClientValidationRule> {rule};
        }
    }

    public class CompletenessModelValidatorProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators ( ModelMetadata metadata, ControllerContext context )
        {
            if (metadata.PropertyName != null && context is ViewContext && context.Controller.ViewData.Model is IMetadataProvider)
            {
                var viewContext = context as ViewContext;
                if(viewContext.ViewData != null)
                {
                    var metadataDto = ( context.Controller.ViewData.Model as IMetadataProvider ).MetadataDto;
                    if ( metadataDto != null )
                    {
                        var propertyParts = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(metadata.PropertyName).Split('.');
                        foreach ( var propertyPart in propertyParts )
                        {
                            var metadataItemDto = metadataDto.FindMetadataItem<RequiredForCompletenessMetadataItemDto>();
                            if (metadataItemDto != null)
                            {
                                yield return new CompletenessModelValidator(metadata, context, metadataItemDto.CompletenessCategory);
                                break;
                            } 
                            if (metadataDto.ChildMetadataExists(propertyPart))
                            {
                                metadataDto = metadataDto.GetChildMetadata ( propertyPart );
                            }
                        }
                    }
                }
            }
        }
    }
}
