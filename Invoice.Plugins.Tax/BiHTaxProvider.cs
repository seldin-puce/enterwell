using System.ComponentModel.Composition;

namespace Invoice.Plugins.Tax
{
    [Export(typeof(ITax))]
    [ExportMetadata("TaxValue", "17 %")]
    public class BiHTaxProvider : ITax
    {
        public decimal Calculate(decimal value)
        {
            return value * 0.17M;
        }
    }
}
