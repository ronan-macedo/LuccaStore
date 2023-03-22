using Newtonsoft.Json;

namespace LuccaStore.Core.Domain.Common
{
    public class ApiErrorResponse
    {
        public string? Error { get; set; }
        public string? Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ValidationErro>? ValidationErrors { get; set; }
    }
}
