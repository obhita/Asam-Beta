namespace Asam.Ppc.Service.Handlers.Assessment.Mappers
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using Domain.AssessmentModule;
    using Pillar.Common.InversionOfControl;

    #endregion

    /// <summary>
    ///  Mapper for mapping assessment sections to there dtos.
    /// </summary>
    public class AssessmentSectionMapper : IAssessmentSectionMapper
    {
        #region Fields

        private readonly Dictionary<string, Func<Assessment, object>> _registeredMappers = new Dictionary<string, Func<Assessment, object>> ();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssessmentSectionMapper" /> class.
        /// </summary>
        public AssessmentSectionMapper ()
        {
            var mappers = IoC.CurrentContainer.ResolveAll<IMapAssessmentSection> ();
            foreach ( var mapAssessmentSection in mappers )
            {
                _registeredMappers.Add ( mapAssessmentSection.Section + mapAssessmentSection.SubSection, mapAssessmentSection.Map );
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Maps the specified assessment.
        /// </summary>
        /// <param name="assessment">The assessment.</param>
        /// <param name="section">The section.</param>
        /// <param name="subSection">The sub section.</param>
        /// <returns>The dto for the assessment section.</returns>
        public object Map ( Assessment assessment, string section, string subSection )
        {
            var key = section + subSection;
            return _registeredMappers.ContainsKey ( key )
                       ? _registeredMappers[key] ( assessment )
                       : AssessmentMapper.MapAssessmentSection ( assessment, section, subSection );
        }

        #endregion
    }
}