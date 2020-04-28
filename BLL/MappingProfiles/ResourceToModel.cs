using DAL.Entities;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using AutoMapper;

namespace BLL.MappingProfiles{
    public class ResourceToModel:Profile{
        public ResourceToModel(){
            CreateMap<ProductResource,Product>();
            CreateMap<OrderResource,Order>();
            CreateMap<OrderProductDTO, OrderProduct>();
        }
    }
}