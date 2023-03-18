namespace LuccaStore.Core.Domain.Entities
{
    public class OrderLinesEntity : BaseEntity
    {
        public double Quantity { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = new ProductEntity();
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; } = new OrderEntity();
    }
}
