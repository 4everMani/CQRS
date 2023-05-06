namespace Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ErrorsMessages { get; set; }

        public string FriendlyErrorMessage { get; set; }

        public CustomValidationException(string friendlyErrorMessage, List<string> errorsMessages)
            : base(friendlyErrorMessage)
        {
            FriendlyErrorMessage = friendlyErrorMessage;
            ErrorsMessages = errorsMessages;
        }
    }
}
