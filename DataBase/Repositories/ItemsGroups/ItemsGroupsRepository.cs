using DataBase.Entities.ItemsGroups;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories.ItemsGroups
{
    public class ItemsGroupsRepository : IItemsGroupsRepository
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
                    ItemsGroup res = dbContext.ItemsGroups.Where(pg => pg.Id == groupId).FirstOrDefault();
                    if (res == null)
                    {
                        return "-2";
                    }

                    return res.Path;
                }
            });
        }

        /// <summary>
        /// Adds new group of items to table with groups of items.
        /// </summary>
        /// <param name="itemsGroup">Group of items.</param>
        /// <returns>Returns 0 if group of items wasn't added to database; otherwise returns real id of new record.</returns>
        /// <date>31.03.2022.</date>
        public Task<int> AddGroupAsync(ItemsGroup itemsGroup)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                dbContext.ItemsGroups.Add(itemsGroup);
                dbContext.SaveChangesAsync();

                return Task.FromResult(itemsGroup.Id);
            }
        }

        /// <summary>
        /// Updates the group of items in the table with groups of items.
        /// </summary>
        /// <param name="itemsGroup">Group of items.</param>
        /// <returns>Returns true if group of items was updated; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        public Task<bool> UpdateGroupAsync(ItemsGroup itemsGroup)
        {
            return Task.Run<bool>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    dbContext.ItemsGroups.Update(itemsGroup);
                    return dbContext.SaveChanges() > 0;
                }
            });
        }

        /// <summary>
        /// Deletes group of items by id.
        /// </summary>
        /// <param name="groupId">Id of group of item.</param>
        /// <returns>Returns true if group of items was deleted; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        public Task<bool> DeleteGroupAsync(int groupId)
        {
            return Task.Run<bool>(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    ItemsGroup itemsGroup = dbContext.ItemsGroups.FirstOrDefault(i => i.Id == groupId);
                    if (itemsGroup == null)
                    {
                        return false;
                    }
                    else
                    {
                        dbContext.ItemsGroups.Remove(itemsGroup);
                        return dbContext.SaveChanges() > 0;
                    }
                }
            });
        }

        /// <summary>
        /// Gets list with groups of items.
        /// </summary>
        /// <returns>Returns list with groups of items.</returns>
        /// <date>01.04.2022.</date>
        public Task<List<ItemsGroup>> GetItemsGroupsAsync()
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.ItemsGroups.ToListAsync();
            }
        }
    }
}
