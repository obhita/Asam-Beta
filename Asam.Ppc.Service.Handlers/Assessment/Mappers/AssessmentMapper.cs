namespace Asam.Ppc.Service.Handlers.Assessment.Mappers
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.AssessmentModule;
    using Domain.AssessmentModule.Review;
    using Messages.Common.Lookups;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Helper for mapping Assessment sections to there dtos.
    /// </summary>
    public static class AssessmentMapper
    {
        #region Static Fields

        private static readonly IDictionary<string, Type> DtoTypeCache;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes the <see cref="AssessmentMapper" /> class.
        /// </summary>
        static AssessmentMapper ()
        {
            DtoTypeCache = typeof(LookupDto).Assembly.GetTypes ()
                                             .Where ( t => t.Name.EndsWith ( "Dto" ) )
                                             .ToDictionary ( t => t.Name.Replace ( "Dto", "" ), t => t );
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Maps the assessment section to its dto.
        /// </summary>
        /// <param name="assessment">The assessment.</param>
        /// <param name="section">The section.</param>
        /// <param name="subSection">The sub section.</param>
        /// <returns>The dto of the assessment section.</returns>
        public static object MapAssessmentSection ( Assessment assessment, string section, string subSection )
        {
            var name = section;
            var entityPropertyInfo = assessment.GetType ().GetProperty ( section );
            var entityToGet = entityPropertyInfo.GetValue ( assessment );
            if ( entityToGet == null && section == "ReviewSection" )
            {
                entityToGet = Activator.CreateInstance<ReviewSection> ();
            }
            var entityType = entityPropertyInfo.PropertyType;
            if ( subSection != null )
            {
                name = subSection;
                entityPropertyInfo = entityType.GetProperty ( subSection );
                entityToGet = entityPropertyInfo.GetValue ( entityToGet );
                entityType = entityPropertyInfo.PropertyType;
            }
            return Mapper.Map ( entityToGet, entityType, DtoTypeCache[name] );
        }

        #endregion
    }
}