using System;
using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Domain.CommonModule.Lookups;
using Asam.Ppc.Domain.PatientModule.Events;
using Asam.Ppc.Primitives;
using Pillar.Common.Utility;
using Pillar.Domain.Attributes;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.PatientModule
{
    using OrganizationModule;

    /// <summary>
    /// Patient class.
    /// </summary>
    public class Patient : AggregateRootBase, IOrganizationMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        internal Patient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" /> class.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="name">The name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        internal Patient(Organization organization, PersonName name, DateTime? dateOfBirth, Gender gender)
        {
            Check.IsNotNull(name, "Name is required.");

            Organization = organization;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [IgnoreMapping]
        public virtual long OrganizationKey { get { return Organization.Key; } }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        [NotNull]
        public virtual Organization Organization { get; protected set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [NotNull]
        public virtual PersonName Name { get; protected set; }

        /// <summary>
        /// Gets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public virtual DateTime? DateOfBirth { get; protected set; }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [NotNull]
        public virtual Gender Gender { get; protected set; }

        /// <summary>
        /// Gets the religion.
        /// </summary>
        /// <value>
        /// The religion.
        /// </value>
        public virtual Religion Religion { get; protected set; }

        /// <summary>
        /// Gets the ethnicity.
        /// </summary>
        /// <value>
        /// The ethnicity.
        /// </value>
        public virtual Ethnicity Ethnicity { get; protected set; }


        /// <summary>
        /// Revises the name.
        /// </summary>
        /// <param name="name">The name.</param>
        public virtual void ReviseName(PersonName name)
        {
            Check.IsNotNull(name, "Name is required.");
            Name = name;

            //TODO:Evaluate need for separate/more specific event
            DomainEvent.Raise(new PatientChangedEvent {Patient = this});
        }

        /// <summary>
        /// Revises the date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        public virtual void ReviseDateOfBirth(DateTime? dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Revises the gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        public virtual void ReviseGender(Gender gender)
        {
            Gender = gender;

            //TODO:Evaluate need for separate/more specific event
            DomainEvent.Raise(new PatientChangedEvent {Patient = this});
        }

        /// <summary>
        /// Revises the religion.
        /// </summary>
        /// <param name="religion">The religion.</param>
        public virtual void ReviseReligion(Religion religion)
        {
            Religion = religion;
        }

        /// <summary>
        /// Revises the ethnicity.
        /// </summary>
        /// <param name="ethnicity">The ethnicity.</param>
        public virtual void ReviseEthnicity(Ethnicity ethnicity)
        {
            Ethnicity = ethnicity;
        }
    }
}