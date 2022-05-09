using System.Collections.Generic;

namespace DataBase.Repositories.VATGroups
{
    public class VATsRepository : IVATsRepository
    {
        /// <summary>
        /// Gets list with groups of VATs.
        /// </summary>
        /// <returns>Returns list with groups of VATs.</returns>
        /// <date>05.05.2022.</date>
        public IAsyncEnumerable<Entities.VATGroups.VATGroup> GetVATGroupsAsync()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Vatgroups.AsAsyncEnumerable();
            }
        }
    }
}
