using DataBase.Entities.PartnersGroups;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Repositories.PartnersGroups
{
    public class PartnersGroupsRepository : IPartnersGroupsRepository
    {

        /// <summary>
        /// Gets path of group by id of group.
        /// </summary>
        /// <param name="groupId">Id of group.</param>
        /// <returns>Returns "-2" if group is absent; otherwise returns path of group.</returns>
        /// <date>31.03.2022.</date>
        public Task<string> GetPathByIdAsync(int groupId)
        {
            return Task.Run<string>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    PartnersGroup res = dbContext.PartnersGroups.Where(pg => pg.Id == groupId).FirstOrDefault();
                    if (res == null)
                    {
                        return "-2";
                    }

                    return res.Path;
                }
            });
        }

        /// <summary>
        /// Adds new group of partners to table with groups of partners.
        /// </summary>
        /// <param name="partnersGroup">Group of partners.</param>
        /// <returns>Returns 0 if group of partners wasn't added to database; otherwise returns real id of new record.</returns>
        /// <date>31.03.2022.</date>
        public Task<int> AddGroupAsync(PartnersGroup partnersGroup)
        {
            return Task.Run<int>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.PartnersGroups.Add(partnersGroup);
                    dbContext.SaveChanges();

                    return partnersGroup.Id;
                }
            });
        }

        /// <summary>
        /// Updates the group of partners in the table with groups of partners.
        /// </summary>
        /// <param name="partnersGroup">Group of partners.</param>
        /// <returns>Returns true if group of partners was updated; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        public Task<bool> UpdateGroupAsync(PartnersGroup partnersGroup)
        {
            return Task.Run<bool>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.PartnersGroups.Update(partnersGroup);
                    return dbContext.SaveChanges() > 0;
                }
            });
        }

        /// <summary>
        /// Deletes group of partners by id.
        /// </summary>
        /// <param name="groupId">Id of group of partners.</param>
        /// <returns>Returns true if group of partners was deleted; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        public Task<bool> DeleteGroupAsync(int groupId)
        {
            return Task.Run<bool>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    PartnersGroup partnersGroup = dbContext.PartnersGroups.FirstOrDefault(i => i.Id == groupId);
                    if (partnersGroup == null)
                    {
                        return false;
                    }
                    else
                    {
                        dbContext.PartnersGroups.Remove(partnersGroup);
                        return dbContext.SaveChanges() > 0;
                    }
                }
            });
        }

        /// <summary>
        /// Gets list with groups of partners.
        /// </summary>
        /// <returns>Returns list with groups of partners.</returns>
        /// <date>01.04.2022.</date>
        public async Task<List<PartnersGroup>> GetPartnersGroupsAsync()
        {
            return await Task.Run(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    return dbContext.PartnersGroups.ToList();
                }
            });
        }
    }
}
