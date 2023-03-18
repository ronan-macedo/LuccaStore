namespace LuccaStore.Core.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<ProductEntity>? Products { get; set; }
    }
}
