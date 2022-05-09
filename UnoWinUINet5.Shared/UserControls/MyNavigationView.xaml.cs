﻿using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Input;
using System.Diagnostics;
using System.Threading;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyNavigationView : UserControl
    {
        public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty
           .Register("IsCollapsed",
               typeof(bool),
               typeof(MyNavigationView),
               new PropertyMetadata(false));

        public bool IsCollapsed
        {
            get { return (bool)GetValue(IsCollapsedProperty); }
            set { SetValue(IsCollapsedProperty, value); }
        }

        public static readonly DependencyProperty MainItemsSourceProperty = DependencyProperty
            .Register("MainItemsSourceProperty",
                typeof(ObservableCollection<MyNavigationViewItem>),
                typeof(MyNavigationView),
                new PropertyMetadata(GetDefaultMainItemsSource()));

        private static ObservableCollection<MyNavigationViewItem> GetDefaultMainItemsSource()
        {
            ObservableCollection<MyNavigationViewItem> source = new ObservableCollection<MyNavigationViewItem>();
            for (int i = 0; i < 10; i++)
            {
                if (i==0)
                {
                    source.Add(new MyNavigationViewItem() { Title = "Продажа"});
                }
                else
                {
                    source.Add(new MyNavigationViewItem() { Title = "Item" + i });
                }
            }
            return source;
        }

        public ObservableCollection<MyNavigationViewItem> MainItemsSource
        {
            get { return (ObservableCollection<MyNavigationViewItem>)GetValue(MainItemsSourceProperty); }
            set { SetValue(MainItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty MainSelectedItemProperty = DependencyProperty
          .Register("MainSelectedItemProperty",
              typeof(MyNavigationViewItem),
              typeof(MyNavigationView),
              new PropertyMetadata(null));
        public MyNavigationViewItem MainSelectedItem
        {
            get { return (MyNavigationViewItem)GetValue(MainSelectedItemProperty); }
            set
            { 
                SetValue(MainSelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty DocumentsSourceProperty = DependencyProperty
            .Register("DocumentsSourceProperty",
                typeof(ObservableCollection<MyNavigationViewItem>),
                typeof(MyNavigationView),
                new PropertyMetadata(GetDefaultDocumentsSource()));

        private static ObservableCollection<MyNavigationViewItem> GetDefaultDocumentsSource()
        {
            ObservableCollection<MyNavigationViewItem> source = new ObservableCollection<MyNavigationViewItem>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new MyNavigationViewItem() { Title = "Document" + i });
            }
            return source;
        }

        public ObservableCollection<MyNavigationViewItem> DocumentsSource
        {
            get { return (ObservableCollection<MyNavigationViewItem>)GetValue(DocumentsSourceProperty); }
            set { SetValue(DocumentsSourceProperty, value); }
        }

        public static readonly DependencyProperty DocumentsSelectedItemProperty = DependencyProperty
          .Register("DocumentsSelectedItemProperty",
              typeof(MyNavigationViewItem),
              typeof(MyNavigationView),
              new PropertyMetadata(null));
        public MyNavigationViewItem DocumentsSelectedItem
        {
            get { return (MyNavigationViewItem)GetValue(DocumentsSelectedItemProperty); }
            set 
            { 
                SetValue(DocumentsSelectedItemProperty, value);
            }
        }

        public MyNavigationView()
        {
            this.InitializeComponent();
            MainListView.SelectionChanged += MainListView_SelectionChanged;
            DocumentsListView.SelectionChanged += DocumentsListView_SelectionChanged;
        }

        private void DocumentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DocumentsSelectedItem != null && DocumentsSource.IndexOf(DocumentsSelectedItem) == DocumentsSource.Count - 1)
            {
               // DocumentsListView.ScrollIntoView(DocumentsSelectedItem,ScrollIntoViewAlignment.Default);
            }
        }

        private void MainListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainSelectedItem != null && MainSelectedItem.Title == "Продажа")
            {
                MainListView.SelectedItem = null;
                DocumentsSource.Add(new MyNavigationViewItem() { Title = "New Prodajba" + DocumentsSource.Count });
                DocumentsListView.SelectedItem = DocumentsSource[DocumentsSource.Count - 1];       
            }
        }

        private void HideBorder_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            IsCollapsed = !IsCollapsed;

            HidePathRotateTransform.Angle = this.IsCollapsed ? 0 : 180;

            foreach (MyNavigationViewItem item in MainItemsSource)
            {
                item.TitleVisibility = this.IsCollapsed ? Visibility.Collapsed : Visibility.Visible;
            }

            foreach (MyNavigationViewItem item in DocumentsSource)
            {
                item.TitleVisibility = this.IsCollapsed ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void DocBorder_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            DocBorder.Focus(FocusState.Programmatic);
            Debug.WriteLine("DocBorder_PointerEntered");
        }

        private void MainBorder_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MainBorder.Focus(FocusState.Programmatic);
            Debug.WriteLine("MainBorder_PointerEntered");
        }

        private void HideBorder_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            HideBorder.Focus(FocusState.Programmatic);
            Debug.WriteLine("HideBorder_PointerEntered");
        }


        public class MyNavigationViewItem : ObservableObject
        {
            private string title;
            public string Title
            { 
                get => title;
                set
                {
                    this.SetProperty(ref this.title, value);
                }
            }

            private Image icon;
            public Image Icon
            {
                get => icon;
                set
                {
                    this.SetProperty(ref this.icon, value);
                }
            }

            private Visibility titleVisibility = Visibility.Visible;
            public Visibility TitleVisibility
            {
                get => titleVisibility;
                set
                {
                    this.SetProperty(ref this.titleVisibility, value);
                }
            }
        }
    }
}
