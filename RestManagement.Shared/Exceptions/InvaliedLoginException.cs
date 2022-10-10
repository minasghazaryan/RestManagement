namespace RestManagement.Shared.Exceptions
{
    public class InvaliedLoginException : Exception
    {
        public InvaliedLoginException() : base("Login or password not correct") { }
        public InvaliedLoginException(Exception ex) : base("Login or password not correct", ex) { }
    }
}
