namespace DNAKitStore.Exceptions;

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException() : base("Order quantity is invalid!")
    {

    }
}