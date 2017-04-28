using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Api.Features.Values;
using Api.Infrastructure.Validation;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Container
{
    public static class AutofacConfig
    {
        public static IContainer UseAutofac(this IServiceCollection serviceCollection)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

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

            //builder.RegisterModule(new MediatorModule());
            //builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ValidationPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return c.TryResolve(t, out o) ? o : null;
                };
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            

            builder.Populate(serviceCollection);

            return builder.Build();
        }
    }
}
