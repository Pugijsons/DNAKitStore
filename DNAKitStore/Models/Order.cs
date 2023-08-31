namespace DNAKitStore.Models;

public class Order
{
    public int CustomerId { get; set; }
    public DateTime ExpectedDelivery { get; set; }
    public int KitQuantity { get; set; }
    public IBaseDnaKit KitType { get; set; }
    public decimal FinalOrderPrice { get; set; } = 0;

    public Order(int customerId, DateTime expectedDelivery, int kitQuantity, IBaseDnaKit kitType)
    {
        CustomerId = customerId;
        ExpectedDelivery = expectedDelivery;
        KitQuantity = kitQuantity;
        KitType = kitType;
    }
}