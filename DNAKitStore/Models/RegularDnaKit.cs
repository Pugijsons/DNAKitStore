namespace DNAKitStore.Models;

public class RegularDnaKit : IBaseDnaKit
{
    public decimal Price => 98.99m;

    public string DnaKitToString()
    {
        return "Regular DNA kit";
    }
}