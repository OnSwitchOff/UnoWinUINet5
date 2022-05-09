using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace UnoWinUINet5.Services.ThemeSelector
{
    public interface IThemeSelectorService
    {
        ElementTheme Theme { get; }

        Task InitializeAsync();

        Task SetThemeAsync(ElementTheme theme);

        Task SetRequestedThemeAsync();
    }
}
