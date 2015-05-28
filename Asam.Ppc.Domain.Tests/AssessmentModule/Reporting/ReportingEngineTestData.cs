using System;
using System.Collections.Generic;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.Scoring.ReportModule;
using Asam.Ppc.Domain.Scoring.ReportModule.AccessToTreatmentIssues;
using Asam.Ppc.Domain.Scoring.ReportModule.AddictionSeverityIndexCompositeScores;
using Asam.Ppc.Domain.Scoring.ReportModule.CriticalItems;
using Asam.Ppc.Domain.Scoring.ReportModule.DiagnosticSuggestion;
using Asam.Ppc.Domain.Scoring.ReportModule.DimensionalAnalysis;
using Asam.Ppc.Domain.Scoring.ReportModule.FinalLevelOfCare;
using Asam.Ppc.Domain.Scoring.ReportModule.WithdrawalScales;
using Asam.Ppc.Primitives;

namespace Asam.Ppc.Domain.Tests.AssessmentModule.Reporting
{
    public class ReportingEngineTestData
    {
        public static AssessmentReport GetDataContext()
        {
            {
                var assessmentReport = new AssessmentReport ( );

                assessmentReport.ReportInfo = new ReportInfo ( )
                    {
                        AppendixFilePath = "http://localhost/Content/StaticFiles/AsamPpcAppendix.pdf",
                        AssessmentClass = "Intake",
                        InterviewMethod = "In person",
                        InterviewCircumstances = "",
                        InterviewerName = "Leo Smith",
                        AdmissionDate = DateTime.Parse("10/1/2012"),
                        AssessmentStartDate = DateTime.Parse("10/1/2012"),
                        AssessmentEndDate = DateTime.Parse("10/2/2012"),
                    };

                assessmentReport.PatientInfo = new PatientInfo ( )
                    {
                        PersonName = new PersonName ( "Ms.", "Jane", "", "Jones", "" ),
                        DateOfBirth = DateTime.Parse ( "2/1/1980" ),
                        Gender = Gender.Female,
                        Id = "100056789"
                    };
                

                // Diagnostic Suggestions Section
                var diagnosticSuggestionsSection = new DiagnosticSuggestionsSection ( );
                diagnosticSuggestionsSection.DiagnosticSummary = "The patient endorsed items in the PPC-2R instrument that indicate the probability of the following diagnoses and chemical use history:";
                diagnosticSuggestionsSection.HarmRiskSummary = "The patient has a history of harm to herself or others, with a relative chronic, historical risk of 6 on a scale of 0 (little or no risk) to 6 (very strong risk). Jane Jones is currently at risk of harming herself or others, with a relative current risk level of 7 on a scale of 0 (little or no risk) to 8 (very strong risk). Regarding her breadth of harm, Ms. jones indicated that the risks of harm exist in 4 out of 7 areas, including demonstrating violent behaviors to self or others, being vulnerable to self-harm or to be victimized by another, having a history of psychotic decompensation, and the fact that the abuse or neglect will worsen without removing them from the family, at least temporarily.";

             
                var substanceDependencies = new List<SubstanceDependence> ( );
                var heroinDependence = new SubstanceDependence ( )
                    {
                        LastUsed = "7 days",
                        Name = "Heroin",
                        Score = new ScaleOf0To7 ( 3 ),
                        WithdrawalWarning = false
                    };
                var methadoneDependence = new SubstanceDependence ( )
                    {
                        LastUsed = "2 hours",
                        Name = "Methadone",
                        Score = new ScaleOf0To7 ( 5 ),
                        WithdrawalWarning = true
                    };
                substanceDependencies.Add ( heroinDependence );
                substanceDependencies.Add ( methadoneDependence );
                diagnosticSuggestionsSection.SubstanceDependencies = substanceDependencies;

                var substanceAbuses = new List<SubstanceAbuse> ( );
                var alcoholAbuse = new SubstanceAbuse
                    {
                        LastUsed = "2 days",
                        Name = "Alcohol",
                        Score = 4,
                        WithdrawalWarning = false
                    };
                substanceAbuses.Add ( alcoholAbuse );
                diagnosticSuggestionsSection.SubstanceAbuses = substanceAbuses;

                var substanceUsesWithoutDependenceOrAbuse = new List<SubstanceUseWithoutDependenceOrAbuse> ( );
                var hallucinogensUse = new SubstanceUseWithoutDependenceOrAbuse
                    {
                        Name = "Hallucinogens",
                        LastUsed = "3 hours"
                    };
                substanceUsesWithoutDependenceOrAbuse.Add ( hallucinogensUse );
                diagnosticSuggestionsSection.SubstanceUsesWithoutDependenceOrAbuse =
                    substanceUsesWithoutDependenceOrAbuse;

                assessmentReport.DiagnosticSuggestionsSection = diagnosticSuggestionsSection;

                // AddictionSeverityIndexCompositeScoresSection
                var asiSection = new AddictionSeverityIndexCompositeScoresSection ( );
                asiSection.AsiSummary =
                    "The ASI Composite scores rate severity in seven areas of the patient’s life. Analysis of her ASI responses revealed the following composite scores:";
                var asiList = new List<NamedAsiScore>
                    {
                        new NamedAsiScore {AsiAspectName = "Medical", Score = 0.235},
                        new NamedAsiScore {AsiAspectName = "Employment", Score = 0.346},
                        new NamedAsiScore {AsiAspectName = "Alcohol", Score = 0.431},
                        new NamedAsiScore {AsiAspectName = "Drug", Score = 0.500},
                        new NamedAsiScore {AsiAspectName = "Legal", Score = 0.589},
                        new NamedAsiScore {AsiAspectName = "Family And Social", Score = 0.187},
                        new NamedAsiScore {AsiAspectName = "Psychiatric", Score = 0.369},
                    };
                asiSection.AddictionSeverityIndexCompositeScores = asiList;
                assessmentReport.AddictionSeverityIndexCompositeScoresSection = asiSection;

                //Critical items
                var criticalItemsSection = new CriticalItemsSection ( );
                criticalItemsSection.MedicalSummary =
                    "During the assessment, one critical medical item was noted, that is";
                //criticalItemsSection.MedicalItems.Add ( "Jane indicated that she has overdosed on alcohol and/or drugs in the past 24 hours");
                criticalItemsSection.PsychSummary =
                    "The following critical psychological/psychiatric items were noted in this assessment:";
                criticalItemsSection.PsychItems.Add (
                    "The patient indicated that she has been sexually abused during the past 30 days." );
                criticalItemsSection.PsychItems.Add (
                    "The patient indicated that she has recently neglected or abused family members. Further evaluation is needed to determine if the neglect or abuse needs to be reported to protective services." );
                criticalItemsSection.PsychItems.Add (
                    "She indicated that there is some likelihood that she might harm or neglect someone else. Additional assessment is needed to determine if the other parties should be informed or protected." );
                criticalItemsSection.PsychItems.Add (
                    "Jane indicated that there is some likelihood that she might be hurt or victimized by someone else. Additional assessment is needed to determine the nature and extent of the threat. Once completed, this assessment will help to determine the extent of needed protective measures, if any." );
                criticalItemsSection.PsychItems.Add (
                    "Jane has reported seeing, hearing, smelling or feeling things that were not there within the past 24 hours." );
                assessmentReport.CriticalItemsSection = criticalItemsSection;

                // Dimensional Analysis
                var daSection = new DimensionalAnalysisSection ( );
                var locList = new List<LevelOfCareCriteria> ( )
                    {
                        null,
                        null,
                        new LevelOfCareCriteria { IsMet = true },
                        new LevelOfCareCriteria { IsMet = false },
                        new LevelOfCareCriteria { IsMet = true },
                        new LevelOfCareCriteria { IsMet = true },
                        new LevelOfCareCriteria { IsMet = false },
                        new LevelOfCareCriteria { IsMet = true },
                        null,
                    };
                var daList = new List<DimensionalAnalysis> ( )
                    {
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension One",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "Her Level IV-D detoxification may be conducted in an appropriately licensed acute care setting that can provide medically directed acute detoxification and related treatment aimed at alleviating acute emotional, behavioral, cognitive or biomedical distress resulting from the patient's use of alcohol or other drugs. One example of such a setting would be a psychiatric hospital inpatient unit."
                            },
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension Two",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "The PPC has no Dimension 2 information to report regarding Jane Jones."
                            },
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension Three",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "In Dimension 3, her needs regarding emotional, behavioral or cognitive conditions and complications can be met at multiple levels, including Level IV-DDE, Level III.7-DDE, Level II.1-DDE, Level II.1-DDC, and Opioid Maintenance Therapy."
                            },
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension Four",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "In Dimension 4, the patient's needs regarding readiness to change can be met at multiple levels, including Level I, Level II.1, Level II.5, and Opioid Maintenance Therapy."
                            },
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension Five",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "In Dimension 5, the patient's needs regarding relapse, continued use or continued problem potential can be met at multiple levels, including Level I, Level III.1, Level III.3, Level III.5, Level III.7, and Opioid Maintenance Therapy."
                            },
                        new DimensionalAnalysis
                            {
                                DimensionTitle = "Dimension Six",
                                LevelsOfCareMet = locList,
                                DimensionSummary =
                                    "In Dimension 6, Jane's needs regarding recovery environment can be met at multiple levels, including Level II.1, Level II.5, Level III.3, Level III.5, Level III.7, and Opioid Maintenance Therapy."
                            },
                    };
                daSection.DimensionalAnalyses = daList;
                assessmentReport.DimensionalAnalysisSection = daSection;


                //access to treatment issues
                var accessSection = new AccessToTreatmentIssuesSection ( );
                accessSection.AccessSummary = "The following items related to access to treatment were noted while completing this assessment:";
                var accessItems = new List<string>
                    {
                        "She has indicated that she is unsteady on her feet, problems with walking or balance, such that she could easily fall or have trouble getting around or using stairs.",
                        "She does not have a valid driver's license.",
                        "The patient states she is currently on probation or parole.",
                        "Jane is presently awaiting charges, trial or criminal sentencing.",
                        "The clinician deduced from the interview or has information that indicates that the patient's current behavior may be inconsistent with reliable self-care, safety, or an ability to participate effectively in treatment."
                    };
                accessSection.AccessItems = accessItems;
                assessmentReport.AccessToTreatmentIssuesSection = accessSection;


                //Final Level of care
                var finalLoc = new FinalLevelOfCareSection ( );
                finalLoc.CareSummary =
                    "The patient should be considered for multiple levels of care. The treatment team should consider her history carefully and place the patient in the level of care that best suits her presentation. The PPC-2R may resolve a patient to multiple levels of care when a patient has disparate needs in different areas, or when the PPC-2R suggests different treatment approaches. Potential levels of care are:";
                var locItems = new List<string>
                    {
                        "The patient requires initial treatment in a Level IV-D -- medically managed intensive inpatient detoxification program.",
                        "Jane requires initial treatment in a Level IV program.",
                        "Jane Jones should be considered for treatment in a Level II.5, partial hospitalization treatment program.",
                        "The patient should be considered for treatment in a Level II.1 -- intensive outpatient treatment program."
                    };
                finalLoc.RecommendedLevelsOfCare = locItems;
                finalLoc.NotAcceptableSummary = "The patient met criteria for placement in Levels III.1, IV, but she indicated that these levels would be unacceptable to her for treatment.";
                locItems = new List<string>
                    {
                        "Level_ID",
                        "Level_III",
                        "Level_IV"
                    };
                finalLoc.NotAcceptableLevelsOfCare = locItems;
                assessmentReport.FinalLevelOfCareSection = finalLoc;

                assessmentReport.WithdrawalScalesSection = new WithdrawalScalesSection
                    {
                        WithdrawalSummary = "The CIWA-Ar alcohol and sedative withdrawal scale is 15, indicating moderate withdrawal. The modified Clinical Institute Narcotic Assessment Scale (CINA-M) opiate withdrawal scale is 13 on a scale of 0 to 35."
                    };

               
                return assessmentReport;
            }
        }
    }
}
