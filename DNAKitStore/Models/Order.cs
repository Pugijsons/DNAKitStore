namespace DNAKitStore.Models;

public class Order
{
    public int CustomerId { get; set; }
    public DateTime ExpectedDelivery { get; set; }
    public int KitQuantity { get; set; }
    public BaseDnaKit KitType { get; set; }
    public double FinalOrderPrice { get; set; } = 0;

    public Order(int customerId, DateTime expectedDelivery, int kitQuantity, BaseDnaKit kitType)
    {
        CustomerId = customerId;
        ExpectedDelivery = expectedDelivery;
        KitQuantity = kitQuantity;
        KitType = kitType;
    }
}