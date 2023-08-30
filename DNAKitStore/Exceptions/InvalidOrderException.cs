namespace DNAKitStore.Exceptions;

public class InvalidOrderException : Exception
{
    public InvalidOrderException() : base("Invalid order parameters")
    {
    }
}