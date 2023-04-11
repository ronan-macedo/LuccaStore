namespace LuccaStore.Core.Domain.Dtos.Identity
{
    public class LoginResponseDto
    {
        public string? Username { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? ExpireIn { get; set; }
    }
}
