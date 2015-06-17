using System;
using Asam.Ppc.Domain.AssessmentModule.Completion;
using Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol;
using Asam.Ppc.Domain.AssessmentModule.EmploymentAndSupport;
using Asam.Ppc.Domain.AssessmentModule.Events;
using Asam.Ppc.Domain.AssessmentModule.FamilyAndSocialHistory;
using Asam.Ppc.Domain.AssessmentModule.GeneralInformation;
using Asam.Ppc.Domain.AssessmentModule.Legal;
using Asam.Ppc.Domain.AssessmentModule.Medical;
using Asam.Ppc.Domain.AssessmentModule.Psychological;
using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Domain.PatientModule;
using Pillar.Domain.Attributes;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.AssessmentModule
{
    using Review;

    /// <summary>
    /// Assessment class.
    /// </summary>
    public class Assessment : AggregateRootBase, IOrganizationMember
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Assessment" /> class.
        /// </summary>
        protected Assessment ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Assessment" /> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public Assessment(Patient patient)
        {
            Patient = patient;
            GeneralInformationSection = new GeneralInformationSection();
            MedicalSection = new MedicalSection();
            EmploymentAndSupportSection = new EmploymentAndSupportSection();
            LegalSection = new LegalSection();
            FamilyAndSocialHistorySection = new FamilyAndSocialHistorySection();
            CompletionSection = new CompletionSection();
            PsychologicalSection = new PsychologicalSection();
            DrugAndAlcoholSection = new DrugAndAlcoholSection();
            ReviewSection = new ReviewSection ();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the completion section.
        /// </summary>
        /// <value>
        /// The completion section.
        /// </value>
        public virtual CompletionSection CompletionSection { get; protected set; }

        /// <summary>
        /// Gets the drug and alcohol section.
        /// </summary>
        /// <value>
        /// The drug and alcohol section.
        /// </value>
        public virtual DrugAndAlcoholSection DrugAndAlcoholSection { get; protected set; }

        /// <summary>
        /// Gets the employment and support section.
        /// </summary>
        /// <value>
        /// The employment and support section.
        /// </value>
        public virtual EmploymentAndSupportSection EmploymentAndSupportSection { get; protected set; }

        /// <summary>
        /// Gets the family and social history section.
        /// </summary>
        /// <value>
        /// The family and social history section.
        /// </value>
        public virtual FamilyAndSocialHistorySection FamilyAndSocialHistorySection { get; protected set; }

        /// <summary>
        /// Gets the general information section.
        /// </summary>
        /// <value>
        /// The general information section.
        /// </value>
        public virtual GeneralInformationSection GeneralInformationSection { get; protected set; }

        /// <summary>
        /// Gets the legal section.
        /// </summary>
        /// <value>
        /// The legal section.
        /// </value>
        public virtual LegalSection LegalSection { get; protected set; }

        /// <summary>
        /// Gets the medical section.
        /// </summary>
        /// <value>
        /// The medical section.
        /// </value>
        public virtual MedicalSection MedicalSection { get; protected set; }

        /// <summary>
        /// Gets the patient.
        /// </summary>
        /// <value>
        /// The patient.
        /// </value>
        [NotNull]
        public virtual Patient Patient { get; protected set; }

        /// <summary>
        /// Gets the psychological section.
        /// </summary>
        /// <value>
        /// The psychological section.
        /// </value>
        public virtual PsychologicalSection PsychologicalSection { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is submitted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is submitted; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsSubmitted { get; set; }

        /// <summary>
        /// Gets the review section.
        /// </summary>
        /// <value>
        /// The review section.
        /// </value>
        public virtual ReviewSection ReviewSection { get; protected set; }


        /// <summary>
        /// Gets or sets the completed timestamp.
        /// </summary>
        /// <value>
        /// The completed timestamp.
        /// </value>
        public virtual DateTimeOffset CompletedTimestamp { get; set; }

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [IgnoreMapping]
        public virtual long OrganizationKey { get { return Patient.Organization.Key; } }

        #endregion

        #region Public Methods

        public virtual void SubmitAssessment(string username = null)
            {
                IsSubmitted = true;
                CompletedTimestamp = DateTimeOffset.Now;
                DomainEvent.Raise(new AssessmentCompletedEvent {AssessmentKey = Key, Username = username});
            }

        public virtual void RevisePatient ( Patient patient )
        {
            Patient = patient;
        }

        #endregion
    }
}