namespace MyProject.Domain.Orders.ValueObjects;

public record Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    protected Money() { } // For EF

    public Money(decimal amount, string currency = "USD")
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be non-negative.");
        if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Currency is required.", nameof(currency));

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }
}