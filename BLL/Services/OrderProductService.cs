using BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using DAL.Entities;
using AutoMapper;
using System;

namespace BLL.Services{
    public class OrderProductService:IOrderProductService{
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public OrderProductService(IUnitOfWork unitOfWork,IMapper mapper){
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProduct(){
            IEnumerable<OrderProduct> ordersProducts = await unitOfWork.OrderProductRepository.GetAllWithOrderAndProductAsync();
            IEnumerable<OrderProductDTO> orderProductDTOs = mapper.Map<IEnumerable<OrderProductDTO>>(ordersProducts);
            return orderProductDTOs;
        }

        public OrderProduct UpdateOrderProduct(OrderProductDTO orderProductDTO)
        {
            OrderProduct orderProduct = mapper.Map<OrderProduct>(orderProductDTO);
            unitOfWork.OrderProductRepository.UpdateOrderProduct(orderProduct);
            //await unitOfWork.Save();
            return orderProduct;
        }
    }
}