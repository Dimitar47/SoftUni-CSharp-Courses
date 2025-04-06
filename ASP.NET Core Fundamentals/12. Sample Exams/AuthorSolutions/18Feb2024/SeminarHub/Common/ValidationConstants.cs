namespace SeminarHub.Common
{
    public static class ValidationConstants
    {
        // Seminar validation constants
        public const int SeminarTopicMinLength = 3;
        public const int SeminarTopicMaxLength = 100;
        public const int SeminarLecturerMinLength = 5;
        public const int SeminarLecturerMaxLength = 60;
        public const int SeminarDetailsMinLength = 10;
        public const int SeminarDetailsMaxLength = 500;
        public const int SeminarDurationMin = 30;
        public const int SeminarDurationMax = 180;

        // Category validation constants
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;
    }
}
