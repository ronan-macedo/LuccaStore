namespace LuccaStore.Core.Domain.Entities
{
    public class PaymentMethodEntity : BaseEntity
    {
        public string PaymentMethodName { get; set; } = string.Empty;
        public Guid PaymentTypeId { get; set; }
        public PaymentTypeEntity PaymentType { get; set;} = new PaymentTypeEntity();
    }
}
