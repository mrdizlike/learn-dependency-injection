public class SecureMessageWriter : IMessageWriter
{ // Стандартный способ применения паттерна "Декоратор"
    private readonly IMessageWriter writer;
    private readonly System.Security.Principal.WindowsIdentity identity;

    public SecureMessageWriter(
        IMessageWriter writer,
        System.Security.Principal.WindowsIdentity identity
    )
    {
        if (writer == null)
            throw new ArgumentNullException("writer");
        if (identity == null)
            throw new ArgumentNullException("identity");

        this.writer = writer;
        this.identity = identity;
    }

    public void Write(string message)
    {
        // if (this.identity.IsAuthenticated)
        // {
        //     this.writer.Write(message);
        // }
    }
}