﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace UnoWinUINet5.Models
{
    /// <summary>
    /// Describes data of group.
    /// </summary>
    public class GroupModel : ObservableObject
    {
        private int id;
        private string name;
        private string path;
        private double discount;
        private bool isExpanded;
        private GroupModel parentGroup;
        private ObservableCollection<GroupModel> subGroups;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupModel"/> class.
        /// </summary>
        public GroupModel()
        {
            this.id = 0;
            this.name = string.Empty;
            this.path = string.Empty;
            this.discount = 0;
            this.isExpanded = false;
            this.subGroups = new ObservableCollection<GroupModel>();
        }

        /// <summary>
        /// Gets or sets get or set Id of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public int Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }

        /// <summary>
        /// Gets or sets get or set name of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        /// <summary>
        /// Gets or sets path of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public string Path
        {
            get => this.path;
            set => this.SetProperty(ref this.path, value);
        }

        /// <summary>
        /// Gets or sets discount of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public double Discount
        {
            get => this.discount;
            set => this.SetProperty(ref this.discount, value);
        }

        /// <summary>
        /// Gets or sets IsExpanded of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public bool IsExpanded
        {
            get => this.isExpanded;
            set => this.SetProperty(ref this.isExpanded, value);
        }

        /// <summary>
        /// Gets or sets parent of group.
        /// </summary>
        /// <date>14.03.2022.</date>
        public GroupModel ParentGroup
        {
            get => this.parentGroup;
            set => this.SetProperty(ref this.parentGroup, value);
        }

        /// <summary>
        /// Gets or sets list with subgroups.
        /// </summary>
        /// <date>14.03.2022.</date>
        public ObservableCollection<GroupModel> SubGroups
        {
            get => this.subGroups;
            set => this.SetProperty(ref this.subGroups, value);
        }

        /// <summary>
        /// Casts GroupModel object to DataBase.My100REnteties.PartnersGroups.PartnersGroup.
        /// </summary>
        /// <param name="group">Data of group.</param>
        /// <date>25.03.2022.</date>
        public static explicit operator DataBase.Entities.PartnersGroups.PartnersGroup(GroupModel group)
        {
            DataBase.Entities.PartnersGroups.PartnersGroup partnersGroup = DataBase.Entities.PartnersGroups.PartnersGroup.Create(group.Path, group.Name, (int)group.Discount);
            partnersGroup.Id = group.Id;

            return partnersGroup;
        }

        /// <summary>
        /// Casts PartnersGroup object to GroupModel.
        /// </summary>
        /// <param name="partnersGroup">Data of group of partner from database.</param>
        /// <date>25.03.2022.</date>
        public static explicit operator GroupModel(DataBase.Entities.PartnersGroups.PartnersGroup partnersGroup)
        {
            if (partnersGroup == null)
            {
                return null;
            }

            return new GroupModel()
            {
                Id = partnersGroup.Id,
                Path = partnersGroup.Path,
                Name = partnersGroup.Name,
                Discount = partnersGroup.Discount,
            };
        }

        /// <summary>
        /// Casts GroupModel object to DataBase.My100REnteties.ItemsGroups.ItemsGroup.
        /// </summary>
        /// <param name="group">Data of group.</param>
        /// <date>25.03.2022.</date>
        public static explicit operator DataBase.Entities.ItemsGroups.ItemsGroup(GroupModel group)
        {
            DataBase.Entities.ItemsGroups.ItemsGroup itemGroup = DataBase.Entities.ItemsGroups.ItemsGroup.Create(group.Path, group.Name, (int)group.Discount);
            itemGroup.Id = group.Id;

            return itemGroup;
        }

        /// <summary>
        /// Casts DataBase.My100REnteties.ItemsGroups.ItemsGroup object to GroupModel.
        /// </summary>
        /// <param name="itemGroup">Data of group of product from database.</param>
        /// <date>25.03.2022.</date>
        public static explicit operator GroupModel(DataBase.Entities.ItemsGroups.ItemsGroup itemGroup)
        {
            GroupModel group = new GroupModel()
            {
                Id = itemGroup.Id,
                Path = itemGroup.Path,
                Name = itemGroup.Name,
                Discount = itemGroup.Discount,
            };

            return group;
        }
    }
}
