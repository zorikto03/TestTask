using System.Collections.Generic;

namespace TestTask.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Sale> Sales { get; set; }

        public Buyer(string name)
        {
            this.Name = name;
        }
    }
}
