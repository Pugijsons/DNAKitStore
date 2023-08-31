using DNAKitStore.Validation;

namespace DNAKitStore.tests;

public class OrderValidationTests
{

    private IOrderValidation _orderValidation;

    [SetUp]
    public void Setup(IOrderValidation orderValidation)
    {
        _orderValidation = orderValidation;
    }


}