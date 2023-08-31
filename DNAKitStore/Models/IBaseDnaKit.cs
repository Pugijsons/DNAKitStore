namespace DNAKitStore.Models;

public interface IBaseDnaKit
{
    public decimal Price { get; }
    public string DnaKitToString();
}