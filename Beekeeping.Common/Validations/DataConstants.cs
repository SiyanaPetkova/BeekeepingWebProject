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

        }

        public static class BeeColonyValidations
        {
            public const int PlateNumberMinLenght = 10;
            public const int PlateNumberMaxLenght = 100;
        }

        public static class BeeQueenValidations
        {
            public const int BreederMinLenght = 3;
            public const int BreederMaxLenght = 100;

            public const int BeeQueenTypeMinLenght = 3;
            public const int BeeQueenTypeMaxLenght = 100;
        }

        public static class HiveTreatmentValidations
        {
            public const int MedicationNameMinLenght = 3;
            public const int MedicationNameMaxLenght = 50;

            public const int ActiveIngredientMinLenght = 3;
            public const int ActiveIngredientMaxLenght = 70;
        }

        public static class FeedingValidations
        {
            public const int FeedintTypeMinLenght = 2;

            public const int FeedintTypeMaxLenght = 70;
        }

        public static class InspectionValidations
        {
            public const int InspectionMinLenght = 2;

            public const int InspectionMaxLenght = 2500;
        }

        public static class IncomeValidations
        {
            public const int IncomeTypeMinLenght = 2;

            public const int IncomeTypeMaxLenght = 100;
        }

        public static class CostValidations
        {
            public const int CostTypeMinLenght = 2;

            public const int CostTypeMaxLenght = 100;
        }

        public static class GalleryValidations
        {
            public const int PicturePathMaxLenght = 2500;

            public const int PictureNameMaxLenght = 70;
        }

        public static class ApplicationUserValidations
        {
            public const int PasswordMinLength = 8;

            public const int PasswordMaxLength = 50;
         
        }
    }
}
