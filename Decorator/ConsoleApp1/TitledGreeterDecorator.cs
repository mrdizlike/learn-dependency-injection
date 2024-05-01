public class TitledGreeterDecorator : IGreeter
{
    private readonly IGreeter decoratee;

    public TitledGreeterDecorator(IGreeter decoratee)
    {
        this.decoratee = decoratee;
    }

    public string Greet(string name)
    {
        string titledName = "Mr. " + name;
        return titledName;
    }
}