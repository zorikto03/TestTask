using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SalesPointId { get; set; }

        [ForeignKey("BuyerId")]
        public int? BuyerId { get; set; }
        public List<SaleData> SalesData { get; set; }
        public float TotalAmount { get; set; }
    }
}
