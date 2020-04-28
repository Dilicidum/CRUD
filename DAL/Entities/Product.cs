using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
