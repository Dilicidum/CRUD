using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
