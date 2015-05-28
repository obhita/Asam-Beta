using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;

namespace Asam.Ppc.Mvc.Infrastructure.Service
{
    using System;

    /// <summary>
    /// Class AsamRouteNavigationService
    /// </summary>
    public class AsamRouteNavigationService : IRouteNavigationService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly List<RouteInfo> _routeInfos = new List<RouteInfo> ();
        private int _restartIndex = 34;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsamRouteNavigationService" /> class.
        /// </summary>
        public AsamRouteNavigationService (IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
            InitializeRoutes ();
        }

        #region IRouteNavigationService Members

        public void LoadAssessment(long assessmentKey)
        {
            var assessment = _assessmentRepository.GetByKey ( assessmentKey );
            HandleUsesSubstances ( assessment );

            if ( assessment.IsSubmitted )
            {
                _routeInfos.Add(new RouteInfo(section: "ReviewSection",
                                                  orderIndex: 33));
            }
            else
            {
                var reviewRoute = _routeInfos.FirstOrDefault ( ri => ri.Section == "ReviewSection" );
                if ( reviewRoute != null )
                {
                    _routeInfos.Remove ( reviewRoute );
                }
            }
        }

        public RouteInfo RecalculateNextRouteInfo(string nextRouteString)
        {
            var routes = nextRouteString.Split(new[] {'^'}, StringSplitOptions.RemoveEmptyEntries);
            var nextRoute = RouteInfo.Parse(routes[0]);
            if (routes.Length == 1)
            {
                return nextRoute;
            }
            var currentRoute = RouteInfo.Parse(routes[1]);
            if (currentRoute.HasSubsection && currentRoute.Section == "DrugAndAlcoholSection" &&
                currentRoute.SubSection == "UsedSubstances")
            {
                if (routes.Length != 3)
                {
                     throw new ArgumentException ( "Not a valid route string", nextRouteString );
                }
                long assessmentKey;
                if (!(long.TryParse(routes[2], out assessmentKey)))
                {
                    throw new ArgumentException("Not a valid route string", nextRouteString);
                }
                LoadAssessment(assessmentKey);
                currentRoute.OrderIndex = 3;
                return GetNextRoute(currentRoute);
            }
            return nextRoute;
        }

        /// <summary>
        /// Gets the next route.
        /// </summary>
        /// <param name="currentRoute">The current route.</param>
        /// <returns>The next route.</returns>
        public RouteInfo GetNextRoute ( RouteInfo currentRoute )
        {
            var nextIndex = currentRoute.OrderIndex + 1 == _restartIndex ? 0 : currentRoute.OrderIndex + 1;
            RouteInfo nextRoute;
            do
            {
                nextRoute = _routeInfos.FirstOrDefault(ri => ri.OrderIndex == nextIndex);
                nextIndex++;
                if (nextIndex == _restartIndex)
                {
                    nextIndex = 0;
                }
            } while (nextRoute == null);
            return nextRoute;
        }

        /// <summary>
        /// Gets the previous route.
        /// </summary>
        /// <param name="currentRoute">The current route.</param>
        /// <returns>The previous route.</returns>
        public RouteInfo GetPreviousRoute ( RouteInfo currentRoute )
        {
            var previousIndex = currentRoute.OrderIndex - 1 == -1 ? _restartIndex - 1 : currentRoute.OrderIndex - 1;
            RouteInfo previousRoute;
            do
            {
                previousRoute = _routeInfos.FirstOrDefault(ri => ri.OrderIndex == previousIndex);
                previousIndex--;
                if (previousIndex == -1)
                {
                    previousIndex = _restartIndex - 1;
                }
            } while (previousRoute == null);
            return previousRoute;
        }

        /// <summary>
        /// Gets the initial route.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The initial route.
        /// </returns>
        public RouteInfo GetInitialRoute (long? key = null)
        {
            if ( key.HasValue )
            {
                var assessment = _assessmentRepository.GetByKey ( key.Value );
                if ( assessment.IsSubmitted )
                {
                    return new RouteInfo(section: "ReviewSection",
                                                  orderIndex: 33);
                }
            }
            
            return _routeInfos.First ( ri => ri.OrderIndex == 0 );
        }

