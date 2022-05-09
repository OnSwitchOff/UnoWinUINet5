namespace UnoWinUINet5.Handlers
{
    public interface IActivationHandler
    {
        /// <summary>
        /// Checks, that current handler can be activated.
        /// </summary>
        /// <param name="args">Argument, that can be used for object activation.</param>
        /// <returns>True, if activation can be handled successfully.</returns>
        bool CanHandle(object args);

        /// <summary>
        /// Trying to activate current handler.
        /// </summary>
        /// <param name="args">Argument, that can be used for object activation.</param>
        /// <returns>Task, that will be complete, when the current activation handler finished its job.</returns>
        System.Threading.Tasks.Task HandleAsync(object args);
    }
}
