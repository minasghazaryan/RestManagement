namespace RestManagement.Shared.Exceptions
{
    public class InvalidRegisterException : Exception
    {
        public InvalidRegisterException(string message) : base(message) { }
        public InvalidRegisterException(Exception ex , string message) : base(message, ex) { }
    }
}
