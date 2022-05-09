using Autofac;
using UnoWinUINet5.Handlers;
using UnoWinUINet5.Services.Activation;

namespace UnoWinUINet5.AutofacModules
{
    public sealed class ActivationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();
            builder.RegisterType<ActivationHandler>().As<IActivationHandler>().InstancePerDependency();
            //builder.RegisterType<ActivationHandler<LaunchActivatedEventArgs>>().As<IActivationHandler>().InstancePerDependency();
        }
    }
}
