using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
