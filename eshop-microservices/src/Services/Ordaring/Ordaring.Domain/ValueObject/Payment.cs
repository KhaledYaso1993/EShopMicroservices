namespace Ordaring.Domain.ValueObject;

public record Payment
{

    public string? CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiraton { get; } = default!;
    public string CVV { get; } = default!;
    public string PaymentMethod { get; } = default!;

    protected Payment() { }
    private Payment(string? cardName, string cardNumber, string expiraton, string cVV, string paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiraton = expiraton;
        CVV = cVV;
        PaymentMethod = paymentMethod;



    }

    public static Payment Of(string? cardName, string cardNumber, string expiraton, string cVV, string paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cVV);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cVV.Length, 3);
        return new Payment(cardName, cardNumber, expiraton, cVV, paymentMethod);


    }

}
