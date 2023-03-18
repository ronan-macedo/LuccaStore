using Microsoft.AspNetCore.Identity;

namespace LuccaStore.Domain.Models.Identity
{
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;        
    }
}
