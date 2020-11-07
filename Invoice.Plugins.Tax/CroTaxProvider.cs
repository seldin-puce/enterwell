using System.ComponentModel.Composition;

namespace Invoice.Plugins.Tax
{
    [Export(typeof(ITax))]
    [ExportMetadata("TaxValue", "25 %")]
    public class CroTaxProvider : ITax
    {
        public decimal Calculate(decimal value)
        {
            return value * 0.25M;
        }
    }
}
