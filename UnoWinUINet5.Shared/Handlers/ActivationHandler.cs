using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace UnoWinUINet5.Handlers
{
    [Inject]
    public partial class ActivationHandler : IActivationHandler
    {
        /// <inheritdoc/>
        public bool CanHandle(object args)
        {
            return args is LaunchActivatedEventArgs;
        }

        /// <inheritdoc/>
        public async Task HandleAsync(object args)
        {
            await Task.Run(() =>
            {
                using (DataBase.DatabaseContext dbContext = new DataBase.DatabaseContext())
                {
                    return true;// Task.FromResult(System.Convert.ToInt32(dbContext.DataBaseCreated));
                }
            });
        }

        ///// <summary>
        ///// Function, that incapsulates <see cref="HandleAsync(object)"/> function, and allows to use typed parameter.
        ///// </summary>
        ///// <param name="args">Typed argument, that can be used for object activation.</param>
        ///// <returns><inheritdoc cref="IActivationHandler.HandleAsync(object)" path="/returns"/></returns>
        //protected abstract System.Threading.Tasks.Task HandleInternalAsync(T args);
    }
}
