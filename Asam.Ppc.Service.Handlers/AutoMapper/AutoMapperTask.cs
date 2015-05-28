//using Asam.Ppc.Domain.EhrModule;

using Asam.Ppc.Domain.EhrModule;
using Asam.Ppc.Domain.Scoring.ScoringModule;
using Asam.Ppc.Service.Messages.Ehr;

namespace Asam.Ppc.Service.Handlers.AutoMapper
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.AssessmentModule;
    using Domain.AssessmentModule.Completion;
    using Domain.AssessmentModule.DrugAndAlcohol;
    using Domain.AssessmentModule.EmploymentAndSupport;
    using Domain.AssessmentModule.FamilyAndSocialHistory;
    using Domain.AssessmentModule.GeneralInformation;
    using Domain.AssessmentModule.Legal;
    using Domain.AssessmentModule.Medical;
    using Domain.AssessmentModule.Psychological;
    using Domain.AssessmentModule.Review;
    using Domain.CommonModule;
    using Domain.CommonModule.ValueObjects;
    using Domain.OrganizationModule;
    using Domain.PatientModule;
    using Domain.SecurityModule;
    using Messages.Assessment;
    using Messages.Assessment.Completion;
    using Messages.Assessment.DrugAndAlcohol;
    using Messages.Assessment.EmploymentAndSupport;
    using Messages.Assessment.FamilyAndSocialHistory;
    using Messages.Assessment.GeneralInformation;
    using Messages.Assessment.Legal;
    using Messages.Assessment.Medical;
    using Messages.Assessment.Psychological;
    using Messages.Assessment.Review;
    using Messages.Common;
    using Messages.Common.Lookups;
    using Messages.Core;
    using Messages.Organization;
    using Messages.Security;
    using Pillar.Common.Bootstrapper;
    using Pillar.Domain.Primitives;
    using Pillar.Security.AccessControl;
    using global::AutoMapper;

    #endregion

    /// <summary>
    /// Class for setting up automapper profiles.
    /// </summary>
    public class AutoMapperTask : IBootstrapperTask
    {
        #region Public Methods and Operators

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute ()
        {
            CreateAsamPpcAssessmentMapping ();
            CreateAsamPpcAssessmentScoreMappings();
            CreatePatientMappings ();
            CreateOrganizationMappings ();
            CreateEhrMappings();
            CreateSecurityMappings ();
        }

        #endregion

        #region Methods

        private void CreateAsamPpcAssessmentMapping ()
        {
            Mapper.CreateMap<DateTimeOffset, DateTime> ().ConvertUsing<DateTimeTypeConverter> ();
            Mapper.CreateMap<uint?, TimeSpanPicker>().ConstructUsing(src => src == null ? null : new TimeSpanPicker(src / 12,src % 12));
            Mapper.CreateMap<AssessmentMetaData, AssessmentMetaDataDto>();

            Mapper.CreateMap<Lookup, LookupDto> ();
            Mapper.CreateMap<Money, MoneyDto> ()
                  .ForMember ( dest => dest.CurrencyCode, opt => opt.MapFrom ( src => src.Currency == null ? null : src.Currency.Code ) )
                  .ForMember ( dest => dest.CurrencyCultureName, opt => opt.MapFrom ( src => src.Currency == null ? null : src.Currency.CultureName ) );

            Mapper.CreateMap<GeneralInformationSection, GeneralInformationSectionDto> ();
            Mapper.CreateMap<Patient, GeneralInformationSectionDto> ();
            Mapper.CreateMap<MedicalSection, MedicalSectionDto> ();
            Mapper.CreateMap<EmploymentAndSupportSection, EmploymentAndSupportSectionDto> ();
            Mapper.CreateMap<UsedSubstances, UsedSubstancesDto> ();
            Mapper.CreateMap<AlcoholUse, AlcoholUseDto> ();
            Mapper.CreateMap<HeroinUse, HeroinUseDto> ();
            Mapper.CreateMap<MethadoneUse, MethadoneUseDto> ();
            Mapper.CreateMap<OtherOpiateUse, OtherOpiateUseDto> ();
            Mapper.CreateMap<CinaScale, CinaScaleDto> ();
            Mapper.CreateMap<OpiatesInControlledEnvironment, OpiatesInControlledEnvironmentDto> ();
            Mapper.CreateMap<OpioidMaintenanceTherapy, OpioidMaintenanceTherapyDto> ();
            Mapper.CreateMap<BarbiturateUse, BarbiturateUseDto> ();
            Mapper.CreateMap<OtherSedativeUse, OtherSedativeUseDto> ();
            Mapper.CreateMap<CiwaScale, CiwaScaleDto> ();
            Mapper.CreateMap<CocaineUse, CocaineUseDto> ();
            Mapper.CreateMap<StimulantUse, StimulantUseDto> ();
            Mapper.CreateMap<CannabisUse, CannabisUseDto> ();
            Mapper.CreateMap<HallucinogenUse, HallucinogenUseDto> ();
            Mapper.CreateMap<SolventAndInhalantUse, SolventAndInhalantUseDto> ();
            Mapper.CreateMap<MultipleSubstanceUsePerDay, MultipleSubstanceUsePerDayDto> ();
            Mapper.CreateMap<NicotineUse, NicotineUseDto> ();
            Mapper.CreateMap<OtherSubstanceUse, OtherSubstanceUseDto> ();
            Mapper.CreateMap<DrugConsequences, DrugConsequencesDto> ();
            Mapper.CreateMap<AddictionTreatmentHistory, AddictionTreatmentHistoryDto> ();
            Mapper.CreateMap<InterviewerEvaluation, InterviewerEvaluationDto> ();
            Mapper.CreateMap<UsedSubstances, InterviewerEvaluationDto> ();
            Mapper.CreateMap<AdditionalAddictionAndTreatmentItems, AdditionalAddictionAndTreatmentItemsDto> ();
            Mapper.CreateMap<AlcoholAndDrugInterviewerRating, AlcoholAndDrugInterviewerRatingDto> ();
            Mapper.CreateMap<LegalSection, LegalSectionDto> ();
            Mapper.CreateMap<PsychologicalHistory, PsychologicalHistoryDto> ();
            Mapper.CreateMap<InterviewerRating, InterviewerRatingDto> ();
            Mapper.CreateMap<DepressionEvaluation, DepressionEvaluationDto> ();
            Mapper.CreateMap<CompletionSection, CompletionSectionDto> ();
            Mapper.CreateMap<FamilyAndSocialHistorySection, FamilyAndSocialHistorySectionDto> ();
            Mapper.CreateMap<ReviewSection, ReviewSectionDto> ();

            Mapper.CreateMap<Assessment, AssessmentDto> ();

            Mapper.CreateMap<PsychologicalSection, PsychologicalSectionDto> ();
            Mapper.CreateMap<DrugAndAlcoholSection, DrugAndAlcoholSectionDto> ();

            Mapper.CreateMap<Assessment, AssessmentSummaryDto> ()
                  .ForMember ( dest => dest.PatientId, opt => opt.MapFrom ( src => src.Patient.Key ) )
                  .ForMember ( dest => dest.PatientFirstName, opt => opt.MapFrom ( src => src.Patient.Name.FirstName ) )
                  .ForMember ( dest => dest.PatientLastName, opt => opt.MapFrom ( src => src.Patient.Name.LastName ) );
        }

        private void CreateAsamPpcAssessmentScoreMappings()
        {
            Mapper.CreateMap<AssessmentScore, AssessmentScoreDto>();
        }

        private void CreatePatientMappings ()
        {
            Mapper.CreateMap<Patient, PatientDto> ();
        }

        private void CreateEhrMappings()
        {
            Mapper.CreateMap<Ehr, EhrDto>();
        }

        private void CreateOrganizationMappings ()
        {
            Mapper.CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode == null ? null : src.PostalCode.Code));
            Mapper.CreateMap<Phone, PhoneDto>();

            Mapper.CreateMap<OrganizationAddress, OrganizationAddressDto>()
                .ForMember(dest => dest.OriginalHash, opt => opt.MapFrom(src => src.Key));
            Mapper.CreateMap<OrganizationPhone, OrganizationPhoneDto>()
                .ForMember(dest => dest.OriginalHash, opt => opt.MapFrom(src => src.Key));

            Mapper.CreateMap<OrganizationApiKey, OrganizationApiKeyDto>()
                .ForMember(dest => dest.ApiKey, opt => opt.MapFrom(src => src.Key));

            Mapper.CreateMap<Organization, OrganizationDto>();
            Mapper.CreateMap<Organization, OrganizationSummaryDto>()
                  .ForMember(dest => dest.PrimaryAddress,
                               opt =>
                               opt.MapFrom(
                                            src =>
                                            (src.OrganizationAddresses.FirstOrDefault(a => a.IsPrimary) ?? src.OrganizationAddresses.FirstOrDefault()) == null
                                                ? null
                                                : (src.OrganizationAddresses.FirstOrDefault(a => a.IsPrimary) ?? src.OrganizationAddresses.FirstOrDefault()).Address))
                  .ForMember(dest => dest.PrimaryPhone,
                               opt =>
                               opt.MapFrom(
                                            src =>
                                            (src.OrganizationPhones.FirstOrDefault(p => p.IsPrimary) ?? src.OrganizationPhones.FirstOrDefault()) == null
                                                ? null
                                                : (src.OrganizationPhones.FirstOrDefault(p => p.IsPrimary) ?? src.OrganizationPhones.FirstOrDefault()).Phone.Number));
            Mapper.CreateMap<Staff, StaffDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address));

            Mapper.CreateMap<Staff, TeamStaffDto>();
            Mapper.CreateMap<Patient, TeamPatientDto>();

            Mapper.CreateMap<Team, TeamSummaryDto>();
            Mapper.CreateMap<Team, TeamDto>();
            Mapper.CreateMap<Email, string>()
                .ConvertUsing(email => email == null ? null : email.Address);
        }

        private void CreateSecurityMappings ()
        {
            Mapper.CreateMap<Role, RoleDto> ()
                  .ForMember ( dest => dest.Permissions,
                               opt => opt.MapFrom ( src => src.Permissions == null ? null : src.Permissions.Select ( p => p.SystemPermission.WellKnownName ) ) );
            Mapper.CreateMap<long, RoleDto> ().ForMember ( dest => dest.Key, opt => opt.MapFrom ( src => src ) );
            Mapper.CreateMap<SystemAccount, SystemAccountDto> ()
                  .ForMember ( dest => dest.Email, opt => opt.MapFrom ( src => src.Email.Address ) )
                  .ForMember ( dest => dest.Roles, opt => opt.MapFrom ( src => src.Roles == null ? null : src.Roles.Select ( sar => sar.Role ) ) );
        }

        #endregion
    }
}