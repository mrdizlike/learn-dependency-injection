using System.Windows.Input;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = LoadConnectionString();

        CurrencyParser parser = CreateCurrencyParser(connectionString);

        ICommand command parser.Parse(args);
        command.Execute();
    }

    static string LoadConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build()

        return configuration.GetConnectionString("CommerceConnectionString");
    }

    static CurrencyParser CreateCurrencyParser(string connectionString)
    {
        IExchangeRateProvider provider = new SqlExchangeRateProvider(
            new CommerceContext(connectionString));
        
        return new CurrencyParser(provider);
    }
}