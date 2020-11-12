using System.ComponentModel.Composition;

namespace Invoice.Plugins.Tax
{
    [Export(typeof(ITax))]
    [ExportMetadata("TaxValue", "25 %")]
    public class CroTaxProvider : ITax
    {
        public double Calculate(double value)
        {
            return value * 0.25;
        }
    }
}
