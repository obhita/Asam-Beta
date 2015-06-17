using System;
using System.Web.Mvc;

namespace Asam.Ppc.Mvc.Infrastructure
{
    /// <summary>
    /// Extended model state with warnings support.
    /// </summary>
    [Serializable]
    public class ExtendedModelState : ModelState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedModelState" /> class.
        /// </summary>
        public ExtendedModelState()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedModelState" /> class.
        /// </summary>
        /// <param name="state">The state.</param>
        public ExtendedModelState(ModelState state)
        {
            Value = state.Value;
            foreach (var error in state.Errors)
            {
                Errors.Add(error);
            }
        }

        private readonly ModelErrorCollection _warnings = new ModelErrorCollection();

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <value>
        /// The warnings.
        /// </value>
        public ModelErrorCollection Warnings
        {
            get { return _warnings; }
        }
    }
}
