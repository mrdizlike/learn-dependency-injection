public class Currency
{
    public readonly string Code;

    public Currency(string code)
    {
        if (code == null) throw new ArgumentNullException("code");

        this.Code = code;
    }
}