namespace Asam.Ppc.Service.Handlers.Assessment
{
    #region Using Statements

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using Common;
    using Domain.AssessmentModule;
    using Domain.AssessmentModule.Review;
    using Domain.CommonModule;
    using Messages.Common;
    using Messages.Common.Lookups;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Saves the section dto.
    /// </summary>
    public class SaveSectionDtoRequestHandler : ServiceRequestHandler<SaveSectionDtoRequest, SaveDtoResponse<IKeyedDataTransferObject>>
    {
        #region Fields

        private readonly IAssessmentRepository _assessmentRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveSectionDtoRequestHandler" /> class.
        /// </summary>
        /// <param name="assessmentRepository">The assessment repository.</param>
        public SaveSectionDtoRequestHandler ( IAssessmentRepository assessmentRepository )
        {
            _assessmentRepository = assessmentRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( SaveSectionDtoRequest request, SaveDtoResponse<IKeyedDataTransferObject> response )
        {
            var dto = request.DataTransferObject;

            var assessment = _assessmentRepository.GetByKey ( dto.Key );

            var dtoType = dto.GetType ();
            var entityPropertyInfo = assessment.GetType ().GetProperty ( request.Section );
            var entity = entityPropertyInfo.GetValue(assessment) as RevisionBase;
            if (entity == null && request.Section == "ReviewSection")
            {
                entity = Activator.CreateInstance<ReviewSection>();
                entityPropertyInfo.SetValue ( assessment, entity );
            }
            if ( request.SubSection != null )
            {
                entityPropertyInfo = entityPropertyInfo.PropertyType.GetProperty ( request.SubSection );
                entity = entityPropertyInfo.GetValue ( entity ) as RevisionBase;
            }
            var entityType =entityPropertyInfo.PropertyType;
            foreach (var propertyInfo in dtoType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).Where(pi =>
                {
                    var readonlyAttribute = pi.GetCustomAttributes ( typeof(ReadOnlyAttribute), false ).FirstOrDefault () as ReadOnlyAttribute;
                    return readonlyAttribute == null || !readonlyAttribute.IsReadOnly;
                } ) )
            {
                var valueToSet = propertyInfo.GetValue ( dto );
                var lookupDto = valueToSet as LookupDto;
                if ( lookupDto != null )
                {
                    var entityProperty = entityType.GetProperty ( propertyInfo.Name );
                    valueToSet = Lookup.Find ( entityProperty.PropertyType.Name, lookupDto.Code );
                }
                var enumerableLookups = valueToSet as IEnumerable<LookupDto>;
                if ( enumerableLookups != null )
                {
                    var entityProperty = entityType.GetProperty ( propertyInfo.Name );
                    var lookupType = entityProperty.PropertyType.GetGenericArguments ()[0];
                    var newValues = Activator.CreateInstance ( typeof(List<>).MakeGenericType ( entityProperty.PropertyType.GetGenericArguments ()[0] ) ) as IList;
                    foreach ( var lookup in ( valueToSet as IEnumerable<LookupDto> ) )
                    {
                        newValues.Add ( Lookup.Find ( lookupType.Name, lookup.Code ) );
                    }
                    valueToSet = newValues;
                }
                entity.ReviseProperty ( assessment.Key, propertyInfo.Name, valueToSet );
            }

            response.DataTransferObject = Mapper.Map ( entity, entityType, dtoType ) as IKeyedDataTransferObject;

            response.DataTransferObject.Key = assessment.Key;
        }

        #endregion
    }
}