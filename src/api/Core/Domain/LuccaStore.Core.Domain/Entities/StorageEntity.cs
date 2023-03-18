namespace LuccaStore.Core.Domain.Entities
{
    public class StorageEntity : BaseEntity
    {
        public Guid ProductId { get; set; }
        public double QuantityInStorage { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
