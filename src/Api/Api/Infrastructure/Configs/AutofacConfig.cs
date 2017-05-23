using System.Linq;
using System.Reflection;
using Api.Features.Values;
using Api.Infrastructure.Container;
using Api.Infrastructure.Validation;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Configs
{
    public static class AutofacConfig
    {
        public static IContainer UseAutofac(this IServiceCollection serviceCollection)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(ValuesController).GetTypeInfo().Assembly).Where(t =>
                    t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(INotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncNotificationHandler<>))
                    )
                )
                .AsImplementedInterfaces();

            builder.RegisterModule(new MediatorModule());
            
            builder.RegisterGeneric(typeof(ValidationPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

            builder.Populate(serviceCollection);

            return builder.Build();
        }
    }
}
