namespace TestTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
