using Autofac;
using UnoWinUINet5.Services.ThemeSelector;
using UnoWinUINet5.ViewModels;

namespace UnoWinUINet5.AutofacModules
{
    public class ApplicationServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().InstancePerDependency();
            builder.RegisterType<SaleViewModel>().InstancePerDependency();
            builder.RegisterType<DocumentViewModel>().InstancePerDependency();
            builder.RegisterType<CashRegisterViewModel>().InstancePerDependency();
            builder.RegisterType<ExchangeViewModel>().InstancePerDependency();
            builder.RegisterType<ReportsViewModel>().InstancePerDependency();
            builder.RegisterType<SettingsViewModel>().InstancePerDependency();

            builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
