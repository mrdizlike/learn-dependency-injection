
public class Salutation
{
    private readonly IMessageWriter writer;

    public Salutation(IMessageWriter writer)
    {
        if (writer == null)
            throw new ArgumentNullException("writer");

        this.writer = writer;
    }

    public void ExclaimWillWriteCorrectMessageToMessageWriter()
    {
        var writer = new SpyMessageWriter();
        var sut = new Salutation(writer);
        sut.Exclaim();
        // Assert.Equal(
        //     expected: "Hello DI!",
        //     actual: writer.WrittenMessage);
        // Microsoft.VisualStudio.TestTools.UnitTesting
    }

    public void Exclaim()
    {
        this.writer.Write("Hello DI!");
    }
}