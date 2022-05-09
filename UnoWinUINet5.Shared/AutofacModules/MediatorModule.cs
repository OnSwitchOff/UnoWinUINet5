using Autofac;
using FluentValidation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using UnoWinUINet5.Helpers;

namespace UnoWinUINet5.AutofacModules
{
    public sealed class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(MediatorAssemblies.ApplicationLayer);

            var openHandlerTypes = new[]
            {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>),
            typeof(IValidator<>),
        };

            foreach (var openHandlerType in openHandlerTypes)
            {
                builder.RegisterAssemblyTypes(MediatorAssemblies.ApplicationLayer)
                    .AsClosedTypesOf(openHandlerType)
                    .AsImplementedInterfaces();
            }
        }
    }
}
