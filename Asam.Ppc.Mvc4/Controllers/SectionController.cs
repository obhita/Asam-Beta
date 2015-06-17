namespace Asam.Ppc.Mvc4.Controllers
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Agatha.Common;
    using Infrastructure.Services;
    using Models;
    using Mvc.Infrastructure;
    using Mvc.Infrastructure.Security;
    using Mvc.Infrastructure.Service;
    using Service.Messages.Assessment;
    using Service.Messages.Common;
    using Service.Messages.Common.Lookups;
    using Service.Messages.Core;

    #endregion

    /// <summary>
    /// Controller for Sections and Subsections of an Assessment.
    /// </summary>
    public class SectionController : BaseController
    {
        #region Fields

        private readonly IRouteNavigationService _routeNavigationService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionController" /> class.
        /// </summary>
        /// <param name="requestDispatcherFactory">The request dispatcher factory.</param>
        /// <param name="routeNavigationService">The route navigation service.</param>
        /// <param name="patientAccessControlManager">The patient access control manager.</param>
        public SectionController ( IRequestDispatcherFactory requestDispatcherFactory,
                                   IRouteNavigationService routeNavigationService,
                                   IPatientAccessControlManager patientAccessControlManager )
            :
                base ( requestDispatcherFactory, patientAccessControlManager )
        {
            _routeNavigationService = routeNavigationService;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the Edit view of the specified section.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="subsection">The subsection.</param>
        /// <param name="id">The id.</param>
        /// <returns><see cref="ActionResult"/> of the action.</returns>
        /// <exception cref="System.Web.HttpException">404;Assessment or patient record not found.</exception>
        public async Task<ActionResult> Edit ( string section, string subsection, long id )
        {
            var request = new GetSectionDtoByKeyRequest {Key = id, Section = section, SubSection = subsection};

            var requestDispatcher = CreateAsyncRequestDispatcher ();
            requestDispatcher.Add ( request );

            requestDispatcher.Add ( new GetPatientDtoByAssessmentKeyRequest {AssessmentKey = id} );
            var dtoType = GetDtoType ( subsection ?? section );
            AddLookupRequests ( requestDispatcher, dtoType );
            var response = await requestDispatcher.GetAsync<GetSectionDtoByKeyResponse<IKeyedDataTransferObject>> ();
            var patientResponse = requestDispatcher.Get<GetPatientDtoResponse> ();
            AddLookupResponsesToViewData ( requestDispatcher );
            
            if ( response.DataTransferObject == null || patientResponse.DataTransferObject == null )
            {
                throw new HttpException ( 404, "Assessment or patient record not found." );
            }

            ViewData["Patient"] = patientResponse.DataTransferObject;
            ViewData["AssessmentId"] = id;
            ViewData["AssessmentViewModel"] = new AssessmentViewModel(id, _routeNavigationService, section, subsection, response.Completeness);

            if ( _patientAccessControlManager.CanAccessPatient ( patientResponse.DataTransferObject.Key ) )
            {
                return View ( response.Dto );
            }
            return HttpNotFound ();
        }

        /// <summary>
        /// Action method for handling posting of the specified section.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="subsection">The subsection.</param>
        /// <param name="nextRoute">The next route.</param>
        /// <param name="id">The assessment id.</param>
        /// <param name="patientId">The patient id.</param>
        /// <returns><see cref="ActionResult"/> of the action.</returns>
        /// <exception cref="System.Web.HttpException">500;Section/subsection cannot be saved.</exception>
        [HttpPost]
        public async Task<ActionResult> Edit ( string section, string subsection, string nextRoute, long id, long? patientId )
        {
            var nextRouteInfo = _routeNavigationService.RecalculateNextRouteInfo(nextRoute);
            if ( !patientId.HasValue )
            {
                if (nextRouteInfo.HasSubsection)
                {
                    return RedirectToRoute("SubSectionRoute",
                                             new
                                             {
                                                 id = id,
                                                 section = nextRouteInfo.Section,
                                                 subSection = nextRouteInfo.SubSection
                                             });
                }
                return RedirectToRoute("SectionRoute",
                                         new { id = id, section = nextRouteInfo.Section });
            }
            if ( _patientAccessControlManager.CanAccessPatient ( patientId.Value ) )
            {
                var dtoType = GetDtoType ( subsection ?? section );
                var sectionDto = Activator.CreateInstance ( dtoType ) as IKeyedDataTransferObject;
                TryUpdateModel ( sectionDto );
                var request = new SaveSectionDtoRequest
                    {
                        Section = section,
                        SubSection = subsection,
                        DataTransferObject = sectionDto
                    };

                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add ( request );
                var response = await requestDispatcher.GetAsync<SaveDtoResponse<IKeyedDataTransferObject>> ();

                if ( response.DataTransferObject == null )
                {
                    throw new HttpException ( 500, "Section/subsection cannot be saved." );
                }

                var view = this.HandleErrorsAndWarnings (
                                                         response.DataTransferObject.DataErrorInfoCollection,
                                                         response.Notification,
                                                         () =>
                                                             {
                                                                 requestDispatcher = CreateAsyncRequestDispatcher ();
                                                                 requestDispatcher.Add ( new GetPatientDtoByKeyRequest {PatientKey = patientId.Value} );
                                                                 AddLookupRequests ( requestDispatcher, dtoType );
                                                                 var patientResponse = requestDispatcher.Get<GetPatientDtoResponse> ();
                                                                 AddLookupResponsesToViewData ( requestDispatcher );

                                                                 ViewData["Patient"] = patientResponse.DataTransferObject;
                                                                 ViewData["AssessmentId"] = sectionDto.Key;
                                                                 ViewData["AssessmentViewModel"] =
                                                                     new AssessmentViewModel ( sectionDto.Key,
                                                                                               _routeNavigationService,
                                                                                               section,
                                                                                               subsection, new CompletenessResults ( "Test", 1, 0 ) );
                                                                 return View ( sectionDto );
                                                             } );
                if ( view != null )
                {
                    return view;
                }

                if ( nextRouteInfo.HasSubsection )
                {
                    return RedirectToRoute ( "SubSectionRoute",
                                             new
                                                 {
                                                     id = response.DataTransferObject.Key,
                                                     section = nextRouteInfo.Section,
                                                     subSection = nextRouteInfo.SubSection
                                                 } );
                }
                return RedirectToRoute ( "SectionRoute",
                                         new {id = response.DataTransferObject.Key, section = nextRouteInfo.Section} );
            }
            return HttpNotFound ();
        }

        /// <summary>
        /// Submits the specified assessment by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="patientId">The patient id.</param>
        /// <returns><see cref="ActionResult"/> of the action.</returns>
        /// <exception cref="System.Web.HttpException">500;Submit assessment failed.</exception>
        public async Task<ActionResult> Submit ( long id, long patientId )
        {
            if ( _patientAccessControlManager.CanAccessPatient ( patientId ) )
            {
                var requestDispatcher = CreateAsyncRequestDispatcher ();
                requestDispatcher.Add(new SubmitAssessmentRequest { AssessmentKey = id, Username = PatientAccessControlManager.GetCurrentUserName() });
                requestDispatcher.Add ( new GetPatientDtoByKeyRequest { PatientKey = patientId } );
                var submitResponse = await requestDispatcher.GetAsync<SubmitAssessmentResponse> ();
                var patientResponse = requestDispatcher.Get<GetPatientDtoResponse>();

                if ( submitResponse.AssessmentKey == 0 )
                {
                    throw new HttpException ( 500, "Submit assessment failed." );
                }

                ViewData["Patient"] = patientResponse.DataTransferObject;
                ViewData["AssessmentId"] = id;
                ViewData["AssessmentViewModel"] =
                    new AssessmentViewModel(id,
                                              _routeNavigationService,
                                              "ReviewSection",
                                              null, new CompletenessResults ( "", 1,0 ) { CompletenessResultsPerRuleSet = new Dictionary<string, CompletenessResults> ()});

                return View (id);
            }
            return HttpNotFound ();
        }

        #endregion

        #region Methods

        protected bool TryUpdateModel ( object model )
        {
            if ( model == null )
            {
                throw new ArgumentNullException ( "model" );
            }
            var modelContext = new ModelBindingContext ()
                {
                    ModelMetadata =
                        ModelMetadataProviders.Current.GetMetadataForType ( ( () => model ), model.GetType () ),
                    ModelName = null,
                    ModelState = ModelState,
                    PropertyFilter = s => true,
                    ValueProvider = ValueProvider
                };
            Binders.GetBinder ( model.GetType () ).BindModel ( ControllerContext, modelContext );
            return ModelState.IsValid;
        }

        private Type GetDtoType ( string name )
        {
            name += "Dto";
            var dtoType = typeof(LookupDto).Assembly.GetTypes ().First ( t => t.Name == name );
            return dtoType;
        }

        #endregion
    }
}