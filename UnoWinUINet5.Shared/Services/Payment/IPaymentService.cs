﻿using UnoWinUINet5.Services.Payment.Device;

namespace UnoWinUINet5.Services.Payment
{
    /// <summary>
    /// Describes payment modules.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Gets the class to make a payment.
        /// </summary>
        /// <date>15/03/2022.</date>
        IDevice FiscalDevice { get; }

        /// <summary>
        /// Gets a value indicating whether the class to make a payment is initialized.
        /// </summary>
        /// <date>19/04/2022.</date>
        bool FiscalDeviceInitialized { get; }

        /// <summary>
        /// Gets number of receipt.
        /// </summary>
        /// <param name="fiscalDevice">Class to make a payment.</param>
        /// <date>15/03/2022.</date>
        void SetPaymentTool(IDevice fiscalDevice);
    }
}
