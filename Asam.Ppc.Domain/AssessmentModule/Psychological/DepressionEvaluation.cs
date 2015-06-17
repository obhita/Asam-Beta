namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    /// <summary>
    /// Depression Evaluation class.
    /// </summary>
    public class DepressionEvaluation : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DepressionEvaluation" /> class.
        /// </summary>
        protected internal DepressionEvaluation()
        {
        }
        
        #endregion

        #region public Properties

        /// <summary>
        /// Gets the observed retardation of thought or speech.
        /// </summary>
        /// <value>
        /// The observed retardation of thought or speech.
        /// </value>
        public virtual RetardationOfThoughtOrSpeech ObservedRetardationOfThoughtOrSpeech { get; protected set; }

        /// <summary>
        /// Gets the range of energy in past week.
        /// </summary>
        /// <value>
        /// The range of energy in past week.
        /// </value>
        public virtual RangeOfEnergy RangeOfEnergyInPastWeek { get; protected set; }

        /// <summary>
        /// Gets the range of guilt in past week.
        /// </summary>
        /// <value>
        /// The range of guilt in past week.
        /// </value>
        public virtual RangeOfGuilt RangeOfGuiltInPastWeek { get; protected set; }

        /// <summary>
        /// Gets the range of interest in doing things in past week.
        /// </summary>
        /// <value>
        /// The range of interest in doing things in past week.
        /// </value>
        public virtual RangeOfInterestInDoingThings RangeOfInterestInDoingThingsInPastWeek { get; protected set; }

        /// <summary>
        /// Gets the range of irritability in past week.
        /// </summary>
        /// <value>
        /// The range of irritability in past week.
        /// </value>
        public virtual RangeOfIrritability RangeOfIrritabilityInPastWeek { get; protected set; }

        /// <summary>
        /// Gets the range of mood in past week.
        /// </summary>
        /// <value>
        /// The range of mood in past week.
        /// </value>
        public virtual RangeOfMood RangeOfMoodInPastWeek { get; protected set; }

        #endregion
    }
}