using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.DrugAndAlcohol
{
    public class SubstanceCategory : Lookup
    {
        public static SubstanceCategory None = new SubstanceCategory
            {
                Code = "None",
                SortOrder = 0,
                Value = 0
            };

        public static SubstanceCategory Alcohol = new SubstanceCategory
            {
                Code = "Alcohol",
                SortOrder = 2,
                Value = 1
            };

        public static SubstanceCategory Heroin = new SubstanceCategory
            {
                Code = "Heroin",
                SortOrder = 5,
                Value = 2
            };

        public static SubstanceCategory Methadone = new SubstanceCategory
            {
                Code = "Methadone",
                SortOrder = 6,
                Value = 3
            };

        public static SubstanceCategory OtherOpiate = new SubstanceCategory
            {
                Code = "OtherOpiate",
                SortOrder = 4,
                Value = 4
            };

        public static SubstanceCategory Barbiturates = new SubstanceCategory
            {
                Code = "Barbiturates",
                SortOrder = 9,
                Value = 5
            };

        public static SubstanceCategory OtherSedatives = new SubstanceCategory
            {
                Code = "OtherSedatives",
                SortOrder = 10,
                Value = 6
            };

        public static SubstanceCategory Cocaine = new SubstanceCategory
            {
                Code = "Cocaine",
                SortOrder = 7,
                Value = 7
            };

        public static SubstanceCategory Stimulants = new SubstanceCategory
            {
                Code = "Stimulants",
                SortOrder = 8,
                Value = 8
            };

        public static SubstanceCategory Cannabis = new SubstanceCategory
            {
                Code = "Cannabis",
                SortOrder = 3,
                Value = 9
            };

        public static SubstanceCategory Hallucinogens = new SubstanceCategory
            {
                Code = "Hallucinogens",
                SortOrder = 12,
                Value = 10
            };

        public static SubstanceCategory SolventInhalants = new SubstanceCategory
            {
                Code = "SolventInhalants",
                SortOrder = 11,
                Value = 11
            };

        public static SubstanceCategory MultiplePerDay = new SubstanceCategory
            {
                Code = "MultiplePerDay",
                SortOrder = 14,
                Value = 12
            };

        public static SubstanceCategory Nicotine = new SubstanceCategory
            {
                Code = "Nicotine",
                SortOrder = 1,
                Value = 13
            };

        public static SubstanceCategory OtherSubstance = new SubstanceCategory
            {
                Code = "OtherSubstance",
                SortOrder = 13,
                Value = 14
            };

        public static SubstanceCategory NoHistory = new SubstanceCategory
        {
            Code = "NoHistory",
            SortOrder = 14,
            Value = 0
        };

    }
}