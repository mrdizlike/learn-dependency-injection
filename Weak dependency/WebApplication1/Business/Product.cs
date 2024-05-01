using Microsoft.AspNetCore.Identity;

public class Product
{
    public string Name { get; set; }
    public Money UnitPrice { get; set; }
    public bool IsFeatured { get; set; }

    public Product ConvertTo(Currency currency, ICurrencyConverter converter)
    {
        if (currency == null)
            throw new ArgumentNullException("currency");
        if (converter == null)
            throw new ArgumentNullException("converter");

        var newUnitPrice = converter.Exchange(this.UnitPrice, currency);
        return this.WithUnitPrice(newUnitPrice);
    }

    public Product WithUnitPrice(Money unitPrice)
    {
        return new Product
        {
            Name = this.Name,
            UnitPrice = unitPrice,
            IsFeatured = this.IsFeatured
        };
    }

    public DiscountedProduct ApplyDiscountFor(IUserContext user)
    {
        bool preferred = user.IsInRole(Role.PreferredCustomer);

        decimal discount = preferred ? .95m : 1.00m;

        return new DiscountedProduct(name: this.Name, unitPrice: this.UnitPrice.Amount * discount);
    }
}