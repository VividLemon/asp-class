namespace Lab_03.Models
{
    public class Product
    {
        public Product(bool stock = true) { InStock = stock; }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get;set; }
        public bool InStock { get; }
        public bool NameBeginsWithS => Name?[0] == 'S';

        public static Product[] GetProducts ()
        {
            Product lifeJacket = new Product(false) { Name = "Life Jacket", Price = 58.95M };
            Product kayak = new Product() { Name = "Kayak", Price = 275M, Category = "Water Craft", Related = lifeJacket };
            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
