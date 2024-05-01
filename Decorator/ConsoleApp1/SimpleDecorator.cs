public class SimpleDecorator : IGreeter
{
    private readonly IGreeter decoratee;

    public SimpleDecorator(IGreeter decoratee)
    {
        this.decoratee = decoratee;
    }

    public string Greet(string name)
    {
        return this.decoratee.Greet(name);
    }
}