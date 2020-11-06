namespace Invoice.Model.Request
{
    public class Item
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalUnitRawPrice { get; set; }
    }
}
