namespace DNAKitStore.Exceptions;

public class InvalidDeliveryDateException : Exception
{
    public InvalidDeliveryDateException() : base("Invalid delivery date!") { }
}