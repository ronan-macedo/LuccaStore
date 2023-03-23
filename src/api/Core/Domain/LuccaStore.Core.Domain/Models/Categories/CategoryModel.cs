namespace LuccaStore.Core.Domain.Models.Categories
{
    public class CategoryModel
    {
        public Guid? Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
