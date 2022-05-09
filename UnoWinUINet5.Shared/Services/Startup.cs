using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UnoWinUINet5.AutofacModules;

namespace UnoWinUINet5.Services
{
    /// <summary>
    /// Class to register services.
    /// </summary>
    internal static class Startup
    {
        /// <summary>
        /// Configures services.
        /// </summary>
        /// <returns>AutofacServiceProvider.</returns>
        internal static IServiceProvider ConfigureServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ActivationModule>();
            builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<ProcessingModule>();
            builder.RegisterModule<ApplicationServicesModule>();
            builder.RegisterModule<DatabaseModule>();
                //new DatabaseModule(
                //    DatabaseConfiguration.GetOptions()));

            builder.RegisterModule<SettingsModule>();
            //builder.RegisterModule<SerializationModule>();
            //builder.RegisterModule<ScanningModule>();
            builder.RegisterModule<PaymentModule>();
            //builder.RegisterModule<SearchDataModule>();
            //builder.RegisterModule<DocumentModule>();
            //builder.RegisterModule<AxisCloudModule>();

            return new Autofac.Extensions.DependencyInjection.AutofacServiceProvider(builder.Build());
        }
    }
}
