using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestTask.Models
{
    public class Initialize
    {
        public static void Init(TT_DB_Context context)
        {
         //   context.Database.Migrate();
            if (!context.Buyers.Any())
            {
                var buyer = new Buyer("firstBuyer");
                context.Add(buyer);

                var product = new Product("product1", 100f);
                var product1 = new Product("product2", 120f);
                context.Add(product);
                context.Add(product1);
            
                var point = new SalesPoint("salesPoint#1");
                context.Add(point);

                context.SaveChanges();

                var provided = new ProvidedProduct(point.Id, product.Id, 10);
                var provided2 = new ProvidedProduct(point.Id, product1.Id, 10);

                context.Add(provided);
                context.Add(provided2); 
                point.ProvidedProducts.Add(provided);
                point.ProvidedProducts.Add(provided2);
                context.SaveChanges();
            }
        }
    }
}
