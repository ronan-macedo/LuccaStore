namespace LuccaStore.Core.Domain.Entities
{
    public enum Type
    {
        BankDeposit,
        DebitCard,
        CreditCard
    }

    public class PaymentMethodEntity : BaseEntity
    {
        public string PaymentMethodName { get; set; } = string.Empty;
        public Type PaymentType { get; set; }
    }
}