        /// <summary>
        /// Gets the ordered route info list.
        /// </summary>
        /// <value>The ordered route info list.</value>
        public IReadOnlyCollection<RouteInfo> OrderedRouteInfoList
        {
            get { return new ReadOnlyCollection<RouteInfo> (_routeInfos.OrderBy ( r => r.OrderIndex ).ToList ()); }
        }

        /// <summary>
        /// Gets the route info by section info.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="subsection">The subsection.</param>
        /// <returns></returns>
        public RouteInfo GetRouteInfoBySectionInfo ( string section, string subsection )
        {
            return _routeInfos.FirstOrDefault ( r => r.Section == section && r.SubSection == subsection );
        }

        #endregion

        /// <summary>
        /// Initializes the routes.
        /// </summary>
        private void InitializeRoutes ()
        {
            _routeInfos.Clear ();

            _routeInfos.Add ( new RouteInfo ( section: "GeneralInformationSection",
                                              orderIndex: 0 ) );

            _routeInfos.Add ( new RouteInfo ( section: "MedicalSection",
                                              orderIndex: 1 ) );

            _routeInfos.Add ( new RouteInfo ( section: "EmploymentAndSupportSection",
                                              orderIndex: 2 ) );

            _routeInfos.Add ( new RouteInfo ( section: "DrugAndAlcoholSection",
                                              subSection: "UsedSubstances",
                                              orderIndex: 3 ) );

            _routeInfos.Add ( new RouteInfo ( section: "LegalSection",
                                              orderIndex: 27 ) );

            _routeInfos.Add ( new RouteInfo ( section: "FamilyAndSocialHistorySection",
                                              orderIndex: 28 ) );

            _routeInfos.Add ( new RouteInfo ( section: "PsychologicalSection",
                                              subSection: "PsychologicalHistory",
                                              orderIndex: 29 ) );

            _routeInfos.Add ( new RouteInfo ( section: "PsychologicalSection",
                                              subSection: "InterviewerRating",
                                              orderIndex: 30 ) );

            _routeInfos.Add ( new RouteInfo ( section: "PsychologicalSection",
                                              subSection: "DepressionEvaluation",
                                              orderIndex: 31 ) );

            _routeInfos.Add ( new RouteInfo ( section: "CompletionSection",
                                              orderIndex: 32));
        }

