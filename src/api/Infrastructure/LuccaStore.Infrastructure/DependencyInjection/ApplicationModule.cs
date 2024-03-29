﻿using Autofac;
using LuccaStore.Application.Services;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Application.Services;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Infrastructure.Data.Repository;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Add Service DI
            builder.RegisterType<IdentityService>().As<IIdentityService>().InstancePerDependency();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerDependency();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerDependency();

            // Add Repository DI
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<IdentityRepository>().As<IIdentityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
        }
    }
}
