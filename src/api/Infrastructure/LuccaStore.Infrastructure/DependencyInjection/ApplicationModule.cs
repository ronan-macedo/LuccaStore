using Autofac;
using LuccaStore.Application.Services;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Infrastructure.Data.Repository;

namespace LuccaStore.Infrastructure.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Add Service DI
            builder.RegisterType<IdentityService>().As<IIdentityService>().InstancePerDependency();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerDependency();

            // Add Repository DI
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<IdentityRepository>().As<IIdentityRepository>().InstancePerLifetimeScope();
        }
    }
}
