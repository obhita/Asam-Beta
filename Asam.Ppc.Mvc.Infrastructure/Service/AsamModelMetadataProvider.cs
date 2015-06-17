namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    #region Using Statements

    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Resources;
    using System.Web.Mvc;
    using Ppc.Service.Messages.Assessment;
    using Primitives;

    #endregion

    public class AsamModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private static readonly OrderedDictionary _resourceManagerCache = new OrderedDictionary();

        #region Public Methods and Operators

        public override ModelMetadata GetMetadataForProperty ( Func<object> modelAccessor, Type containerType, string propertyName )
        {
            var modelMetadata = base.GetMetadataForProperty ( modelAccessor, containerType, propertyName );
            ResourceManager resourceManager = null;
            if ( typeof(IPrimitive).IsAssignableFrom ( containerType ) )
            {
                modelMetadata.IsRequired = false;
            }
            if ( modelMetadata.DisplayName == null )
            {
                if ( typeof(IPrimitive).IsAssignableFrom ( containerType ) )
                {
                    resourceManager = AsamPpcPrimitiveResources.ResourceManager;
                }
                else if ( typeof(IAssessmentDto).IsAssignableFrom ( containerType ) )
                {
                    resourceManager = AsamPpcResources.ResourceManager;
                }
                else
                {
                    var fullNamePrefix = containerType.FullName.Substring ( 0, containerType.FullName.LastIndexOf ( '.' ) );
                    var index = fullNamePrefix.LastIndexOf ( '.' ) + 1;
                    var resourceName = fullNamePrefix.Substring ( index, fullNamePrefix.Length - index );
                    var fullName = string.Format ( "{0}.{1}Resources", fullNamePrefix, resourceName );
                    if (containerType.Assembly.GetManifestResourceNames().Contains(fullName + ".resources"))
                    {
                        if ( !_resourceManagerCache.Contains ( fullName ) )
                        {
                            if ( _resourceManagerCache.Count >= 5 )
                            {
                                _resourceManagerCache.RemoveAt ( _resourceManagerCache.Count - 1 );
                            }
                            _resourceManagerCache.Insert ( 0, fullName, new ResourceManager ( fullName, containerType.Assembly ) );
                        }
                        resourceManager = _resourceManagerCache[fullName] as ResourceManager;
                    }
                }
            }
            if ( resourceManager != null )
            {
                modelMetadata.DisplayName = resourceManager.GetString ( string.Format ( "{0}_{1}", containerType.Name.Replace ( "Dto", "" ), modelMetadata.PropertyName ) );
            }

            return modelMetadata;
        }

        #endregion
    }
}