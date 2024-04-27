public class SpyMessageWriter : IMessageWriter
{
    public string WrittenMessage { get; private set; }

    public void Write(string message)
    {
        this.WrittenMessage += message;
    }
}