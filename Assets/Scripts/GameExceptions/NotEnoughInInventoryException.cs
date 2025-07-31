namespace GameExceptions
{
    public class NotEnoughInInventoryException : System.Exception
    {
        public NotEnoughInInventoryException(string message) : base(message) { }
    }
}