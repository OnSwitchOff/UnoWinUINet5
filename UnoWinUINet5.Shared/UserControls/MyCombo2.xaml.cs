using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;



// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyCombo2 : UserControl
    {

        #region MainTextBlock DependecyProperties
        public static readonly DependencyProperty MainTextBoxForegroundProperty = DependencyProperty
           .Register("MainTextBoxForeground",
               typeof(Brush),
               typeof(MyCombo2),
               new PropertyMetadata(GetMainTextBoxForeground()));

        private static Brush GetMainTextBoxForeground()
        {


            if (App.Current.RequestedTheme == ApplicationTheme.Light)
            {
                return new SolidColorBrush(Colors.Black);
            }
            if (App.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                return new SolidColorBrush(Colors.White);
            }

            if (Application.Current.Resources.Keys.Contains("ApplicationForegroundThemeBrush"))
            {
                return Application.Current.Resources["ApplicationForegroundThemeBrush"] as Brush;
            }

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();

            linearGradientBrush.StartPoint = new Windows.Foundation.Point(0, 0);
            linearGradientBrush.EndPoint = new Windows.Foundation.Point(0, 1);        

            GradientStopCollection gradientStops = new GradientStopCollection();

            GradientStop gradientStop1 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0xA3, (byte)0xAE, (byte)0xB9);
            gradientStop1.Offset = 0.0;
            gradientStops.Add(gradientStop1);
            GradientStop gradientStop2 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0x71, (byte)0x85, (byte)0x97);
            gradientStop1.Offset = 0.375;
            gradientStops.Add(gradientStop2);
            GradientStop gradientStop3 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0x61, (byte)0x75, (byte)0x84);
            gradientStop1.Offset = 1.0;
            gradientStops.Add(gradientStop3);

            (linearGradientBrush as GradientBrush).GradientStops = gradientStops;

            return linearGradientBrush;
        }



        public static readonly DependencyProperty MainTextBoxBackgroundProperty = DependencyProperty
          .Register("MainTextBoxBackground",
              typeof(Brush),
              typeof(MyCombo2),
              new PropertyMetadata(GetMainTextBoxBackground()));

        private static Brush GetMainTextBoxBackground()
        {
            if (App.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                return new SolidColorBrush(Colors.Black);
            }
            if (App.Current.RequestedTheme == ApplicationTheme.Light)
            {
                return new SolidColorBrush(Colors.White);
            }

            if (Application.Current.Resources.Keys.Contains("ApplicationPageBackgroundThemeBrush"))
            {
                return Application.Current.Resources["ApplicationPageBackgroundThemeBrush"] as Brush;
            }

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();

            linearGradientBrush.StartPoint = new Windows.Foundation.Point(0, 0);
            linearGradientBrush.EndPoint = new Windows.Foundation.Point(0, 1);

            GradientStopCollection gradientStops = new GradientStopCollection();

            GradientStop gradientStop1 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0xA3, (byte)0xAE, (byte)0xB9);
            gradientStop1.Offset = 0.0;
            gradientStops.Add(gradientStop1);
            GradientStop gradientStop2 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0x71, (byte)0x85, (byte)0x97);
            gradientStop1.Offset = 0.375;
            gradientStops.Add(gradientStop2);
            GradientStop gradientStop3 = new GradientStop();
            gradientStop1.Color = Windows.UI.Color.FromArgb((byte)0xFF, (byte)0x61, (byte)0x75, (byte)0x84);
            gradientStop1.Offset = 1.0;
            gradientStops.Add(gradientStop3);

            (linearGradientBrush as GradientBrush).GradientStops = gradientStops;

            return linearGradientBrush;
        }

        public Brush MainTextBoxBackground
        {
            get { return (Brush)GetValue(MainTextBoxBackgroundProperty); }
            set { SetValue(MainTextBoxBackgroundProperty, value); }
        }

        public Brush MainTextBoxForeground
        {
            get { return (Brush)GetValue(MainTextBoxForegroundProperty); }
            set { SetValue(MainTextBoxForegroundProperty, value); }
        }

        #endregion


        public static readonly DependencyProperty PopupListViewItemsSourceProperty = DependencyProperty
          .Register("PopupListViewItemsSource",
              typeof(ObservableCollection<Item>),
              typeof(MyCombo2),
              new PropertyMetadata(GetDefaultListViewItemsSource()));

        public static readonly DependencyProperty PopupListViewItemTemplateProperty = DependencyProperty
          .Register("PopupListViewItemTemplate",
              typeof(DataTemplate),
              typeof(MyCombo2),
              new PropertyMetadata(GetDefaultListViewDataTemplate()));

        public DataTemplate PopupListViewItemTemplate
        {
            get { return (DataTemplate)GetValue(PopupListViewItemTemplateProperty); }
            set { SetValue(PopupListViewItemTemplateProperty, value); }
        }

        private static DataTemplate GetDefaultListViewDataTemplate()
        {
            DataTemplate dataTemplate = XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock  Foreground =\"{ Binding ElementName = UC2, Path = MainTextBoxForeground}\" Text =\"{Binding Path=Text}\"/></DataTemplate>") as DataTemplate;
            return dataTemplate;
        }

        public ObservableCollection<Item> PopupListViewItemsSource
        {
            get { return (ObservableCollection<Item>)GetValue(PopupListViewItemsSourceProperty); }
            set { SetValue(PopupListViewItemsSourceProperty, value); }
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

        public MyCombo2()
        {
            this.InitializeComponent();
            //ObservableCollection<Item> source = new ObservableCollection<Item>();
            //for (int i = 0; i < 10; i++)
            //{
            //    source.Add(new Item() { Text = "Item" + i });
            //}
            //PopupListView.ItemsSource = source;
            MainTextBox.PointerPressed += MainTextBox_PointerPressed;
        }

        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            MainTextBox.Visibility = Visibility.Visible;
        }

        private void MainTextBox_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //MainTextBox.Visibility = Visibility.Collapsed; 
        }

        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            //PopupScrolViewer.Width = MainGrid.ActualWidth;
            PopupBorder.PointerExited += PopupBorder_PointerExited;
            PopupListView.SelectionChanged += PopupListView_SelectionChanged;
            PopupScrolViewer.Width = MainGrid.ActualWidth - MainGrid.BorderThickness.Left - PopupBorder.BorderThickness.Left - 1;
            StandardPopup.Margin = new Thickness(0, MainGrid.ActualHeight - MainGrid.BorderThickness.Top - PopupBorder.BorderThickness.Top, 0, 0);

        }

        private void PopupListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTextBox.Text = GetSelectedValueString(PopupListView.SelectedValue);
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            MainTextBox.Visibility = Visibility.Visible;
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

        public class Item
        {
            public string Text { get; set; }
        }
    }
}
