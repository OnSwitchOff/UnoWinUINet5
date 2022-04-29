using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.ObjectModel;
using Windows.UI;

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyComboBox : UserControl
    {

        #region MainTextBox DependecyProperties
        public static readonly DependencyProperty MainTextBoxForegroundProperty = DependencyProperty
           .Register("MainTextBoxForeground",
               typeof(Brush),
               typeof(MyComboBox),
               new PropertyMetadata(Application.Current.Resources["ApplicationForegroundThemeBrush"] as Brush));

        public static readonly DependencyProperty MainTextBoxBackgroundProperty = DependencyProperty
            .Register("MainTextBoxBackground",
                typeof(Brush),
                typeof(MyComboBox),
                new PropertyMetadata(Application.Current.Resources["ApplicationPageBackgroundThemeBrush"] as Brush));

        public static readonly DependencyProperty MainTextBoxIsReadOnlyProperty = DependencyProperty
            .Register("MainTextBoxIsReadOnly",
                typeof(bool),
                typeof(MyComboBox),
                new PropertyMetadata(true));

        public static readonly DependencyProperty MainTextBoxPaddingProperty = DependencyProperty
            .Register("MainTextBoxPadding",
                typeof(Thickness),
                typeof(MyComboBox),
                new PropertyMetadata(new Thickness(10, 0, 10, 0)));
        #endregion

        #region MainButton DependecyProperties
        public static readonly DependencyProperty MainButtonContentProperty = DependencyProperty
            .Register("MainButtonContent",
                typeof(object),
                typeof(MyComboBox),
                new PropertyMetadata(GetDefaultMainButtonContent()));
        #endregion

        #region MainBorder DependecyProperties
        public static readonly DependencyProperty PopupBorderBorderBrushProperty = DependencyProperty
           .Register("PopupBorderBorderBrush",
               typeof(Brush),
               typeof(MyComboBox),
               new PropertyMetadata(Application.Current.Resources["AppBarBorderThemeBrush"] as Brush));

        public static readonly DependencyProperty PopupBorderBackgroundProperty = DependencyProperty
            .Register("PopupBorderBackground",
                typeof(Brush),
                typeof(MyComboBox),
                new PropertyMetadata(Application.Current.Resources["ApplicationPageBackgroundThemeBrush"] as Brush));

        public static readonly DependencyProperty PopupBorderBorderThicknessProperty = DependencyProperty
           .Register("PopupBorderBorderThickness",
               typeof(Thickness),
               typeof(MyComboBox),
               new PropertyMetadata(new Thickness(2)));
        #endregion

        #region PopupScrollViewer DependecyProperties
        public static readonly DependencyProperty PopupScrollViewerMaxHeightProperty = DependencyProperty
           .Register("PopupScrollViewerMaxHeight",
               typeof(Double),
               typeof(MyComboBox),
               new PropertyMetadata(300D));
        #endregion

        #region PopupListView DependecyProperties
        public static readonly DependencyProperty PopupListViewItemTemplateProperty = DependencyProperty
          .Register("PopupListViewItemTemplate",
              typeof(DataTemplate),
              typeof(MyComboBox),
              new PropertyMetadata(GetDefaultListViewDataTemplate()));

        public static readonly DependencyProperty PopupListViewItemsSourceProperty = DependencyProperty
          .Register("PopupListViewItemsSource",
              typeof(object),
              typeof(MyComboBox),
              new PropertyMetadata(GetDefaultListViewItemsSource()));



        #endregion

        public Brush MainTextBoxForeground
        {
            get { return (Brush)GetValue(MainTextBoxForegroundProperty); }
            set { SetValue(MainTextBoxForegroundProperty, value); }
        }

        public Brush MainTextBoxBackground
        {
            get { return (Brush)GetValue(MainTextBoxBackgroundProperty); }
            set { SetValue(MainTextBoxBackgroundProperty, value); }
        }

        public bool MainTextBoxIsReadOnly
        {
            get { return (bool)GetValue(MainTextBoxIsReadOnlyProperty); }
            set { SetValue(MainTextBoxIsReadOnlyProperty, value); }
        }

        public  Thickness MainTextBoxPadding
        {
            get { return (Thickness)GetValue(MainTextBoxPaddingProperty); }
            set { SetValue(MainTextBoxPaddingProperty, value); }
        }

        public object MainButtonContent
        {
            get { return GetValue(MainButtonContentProperty); }
            set { SetValue(MainButtonContentProperty, value); }
        }

        public Brush PopupBorderBorderBrush
        {
            get { return (Brush)GetValue(PopupBorderBorderBrushProperty); }
            set { SetValue(PopupBorderBorderBrushProperty, value); }
        }

        public Brush PopupBorderBackground
        {
            get { return (Brush)GetValue(PopupBorderBackgroundProperty); }
            set { SetValue(PopupBorderBackgroundProperty, value); }
        }

        public Thickness PopupBorderBorderThickness
        {
            get { return (Thickness)GetValue(PopupBorderBorderThicknessProperty); }
            set { SetValue(PopupBorderBorderThicknessProperty, value); }
        }

        public double PopupScrollViewerMaxHeight
        {
            get { return (double)GetValue(PopupScrollViewerMaxHeightProperty); }
            set { SetValue(PopupScrollViewerMaxHeightProperty, value); }
        }

        public DataTemplate PopupListViewItemTemplate
        {
            get { return (DataTemplate)GetValue(PopupListViewItemTemplateProperty); }
            set { SetValue(PopupListViewItemTemplateProperty, value); }
        }

        public object PopupListViewItemsSource
        {
            get { return GetValue(PopupListViewItemsSourceProperty); }
            set { SetValue(PopupListViewItemsSourceProperty, value); }
        }

        public MyComboBox()
        {
            this.InitializeComponent();
        }

        private static object GetDefaultMainButtonContent()
        {
            Path path = new Path();
            path.Fill = new SolidColorBrush(Color.FromArgb((byte)0xFF, (byte)0x71, (byte)0x85, (byte)0x97));
            path.HorizontalAlignment = HorizontalAlignment.Center;
            path.VerticalAlignment = VerticalAlignment.Center;

            var data = "M 0 0 L 5 5 L 10 0 Z";
            path.Data = (Geometry)XamlReader.Load("<Geometry xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" + data + "</Geometry>");
            Grid grid = new Grid();
            grid.Children.Add(path);
            return grid;
        }

        private static DataTemplate GetDefaultListViewDataTemplate()
        {
            DataTemplate dataTemplate = XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock Foreground =\"{Binding ElementName=UC, Path=MainTextBoxForeground}\" Text =\"{Binding Path=Source}\"/></DataTemplate>") as DataTemplate;
            return dataTemplate;
        }

        private static object GetDefaultListViewItemsSource()
        {
            ObservableCollection<Item> source = new ObservableCollection<Item>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new Item() { Text = "Item" + i });
            }
            return source;
        }

        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            PopupScrolViewer.Width = MainGrid.ActualWidth - MainGrid.BorderThickness.Left - PopupBorder.BorderThickness.Left-1;
            StandardPopup.Margin = new Thickness(0,MainGrid.ActualHeight- MainGrid.BorderThickness.Top - PopupBorder.BorderThickness.Top, 0,0);
            PopupBorder.PointerExited += PopupBorder_PointerExited; 
            PopupListView.SelectionChanged += PopupListView_SelectionChanged; 

        }

        private void PopupListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTextBox.Text = GetSelectedValueString(PopupListView.SelectedValue);
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private string GetSelectedValueString(object selectedValue)
        {
            Type type = selectedValue.GetType();

            if (type == typeof(string))
            {
                return (string)selectedValue;
            }

            if (type == typeof(TextBlock))
            {
                return (selectedValue as TextBlock).Text;
            }

            if (type == typeof(Item))
            {
                return (selectedValue as Item).Text;
            }
        
            return selectedValue.ToString();          
        }

        private void PopupBorder_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private class Item
        {
            public string Text { get; set; }
        }
    }
}
