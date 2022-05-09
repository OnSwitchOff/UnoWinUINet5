﻿using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace UnoWinUINet5.Services.Activation
{
    public interface IActivationService
    {
        /// <summary>
        /// Runs activation handlers to perform the program activation.
        /// </summary>
        /// <param name="activationArgs">Stores information about application startup. Usually it's startup arguments.</param>
        /// <returns>Task with process of programm activation.</returns>
        Task ActivateAsync(LaunchActivatedEventArgs activationArgs);
    }
}
