using System.Linq;
using System.Reflection;
using Api.Domain.Values;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Container
{
    public static class AutofacConfig
    {
        public static IContainer UseAutofac(this IServiceCollection serviceCollection)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(ValuesController).GetTypeInfo().Assembly).Where(t =>
                    t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(INotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncNotificationHandler<>))
                    )
                )
                .AsImplementedInterfaces();

            builder.RegisterModule(new MediatorModule());

            builder.Populate(serviceCollection);

            return builder.Build();
        }
    }
}
