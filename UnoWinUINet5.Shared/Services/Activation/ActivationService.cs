using CommunityToolkit.Mvvm.DependencyInjection;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnoWinUINet5.Handlers;
using UnoWinUINet5.Services.Settings;
using UnoWinUINet5.Services.ThemeSelector;
using UnoWinUINet5.Services.Translation;
using UnoWinUINet5.Views;

namespace UnoWinUINet5.Services.Activation
{
    [Inject]
    public partial class ActivationService : IActivationService
    {
        private readonly ActivationHandler defaultHandler;
        //private readonly IEnumerable<IActivationHandler> activationHandlers;
        private readonly ISettingsService _settings;
        private ITranslationService translation;
        private readonly IThemeSelectorService _themeSelectorService;
        private UIElement shell = null;

        //public ActivationService(ActivationHandler defaultHandler, IEnumerable<IActivationHandler> activationHandlers, ISettingsService _settings, IThemeSelectorService _themeSelectorService)
        //{
        //    this.defaultHandler = defaultHandler;
        //    this.activationHandlers = activationHandlers;
        //    this._settings = _settings;
        //    this._themeSelectorService = _themeSelectorService;
        //}

        public async Task ActivateAsync(LaunchActivatedEventArgs activationArgs)
        {
            // Initialize services that you need before app activation
            // take into account that the splash screen is shown while this code runs.
            await InitializeAsync();

            if (App.MainWindow.Content is null)
            {
                this.translation = TranslationService.CreateInstance();
                this.translation.InitializeDictionary(this._settings.AppLanguage.CombineCode);
                shell = Ioc.Default.GetService<MainView>();
                App.MainWindow.Content = shell ?? new Frame();
            }

            // Depending on activationArgs one of ActivationHandlers or DefaultActivationHandler
            // will navigate to the first page
            await HandleActivationAsync(activationArgs);

            // Ensure the current window is active
            App.MainWindow.Activate();

            // Tasks after activation
            await StartupAsync();
        }

        private async Task HandleActivationAsync(object activationArgs)
        {
            //var activationHandler = activationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

            //if (activationHandler != null)
            //{
            //    await activationHandler.HandleAsync(activationArgs);
            //}

            if (defaultHandler.CanHandle(activationArgs))
            {
                await defaultHandler.HandleAsync(activationArgs);
            }
        }

        private async Task InitializeAsync()
        {
            await _themeSelectorService.InitializeAsync().ConfigureAwait(false);
            //await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await _themeSelectorService.SetRequestedThemeAsync();
            //await Task.CompletedTask;
        }
    }
}
