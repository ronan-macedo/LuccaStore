namespace LuccaStore.Core.Domain.Entities
{
    public class PaymentTypeEntity : BaseEntity
    {
        public string PaymentTypeName { get; set; } = string.Empty;
        public ICollection<PaymentMethodEntity>? PaymentMethods { get; set; }
    }
}
