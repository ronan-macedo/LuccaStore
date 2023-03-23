namespace LuccaStore.Core.Domain.Dtos.Categories
{
    public class CategoryResponseDto
    {
        public Guid? Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
