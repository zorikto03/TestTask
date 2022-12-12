namespace TestTask.Models
{
    public class ProvidedProduct
    {
        public int Id { get; set; }
        public int SalesPointId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public ProvidedProduct(int salesPointId, int productId, int count)
        {
            ProductId = productId;
            Count = count;
        }
    }
}
