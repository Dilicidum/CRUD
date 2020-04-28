using System.Collections.Generic;
namespace BLL.ModelsDTO.DTO{
    public class OrderDTO{
        public int Id{get;set;}
        public ICollection<OrderProductDTO> OrderProducts { get; set; }
    }
}