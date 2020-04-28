using AutoMapper;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using DAL.Entities;
namespace BLL.MappingProfiles{
    public class ModelToResource:Profile{
        public ModelToResource(){
            CreateMap<Order,OrderResource>();
            CreateMap<OrderDTO,OrderResource>();
            CreateMap<Product,ProductDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>()
                .ForMember(dest=>dest.OrderProducts,act=>act.MapFrom(src=>src.OrderProducts));
            CreateMap<ProductDTO, Product>();
            CreateMap<Product,ProductResource>();
            CreateMap<OrderProduct,OrderProductDTO>()
                .ForMember(dest => dest.Order, act => act.MapFrom(src => src.Order))
                .ForMember(dest => dest.Product, act => act.MapFrom(src => src.Product));
            CreateMap<OrderProductDTO, OrderProduct>()
                .ForMember(dest=>dest.Order,act=>act.MapFrom(src=>src.Order))
                .ForMember(dest=>dest.Product,act=>act.MapFrom(src=>src.Product));
        }
    }
}