// ReSharper disable UnusedType.Global

namespace Modulos.Autofac
{
    using System;
    using global::Autofac;
    using global::Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class AutofacModulosServiceProviderFactory : ModulosServiceProviderFactoryBase<ContainerBuilder>
    {
        public AutofacModulosServiceProviderFactory(ModulosApp modulos, HostBuilderContext context, Action<AutoRegistrationModule> modifier = null)
            : base
            (
                modulos,
                collection => new ContainerBuilder(),
                modifier,
                context, context.Configuration, context.HostingEnvironment
            )
        {
        }

        protected override void Populate(ContainerBuilder builder, IServiceCollection collection)
        {
            builder.Populate(collection);
        }

        protected override IServiceProvider Build(ContainerBuilder builder)
        {
            return new AutofacServiceProvider(builder.Build());
        }
    }
}