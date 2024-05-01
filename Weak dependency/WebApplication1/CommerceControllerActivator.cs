using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebApplication1.Controllers;

public class CommerceControllerActivator : IControllerActivator
{
    private readonly string connectionString;

    public CommerceControllerActivator(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public object Create(ControllerContext ctx)
    {
        Type type = ctx.ActionDescriptor
            .ControllerTypeInfo.AsType();

            if (type == typeof(HomeController))
            { //Граф объектов
                return 
                    new HomeController(
                            new productService(
                                new SqlProductRepository(
                                    new CommerceContext(
                                        this.connectionString)),
                                        new AspNetUserContextAdapter()));
            } 
            else
            {
                throw new Exception("Unknown controller.");
            }
    }

    public void Release(ControllerContext context, object controller)
    {
        throw new NotImplementedException();
    }
}