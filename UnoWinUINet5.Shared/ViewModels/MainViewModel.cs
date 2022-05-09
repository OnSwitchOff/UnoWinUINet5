using CommunityToolkit.Mvvm.ComponentModel;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml.Controls;
using UnoWinUINet5.Services.Settings;

namespace UnoWinUINet5.ViewModels
{
    [Inject]
    public partial class MainViewModel : ObservableObject
    {
        //private readonly ISettingsService settingsService;

        //public ISettingsService SettingsService => settingsService;

        private string helpMessage;
        private string licenseData = "Продукт активирован 24,09,1990 №123123123";

        public string HelpMessage
        {
            get => helpMessage;
            set => SetProperty(ref helpMessage, value);
        }

        public string LicenseData
        {
            get => licenseData;
            set => SetProperty(ref licenseData, value);
        }

        private bool isBackEnabled;
        public bool IsBackEnabled { get => isBackEnabled; set => SetProperty(ref isBackEnabled, value); }

        private NavigationViewItem selected;
        public NavigationViewItem Selected
        {
            get => selected;
            set => SetProperty(ref selected, value);
        }
    }
}
