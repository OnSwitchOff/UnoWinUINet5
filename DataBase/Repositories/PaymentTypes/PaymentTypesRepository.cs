using System.Collections.Generic;

namespace DataBase.Repositories.PaymentTypes
{
    public class PaymentTypesRepository : IPaymentTypesRepository
    {
        /// <summary>
        /// Gets list with types of payments.
        /// </summary>
        /// <returns>Returns list with types of payments.</returns>
        /// <date>05.05.2022.</date>
        public IAsyncEnumerable<Entities.PaymentTypes.PaymentType> GetPaymentTypes()
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.PaymentTypes.AsAsyncEnumerable();
            }
        }
    }
}
