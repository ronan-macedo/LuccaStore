namespace LuccaStore.Core.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }
        public double Price { get; set; }        
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = new CategoryEntity();
        public IList<OrderLinesEntity>? Lines { get; set; }
        public StorageEntity? Storage { get; set; }
    }
}
