namespace Beekeeping.Common.Validations
{

    //To be in separate project and they will be used again in ViewModels
    public static class DataConstants
    {
        public static class ApiaryValidations
        {
            public const int ApiaryNameMinLenght = 3;
            public const int ApiaryNameMaxLenght = 40;

            public const int LocationMinLenght = 4;
            public const int LocationMaxLenght = 200;

            public const int OwnerIdMinLenght = 30;
            public const int OwnerIdMaxLenght = 34;

        }

        public static class BeeHiveValidations
        {
            public const int PlateNumberMaxLenght = 100;
        }

        public static class BeeQueenValidations
        {
            public const int BreederMaxLenght = 100;
        }

        public static class HiveTreatmentValidations
        {
            public const int MedicationNameMaxLenght = 50;

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
    }
}
