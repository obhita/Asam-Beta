namespace Asam.Ppc.Domain.OrganizationModule
{
    #region Using Statements

    using System;
    using System.Collections.Generic;
    using CommonModule;
    using PatientModule;
    using Pillar.Common.Utility;
    using Pillar.Domain.Attributes;

    #endregion

    public class Team : AggregateRootBase, IOrganizationMember
    {
        #region Fields

        private readonly IList<Patient> _patients = new List<Patient>();
        private readonly IList<Staff> _staff = new List<Staff>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Team" /> class.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="name">The name.</param>
        internal Team ( Organization organization, string name )
        {
            Check.IsNotNullOrWhitespace ( name, () => Name );

            Organization = organization;
            Name = name;
        }

        internal Team(){}

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the organization key.
        /// </summary>
        /// <value>
        /// The organization key.
        /// </value>
        [IgnoreMapping]
        public virtual long OrganizationKey { get { return Organization.Key; } }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [NotNull]
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     Gets the organization.
        /// </summary>
        /// <value>
        ///     The organization.
        /// </value>
        [NotNull]
        public virtual Organization Organization { get; protected set; }

        /// <summary>
        ///     Gets the patients.
        /// </summary>
        /// <value>
        ///     The patients.
        /// </value>
        public virtual IEnumerable<Patient> Patients
        {
            get { return _patients; }
        }

        /// <summary>
        ///     Gets the staff.
        /// </summary>
        /// <value>
        ///     The staff.
        /// </value>
        public virtual IEnumerable<Staff> Staff
        {
            get { return _staff; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public virtual void AddPatient(Patient patient)
        {
            if ( !_patients.Contains ( patient ) )
            {
                _patients.Add(patient);
            }
        }

        /// <summary>
        ///     Adds the staff.
        /// </summary>
        /// <param name="staffKey">The staff.</param>
        public virtual void AddStaff(Staff staff)
        {
            if (!_staff.Contains(staff))
            {
                _staff.Add(staff);
            }
        }

        /// <summary>
        /// Removes the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        public virtual void RemoveStaff(Staff staff)
        {
            if ( _staff.Contains ( staff ) )
            {
                _staff.Remove ( staff );
            }
        }

        /// <summary>
        /// Removes the patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public virtual void RemovePatient(Patient patient)
        {
            if (_patients.Contains(patient))
            {
                _patients.Remove ( patient );
            }
        }

        /// <summary>
        /// Revises the name.
        /// </summary>
        /// <param name="name">The name.</param>
        public virtual void ReviseName(string name)
        {
            Check.IsNotNullOrWhitespace ( name, () => Name );

            Name = name;
        }

        #endregion
    }
}