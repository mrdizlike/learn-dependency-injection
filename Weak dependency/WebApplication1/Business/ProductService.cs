public class productService : IProductService
{
    private readonly IProductRepository repository;
    private readonly IUserContext userContext;
    private readonly ICurrencyConverter converter;

    public productService(
        IProductRepository repository,
        IUserContext userContext,
        ICurrencyConverter converter)
    {
        if (repository == null)
            throw new ArgumentNullException("repository");
        if (userContext == null)
            throw new ArgumentNullException("userContext");
        if (converter == null)
            throw new ArgumentNullException("converter");

        this.repository = repository;
        this.userContext = userContext;
        this.converter = converter;
    }

    public IEnumerable<DiscountedProduct> GetFeaturedProducts()
    {
        Currency currency = this.userContext.Currency;

        return
            from product in this.repository.GetFeaturedProducts()
            select product
                .ConvertTo(currency, this.converter)
                .ApplyDiscountFor(this.userContext);
    }
}