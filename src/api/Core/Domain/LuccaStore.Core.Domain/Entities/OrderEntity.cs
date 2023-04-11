namespace LuccaStore.Core.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public IList<OrderLinesEntity>? Lines { get; set; }
        public Guid PaymentMethodId { get; set; }
        public double TotalPrice { get; set; }
        public PaymentMethodEntity PaymentMethod { get; set; } = new PaymentMethodEntity();
    }
}
