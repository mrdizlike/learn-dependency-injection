using Microsoft.AspNetCore.Mvc.Controllers;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddHttpContextAccessor();

        var connectionString = this.Configuration.GetConnectionString("CommerceConnection");

        services.AddSingleton<IControllerActivator>(new CommerceControllerActivator(connectionString));
    }
}