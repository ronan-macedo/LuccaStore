using Microsoft.AspNetCore.Identity;

namespace LuccaStore.Core.Domain.Entities
{
    public class IdentityEntity
    {
        public IdentityUser User { get; set; } = new IdentityUser();
        public IList<string>? Roles { get; set; }
    }
}
