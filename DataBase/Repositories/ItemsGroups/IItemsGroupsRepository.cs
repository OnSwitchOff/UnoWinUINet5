﻿using DataBase.Entities.ItemsGroups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase.Repositories.ItemsGroups
{
    public interface IItemsGroupsRepository
    {
        /// <summary>
        /// Gets path of group by id of group.
        /// </summary>
        /// <param name="groupId">Id of group.</param>
        /// <returns>Returns "-2" if group is absent; otherwise returns path of group.</returns>
        /// <date>31.03.2022.</date>
        Task<string> GetPathByIdAsync(int groupId);

        /// <summary>
        /// Adds new group of items to table with groups of items.
        /// </summary>
        /// <param name="itemsGroup">Group of items.</param>
        /// <returns>Returns 0 if group of items wasn't added to database; otherwise returns real id of new record.</returns>
        /// <date>31.03.2022.</date>
        Task<int> AddGroupAsync(ItemsGroup itemsGroup);

        /// <summary>
        /// Updates the group of items in the table with groups of items.
        /// </summary>
        /// <param name="itemsGroup">Group of items.</param>
        /// <returns>Returns true if group of items was updated; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        Task<bool> UpdateGroupAsync(ItemsGroup itemsGroup);

        /// <summary>
        /// Deletes group of items by id.
        /// </summary>
        /// <param name="groupId">Id of group of item.</param>
        /// <returns>Returns true if group of items was deleted; otherwise returns false.</returns>
        /// <date>31.03.2022.</date>
        Task<bool> DeleteGroupAsync(int groupId);

        /// <summary>
        /// Gets list with groups of items.
        /// </summary>
        /// <returns>Returns list with groups of items.</returns>
        /// <date>01.04.2022.</date>
        Task<List<ItemsGroup>> GetItemsGroupsAsync();
    }
}
