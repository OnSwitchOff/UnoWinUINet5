using System;
using UnoWinUINet5.Services.Payment.Device;

namespace UnoWinUINet5.Services.Payment
{
    /// <summary>
    /// Describes payment service.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private IDevice fiscalDevice = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        public PaymentService()
        {
            this.fiscalDevice = null;
        }

        /// <summary>
        /// Gets the class to make a payment.
        /// </summary>
        /// <date>15/03/2022.</date>
        public IDevice FiscalDevice
        {
            get
            {
                if (this.fiscalDevice == null)
                {
                    throw new Exception("Device doesn't initialized!");
                }

                return this.fiscalDevice;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the class to make a payment is initialized.
        /// </summary>
        /// <date>19/04/2022.</date>
        public bool FiscalDeviceInitialized => this.fiscalDevice != null;

        /// <summary>
        /// Gets number of receipt.
        /// </summary>
        /// <param name="fiscalDevice">Class to make a payment.</param>
        /// <date>15/03/2022.</date>
        public void SetPaymentTool(IDevice fiscalDevice)
        {
            this.fiscalDevice = fiscalDevice;
        }
    }
}
