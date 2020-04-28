using System.Threading.Tasks;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using System.Collections.Generic;
namespace BLL.Interfaces{
    public interface IProductService{
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductResource productResource);
    }
}