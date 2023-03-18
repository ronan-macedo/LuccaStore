namespace LuccaStore.Core.Domain.Dtos.Identity
{
    public class LoginResponseDto
    {
        public string? AccessToken { get; set; }
        public DateTime? ExpireIn { get; set; }
    }
}
