namespace Invoice.Data.Model
{
    public class Item : BaseModel<int>
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalUnitRawPrice { get; set; }
    }
}
