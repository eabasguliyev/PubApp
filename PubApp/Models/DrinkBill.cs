namespace PubApp.Models
{
    public class DrinkBill
    {
        public Drink Drink { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public decimal Cost { get; set; }
    }
}