        public void HandleUsesSubstances( Assessment assessment )
        {
            var usedSubstances = assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed == null
                                     ? Enumerable.Empty<string> ()
                                     : assessment.DrugAndAlcoholSection.UsedSubstances.SubstanceHasEverUsed.Select ( s => s.Code );

            if (usedSubstances.Contains(SubstanceCategory.Alcohol.Code))
            {
                _routeInfos.Add ( new RouteInfo ( section: "DrugAndAlcoholSection",
                                                  subSection: "AlcoholUse",
                                                  orderIndex: 4 ) );
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 4 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Heroin.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "HeroinUse",
                                              orderIndex: 5));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 5 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Methadone.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "MethadoneUse",
                                              orderIndex: 6));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 6 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.OtherOpiate.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "OtherOpiateUse",
                                              orderIndex: 7));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 7 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if ( usedSubstances.Contains ( SubstanceCategory.Heroin.Code ) ||
                 usedSubstances.Contains(SubstanceCategory.Methadone.Code) ||
                 usedSubstances.Contains(SubstanceCategory.OtherOpiate.Code))
            {

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "CinaScale",
                                                  orderIndex: 8));

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "OpiatesInControlledEnvironment",
                                                  orderIndex: 9));

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "OpioidMaintenanceTherapy",
                                                  orderIndex: 10));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault(r => r.OrderIndex == 8);
                if (routeItem != null)
                {
                    _routeInfos.Remove(routeItem);
                }
                var routeItem2 = _routeInfos.FirstOrDefault(r => r.OrderIndex == 9);
                if (routeItem2 != null)
                {
                    _routeInfos.Remove(routeItem2);
                }
                var routeItem3 = _routeInfos.FirstOrDefault(r => r.OrderIndex == 10);
                if (routeItem3 != null)
                {
                    _routeInfos.Remove(routeItem3);
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Barbiturates.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "BarbiturateUse",
                                              orderIndex: 11));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 11 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.OtherSedatives.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "OtherSedativeUse",
                                              orderIndex: 12));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 12 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if(usedSubstances.Contains ( SubstanceCategory.Alcohol.Code ) ||
                usedSubstances.Contains ( SubstanceCategory.Barbiturates.Code ) ||
                usedSubstances.Contains ( SubstanceCategory.OtherSedatives.Code ))
            {

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "CiwaScale",
                                                  orderIndex: 13));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault(r => r.OrderIndex == 13);
                if (routeItem != null)
                {
                    _routeInfos.Remove(routeItem);
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Cocaine.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "CocaineUse",
                                              orderIndex: 14));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 14 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Stimulants.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "StimulantUse",
                                              orderIndex: 15));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 15 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Cannabis.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "CannabisUse",
                                              orderIndex: 16));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 16 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Hallucinogens.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "HallucinogenUse",
                                              orderIndex: 17));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 17 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.SolventInhalants.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "SolventAndInhalantUse",
                                              orderIndex: 18));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 18 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.MultiplePerDay.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "MultipleSubstanceUsePerDay",
                                              orderIndex: 19));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 19 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.Nicotine.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "NicotineUse",
                                              orderIndex: 20));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 20 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Contains(SubstanceCategory.OtherSubstance.Code))
            {
            _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                              subSection: "OtherSubstanceUse",
                                              orderIndex: 21));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault ( r => r.OrderIndex == 21 );
                if(routeItem != null)
                {
                    _routeInfos.Remove ( routeItem );
                }
            }
            if (usedSubstances.Count(s => s != SubstanceCategory.Alcohol.Code && s != SubstanceCategory.NoHistory.Code) > 0 )
            {
                _routeInfos.Add ( new RouteInfo ( section: "DrugAndAlcoholSection",
                                                  subSection: "DrugConsequences",
                                                  orderIndex: 22 ) );
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault(r => r.OrderIndex == 22);
                if (routeItem != null)
                {
                    _routeInfos.Remove(routeItem);
                }
            }
            if (usedSubstances.Any( r => r != SubstanceCategory.NoHistory.Code ))
            {
                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "AddictionTreatmentHistory",
                                                  orderIndex: 23));

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "AdditionalAddictionAndTreatmentItems",
                                                  orderIndex: 24));

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "AlcoholAndDrugInterviewerRating",
                                                  orderIndex: 25));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault(r => r.OrderIndex == 23);
                if (routeItem != null)
                {
                    _routeInfos.Remove(routeItem);
                }
                var routeItem2 = _routeInfos.FirstOrDefault(r => r.OrderIndex == 24);
                if (routeItem2 != null)
                {
                    _routeInfos.Remove(routeItem2);
                }
                var routeItem3 = _routeInfos.FirstOrDefault(r => r.OrderIndex == 25);
                if (routeItem3 != null)
                {
                    _routeInfos.Remove(routeItem3);
                }
            }
            if((usedSubstances.Contains ( SubstanceCategory.Methadone.Code ) && assessment.DrugAndAlcoholSection.MethadoneUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains ( SubstanceCategory.OtherOpiate.Code ) && assessment.DrugAndAlcoholSection.OtherOpiateUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains ( SubstanceCategory.Barbiturates.Code ) && assessment.DrugAndAlcoholSection.BarbiturateUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains ( SubstanceCategory.OtherSedatives.Code ) && assessment.DrugAndAlcoholSection.OtherSedativeUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains ( SubstanceCategory.Stimulants.Code ) && assessment.DrugAndAlcoholSection.StimulantUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains ( SubstanceCategory.Nicotine.Code ) && assessment.DrugAndAlcoholSection.NicotineUse.HasHealthCareProviderPrescribedUse == true) ||
                (usedSubstances.Contains(SubstanceCategory.OtherSubstance.Code) && assessment.DrugAndAlcoholSection.OtherSubstanceUse.HasHealthCareProviderPrescribedUse == true))
            {

                _routeInfos.Add(new RouteInfo(section: "DrugAndAlcoholSection",
                                                  subSection: "InterviewerEvaluation",
                                                  orderIndex: 26));
            }
            else
            {
                var routeItem = _routeInfos.FirstOrDefault(r => r.OrderIndex == 26);
                if (routeItem != null)
                {
                    _routeInfos.Remove(routeItem);
                } 
            }
        }
    }
}