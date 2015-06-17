namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    using Lookups;

    public interface IPrescribedSubstance
    {
        /// <summary>
        ///     (ASId04Q)
        /// </summary>
        SubstanceTakenAsPrescribed WasSubstanceTakenAsPrescribed { get; }
    }
}