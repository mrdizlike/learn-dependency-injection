using System.Security.Principal;

internal class Program
{
    private static void Main()
    {
        // IMessageWriter securedWriter = new SecureMessageWriter(
        //     new ConsoleMessageWriter(),
        //     WindowsIdentity.GetCurrent()
        // ); 
        //ConsoleMessageWriter перехватывается декоратором SecureMessageWriter

        IMessageWriter writer = new ConsoleMessageWriter(); //Просто создаем новый экземпляр класса

        var salutation = new Salutation(writer);
        salutation.Exclaim();
    }
}