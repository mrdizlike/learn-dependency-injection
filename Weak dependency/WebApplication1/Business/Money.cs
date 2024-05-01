public class Money
{
    public readonly decimal Amount;
    public readonly Currency Currency;

    public Money(decimal amount, Currency currency)
    {
        if (currency == null) throw new ArgumentNullException("currency");

        this.Amount = amount;
        this.Currency = currency;
    }
}