using DAL.Interfaces;
using BLL.Interfaces;
using DAL.Entities;
using BLL.ModelsDTO.Resources;
using BLL.ModelsDTO.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace BLL.Services{
    public class OrderService:IOrderService{
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork,IMapper mapper){
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders(){
            IEnumerable<Order> orders = await unitOfWork.OrderRepository.GetAllWithProducts();
            IEnumerable<OrderDTO> ordersDTO = mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

        public async Task<OrderDTO> GetOrderById(int id){
            Order order = await unitOfWork.OrderRepository.GetWithProductsById(id);
            OrderDTO orderDTO = mapper.Map<OrderDTO>(order);
            return orderDTO;
        }
        
        public async Task<IEnumerable<OrderProduct>> AddOrder(OrderResource orderResource){
            Order order = mapper.Map<Order>(orderResource);
            await unitOfWork.OrderRepository.AddAsync(order);
            await unitOfWork.Save();
            var orderResources = (await unitOfWork.OrderProductRepository.GetAllAsync()).Where(c=>c.OrderId==order.Id);
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            Order train = (await unitOfWork.OrderRepository.GetAllWithProducts()).Where(c => c.Id == order.Id).FirstOrDefault();
            foreach (var i in orderResources)
            {
                i.Order = (await unitOfWork.OrderRepository.GetAllAsync()).Where(c => c.Id == i.OrderId).FirstOrDefault();
                i.Product = (await unitOfWork.ProductRepository.GetAllAsync()).Where(c => c.Id == i.ProductId).FirstOrDefault();
                unitOfWork.OrderProductRepository.Update(i);
            }

            await unitOfWork.Save();
            return orderResources;
            //return train;
        }

        public async Task<Order> GetById(int id)
        {
            return await unitOfWork.OrderRepository.GetWithProductsById(id);
        }

        public async Task<int> FindOrderId(OrderResource orderResource){
            Order order = mapper.Map<Order>(orderResource);
            IEnumerable<Order> orders = await unitOfWork.OrderRepository.GetAllWithProducts();
            int Id = -1;
            foreach(var i in orders){
                if(i  == order){
                    Id = i.Id;
                }
            }
            return Id;
        }

        public async Task DeleteOrderById(int id){
            Order order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            unitOfWork.OrderRepository.Remove(order);
            await unitOfWork.Save();
        }

        public async Task DeleteAllOrders(){
            IEnumerable<Order> orders = await unitOfWork.OrderRepository.GetAllAsync();
            unitOfWork.OrderRepository.RemoveRange(orders);
            await unitOfWork.Save();
        }

        public async Task<OrderProduct> UpdateOrder(int productId,int orderId)
        {
            Product product = await unitOfWork.ProductRepository.GetWithOrderById(productId);
            Order order= await unitOfWork.OrderRepository.GetWithProductsById(orderId);
            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = orderId,
                ProductId = productId,
                Product = product,
                Order = order
            };
            //await unitOfWork.OrderProductRepository.AddAsync(orderProduct);
            order.OrderProducts.Add(orderProduct);
            await unitOfWork.Save();
            return orderProduct;
        }
    }
}