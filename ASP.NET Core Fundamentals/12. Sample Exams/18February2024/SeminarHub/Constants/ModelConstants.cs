namespace SeminarHub.Constants
{
    public static class ModelConstants
    {
        //Seminar

        public const int SeminarTopicMinLength = 3;
        public const int SeminarTopicMaxLength = 100;

        public const int SeminarLecturerMinLength = 5;
        public const int SeminarLecturerMaxLength = 60;

        public const int SeminarDetailsMinLength = 10;
        public const int SeminarDetailsMaxLength = 500;

        public const string SeminarDateAndTimeRegexFormat = @"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$";

        public const int SeminarDurationMinLength = 30;
        public const int SeminarDurationMaxLength = 180;

        //Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;
    }

   
}
