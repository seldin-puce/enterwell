namespace Invoice.Plugins.Tax
{
    public interface ITax
    {
        decimal Calculate(decimal value);
    }
}
