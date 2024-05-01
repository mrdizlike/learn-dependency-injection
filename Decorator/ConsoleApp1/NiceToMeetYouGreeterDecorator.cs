public class NiceToMeetYouGreeterDecorator : IGreeter
{
    private readonly IGreeter decoratee;

    public NiceToMeetYouGreeterDecorator(IGreeter decoratee)
    {
        this.decoratee = decoratee;
    }

    public string Greet(string name)
    {
        string greet = this.decoratee.Greet(name);
        return greet + " Nice to meet you.";
    }
}