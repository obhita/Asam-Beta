using Asam.Ppc.Domain.CommonModule;

namespace Asam.Ppc.Domain.AssessmentModule.Medical
{
    public class MedicalProblemCategory : Lookup
    {
        public static MedicalProblemCategory None = new MedicalProblemCategory
            {
                Code = "None",
                SortOrder = 1,
                Value = 0
            };

        public static MedicalProblemCategory NeurologicalSeizuresFits = new MedicalProblemCategory
            {
                Code = "NeurologicalSeizuresFits",
                SortOrder = 1,
                Value = 1
            };

        public static MedicalProblemCategory OphthalmologicEye = new MedicalProblemCategory
            {
                Code = "OphthalmologicEye",
                SortOrder = 2,
                Value = 2
            };

        public static MedicalProblemCategory EarNoseThroat = new MedicalProblemCategory
            {
                Code = "EarNoseThroat",
                SortOrder = 3,
                Value = 3
            };

        public static MedicalProblemCategory DentalTeethGums = new MedicalProblemCategory
            {
                Code = "DentalTeethGums",
                SortOrder = 4,
                Value = 4
            };

        public static MedicalProblemCategory Cardiovascular = new MedicalProblemCategory
            {
                Code = "Cardiovascular",
                SortOrder = 5,
                Value = 5
            };

        public static MedicalProblemCategory PulmonaryLungAsthma = new MedicalProblemCategory
            {
                Code = "PulmonaryLungAsthma",
                SortOrder = 6,
                Value = 6
            };

        public static MedicalProblemCategory DigestiveBowelLiverPancreasDiabetes = new MedicalProblemCategory
            {
                Code = "DigestiveBowelLiverPancreasDiabetes",
                SortOrder = 7,
                Value = 7
            };

        public static MedicalProblemCategory UrinaryBladder = new MedicalProblemCategory
            {
                Code = "UrinaryBladder",
                SortOrder = 8,
                Value = 8
            };
    }
}