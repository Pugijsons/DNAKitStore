namespace DNAKitStore.Models;

public abstract class BaseDnaKit
{
    public abstract double Price { get; }

    public virtual string DnaKitToString()
    {
        return "Base DNA kit";
    }
}