namespace Application.Exceptions
{
    public class CustomException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public CustomException(string message)
            : base(message)
        {
            Errors = new[] { message };
        }

        public CustomException(IEnumerable<string> errors)
            : base("One or more business rules were violated.")
        {
            Errors = errors;
        }
    }
}
