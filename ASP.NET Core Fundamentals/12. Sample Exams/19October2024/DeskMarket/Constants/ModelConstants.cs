namespace DeskMarket.Constants
{
    public static class ModelConstants
    {
        //Product
        public const int ProductProductNameMinLength = 2;
        public const int ProductProductNameMaxLength = 60;

        public const int ProductDescriptionMinLength = 10;
        public const int ProductDescriptionMaxLength = 250;

        public const decimal ProductPriceMinLength = 1.00m;
        public const decimal ProductPriceMaxLength = 3000.00m;

        public const string ProductAddedOnFormat = "dd-MM-yyyy";

        //Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;
    }
   
}
