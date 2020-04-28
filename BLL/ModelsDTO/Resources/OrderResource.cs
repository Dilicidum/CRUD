using System.Collections.Generic;
using BLL.ModelsDTO.DTO;
namespace BLL.ModelsDTO.Resources{
    public class OrderResource{
        public ICollection<OrderProductDTO> OrderProducts{get;set;} 
    }
}