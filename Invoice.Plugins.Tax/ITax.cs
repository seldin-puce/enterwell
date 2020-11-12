namespace Invoice.Plugins.Tax
{
    public interface ITax
    {
        double Calculate(double value);
    }
}
