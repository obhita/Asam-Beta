using System.Linq;
using Asam.Ppc.Domain.AssessmentModule.Events;
using Pillar.Common.Utility;
using Pillar.Domain.Event;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    #region Using Statements

    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Used substances.
    /// </summary>
    public class UsedSubstances : RevisionBase
    {
        private readonly IList<SubstanceCategory> _substanceHasEverUsed;

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsedSubstances" /> class.
        /// </summary>
        protected internal UsedSubstances()
        {
            _substanceHasEverUsed = new List<SubstanceCategory>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the substance has ever used.
        /// </summary>
        /// <value>
        ///     The substance has ever used.
        /// </value>
        public virtual IEnumerable<SubstanceCategory> SubstanceHasEverUsed
        {
            get { return _substanceHasEverUsed; }

            protected set
            {
                _substanceHasEverUsed.Clear();
                if (value != null)
                {
                    _substanceHasEverUsed.AddRange(value);
                }
            }
        }

        #endregion

        public override void ReviseProperty(long assessmentId, string propertyName, object value)
        {
            if (propertyName == PropertyUtil.ExtractPropertyName(() => SubstanceHasEverUsed))
            {
                var oldValues = new List<SubstanceCategory>(SubstanceHasEverUsed);
                base.ReviseProperty(assessmentId, propertyName, value);
                DomainEvent.Raise(new UsedSubstancesChangedEvent(assessmentId) { NewValues = SubstanceHasEverUsed, OldValues = oldValues });
            }
            else
            {
                base.ReviseProperty(assessmentId, propertyName, value);
            }
        }
    }
}