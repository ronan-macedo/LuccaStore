namespace LuccaStore.Core.Domain.Common
{
    public class ApiErrorResponse
    {
        public string? Error { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationErro>? ValidationErrors { get; set; }
    }
}
