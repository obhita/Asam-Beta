namespace Asam.Ppc.Service.Handlers.Assessment
{
    #region Using Statements

    using Common;
    using Domain.AssessmentModule;
    using Messages.Assessment;

    #endregion

    /// <summary>
    /// Handler for submitting assessment request.
    /// </summary>
    public class SubmitAssessmentRequestHandler : ServiceRequestHandler<SubmitAssessmentRequest, SubmitAssessmentResponse>
    {
        #region Fields

        private readonly IAssessmentRepository _assessmentRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitAssessmentRequestHandler" /> class.
        /// </summary>
        /// <param name="assessmentRepository">The assessment repository.</param>
        public SubmitAssessmentRequestHandler ( IAssessmentRepository assessmentRepository )
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
        protected override void Handle ( SubmitAssessmentRequest request, SubmitAssessmentResponse response )
        {
            var assessment = _assessmentRepository.GetByKey ( request.AssessmentKey );

            if ( assessment != null )
            {
                assessment.SubmitAssessment (request.Username);
                response.AssessmentKey = assessment.Key;
            }
        }

        #endregion
    }
}