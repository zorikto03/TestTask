using System.Collections.Generic;

namespace TestTask.Models
{
    public class SalesPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProvidedProduct> ProvidedProducts { get; set; }

        public SalesPoint(string name)
        {
            Name = name;
        }
    }
}
