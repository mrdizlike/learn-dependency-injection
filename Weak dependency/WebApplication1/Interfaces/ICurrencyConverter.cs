using System.Data.SqlTypes;

public interface ICurrencyConverter
{
    Money Exchange(Money money, Currency targetCurrency);
}