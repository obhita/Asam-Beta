namespace Asam.Ppc.Service.Handlers.Assessment
{
    #region Using Statements

    using Common;
    using Domain.AssessmentModule;
    using Infrastructure;
    using Infrastructure.Services;
    using Mappers;
    using Messages.Common;
    using NHibernate;
    using NLog;
    using Pillar.Common.Metadata;

    #endregion

    /// <summary>
    ///     Gets the section dto based on the key.
    /// </summary>
    public class GetSectionDtoByKeyRequestHandler : ServiceRequestHandler<GetSectionDtoByKeyRequest, GetSectionDtoByKeyResponse<IKeyedDataTransferObject>>
    {
        #region Fields

        private readonly IAssessmentCompletenessManager _assessmentCompletenessManager;
        private readonly ISessionFactory _sessionFactory;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentSectionMapper _assessmentSectionMapper;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetSectionDtoByKeyRequestHandler" /> class.
        /// </summary>
        /// <param name="assessmentRepository">The assessment repository.</param>
        /// <param name="assessmentSectionMapper">The assessment section mapper.</param>
        /// <param name="assessmentCompletenessManager">The assessment completeness manager.</param>
        /// <param name="sessionFactory">The session factory.</param>
        public GetSectionDtoByKeyRequestHandler ( IAssessmentRepository assessmentRepository,
                                                  IAssessmentSectionMapper assessmentSectionMapper,
                                                  IAssessmentCompletenessManager assessmentCompletenessManager,
                                                  ISessionFactory sessionFactory)
        {
            _assessmentRepository = assessmentRepository;
            _assessmentSectionMapper = assessmentSectionMapper;
            _assessmentCompletenessManager = assessmentCompletenessManager;
            _sessionFactory = sessionFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void Handle ( GetSectionDtoByKeyRequest request, GetSectionDtoByKeyResponse<IKeyedDataTransferObject> response )
        {
            var assessment = _assessmentRepository.GetByKey(request.Key);

            if ( assessment != null )
            {
                var sectionDto = _assessmentSectionMapper.Map ( assessment, request.Section, request.SubSection ) as IKeyedDataTransferObject;
                
                if ( sectionDto is IMetadataProvider )
                {
                    if ( request.SubSection == null )
                    {
                        var metadataDto = _assessmentCompletenessManager.GetAsssessmentCompletenessMetadata<Assessment>();
                        ( sectionDto as IMetadataProvider ).MetadataDto = metadataDto.GetChildMetadata ( request.Section );
                    }
                    else
                    {
                        var rootMetadataDto = _assessmentCompletenessManager.GetAsssessmentCompletenessMetadata<Assessment> ();
                        if ( rootMetadataDto.ChildMetadataExists ( request.Section ) )
                        {
                            ( sectionDto as IMetadataProvider ).MetadataDto = rootMetadataDto.GetChildMetadata ( request.Section ).GetChildMetadata ( request.SubSection );
                        }
                    }
                }
                //This is Ayende's recommended approach for fast read-only query: http://ayende.com/blog/2739/optimizing-nhibernate
                using ( var sessionForCompleteness = _sessionFactory.OpenSession() )
                {
                    var assessmentForCompleteness = sessionForCompleteness.Get<Assessment> ( assessment.Key );
                    sessionForCompleteness.FlushMode = FlushMode.Never;
                    var completenessResult = _assessmentCompletenessManager.ExecuteCompleteness("CompleteForScoring", assessmentForCompleteness);
                    response.Completeness = completenessResult;
                }


                response.IsSubmitted = assessment.IsSubmitted;
                sectionDto.Key = assessment.Key;
                Logger.Info ( "User {0}-{1} accessed Section {2} - {3}", UserContext.SystemAccountKey, UserContext.UserName, request.Section, request.SubSection );
                response.DataTransferObject = sectionDto;
            }
        }

        #endregion
    }
}