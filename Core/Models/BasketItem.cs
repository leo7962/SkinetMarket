namespace Core.Models
{
    public class BasketItem
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public decimal Priuce { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Brrand { get; set; }
        public string Type { get; set; }
    }
}