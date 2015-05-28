
$(document).ready(function () {
    $.rules = {
        init: false,
        changeSelector: "",
        Initialize: function (form) {
            $.rules.init = false;
            $.rules.changeSelector = "";
            var section = $('#sectionWrapper').prop('class');
            var subSection = $('#subSectionWrapper').prop('class');
            var rulesContainer = $.rules[section];
            if (subSection != null && subSection != "" && rulesContainer != undefined) {
                rulesContainer = rulesContainer[subSection];
            }
            if (rulesContainer != undefined) {
                for (var ruleName in rulesContainer) {
                    var rule = rulesContainer[ruleName];
                    if (typeof rule === 'function') {
                        rule();
                    }
                }
            }
            
            form.on('change', $.rules.changeSelector, function (e) {
                var idRule = this.id + "Rules",
                    nameRule = this.name + "Rules";
                var rule = rulesContainer[idRule];
                if (typeof rule === 'function') {
                    rule();
                    return;
                }
                rule = rulesContainer[nameRule];
                if (typeof rule === 'function') {
                    rule();
                }
            });
            
            $.rules.init = true;
            $.rules.changeSelector = "";
        },
        Utilities: {
            ConvertTimeMeasureToDays: function (id) {
                var frequency;
                var timeMeasure = {
                    Value: $("#" + id + "_Value").val(),
                    UnitOfTime: $("#" + id + "_UnitOfTime").val()
                };
                switch (timeMeasure.UnitOfTime) {
                    case "Hours": frequency = 0.0417 * timeMeasure.Value;
                        break;
                    case "Days": frequency = 1.0 * timeMeasure.Value;
                        break;
                    case "Weeks": frequency = 7.0 * timeMeasure.Value;
                        break;
                    case "Months": frequency = 30.0 * timeMeasure.Value;
                        break;
                    case "Years": frequency = 365.0 * timeMeasure.Value;
                        break;
                    case "Decades": frequency = 3652.5 * timeMeasure.Value;
                        break;
                    default:
                        frequency = undefined;
                        break;
                }
                return frequency;
            },
            AddSelector: function(selector) {
                if ($.rules.changeSelector && $.rules.changeSelector.length > 0) {
                    $.rules.changeSelector = $.rules.changeSelector + "," + selector;
                } else {
                    $.rules.changeSelector = selector;
                }
            }
        },
        GeneralInformationSection: {
            PatientInControlledEnvironmentLast30DaysRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#PatientInControlledEnvironmentLast30Days");
                }
                var val = $("#PatientInControlledEnvironmentLast30Days").val();
                if (val == undefined || val == "" || val == "None") {
                    $("#NumberOfDaysInControlledEnvironmentInPast30Days").val("").trigger("change")
                                                                         .closest('.question-root').hide();
                }
                else {
                    $("#NumberOfDaysInControlledEnvironmentInPast30Days").closest('.question-root').show();
                }
                if (val == "OtherControlledEnvironment") {
                    $("#ControlledEnvironmentOtherDescription").closest('.question-root').show();
                }
                else {
                    $("#ControlledEnvironmentOtherDescription").val("").trigger("change")
                                                               .closest('.question-root').hide();
                }
            }
        },
        MedicalSection: {
            MedicalProblemsRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="MedicalProblems"]');
                }
                var val = undefined;
                $('[name="MedicalProblems"]').each(function () {
                    val = $(this).prop('checked');
                    if (val != undefined) {
                        return false;
                    }
                });
                if (val == undefined || val == "") {
                    $("#MedicalProblemDescription").val("").trigger("change")
                                                   .closest('.question-root').hide();
                }
                else {
                    $("#MedicalProblemDescription").closest('.question-root').show();
                }
            },
            TimesHospitalizedForMedicalProblemsRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#TimesHospitalizedForMedicalProblems");
                }
                var val = $("#TimesHospitalizedForMedicalProblems").val();
                if (val > 0) {
                    $("#MonthsSinceLastHospitalizationForPhysicalProblem_Year").closest('.question-root').show();
                }
                else {
                    $("#MonthsSinceLastHospitalizationForPhysicalProblem_Year").val("").trigger("change").closest('.question-root').hide();
                    $("#MonthsSinceLastHospitalizationForPhysicalProblem_Month").val("").trigger("change");
                }
            },
            HasChronicMedicalProblemsThatInterfereWithLifeRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="HasChronicMedicalProblemsThatInterfereWithLife"]');
                }
                var val = $('[name="HasChronicMedicalProblemsThatInterfereWithLife"]').prop('checked');
                if (val == undefined || !val) {
                    $("#ChronicMedicalProblemsThatInterfereWithLifeDescription").val("").trigger("change").closest('.question-root').hide();
                }
                else {
                    $("#ChronicMedicalProblemsThatInterfereWithLifeDescription").closest('.question-root').show();
                }
            },
            MedicalSectionGenderRules: function () {
                var val = $("#patient_Gender_Code").val();
                if (val == "Male") {
                    $("#PregnantStatus").val("No").trigger("change").closest('.question-root').hide();
                }
                else {
                    $("#PregnantStatus").closest('.question-root').show();
                }
            },
            PregnantStatusRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#PregnantStatus");
                }
                var val = $('#PregnantStatus').value;
                if (val == "Yes") {
                    $("#HighRiskPregnancyStatus").closest('.question-root').show();
                } else {
                    $("#HighRiskPregnancyStatus").val("").trigger("change").closest('.question-root').hide();
                }
            },
            IsTakingPrescriptionMedicineRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="IsTakingPrescriptionMedicine"]');
                }
                var val = $('[name="IsTakingPrescriptionMedicine"]').prop('checked');
                if (val == undefined || !val) {
                    $("#PrescriptionMedicineDescription").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#PrescriptionMedicineDescription").closest('.question-root').show();
                }
            },
            ReceivesPensionForPhysicalDisabilityRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="ReceivesPensionForPhysicalDisability"]');
                }
                var val = $('[name="ReceivesPensionForPhysicalDisability"]').prop('checked');
                if (val == undefined || !val) {
                    $("#DescriptionOfPhysicalDisabilityPension").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#DescriptionOfPhysicalDisabilityPension").closest('.question-root').show();
                }
            },
            NumberOfDaysWithMedicalProblemsInPast30DaysRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#NumberOfDaysWithMedicalProblemsInPast30Days");
                }
                var val = $('#NumberOfDaysWithMedicalProblemsInPast30Days').val();
                if (val <= 0) {
                    $("#DescriptionOfMedicalProblemsInPast30Days").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#DescriptionOfMedicalProblemsInPast30Days").closest('.question-root').show();
                }
            },
            SeizureInPast24HoursRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#SeizureInPast24Hours");
                }
                var val = $('#SeizureInPast24Hours').val();
                if (val != "Yes") {
                    $("#MultipleSeizuresInPast24Hours").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#MultipleSeizuresInPast24Hours").closest('.question-root').show();
                    }
            },
            MultipleSeriousMedicalProblemsExistRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#MultipleSeriousMedicalProblemsExist");
                }
                var val = $('#MultipleSeriousMedicalProblemsExist').val();
                if (val == undefined || val == "" || val == "No") {
                    $("#LevelOfConcernInPast30DaysAboutMedicalProblems").val("").trigger("change").closest('.question-root').hide();
                    $("#ImportanceOfTreatmentForMedicalProblems").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#LevelOfConcernInPast30DaysAboutMedicalProblems").closest('.question-root').show();
                    $("#ImportanceOfTreatmentForMedicalProblems").closest('.question-root').show();
                    }
            },
            RequiresMedicalMonitoringForReemergenceOfSymptomsRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="RequiresMedicalMonitoringForReemergenceOfSymptoms"]');
                }
                var val = $('[name="RequiresMedicalMonitoringForReemergenceOfSymptoms"]').prop('checked');
                if (val == undefined || !val) {
                    $("#DescriptionOfReemergentSymptoms").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#DescriptionOfReemergentSymptoms").closest('.question-root').show();
                }
            }
        },
        EmploymentAndSupportSection: {
            HasProfessionalTradeOrSkillRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="HasProfessionalTradeOrSkill"]');
                }
                var val = $('[name="HasProfessionalTradeOrSkill"]').prop('checked');
                if (val == undefined || !val) {
                    $("#ProfessionalTradeOrSkillDescription").val("").trigger("change").closest('.question-root').hide();
                } else {
                    $("#ProfessionalTradeOrSkillDescription").closest('.question-root').show();
                    }
            },
            ReceivesFinancialSupportFromOtherPersonRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="ReceivesFinancialSupportFromOtherPerson"]');
                }
                var val = $('[name="ReceivesFinancialSupportFromOtherPerson"]').prop('checked');
                if (val == undefined || !val) {
                    $("#ReceivesMajorityOfFinancialSupportFromOtherPerson").closest('.question-root').hide();
                    $('[name="ReceivesMajorityOfFinancialSupportFromOtherPerson"]').prop('checked', false).trigger("change");
                } else {
                    $("#ReceivesMajorityOfFinancialSupportFromOtherPerson").closest('.question-root').show();
                    }
            },
            AmountOfMoneyInPast30DaysFromEmploymentRules: function () {
                if (!$.rules.init) {
                    $('#NumberOfDaysWorkingInPast30Days').change(function () { $('#NumberOfDaysWorkingInPast30Days').valid(); });
                    $('#AmountOfMoneyInPast30DaysFromEmployment_Amount').keyup($.rules.EmploymentAndSupportSection.AmountOfMoneyInPast30DaysFromEmploymentRules);
                }
                var val = $('#AmountOfMoneyInPast30DaysFromEmployment_Amount').val();
                if (val > 0) {
                    $('#NumberOfDaysWorkingInPast30Days').prop('min', 1);
                    $('#NumberOfDaysWorkingInPast30Days').valid();
                } else {
                    $('#NumberOfDaysWorkingInPast30Days').prop('min', 0);
                }
            }
        },
        DrugAndAlcoholSection: {
            UsedSubstances: {
                SubstanceHasEverUsedRules: function () {
                    if (!$.rules.init) {
                        // if nohistory is checked, uncheck all the checkboxes
                        $("#SubstanceHasEverUsed_NoHistory").change(function () {
                            if ($(this).prop('checked')) {
                                $('[name="SubstanceHasEverUsed"]:not(#SubstanceHasEverUsed_NoHistory)').each(function() {
                                    $(this).prop('checked', false);
                                });
                            }
                        });

                        // if any checkbox but nohistory is checked, uncheck nohistory
                        $('[name="SubstanceHasEverUsed"]:not(#SubstanceHasEverUsed_NoHistory)').change(function () {
                            if ($(this).prop('checked')) {
                                $("#SubstanceHasEverUsed_NoHistory").prop('checked', false);
                            }
                        });

                        $.rules.Utilities.AddSelector('[name="SubstanceHasEverUsed"]');
                    }
                }
            },
            AlcoholUse: {
                LastUsedRules: function() {
                    if (!$.rules.init) {
                        $("#LastUsed_Value").change($.rules.DrugAndAlcoholSection.AlcoholUse.LastUsedRules);
                        $("#LastUsed_UnitOfTime").change($.rules.DrugAndAlcoholSection.AlcoholUse.LastUsedRules);
                        $.rules.Utilities.AddSelector('[name="LastUsed"]');
                    }

                    var lastUsedAlcohol = $.rules.Utilities.ConvertTimeMeasureToDays("LastUsed");
                    if (lastUsedAlcohol > 30) {
                        $("#NumberOfDaysUsedInPast30Days").closest('.question-root').hide();
                    } else {
                        $("#NumberOfDaysUsedInPast30Days").closest('.question-root').show();
                    }
                },
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                LastUsedToIntoxificationRules: function () {
                    if (!$.rules.init) {
                        $("#LastUsedToIntoxification_Value").change(function () { $("#LastUsedToIntoxification_Value").valid(); });
                        $("#LastUsedToIntoxification_UnitOfTime").change(function () { $("#LastUsedToIntoxification_Value").valid(); });
                        $("#LastUsed_Value").change(function () { $("#LastUsedToIntoxification_Value").valid(); });
                        $("#LastUsed_UnitOfTime").change(function () { $("#LastUsedToIntoxification_Value").valid(); });
                        $.validator.addMethod("lastusedintox", function () {
                            var val = $.rules.Utilities.ConvertTimeMeasureToDays("LastUsedToIntoxification");
                            var lastUsedAlcohol = $.rules.Utilities.ConvertTimeMeasureToDays("LastUsed");
                            if (val < lastUsedAlcohol) {
                                return false;
                            }
                            return true;
                        }, "Last use of Alcohol to Intoxication cannot be less than Last Use of Alcohol.");
                        $.validator.addClassRules({
                            lastusedintox: { lastusedintox: true }
                        });
                    }
                },
                AlcoholUsedToIntoxicationRules: function () {
                    if (!$.rules.init) {
                        $("#LastUsedToIntoxification_Value").prop('data-val', false);
                        $("#LastUsedToIntoxification_UnitOfTime").prop('data-val', false);
                        $.rules.Utilities.AddSelector('[name="AlcoholUsedToIntoxication"]');
                    }
                    var val = $('[name="AlcoholUsedToIntoxication"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#LastUsedToIntoxification_Value").prop('disabled', true)
                            .removeClass("lastusedintox")
                            .val("").trigger("change")
                            .closest('.question-root').hide();
                        $("#LastUsedToIntoxification_UnitOfTime").val("").trigger("change");
                        $("#NumberOfDaysIntoxicatedInPast30Days").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfMonthsAsAlcoholConsumerToIntoxication_Year").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfMonthsAsAlcoholConsumerToIntoxication_Month").val("").trigger("change");
                        $("#AlcoholToIntoxicationRouteOfIntake").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#LastUsedToIntoxification_Value").prop('disabled', false).addClass("lastusedintox").closest('.question-root').show();
                        $("#LastUsedToIntoxification_UnitOfTime").prop('disabled', false);
                        $("#NumberOfDaysIntoxicatedInPast30Days").closest('.question-root').show();
                        $("#NumberOfMonthsAsAlcoholConsumerToIntoxication_Year").closest('.question-root').show();
                        $("#AlcoholToIntoxicationRouteOfIntake").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            HeroinUse: {
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            MethadoneUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            OtherOpiateUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            OpioidMaintenanceTherapy: {
                OpioidMaintenanceTherapyReadmissionMedicallyIndicatedRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="OpioidMaintenanceTherapyReadmissionMedicallyIndicated"]');
                    }
                    var val = $('[name="OpioidMaintenanceTherapyReadmissionMedicallyIndicated"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#PhysicianReasonsForOpioidMaintenanceTherapyReadmission").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#PhysicianReasonsForOpioidMaintenanceTherapyReadmission").closest('.question-root').show();
                    }
                }
            },
            BarbiturateUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            OtherSedativeUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            CocaineUse: {
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            StimulantUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            CannabisUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            HallucinogenUse: {
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            SolventAndInhalantUse: {
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            MultipleSubstanceUsePerDay: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                }
            },
            NicotineUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            OtherSubstanceUse: {
                HasHealthCareProviderPrescribedUseRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="HasHealthCareProviderPrescribedUse"]');
                    }
                    var val = $('[name="HasHealthCareProviderPrescribedUse"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#WasSubstanceTakenAsPrescribed").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WasSubstanceTakenAsPrescribed").closest('.question-root').show();
                        }
                },
                ExperiencesWithdrawalSicknessRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="ExperiencesWithdrawalSickness"]');
                    }
                    var val = $('[name="ExperiencesWithdrawalSickness"]').prop('checked');
                    if (val == undefined || !val) {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').prop('checked', false).trigger("change").closest('.question-root').hide();
                    } else {
                        $('[name="UseSubstanceToPreventWithdrawalSickness"]').closest('.question-root').show();
                        }
                }
            },
            AddictionTreatmentHistory: {
                PreviousSubstanceUseTreatmentRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#PreviousSubstanceUseTreatment");
                    }
                    var val = $("#PreviousSubstanceUseTreatment").val();
                    if (val == undefined || val == "" || val == "No") {
                        $("#NumberOfTimesTreatedForAlcoholAbuseLifetime").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfTimesDrugTreatmentLifetime").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime").val("").trigger("change").closest('.question-root').hide();
                        $("#UsuallyLeftDetoxificationBeforeAdvised").closest('.question-root').hide();
                        $('[name="UsuallyLeftDetoxificationBeforeAdvised"]').prop('checked', false).trigger("change");
                        $("#UsuallyEnteredContinuedTreatmentAfterDetoxification").closest('.question-root').hide();
                        $('[name="UsuallyEnteredContinuedTreatmentAfterDetoxification"]').prop('checked', false).trigger("change");
                        $("#NumberOfDaysOutpatientTreatmentInPast30Days").val("").trigger("change").closest('.question-root').hide();
                        $("#HighestCareLevelFailedFromInPast90Days").val("").trigger("change").closest('.question-root').hide();
                        $("#MostRecentCareLevelCompleted").val("").trigger("change").closest('.question-root').hide();
                    }
                    else if (val == "AlcoholOnly") {
                        $("#NumberOfTimesTreatedForAlcoholAbuseLifetime").closest('.question-root').show();
                        $("#NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime").closest('.question-root').show();
                        $("#NumberOfTimesDrugTreatmentLifetime").closest('.question-root').hide();
                        $("#NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime").closest('.question-root').hide();
                        $("#UsuallyLeftDetoxificationBeforeAdvised").closest('.question-root').show();
                        $("#UsuallyEnteredContinuedTreatmentAfterDetoxification").closest('.question-root').show();
                        $("#NumberOfDaysOutpatientTreatmentInPast30Days").closest('.question-root').show();
                        $("#HighestCareLevelFailedFromInPast90Days").closest('.question-root').show();
                        $("#MostRecentCareLevelCompleted").closest('.question-root').show();
                        }
                    else if (val == "DrugOnly") {
                        $("#NumberOfTimesTreatedForAlcoholAbuseLifetime").closest('.question-root').hide();
                        $("#NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime").closest('.question-root').hide();
                        $("#NumberOfTimesDrugTreatmentLifetime").closest('.question-root').show();
                        $("#NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime").closest('.question-root').show();
                        $("#UsuallyLeftDetoxificationBeforeAdvised").closest('.question-root').show();
                        $("#UsuallyEnteredContinuedTreatmentAfterDetoxification").closest('.question-root').show();
                        $("#NumberOfDaysOutpatientTreatmentInPast30Days").closest('.question-root').show();
                        $("#HighestCareLevelFailedFromInPast90Days").closest('.question-root').show();
                        $("#MostRecentCareLevelCompleted").closest('.question-root').show();
                        }
                    else {
                        $("#NumberOfTimesTreatedForAlcoholAbuseLifetime").closest('.question-root').show();
                        $("#NumberOfTimesAlcoholTreatmentDetoxificationOnlyLifetime").closest('.question-root').show();
                        $("#NumberOfTimesDrugTreatmentLifetime").closest('.question-root').show();
                        $("#NumberOfTimesDrugTreatmentDetoxificationOnlyLifetime").closest('.question-root').show();
                        $("#UsuallyLeftDetoxificationBeforeAdvised").closest('.question-root').show();
                        $("#UsuallyEnteredContinuedTreatmentAfterDetoxification").closest('.question-root').show();
                        $("#NumberOfDaysOutpatientTreatmentInPast30Days").closest('.question-root').show();
                        $("#HighestCareLevelFailedFromInPast90Days").closest('.question-root').show();
                        $("#MostRecentCareLevelCompleted").closest('.question-root').show();
                        }
                }
            },
            AdditionalAddictionAndTreatmentItems: {
                WhichSubstanceIsMajorProblemRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#WhichSubstanceIsMajorProblem");
                    }
                    var val = $("#WhichSubstanceIsMajorProblem").val();
                    if (val == undefined || val == "" || val == "NoProblem") {
                        $("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Year").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Month").val("").trigger("change");
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Year").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Monh").val("").trigger("change");
                        $("#NumberOfTimesOverdosedOnDrugs").val("").trigger("change").closest('.question-root').hide();
                    }
                    else {
                        $("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Year").closest('.question-root').show();
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Year").closest('.question-root').show();
                        $("#NumberOfTimesOverdosedOnDrugs").closest('.question-root').show();
                        }
                },
                NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstanceRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Year");
                        $.rules.Utilities.AddSelector("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Month");
                    }
                    var year = $("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Year").val();
                    var month = $("#NumberOfMonthsSinceLastVoluntaryAbstinenceFromSubstance_Month").val();
                    if (year == 0 && month == 0) {
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Year").val("").trigger("change").closest('.question-root').hide();
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Month").val("").trigger("change");
                    } else {
                        $("#NumberOfMonthsSinceAbstinenceEndFromSubstance_Year").closest('.question-root').show();
                    }
                },
                NumberOfTimesOverdosedOnDrugsRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#NumberOfTimesOverdosedOnDrugs");
                    }
                    var val = $("#NumberOfTimesOverdosedOnDrugs").val();
                    if (val > 0) {
                        $("#SubstanceOverdoseInPast24Hours").closest('.question-root').show();
                        }
                    else {
                        $("#SubstanceOverdoseInPast24Hours").val("").trigger("change").closest('.question-root').hide();
                    }
                }
            },
            AlcoholAndDrugInterviewerRating: {
                PatientManifestingSeriousRelapseBehaviorsRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="PatientManifestingSeriousRelapseBehaviors"]');
                    }
                    var val = $('[name="PatientManifestingSeriousRelapseBehaviors"]').prop('checked');
                    if (val == undefined || !val) {
                        $("#PatientManifestingSeriousRelapseBehaviorDescription").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#PatientManifestingSeriousRelapseBehaviorDescription").closest('.question-root').show();
                    }
                }
            },
            InterviewerEvaluation: {
                SubstanceHasEverUsedRules: function () {
                    if (!$.rules.init) {
                        $(".InterviewerEvaluation_HiddenQuestions").hide();
                        }
                    if ($('#SubstanceHasEverUsed_Methadone').prop('checked') && $('#MethadoneHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedMethadoneDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedMethadoneDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_OtherOpiate').prop('checked') && $('#OtherOpiateHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedOtherOpiatesDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedOtherOpiatesDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_Barbiturates').prop('checked') && $('#BarbituratesHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedBarbituatesDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedBarbituatesDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_OtherSedatives').prop('checked') && $('#OtherSedativesHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedSedativeDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedSedativeDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_Stimulants').prop('checked') && $('#StimulantsHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedStimulantDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedStimulantDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_Nicotine').prop('checked') && $('#NicotineHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedNicotineDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedNicotineDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                    if ($('#SubstanceHasEverUsed_OtherSubstance').prop('checked') && $('#OtherSubstanceHasHealthCareProviderPrescribedUse').val() == "True") {
                        $("#HasMaintainedOtherDrugDoseAtTherapeuticLevels").closest('.question-root').show();
                        }
                    else {
                        $("#HasMaintainedOtherDrugDoseAtTherapeuticLevels").closest('.question-root').hide();
                        }
                }
            }
        },
        LegalSection: {
            NumberOfTimesConvictedRules: function () {
                if (!$.rules.init) {
                    $('#NumberOfTimesArrestedForArson').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForAssault').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForBurglaryLarceny').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForContemptOfCourt').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForDrugCharges').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForForgery').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForHomicide').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForOtherArrest').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForParoleProbationViolation').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForProstitution').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForRape').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForRobbery').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $('#NumberOfTimesArrestedForShopliftingVandalism').change($.rules.LegalSection.NumberOfTimesConvictedRules);
                    $.rules.Utilities.AddSelector('#NumberOfTimesConvicted');
                    $('#NumberOfTimesConvicted').addClass('numberconvicted');
                    $.validator.addMethod("numberconvicted", function () {
                        var sum = ($('#NumberOfTimesArrestedForArson').valInt() +
                                   $('#NumberOfTimesArrestedForAssault').valInt() +
                                   $('#NumberOfTimesArrestedForBurglaryLarceny').valInt() +
                                   $('#NumberOfTimesArrestedForContemptOfCourt').valInt() +
                                   $('#NumberOfTimesArrestedForDrugCharges').valInt() +
                                   $('#NumberOfTimesArrestedForForgery').valInt() +
                                   $('#NumberOfTimesArrestedForHomicide').valInt() +
                                   $('#NumberOfTimesArrestedForOtherArrest').valInt() +
                                   $('#NumberOfTimesArrestedForParoleProbationViolation').valInt() +
                                   $('#NumberOfTimesArrestedForProstitution').valInt() +
                                   $('#NumberOfTimesArrestedForRape').valInt() +
                                   $('#NumberOfTimesArrestedForRobbery').valInt() +
                                   $('#NumberOfTimesArrestedForShopliftingVandalism').valInt());
                        var val = $('#NumberOfTimesConvicted').valInt();
                        if (val > sum) {
                            return false;
                        }
                        return true;
                    }, "Number of times convicted cannot be greater than total number of times arrested above.");
                    $.validator.addClassRules({
                        numberconvicted: { numberconvicted: true }
                    });
                }
                if ($('#NumberOfTimesArrestedForArson').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForAssault').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForBurglaryLarceny').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForContemptOfCourt').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForDrugCharges').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForForgery').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForHomicide').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForOtherArrest').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForParoleProbationViolation').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForProstitution').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForRape').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForRobbery').valInt() > 0 ||
                    $('#NumberOfTimesArrestedForShopliftingVandalism').valInt() > 0) {
                    $('#NumberOfTimesConvicted').closest('.question-root').show();
                    }
                else {
                    $('#NumberOfTimesConvicted').val("").trigger("change").closest('.question-root').hide();
                }
                $('#NumberOfTimesConvicted').valid();
            },
            NumberOfMonthsIncarceratedInLifeRules: function () {
                if (!$.rules.init) {
                    $("#NumberOfMonthsIncarceratedInLife_Year").change($.rules.LegalSection.NumberOfMonthsIncarceratedInLifeRules);
                    $("#NumberOfMonthsIncarceratedInLife_Month").change($.rules.LegalSection.NumberOfMonthsIncarceratedInLifeRules);
                }
                var year = $('#NumberOfMonthsIncarceratedInLife_Year').valInt();
                var month = $('#NumberOfMonthsIncarceratedInLife_Month').valInt();
                if (year > 0 || month > 0) {
                    $('#LengthInMonthsOfLastIncarceration_Year').closest('.question-root').show();
                    }
                else {
                    $('#LengthInMonthsOfLastIncarceration_Year').val("").closest('.question-root').hide();
                    $('#LengthInMonthsOfLastIncarceration_Month').val("").trigger("change");
                }
            },
            LengthInMonthsOfLastIncarcerationRules: function () {
                if (!$.rules.init) {
                    $("#LengthInMonthsOfLastIncarceration_Year").change($.rules.LegalSection.LengthInMonthsOfLastIncarcerationRules);
                    $("#LengthInMonthsOfLastIncarceration_Month").change($.rules.LegalSection.LengthInMonthsOfLastIncarcerationRules);
                }
                var year = $('#LengthInMonthsOfLastIncarceration_Year').valInt();
                var month = $('#LengthInMonthsOfLastIncarceration_Month').valInt();
                if (year > 0 || month > 0) {
                    $('#LastIncarcerationReason').closest('.question-root').show();
                    }
                else {
                    $('#LastIncarcerationReason').val("").trigger("change").closest('.question-root').hide();
                }
            },
            IsCurrentlyAwaitingChargesTrialSentenceRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector('[name="IsCurrentlyAwaitingChargesTrialSentence"]');
                }
                var val = $('#IsCurrentlyAwaitingChargesTrialSentence').prop("checked");
                if (val == undefined || !val) {
                    $('#CurrentlyAwaitingChargesTrialSentenceForLegalCharge').val("").trigger("change").closest('.question-root').hide();
                }
                else {
                    $('#CurrentlyAwaitingChargesTrialSentenceForLegalCharge').closest('.question-root').show();
                    }
            }
        },
        FamilyAndSocialHistorySection: {
            SignificantProblemsWithRules: function () {
                if (!$.rules.init) {
                    $('#HadProblemsInLifetimeWithMother').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithFather').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithSibling').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithSexPartner').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithChildren').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithOtherFamily').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithCloseFriends').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithNeighbors').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                    $('#HadProblemsInLifetimeWithCoworkers').change($.rules.FamilyAndSocialHistorySection.SignificantProblemsWithRules);
                }
                var shouldShowMonthGroup = false;
                if ($('#HadProblemsInLifetimeWithMother').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithMother').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithMother').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithFather').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithFather').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithFather').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithSibling').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithSibling').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithSibling').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithSexPartner').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithSexPartner').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithSexPartner').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithChildren').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithChildren').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithChildren').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithOtherFamily').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithOtherFamily').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithOtherFamily').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithCloseFriends').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithCloseFriends').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithCloseFriends').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithNeighbors').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithNeighbors').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithNeighbors').val("").trigger("change").closest('.question-root').hide();
                }
                if ($('#HadProblemsInLifetimeWithCoworkers').val() == "Yes") {
                    $('#HadProblemsInPastMonthWithCoworkers').closest('.question-root').show();
                    shouldShowMonthGroup = true;
                }
                else {
                    $('#HadProblemsInPastMonthWithCoworkers').val("").trigger("change").closest('.question-root').hide();
                }
                if (shouldShowMonthGroup) {
                    $('.FamilyAndSocialHistorySection_PastMonthHeader').show();
                } else {
                    $('.FamilyAndSocialHistorySection_PastMonthHeader').hide();
                }
            },
            HasRecentlyNeglectedOrAbusedFamilyMembersRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#HasRecentlyNeglectedOrAbusedFamilyMembers");
                }
                var val = $("#HasRecentlyNeglectedOrAbusedFamilyMembers").val();
                if (val == undefined || val == "" || val == "NotAtAll") {
                    $("#NeglectedOrAbusedFamilyMembersDuringSubstanceUse").closest('.question-root').hide();
                    $('[name="NeglectedOrAbusedFamilyMembersDuringSubstanceUse"]').prop('checked', false).trigger("change");
                    $("#FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II").val("").trigger("change").closest('.question-root').hide();
                    $('.FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II .ui-scale-option').removeClass("ui-scale-active");
                } else {
                    $("#NeglectedOrAbusedFamilyMembersDuringSubstanceUse").closest('.question-root').show();
                    $("#FamilyNeglectOrAbuseWillWorsenWithoutGreaterThanCareLevel_II").closest('.question-root').show();
                    }
            },
            HowLikelyToCauseHarmNeglectOthersRules: function () {
                if (!$.rules.init) {
                    $.rules.Utilities.AddSelector("#HowLikelyToCauseHarmNeglectOthers");
                    $("#RiskPatientHarmedByOther").change($.rules.FamilyAndSocialHistorySection.HowLikelyToCauseHarmNeglectOthersRules);
                }
                var val = $("#HowLikelyToCauseHarmNeglectOthers").val();
                var val2 = $("#RiskPatientHarmedByOther").val();
                if ((val == undefined || val == "" || val == "NotAtAll") && (val2 == undefined || val2 == "" || val2 == "NotAtAll")) {
                    $("#RiskPatientHarmedByOtherOnlyDuringSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    $('.RiskPatientHarmedByOtherOnlyDuringSubstanceUse .ui-scale-option').removeClass("ui-scale-active");
                } else {
                    $("#RiskPatientHarmedByOtherOnlyDuringSubstanceUse").closest('.question-root').show();
                    }
            }
        },
        PsychologicalSection: {
            PsychologicalHistory: {
                SignificantPeriodOfSeriousDepressionInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodOfSeriousDepressionInLifetime");

                    }
                    var val = $("#SignificantPeriodOfSeriousDepressionInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodOfSeriousDepressionInLastMonth").val("").trigger("change")
                                                                             .closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodOfSeriousDepressionInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodOfSeriousDepressionInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodOfSeriousDepressionInLastMonth");
                    }
                    var val = $("#SignificantPeriodOfSeriousDepressionInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodOfSeriousDepressionInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodOfSeriousDepressionInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodOfSeriousDepressionInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodOfSeriousDepressionInLast24Hours");
                    }
                    var val = $("#SignificantPeriodOfSeriousDepressionInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#DepressionWithin24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#DepressionWithin24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                InabilityToFeelPleasureFromActivitiesInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#InabilityToFeelPleasureFromActivitiesInLifetime");
                    }
                    var val = $("#InabilityToFeelPleasureFromActivitiesInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#InabilityToFeelPleasureFromActivitiesInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#InabilityToFeelPleasureFromActivitiesInLastMonth").closest('.question-root').show();
                    }
                },
                InabilityToFeelPleasureFromActivitiesInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#InabilityToFeelPleasureFromActivitiesInLastMonth");
                    }
                    var val = $("#InabilityToFeelPleasureFromActivitiesInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#InabilityToFeelPleasureFromActivitiesInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#InabilityToFeelPleasureFromActivitiesInLast24Hours").closest('.question-root').show();
                    }
                },
                InabilityToFeelPleasureFromActivitiesInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#InabilityToFeelPleasureFromActivitiesInLast24Hours");
                    }
                    var val = $("#InabilityToFeelPleasureFromActivitiesInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#InabilityToFeelPleasureFromActivitiesRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                PoorAppetiteOrOvereatingInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#PoorAppetiteOrOvereatingInLifetime");
                    }
                    var val = $("#PoorAppetiteOrOvereatingInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#PoorAppetiteOrOvereatingInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#PoorAppetiteOrOvereatingInLastMonth").closest('.question-root').show();
                    }
                },
                PoorAppetiteOrOvereatingInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#PoorAppetiteOrOvereatingInLastMonth");
                    }
                    var val = $("#PoorAppetiteOrOvereatingInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#PoorAppetiteOrOvereatingInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#PoorAppetiteOrOvereatingInLast24Hours").closest('.question-root').show();
                    }
                },
                PoorAppetiteOrOvereatingInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#PoorAppetiteOrOvereatingInLast24Hours");
                    }
                    var val = $("#PoorAppetiteOrOvereatingInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#PoorAppetiteOrOvereatingInLast24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#PoorAppetiteOrOvereatingInLast24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                FeelLikeFailureInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#FeelLikeFailureInLifetime");
                    }
                    var val = $("#FeelLikeFailureInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#FeelLikeFailureInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                                             .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#FeelLikeFailureInLastMonth").closest('.question-root').show();
                    }
                },
                FeelLikeFailureInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#FeelLikeFailureInLastMonth");
                    }
                    var val = $("#FeelLikeFailureInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#FeelLikeFailureInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#FeelLikeFailureInLast24Hours").closest('.question-root').show();
                    }
                },
                FeelLikeFailureInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#FeelLikeFailureInLast24Hours");
                    }
                    var val = $("#FeelLikeFailureInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#FeelLikeFailureInLast24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#FeelLikeFailureInLast24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                MovingSpeakingSlowlyInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#MovingSpeakingSlowlyInLifetime");
                    }
                    var val = $("#MovingSpeakingSlowlyInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#MovingSpeakingSlowlyInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#MovingSpeakingSlowlyInLastMonth").closest('.question-root').show();
                    }
                },
                MovingSpeakingSlowlyInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#MovingSpeakingSlowlyInLastMonth");
                    }
                    var val = $("#MovingSpeakingSlowlyInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#MovingSpeakingSlowlyInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#MovingSpeakingSlowlyInLast24Hours").closest('.question-root').show();
                    }
                },
                MovingSpeakingSlowlyInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#MovingSpeakingSlowlyInLast24Hours");
                    }
                    var val = $("#MovingSpeakingSlowlyInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#MovingSpeakingSlowlyWithin24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#MovingSpeakingSlowlyWithin24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyTensionWorryInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyTensionWorryInLifetime");
                    }
                    var val = $("#AnxietyTensionWorryInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyTensionWorryInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyTensionWorryInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyTensionWorryInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyTensionWorryInLastMonth");
                    }
                    var val = $("#AnxietyTensionWorryInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyTensionWorryInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyTensionWorryInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyTensionWorryInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyTensionWorryInLast24Hours");
                    }
                    var val = $("#AnxietyTensionWorryInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyTensionWorryWithin24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyTensionWorryWithin24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackInLifetime");
                    }
                    var val = $("#AnxietyAttackInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");

                        $('fieldset.PsychologicalHistory_RegardingAnxietyAttackHeader.fieldsetgroup').hide();
                        $('fieldset.PsychologicalHistory_AttacksGiveYouHeader.fieldsetgroup').hide();

                        $('#AnxietyAttackMoreThanOnceInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackRandomInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#WorriedAboutAnxietyAttackInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackPalpitationsInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackChestPainsInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackShortnessBreathInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackChokingInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackSweatyInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackTremblingInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackNauseaDiarrheaInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackDizzinessFaintnessInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackDistortedRealityInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackNumbnessInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackChillsHotFlashesInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackLoseControlInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                        $('#AnxietyAttackDyingSensationInLifetime').val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");

                    } else {
                        $("#AnxietyAttackInLastMonth").closest('.question-root').show();

                        $('fieldset.PsychologicalHistory_RegardingAnxietyAttackHeader.fieldsetgroup').show();
                        $('fieldset.PsychologicalHistory_AttacksGiveYouHeader.fieldsetgroup').show();

                        $("#AnxietyAttackMoreThanOnceInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackRandomInLifetime").closest('.question-root').show();
                        $("#WorriedAboutAnxietyAttackInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackPalpitationsInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackChestPainsInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackShortnessBreathInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackChokingInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackSweatyInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackTremblingInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackNauseaDiarrheaInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackDizzinessFaintnessInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackDistortedRealityInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackNumbnessInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackChillsHotFlashesInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackLoseControlInLifetime").closest('.question-root').show();
                        $("#AnxietyAttackDyingSensationInLifetime").closest('.question-root').show();
                    }
                },
                AnxietyAttackInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackInLastMonth");
                    }
                    var val = $("#AnxietyAttackInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackInLast24Hours");
                    }
                    var val = $("#AnxietyAttackInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackWithin24HoursRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackWithin24HoursRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackMoreThanOnceInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackMoreThanOnceInLifetime");
                    }
                    var val = $("#AnxietyAttackMoreThanOnceInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackMoreThanOnceInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackMoreThanOnceInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackMoreThanOnceInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackMoreThanOnceInLastMonth");
                    }
                    var val = $("#AnxietyAttackMoreThanOnceInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackMoreThanOnceInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackMoreThanOnceInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackMoreThanOnceInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackMoreThanOnceInLast24Hours");
                    }
                    var val = $("#AnxietyAttackMoreThanOnceInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackMoreThanOnceRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackMoreThanOnceRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackRandomInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackRandomInLifetime");
                    }
                    var val = $("#AnxietyAttackRandomInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackRandomInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackRandomInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackRandomInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackRandomInLastMonth");
                    }
                    var val = $("#AnxietyAttackRandomInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackRandomInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackRandomInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackRandomInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackRandomInLast24Hours");
                    }
                    var val = $("#AnxietyAttackRandomInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackRandomRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackRandomRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                WorriedAboutAnxietyAttackInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#WorriedAboutAnxietyAttackInLifetime");
                    }
                    var val = $("#WorriedAboutAnxietyAttackInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#WorriedAboutAnxietyAttackInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#WorriedAboutAnxietyAttackInLastMonth").closest('.question-root').show();
                    }
                },
                WorriedAboutAnxietyAttackInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#WorriedAboutAnxietyAttackInLastMonth");
                    }
                    var val = $("#WorriedAboutAnxietyAttackInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#WorriedAboutAnxietyAttackInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#WorriedAboutAnxietyAttackInLast24Hours").closest('.question-root').show();
                    }
                },
                WorriedAboutAnxietyAttackInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#WorriedAboutAnxietyAttackInLast24Hours");
                    }
                    var val = $("#WorriedAboutAnxietyAttackInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#WorriedAboutAnxietyAttackRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#WorriedAboutAnxietyAttackRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackPalpitationsInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackPalpitationsInLifetime");
                    }
                    var val = $("#AnxietyAttackPalpitationsInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackPalpitationsInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackPalpitationsInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackPalpitationsInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackPalpitationsInLastMonth");
                    }
                    var val = $("#AnxietyAttackPalpitationsInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackPalpitationsInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackPalpitationsInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackPalpitationsInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackPalpitationsInLast24Hours");
                    }
                    var val = $("#AnxietyAttackPalpitationsInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackPalpitationsRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackPalpitationsRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackChestPainsInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChestPainsInLifetime");
                    }
                    var val = $("#AnxietyAttackChestPainsInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChestPainsInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChestPainsInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackChestPainsInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChestPainsInLastMonth");
                    }
                    var val = $("#AnxietyAttackChestPainsInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChestPainsInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChestPainsInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackChestPainsInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChestPainsInLast24Hours");
                    }
                    var val = $("#AnxietyAttackChestPainsInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChestPainsRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackChestPainsRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackShortnessBreathInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackShortnessBreathInLifetime");
                    }
                    var val = $("#AnxietyAttackShortnessBreathInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackShortnessBreathInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackShortnessBreathInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackShortnessBreathInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackShortnessBreathInLastMonth");
                    }
                    var val = $("#AnxietyAttackShortnessBreathInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackShortnessBreathInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackShortnessBreathInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackShortnessBreathInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackShortnessBreathInLast24Hours");
                    }
                    var val = $("#AnxietyAttackShortnessBreathInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackShortnessBreathRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackShortnessBreathRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackChokingInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChokingInLifetime");
                    }
                    var val = $("#AnxietyAttackChokingInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChokingInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChokingInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackChokingInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChokingInLastMonth");
                    }
                    var val = $("#AnxietyAttackChokingInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChokingInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChokingInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackChokingInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChokingInLast24Hours");
                    }
                    var val = $("#AnxietyAttackChokingInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChokingRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackChokingRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackSweatyInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackSweatyInLifetime");
                    }
                    var val = $("#AnxietyAttackSweatyInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackSweatyInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackSweatyInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackSweatyInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackSweatyInLastMonth");
                    }
                    var val = $("#AnxietyAttackSweatyInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackSweatyInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackSweatyInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackSweatyInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackSweatyInLast24Hours");
                    }
                    var val = $("#AnxietyAttackSweatyInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackSweatyRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackSweatyRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackTremblingInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackTremblingInLifetime");
                    }
                    var val = $("#AnxietyAttackTremblingInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackTremblingInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackTremblingInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackTremblingInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackTremblingInLastMonth");
                    }
                    var val = $("#AnxietyAttackTremblingInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackTremblingInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackTremblingInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackTremblingInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackTremblingInLast24Hours");
                    }
                    var val = $("#AnxietyAttackTremblingInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackTremblingRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackTremblingRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackNauseaDiarrheaInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNauseaDiarrheaInLifetime");
                    }
                    var val = $("#AnxietyAttackNauseaDiarrheaInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNauseaDiarrheaInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackNauseaDiarrheaInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackNauseaDiarrheaInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNauseaDiarrheaInLastMonth");
                    }
                    var val = $("#AnxietyAttackNauseaDiarrheaInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNauseaDiarrheaInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackNauseaDiarrheaInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackNauseaDiarrheaInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNauseaDiarrheaInLast24Hours");
                    }
                    var val = $("#AnxietyAttackNauseaDiarrheaInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNauseaDiarrheaRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackNauseaDiarrheaRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackDizzinessFaintnessInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDizzinessFaintnessInLifetime");
                    }
                    var val = $("#AnxietyAttackDizzinessFaintnessInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDizzinessFaintnessInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDizzinessFaintnessInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackDizzinessFaintnessInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDizzinessFaintnessInLastMonth");
                    }
                    var val = $("#AnxietyAttackDizzinessFaintnessInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDizzinessFaintnessInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDizzinessFaintnessInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackDizzinessFaintnessInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDizzinessFaintnessInLast24Hours");
                    }
                    var val = $("#AnxietyAttackDizzinessFaintnessInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDizzinessFaintnessRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackDizzinessFaintnessRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackDistortedRealityInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDistortedRealityInLifetime");
                    }
                    var val = $("#AnxietyAttackDistortedRealityInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDistortedRealityInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDistortedRealityInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackDistortedRealityInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDistortedRealityInLastMonth");
                    }
                    var val = $("#AnxietyAttackDistortedRealityInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDistortedRealityInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDistortedRealityInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackDistortedRealityInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDistortedRealityInLast24Hours");
                    }
                    var val = $("#AnxietyAttackDistortedRealityInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDistortedRealityRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackDistortedRealityRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackNumbnessInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNumbnessInLifetime");
                    }
                    var val = $("#AnxietyAttackNumbnessInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNumbnessInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackNumbnessInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackNumbnessInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNumbnessInLastMonth");
                    }
                    var val = $("#AnxietyAttackNumbnessInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNumbnessInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackNumbnessInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackNumbnessInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackNumbnessInLast24Hours");
                    }
                    var val = $("#AnxietyAttackNumbnessInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackNumbnessRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackNumbnessRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackChillsHotFlashesInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChillsHotFlashesInLifetime");
                    }
                    var val = $("#AnxietyAttackChillsHotFlashesInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChillsHotFlashesInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChillsHotFlashesInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackChillsHotFlashesInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChillsHotFlashesInLastMonth");
                    }
                    var val = $("#AnxietyAttackChillsHotFlashesInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChillsHotFlashesInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackChillsHotFlashesInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackChillsHotFlashesInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackChillsHotFlashesInLast24Hours");
                    }
                    var val = $("#AnxietyAttackChillsHotFlashesInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackChillsHotFlashesRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackChillsHotFlashesRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackLoseControlInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackLoseControlInLifetime");
                    }
                    var val = $("#AnxietyAttackLoseControlInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackLoseControlInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackLoseControlInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackLoseControlInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackLoseControlInLastMonth");
                    }
                    var val = $("#AnxietyAttackLoseControlInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackLoseControlInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackLoseControlInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackLoseControlInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackLoseControlInLast24Hours");
                    }
                    var val = $("#AnxietyAttackLoseControlInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackLoseControlRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackLoseControlRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                AnxietyAttackDyingSensationInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDyingSensationInLifetime");
                    }
                    var val = $("#AnxietyAttackDyingSensationInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDyingSensationInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDyingSensationInLastMonth").closest('.question-root').show();
                    }
                },
                AnxietyAttackDyingSensationInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDyingSensationInLastMonth");
                    }
                    var val = $("#AnxietyAttackDyingSensationInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDyingSensationInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#AnxietyAttackDyingSensationInLast24Hours").closest('.question-root').show();
                    }
                },
                AnxietyAttackDyingSensationInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#AnxietyAttackDyingSensationInLast24Hours");
                    }
                    var val = $("#AnxietyAttackDyingSensationInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#AnxietyAttackDyingSensationRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#AnxietyAttackDyingSensationRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodFidgetingInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFidgetingInLifetime");
                    }
                    var val = $("#SignificantPeriodFidgetingInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFidgetingInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodFidgetingInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodFidgetingInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFidgetingInLastMonth");
                    }
                    var val = $("#SignificantPeriodFidgetingInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFidgetingInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodFidgetingInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodFidgetingInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFidgetingInLast24Hours");
                    }
                    var val = $("#SignificantPeriodFidgetingInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFidgetingRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodFidgetingRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodSleepDisorderInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSleepDisorderInLifetime");
                    }
                    var val = $("#SignificantPeriodSleepDisorderInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSleepDisorderInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodSleepDisorderInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodSleepDisorderInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSleepDisorderInLastMonth");
                    }
                    var val = $("#SignificantPeriodSleepDisorderInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSleepDisorderInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodSleepDisorderInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodSleepDisorderInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSleepDisorderInLast24Hours");
                    }
                    var val = $("#SignificantPeriodSleepDisorderInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSleepDisorderRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodSleepDisorderRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodLethargyInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodLethargyInLifetime");
                    }
                    var val = $("#SignificantPeriodLethargyInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodLethargyInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodLethargyInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodLethargyInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodLethargyInLastMonth");
                    }
                    var val = $("#SignificantPeriodLethargyInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodLethargyInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodLethargyInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodLethargyInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodLethargyInLast24Hours");
                    }
                    var val = $("#SignificantPeriodLethargyInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodLethargyRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodLethargyRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodMuscleTensionInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodMuscleTensionInLifetime");
                    }
                    var val = $("#SignificantPeriodMuscleTensionInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodMuscleTensionInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodMuscleTensionInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodMuscleTensionInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodMuscleTensionInLastMonth");
                    }
                    var val = $("#SignificantPeriodMuscleTensionInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodMuscleTensionInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodMuscleTensionInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodMuscleTensionInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodMuscleTensionInLast24Hours");
                    }
                    var val = $("#SignificantPeriodMuscleTensionInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodMuscleTensionRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodMuscleTensionRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodNegativeThoughtsInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodNegativeThoughtsInLifetime");
                    }
                    var val = $("#SignificantPeriodNegativeThoughtsInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodNegativeThoughtsInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodNegativeThoughtsInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodNegativeThoughtsInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodNegativeThoughtsInLastMonth");
                    }
                    var val = $("#SignificantPeriodNegativeThoughtsInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodNegativeThoughtsInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodNegativeThoughtsInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodNegativeThoughtsInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodNegativeThoughtsInLast24Hours");
                    }
                    var val = $("#SignificantPeriodNegativeThoughtsInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodNegativeThoughtsRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodNegativeThoughtsRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodExcessiveBehaviorInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodExcessiveBehaviorInLifetime");
                    }
                    var val = $("#SignificantPeriodExcessiveBehaviorInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodExcessiveBehaviorInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodExcessiveBehaviorInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodExcessiveBehaviorInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodExcessiveBehaviorInLastMonth");
                    }
                    var val = $("#SignificantPeriodExcessiveBehaviorInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodExcessiveBehaviorInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodExcessiveBehaviorInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodExcessiveBehaviorInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodExcessiveBehaviorInLast24Hours");
                    }
                    var val = $("#SignificantPeriodExcessiveBehaviorInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodExcessiveBehaviorRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodExcessiveBehaviorRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodParanoiaInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodParanoiaInLifetime");
                    }
                    var val = $("#SignificantPeriodParanoiaInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodParanoiaInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodParanoiaInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodParanoiaInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodParanoiaInLastMonth");
                    }
                    var val = $("#SignificantPeriodParanoiaInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodParanoiaInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodParanoiaInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodParanoiaInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodParanoiaInLast24Hours");
                    }
                    var val = $("#SignificantPeriodParanoiaInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodParanoiaRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodParanoiaRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodUntruePerceptionInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodUntruePerceptionInLifetime");
                    }
                    var val = $("#SignificantPeriodUntruePerceptionInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodUntruePerceptionInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodUntruePerceptionInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodUntruePerceptionInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodUntruePerceptionInLastMonth");
                    }
                    var val = $("#SignificantPeriodUntruePerceptionInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodUntruePerceptionInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodUntruePerceptionInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodUntruePerceptionInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodUntruePerceptionInLast24Hours");
                    }
                    var val = $("#SignificantPeriodUntruePerceptionInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodUntruePerceptionRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodUntruePerceptionRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodHallucinationsInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodHallucinationsInLifetime");
                    }
                    var val = $("#SignificantPeriodHallucinationsInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodHallucinationsInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodHallucinationsInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodHallucinationsInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodHallucinationsInLastMonth");
                    }
                    var val = $("#SignificantPeriodHallucinationsInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodHallucinationsInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodHallucinationsInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodHallucinationsInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodHallucinationsInLast24Hours");
                    }
                    var val = $("#SignificantPeriodHallucinationsInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodHallucinationsRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodHallucinationsRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodFlashbacksInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFlashbacksInLifetime");
                    }
                    var val = $("#SignificantPeriodFlashbacksInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFlashbacksInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodFlashbacksInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodFlashbacksInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFlashbacksInLastMonth");
                    }
                    var val = $("#SignificantPeriodFlashbacksInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFlashbacksInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodFlashbacksInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodFlashbacksInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodFlashbacksInLast24Hours");
                    }
                    var val = $("#SignificantPeriodFlashbacksInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodFlashbacksRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodFlashbacksRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodImpairedThoughtInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodImpairedThoughtInLifetime");
                    }
                    var val = $("#SignificantPeriodImpairedThoughtInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodImpairedThoughtInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodImpairedThoughtInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodImpairedThoughtInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodImpairedThoughtInLastMonth");
                    }
                    var val = $("#SignificantPeriodImpairedThoughtInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodImpairedThoughtInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodImpairedThoughtInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodImpairedThoughtInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodImpairedThoughtInLast24Hours");
                    }
                    var val = $("#SignificantPeriodImpairedThoughtInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodImpairedThoughtRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodImpairedThoughtRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodIrritabilityInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodIrritabilityInLifetime");
                    }
                    var val = $("#SignificantPeriodIrritabilityInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodIrritabilityInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodIrritabilityInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodIrritabilityInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodIrritabilityInLastMonth");
                    }
                    var val = $("#SignificantPeriodIrritabilityInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodIrritabilityInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodIrritabilityInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodIrritabilityInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodIrritabilityInLast24Hours");
                    }
                    var val = $("#SignificantPeriodIrritabilityInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodIrritabilityRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodIrritabilityRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodCurbingViolentBehaviorInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodCurbingViolentBehaviorInLifetime");
                    }
                    var val = $("#SignificantPeriodCurbingViolentBehaviorInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodCurbingViolentBehaviorInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodCurbingViolentBehaviorInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodCurbingViolentBehaviorInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodCurbingViolentBehaviorInLastMonth");
                    }
                    var val = $("#SignificantPeriodCurbingViolentBehaviorInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodCurbingViolentBehaviorInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodCurbingViolentBehaviorInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodCurbingViolentBehaviorInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodCurbingViolentBehaviorInLast24Hours");
                    }
                    var val = $("#SignificantPeriodCurbingViolentBehaviorInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodCurbingViolentBehaviorRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodViolentUrgesInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodViolentUrgesInLifetime");
                    }
                    var val = $("#SignificantPeriodViolentUrgesInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodViolentUrgesInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodViolentUrgesInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodViolentUrgesInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodViolentUrgesInLastMonth");
                    }
                    var val = $("#SignificantPeriodViolentUrgesInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodViolentUrgesInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodViolentUrgesInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodViolentUrgesInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodViolentUrgesInLast24Hours");
                    }
                    var val = $("#SignificantPeriodViolentUrgesInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodViolentUrgesRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodViolentUrgesRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodTroubleWithAttitudeTowardOthersInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime");
                    }
                    var val = $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth");
                    }
                    var val = $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodTroubleWithAttitudeTowardOthersInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours");
                    }
                    var val = $("#SignificantPeriodTroubleWithAttitudeTowardOthersInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodTroubleWithAttitudeTowardOthersRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodSuicidalThoughtsInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSuicidalThoughtsInLifetime");
                    }
                    var val = $("#SignificantPeriodSuicidalThoughtsInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSuicidalThoughtsInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodSuicidalThoughtsInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodSuicidalThoughtsInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSuicidalThoughtsInLastMonth");
                    }
                    var val = $("#SignificantPeriodSuicidalThoughtsInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSuicidalThoughtsInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodSuicidalThoughtsInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodSuicidalThoughtsInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodSuicidalThoughtsInLast24Hours");
                    }
                    var val = $("#SignificantPeriodSuicidalThoughtsInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodSuicidalThoughtsRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodThoughtsOfSelfInjuryInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodThoughtsOfSelfInjuryInLifetime");
                    }
                    var val = $("#SignificantPeriodThoughtsOfSelfInjuryInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodThoughtsOfSelfInjuryInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodThoughtsOfSelfInjuryInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodThoughtsOfSelfInjuryInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodThoughtsOfSelfInjuryInLastMonth");
                    }
                    var val = $("#SignificantPeriodThoughtsOfSelfInjuryInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodThoughtsOfSelfInjuryInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodThoughtsOfSelfInjuryInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodThoughtsOfSelfInjuryInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodThoughtsOfSelfInjuryInLast24Hours");
                    }
                    var val = $("#SignificantPeriodThoughtsOfSelfInjuryInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodThoughtsOfSelfInjuryRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodThoughtsOfSelfInjuryRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                SignificantPeriodAttemptedSuicideInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodAttemptedSuicideInLifetime");
                    }
                    var val = $("#SignificantPeriodAttemptedSuicideInLifetime").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodAttemptedSuicideInLastMonth").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodAttemptedSuicideInLastMonth").closest('.question-root').show();
                    }
                },
                SignificantPeriodAttemptedSuicideInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodAttemptedSuicideInLastMonth");
                    }
                    var val = $("#SignificantPeriodAttemptedSuicideInLastMonth").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodAttemptedSuicideInLast24Hours").val("").trigger("change").closest('.question-root').hide()
                                                          .find('.ui-scale-option').removeClass("ui-scale-active");
                    } else {
                        $("#SignificantPeriodAttemptedSuicideInLast24Hours").closest('.question-root').show();
                    }
                },
                SignificantPeriodAttemptedSuicideInLast24HoursRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector("#SignificantPeriodAttemptedSuicideInLast24Hours");
                    }
                    var val = $("#SignificantPeriodAttemptedSuicideInLast24Hours").val();
                    if (val == undefined || val == "" || val == "NotAtAll") {
                        $("#SignificantPeriodAttemptedSuicideRelatedToSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    } else {
                        $("#SignificantPeriodAttemptedSuicideRelatedToSubstanceUse").closest('.question-root').show();
                    }
                },
                MedicatedForPsychologicalEmotionalProblemInLifetimeRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="MedicatedForPsychologicalEmotionalProblemInLifetime"]');
                    }
                    var val = $("#MedicatedForPsychologicalEmotionalProblemInLifetime").prop('checked');
                    if (val == undefined || !val) {
                        $("#MedicatedForPsychologicalEmotionalProblemInLastMonth").closest('.question-root').hide()
                        .find('[name="MedicatedForPsychologicalEmotionalProblemInLastMonth"]').prop('checked', false).trigger("change");
                    } else {
                        $("#MedicatedForPsychologicalEmotionalProblemInLastMonth").closest('.question-root').show();
                    }
                },
                MedicatedForPsychologicalEmotionalProblemInLastMonthRules: function () {
                    if (!$.rules.init) {
                        $.rules.Utilities.AddSelector('[name="MedicatedForPsychologicalEmotionalProblemInLastMonth"]');
                    }
                    var val = $("#MedicatedForPsychologicalEmotionalProblemInLastMonth").prop('checked');
                    if (val == undefined || !val) {
                        $("#MedicatedForPsychologicalEmotionalProblemInLast24Hours").closest('.question-root').hide()
                        .find('[name="MedicatedForPsychologicalEmotionalProblemInLast24Hours"]').prop('checked', false).trigger("change");
                    } else {
                        $("#MedicatedForPsychologicalEmotionalProblemInLast24Hours").closest('.question-root').show();
                    }
                }
            },
            InterviewerRating: {
                ActivePsychiatricDiagnosesOtherThanSubstanceAbuseRules: function () {
                    if (!$.rules.init) {
                        }
                },
                RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse: function () {
                    if (!$.rules.init) {
                        $("#HasSuicidalThoughts_Value").change($.rules.PsychologicalSection.InterviewerRating.RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse);
                        $("#DemonstratingDangerToSelfOrOthers_Value").change($.rules.PsychologicalSection.InterviewerRating.RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse);
                        $("#IndicatingRiskOfHarmToOthers_Value").change($.rules.PsychologicalSection.InterviewerRating.RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse);
                        $("#IndicatingRiskOfHarmToSelfOrVictimizationByOthers_Value").change($.rules.PsychologicalSection.InterviewerRating.RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse);
                    }
                    var suicidalVal = $("#HasSuicidalThoughts_Value").val();
                    var dangerToOthersVal = $("#DemonstratingDangerToSelfOrOthers_Value").val();
                    var harmToOthersVal = $("#IndicatingRiskOfHarmToOthers_Value").val();
                    var harmToSelfVal = $("#IndicatingRiskOfHarmToSelfOrVictimizationByOthers_Value").val();
                    if (suicidalVal > 0 || dangerToOthersVal > 0 || harmToOthersVal > 0 || harmToSelfVal > 0) {
                        $("#RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse").closest('.question-root').show();
                        } else {
                        $("#RiskOfHarmToSelfOrOthersIsHigherWithSubstanceUse").val("").trigger("change").closest('.question-root').hide();
                    }
                }
            }
        },
        CompletionSection: {
            UnacceptableCareLevelsRules: function () {
                if (!$.rules.init) {
                    }
            },
            UnavailableCareLevelsRules: function () {
                if (!$.rules.init) {
                    }
            }
        }
    };
});