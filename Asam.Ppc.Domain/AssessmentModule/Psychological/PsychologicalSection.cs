namespace Asam.Ppc.Domain.AssessmentModule.Psychological
{
    /// <summary>
    /// Psychological section class.
    /// </summary>
    public class PsychologicalSection : RevisionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PsychologicalSection" /> class.
        /// </summary>
        protected internal PsychologicalSection()
        { 
            DepressionEvaluation = new DepressionEvaluation();
            InterviewerRating = new InterviewerRating();
            PsychologicalHistory = new PsychologicalHistory();
        }

        #endregion

        #region public Properties

        /// <summary>
        /// Gets the depression evaluation.
        /// </summary>
        /// <value>
        /// The depression evaluation.
        /// </value>
        public virtual DepressionEvaluation DepressionEvaluation { get; protected set; }

        /// <summary>
        /// Gets the interviewer rating.
        /// </summary>
        /// <value>
        /// The interviewer rating.
        /// </value>
        public virtual InterviewerRating InterviewerRating { get; protected set; }

        /// <summary>
        /// Gets the psychological history.
        /// </summary>
        /// <value>
        /// The psychological history.
        /// </value>
        public virtual PsychologicalHistory PsychologicalHistory { get; protected set; }

        #endregion

    }
}