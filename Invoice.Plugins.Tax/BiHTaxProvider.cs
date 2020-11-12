using System.ComponentModel.Composition;

namespace Invoice.Plugins.Tax
{
    [Export(typeof(ITax))]
    [ExportMetadata("TaxValue", "17 %")]
    public class BiHTaxProvider : ITax
    {
        public double Calculate(double value)
        {
            return value * 0.17;
        }
    }
}
