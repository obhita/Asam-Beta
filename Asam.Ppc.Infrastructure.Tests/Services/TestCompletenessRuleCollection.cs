namespace Asam.Ppc.Infrastructure.Tests.Services
{
    using Infrastructure.Services;
    using Pillar.FluentRuleEngine;
    using Ppc.Domain.AssessmentModule;

    public class TestCompletenessRuleCollection : AbstractRuleCollection<Assessment>, ICompletenessRuleCollection<Assessment>
    {
        #region Constructors and Destructors

        public TestCompletenessRuleCollection()
        {
            AutoValidatePropertyRules = true;

            NewPropertyRule(() => AssessmentClassRule).WithProperty(a => a.GeneralInformationSection.AssessmentClass).NotNull();

            NewRuleSet(() => GeneralInformationSectionRuleSet, AssessmentClassRule);
        }

        #endregion

        #region Public Properties

        public IPropertyRule AssessmentClassRule { get; private set; }
        public IRuleSet GeneralInformationSectionRuleSet { get; private set; }

        #endregion

        public string CompletenessCategory { get { return "TestCompleteness"; } }
    }
}