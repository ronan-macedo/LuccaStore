using LuccaStore.Core.Domain.Entities;
using LuccaStore.Infrastructure.Data.Context;

namespace LuccaStore.Infrastructure.Data.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethodEntity>
    {

        public PaymentMethodRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
