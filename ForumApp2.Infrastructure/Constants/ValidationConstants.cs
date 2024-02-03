namespace ForumApp2.Infrastructure.Constants
{
    /// <summary>
    /// Constants values used for model validation
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Minimal post title length
        /// </summary>
        public const int TitleMinLength = 10;

        /// <summary>
        /// Maximal post title length
        /// </summary>
        public const int TitleMaxLength = 50;

        /// <summary>
        /// Minimal post content length
        /// </summary>
        public const int ContentMinLength = 30;

        /// <summary>
        /// Maximal post content length
        /// </summary>
        public const int ContentMaxLength = 1500;

        /// <summary>
        /// The text used for "Required" error
        /// </summary>
        public const string RequiredErrorMessage = "The field {0} is required";

        /// <summary>
        /// The text shows the error for length of field
        /// </summary>
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
