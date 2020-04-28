using BLL.Interfaces;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using DAL.Interfaces;
using AutoMapper;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BLL.Services{
    public class ProductService:IProductService{
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork,IMapper mapper){
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts(){
            var products = await unitOfWork.ProductRepository.GetAllAsync();
            IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<ProductDTO>>(products);
            return productsDTO;
        }

        public async Task<ProductDTO> GetProductById(int id){
            Product product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            ProductDTO productDTO = mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task AddProduct(ProductResource productResource){
            Product product = mapper.Map<Product>(productResource);
            await unitOfWork.ProductRepository.AddAsync(product);
            await unitOfWork.Save();
            
        }

        
    }
}