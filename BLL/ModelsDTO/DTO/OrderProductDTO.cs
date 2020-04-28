namespace BLL.ModelsDTO.DTO{
    public class OrderProductDTO{
        public OrderDTO Order{get;set;}
        public ProductDTO Product{get;set;}
        public int ProductId{get;set;}
        public int OrderId{get;set;}
    }
}