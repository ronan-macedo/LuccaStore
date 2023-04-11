using Autofac;
using AutoMapper;
using LuccaStore.Infrastructure.Mappings;

namespace LuccaStore.Infrastructure.DependencyInjection
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly)
                .AssignableTo(typeof(Profile))
                .As<Profile>()
                .SingleInstance();

            builder.Register(context => new MapperConfiguration(config =>
            {
                config.AddProfile<DtoToModelProfile>();
                config.AddProfile<ModelToDtoProfile>();
                config.AddProfile<ModelToEntityProfile>();
                config.AddProfile<EntityToModelProfile>();
                config.AddProfile<EntityToDtoProfile>();                
            })).AsSelf().SingleInstance();

            builder.Register(context => context.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}
