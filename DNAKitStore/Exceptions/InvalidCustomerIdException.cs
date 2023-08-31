namespace DNAKitStore.Exceptions;

public class InvalidCustomerIdException : Exception
{
    public InvalidCustomerIdException() : base("Invalid customer id provided!")
    {

    }
}