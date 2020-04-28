using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DAL;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using BLL.Interfaces;
using DAL.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService orderService;
        private IOrderProductService orderProductService;
        private IProductService productService;
        public OrdersController(IOrderService orderService,IOrderProductService orderProductService,IProductService productService)
        {
            this.orderService = orderService;
            this.orderProductService = orderProductService;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {   
            IEnumerable<OrderDTO> orderDTOs = await orderService.GetAllOrders();
            return orderDTOs;
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> GetOrderId(int id)
        {
            OrderDTO order = await orderService.GetOrderById(id);

            return order;
        }

        //[Route("api/[controller]/{orderId}/products")]
        [HttpGet("{orderId}/products")]
        public async Task<IEnumerable<ProductDTO>> GetProductsByOrderId(int orderId)
        {
            OrderDTO order = await orderService.GetOrderById(orderId);

            IEnumerable<ProductDTO> products = order.OrderProducts.Select(c => c.Product);

            return products;
        }

        [HttpPut("{orderId}/products")]
        public async Task<OrderProduct> AddProductToOrder(OrderProductDTO orderProductDTO)
        {
            //await orderService.UpdateOrder(productId, orderId);
            return await orderService.UpdateOrder(orderProductDTO.ProductId, orderProductDTO.OrderId);
            
            //return NoContent();
        }

        [HttpPost]
        public async Task<IEnumerable<OrderProduct>> AddOrder(OrderResource order)
        {
            var order1 =  await orderService.AddOrder(order);
            return order1;
        }

        [Route("api/orders")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            OrderDTO orderDTO = await orderService.GetOrderById(id);
            if(orderDTO == null){
                return BadRequest();
            }

            await orderService.DeleteOrderById(id);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await orderService.DeleteAllOrders();
            return NoContent();
        }
    }
}