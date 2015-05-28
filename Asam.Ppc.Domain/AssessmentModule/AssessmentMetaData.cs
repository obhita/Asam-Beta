using Asam.Ppc.Domain.CommonModule;
using Pillar.Common.Utility;
using Pillar.Domain.Attributes;

namespace Asam.Ppc.Domain.AssessmentModule
{
    #region Using Statements

    #endregion

    /// <summary>
    ///     AssessmentMetaData aggregate root.
    /// </summary>
    public class AssessmentMetaData : AggregateRootBase, IAssessmentMetaDataMember
    {
        #region Fields

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AssessmentMetaData" /> class.
        /// </summary>
        /// <param name="assessmentKey">The assessmentKey.</param>
        /// <param name="metaDataKey">The assessment MetaData Key.</param>
        /// <param name="metaDataValue">The assessment MetaData Value.</param>
        public AssessmentMetaData(long assessmentKey, string metaDataKey, string metaDataValue)
        {
            AssessmentKey = assessmentKey;
            MetaDataKey = metaDataKey;
            MetaDataValue = metaDataValue;
        }

        internal AssessmentMetaData()
        {
        }

        #endregion

        #region Public Properties

        [IgnoreMapping]
        public virtual long AssessmentMetaDataKey { get { return Key; } }

        /// <summary>
        /// Gets the Assessmen key.
        /// </summary>
        /// <value>
        /// The Assessment key.
        /// </value>
        [NotNull]
        public virtual long AssessmentKey { get; protected set; }

        /// <summary>
        ///     Gets the MetaDataKey.
        /// </summary>
        /// <value>
        ///     The MetaDataKey.
        /// </value>
        [NotNull]
        public virtual string MetaDataKey { get; protected set; }

        /// <summary>
        ///     Gets the MetaDataValue.
        /// </summary>
        /// <value>
        ///     The MetaDataValue.
        /// </value>
        [NotNull]
        public virtual string MetaDataValue { get; protected set; }

        #endregion

        #region Public Methods and Operators

        public virtual void ReviseAssessmentMetaDataValue(string metaDataValue)
        {
            Check.IsNotNullOrWhitespace(metaDataValue, () => metaDataValue);

            MetaDataValue = metaDataValue;
        }

        #endregion
    }
}