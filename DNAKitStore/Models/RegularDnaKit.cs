namespace DNAKitStore.Models;

public class RegularDnaKit : BaseDnaKit
{
    public override double Price => 98.99;

    public override string DnaKitToString()
    {
        return "Regular DNA kit";
    }
}