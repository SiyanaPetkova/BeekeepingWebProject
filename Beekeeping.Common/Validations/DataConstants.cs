namespace Beekeeping.Common.Validations
{
    public static class DataConstants
    {
        public static class ApiaryValidations
        {
            public const int ApiaryNameMinLenght = 3;
            public const int ApiaryNameMaxLenght = 40;

            public const int LocationMinLenght = 4;
            public const int LocationMaxLenght = 200;

            public const int RegistrationMinLenght = 8;
            public const int RegistrationMaxLenght = 10;

            public const int OwnerIdMinLenght = 30;
            public const int OwnerIdMaxLenght = 34;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class BeeColonyValidations
        {
            public const int PlateNumberMinLenght = 1;
            public const int PlateNumberMaxLenght = 100;

            public const int NumberOfSupersMinValue = 0;
            public const int NumberOfSupersMaxValue = 10;

            public const int NumberOfBoxesMinValue = 0;
            public const int NumberOfBoxesMaxValue = 10;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";

        }

        public static class BeeQueenValidations
        {
            public const int BreederMinLenght = 3;
            public const int BreederMaxLenght = 100;

            public const int BeeQueenTypeMinLenght = 3;
            public const int BeeQueenTypeMaxLenght = 100;

            public const int BeeQueenYearMinValue = 2018;
            public const int BeeQueenYearMaxValue = 2050;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";

        }

        public static class HiveTreatmentValidations
        {
            public const int MedicationNameMinLenght = 3;
            public const int MedicationNameMaxLenght = 50;

            public const int ActiveIngredientMinLenght = 3;
            public const int ActiveIngredientMaxLenght = 70;

            public const int TreatmentPriceMinValue = 0;
            public const int TreatmentPriceMaxValue = 10000;

            public const int NumberOfTreatedColoniesMinValue = 1;
            public const int NumberOfTreatedColoniesMaxValue = 10000;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class FeedingValidations
        {
            public const int FeedingTypeMinLenght = 2;
            public const int FeedingTypeMaxLenght = 70;

            public const int FeedingPriceMinValue = 0;
            public const int FeedingPriceMaxValue = 100000;

            public const int NumberOfFedColoniesMinValue = 1;
            public const int NumberOfFedColoniesMaxValue = 10000;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class InspectionValidations
        {
            public const int InspectionDescriptionMinLenght = 2;
            public const int InspectionDescriptionMaxLenght = 2500;

            public const int NumberOfFramesMinLenght = 1;
            public const int NumberOfFramesMaxLenght = 40;

            public const int NumberOfBroodFramesMinLenght = 0;
            public const int NumberOfBroodFramesMaxLenght = 20;

            public const int StrenghtMinLenght = 1;
            public const int StrenghtMaxLenght = 10;

            public const int TemperamentMinLenght = 1;
            public const int TemperamentMaxLenght = 10;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class IncomeValidations
        {
            public const int IncomeTypeMinLenght = 2;
            public const int IncomeTypeMaxLenght = 100;

            public const int IncomeValueMinValue = 0;
            public const int IncomeValueMaxValue = 1000000000;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class CostValidations
        {
            public const int CostTypeMinLenght = 2;
            public const int CostTypeMaxLenght = 100;

            public const int CostValueMinValue = 0;
            public const int CostValueMaxValue = 1000000000;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class NoteToDoValidations
        {
            public const int NoteDescriptionMinLenght = 2;
            public const int NoteDescriptionMaxLenght = 100;

            public const string StringRequirmentRegex = @"[А-Яа-я\s\d\w-.,;():]+";
        }

        public static class ApplicationUserValidations
        {
            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 50;

            public const string RegularExpressionValidation = @"^(?=.*[A-Z])(?=.*\d).+$";

        }
    }
}
