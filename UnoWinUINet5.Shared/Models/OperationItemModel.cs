﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microinvest.DeviceService.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UnoWinUINet5.Models
{
    /// <summary>
    /// Describes data of operation.
    /// </summary>
    public class OperationItemModel : ObservableObject
    {
        private ItemModel item;
        private string code;
        private string name;
        private string barcode;
        private double qty;
        private ObservableCollection<ItemCodeModel> measures;
        private ItemCodeModel selectedMeasure;
        private double partnerDiscount;
        private double itemDiscount;
        private double discount;
        private double price;
        private double amount;
        private string note;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationItemModel"/> class.
        /// </summary>
        public OperationItemModel()
        {
            this.item = new ItemModel();
            this.code = string.Empty;
            this.name = string.Empty;
            this.barcode = string.Empty;
            this.qty = 0;
            this.selectedMeasure = new ItemCodeModel();
            this.measures = new ObservableCollection<ItemCodeModel>();
            this.measures.Add(this.selectedMeasure);
            this.partnerDiscount = 0;
            this.itemDiscount = 0;
            this.discount = 0;
            this.price = 0;
            this.amount = 0;
            this.note = string.Empty;
        }

        /// <summary>
        /// Gets or sets id of additional code of item.
        /// </summary>
        /// <date>14.03.2022.</date>
        public ItemModel Item
        {
            get => this.item;
            set => this.SetProperty(ref this.item, value);
        }

        /// <summary>
        /// Gets or sets code of item.
        /// </summary>
        /// <date>15.03.2022.</date>
        public string Code
        {
            get => this.code;
            set => this.SetProperty(ref this.code, value);
        }

        /// <summary>
        /// Gets or sets name of item.
        /// </summary>
        /// <date>15.03.2022.</date>
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        /// <summary>
        /// Gets or sets barcode of item.
        /// </summary>
        /// <date>15.03.2022.</date>
        public string Barcode
        {
            get => this.barcode;
            set => this.SetProperty(ref this.barcode, value);
        }

        /// <summary>
        /// Gets or sets quantity of item.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double Qty
        {
            get => this.qty;
            set => this.SetProperty(ref this.qty, value);
        }

        /// <summary>
        /// Gets or sets supported measures list.
        /// </summary>
        /// <date>15.03.2022.</date>
        public ObservableCollection<ItemCodeModel> Measures
        {
            get => this.measures;
            set => this.SetProperty(ref this.measures, value);
        }

        /// <summary>
        /// Gets or sets selected measure.
        /// </summary>
        /// <date>15.03.2022.</date>
        public ItemCodeModel SelectedMeasure
        {
            get => this.selectedMeasure;
            set => this.SetProperty(ref this.selectedMeasure, value);
        }

        /// <summary>
        /// Gets or sets discount of group of partners.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double PartnerDiscount
        {
            get => this.partnerDiscount;
            set => this.SetProperty(ref this.partnerDiscount, value);
        }

        /// <summary>
        /// Gets or sets discount of group of items.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double ItemDiscount
        {
            get => this.itemDiscount;
            set => this.SetProperty(ref this.itemDiscount, value);
        }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double Discount
        {
            get => this.discount;
            set => this.SetProperty(ref this.discount, value);
        }

        /// <summary>
        /// Gets or sets price of item.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double Price
        {
            get => this.price;
            set => this.SetProperty(ref this.price, value);
        }

        /// <summary>
        /// Gets amount to pay.
        /// </summary>
        /// <date>15.03.2022.</date>
        public double Amount
        {
            get => this.amount;
            private set => this.SetProperty(ref this.amount, value);
        }

        /// <summary>
        /// Gets or sets notey.
        /// </summary>
        /// <date>15.03.2022.</date>
        public string Note
        {
            get => this.note;
            set => this.SetProperty(ref this.note, value);
        }

        /// <summary>
        /// Casts OperationItemModel to SaleProductModel.
        /// </summary>
        /// <param name="operationItem">Operation item data.</param>
        /// <date>17.03.2022.</date>
        public static implicit operator SaleProductModel(OperationItemModel operationItem)
        {
            SaleProductModel productModel = new SaleProductModel();
            productModel.Name = operationItem.Item.Name;
            productModel.Price = (decimal)operationItem.Price;
            productModel.Quantity = (decimal)operationItem.Qty;
            productModel.Discount = Math.Round((decimal)operationItem.Discount / 100, 2);
            productModel.VAT = new PrinterService.Models.VATModel(
                operationItem.Item.VATGroup.Id.ToString(),
                operationItem.Item.VATGroup.Name,
                Math.Round((decimal)operationItem.Item.VATGroup.Value / 100, 2));

            return productModel;
        }

        /// <summary>
        /// Updates dependent property when main property was changed.
        /// </summary>
        /// <param name="e">Event args.</param>
        /// <date>29.03.2022.</date>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.Item):
                    this.Code = this.Item.Code;
                    this.Barcode = this.Item.Barcode;
                    this.Name = this.Item.Name;
                    this.Measures.Clear();
                    this.Measures.Add(new ItemCodeModel()
                    {
                        Code = this.Code,
                        Measure = this.Item.Measure,
                    });
                    foreach (ItemCodeModel itemCode in this.Item.Codes)
                    {
                        this.Measures.Add(itemCode);
                    }

                    this.SelectedMeasure = this.Measures[0];
                    this.Qty = 1;
                    this.Price = (double)this.Item.Price;
                    this.ItemDiscount = this.Item.Group.Discount;

                    break;
                case nameof(this.Qty):
                    break;
                case nameof(this.Price):
                    break;
                case nameof(this.Discount):
                    break;
                case nameof(this.ItemDiscount):
                case nameof(this.PartnerDiscount):
                    break;
            }

            base.OnPropertyChanged(e);
        }
    }
}
