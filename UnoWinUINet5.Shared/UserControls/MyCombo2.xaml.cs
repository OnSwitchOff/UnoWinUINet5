using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyCombo2 : UserControl
    {
        public static readonly DependencyProperty MainFontSizeProperty = DependencyProperty
           .Register("MainFontSize",
               typeof(Double),
               typeof(MyCombo2),
               new PropertyMetadata(14));
        public double MainFontSize
        {
            get { return (double)GetValue(MainFontSizeProperty); }
            set { SetValue(MainFontSizeProperty, value); }
        }

        public static readonly DependencyProperty MainTextBoxPaddingProperty = DependencyProperty
            .Register("MainTextBoxPadding",
                typeof(Thickness),
                typeof(MyCombo2),
                new PropertyMetadata(new Thickness(10, 6, 10, 6)));

        public Thickness MainTextBoxPadding
        {
            get { return (Thickness)GetValue(MainTextBoxPaddingProperty); }
            set 
            { 
                SetValue(MainTextBoxPaddingProperty, value);
#if WINDOWS
                UnderTextBox.Padding = this.MainTextBoxPadding;
#else
             UnderTextBox.Padding = new Thickness(this.MainTextBoxPadding.Left, this.MainTextBoxPadding.Top + 2, this.MainTextBoxPadding.Right, this.MainTextBoxPadding.Bottom);
#endif
            }
        }

        public static readonly DependencyProperty IsEditableTextProperty = DependencyProperty
           .Register("IsEditableText",
               typeof(bool),
               typeof(MyCombo2),
               new PropertyMetadata(false));

        public bool IsEditableText
        {
            get { return (bool)GetValue(IsEditableTextProperty); }
            set { SetValue(IsEditableTextProperty, value); }
        }

        public static readonly DependencyProperty IsExistClearBtnProperty = DependencyProperty
           .Register("IsExistClearBtn",
               typeof(bool),
               typeof(MyCombo2),
               new PropertyMetadata(false));

        public bool IsExistClearBtn
        {
            get { return (bool)GetValue(IsExistClearBtnProperty); }
            set { SetValue(IsExistClearBtnProperty, value); }
        }

        #region Main DependecyProperties
        public static readonly DependencyProperty MainForegroundProperty = DependencyProperty
           .Register("MainForeground",
               typeof(Brush),
               typeof(MyCombo2),
               new PropertyMetadata(GetMainForeground()));

        private static Brush GetMainForeground()
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

        public Brush MainForeground
        {
            get { return (Brush)GetValue(MainForegroundProperty); }
            set { SetValue(MainForegroundProperty, value); }
        }

        public static readonly DependencyProperty MainBackgroundProperty = DependencyProperty
          .Register("MainBackground",
              typeof(Brush),
              typeof(MyCombo2),
              new PropertyMetadata(GetMainBackground()));

        private static Brush GetMainBackground()
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

        public Brush MainBackground
        {
            get { return (Brush)GetValue(MainBackgroundProperty); }
            set { SetValue(MainBackgroundProperty, value); }
        }
        #endregion

        #region PopupListView Properties
        public static readonly DependencyProperty PopupListViewItemsSourceProperty = DependencyProperty
            .Register("PopupListViewItemsSource",
                typeof(object),
                typeof(MyCombo2),
                new PropertyMetadata(GetDefaultListViewItemsSource()));

        private static object GetDefaultListViewItemsSource()
        {
            ObservableCollection<Item> source = new ObservableCollection<Item>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new Item() { Text = "Item" + i });
            }
            return source;
        }

        public object PopupListViewItemsSource
        {
            get { return GetValue(PopupListViewItemsSourceProperty); }
            set { SetValue(PopupListViewItemsSourceProperty, value); }
        }


        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty
            .Register("SelectedItem",
                typeof(object),
                typeof(MyCombo2),
                new PropertyMetadata(null));

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set 
            {
                SetValue(SelectedItemProperty, value);
                //MainTextBox.Text = GetSelectedValueString(value);
            }
        }

        public static readonly DependencyProperty PopupListViewItemTemplateProperty = DependencyProperty
          .Register("PopupListViewItemTemplate",
              typeof(DataTemplate),
              typeof(MyCombo2),
              new PropertyMetadata(GetDefaultListViewDataTemplate()));

        private static DataTemplate GetDefaultListViewDataTemplate()
        {
            DataTemplate dataTemplate = XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock Text =\"{Binding Path=Text}\"/></DataTemplate>") as DataTemplate;
            return dataTemplate;
        }

        public DataTemplate PopupListViewItemTemplate
        {
            get { return (DataTemplate)GetValue(PopupListViewItemTemplateProperty); }
            set { SetValue(PopupListViewItemTemplateProperty, value); }
        }
        #endregion


        public MyCombo2()
        {
            this.InitializeComponent();



            //MainTextBox.PointerPressed += MainTextBox_PointerPressed;
            //MainTextBox.Text = GetSelectedValueString(this.SelectedItem);
        }

        private void UnderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UnderTextBox.SelectAll();
        }

        private void UnderTextBox_KeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {

                (this.PopupListViewItemsSource as ObservableCollection<Item>).Add(new Item() { Text = UnderTextBox.Text });
                this.SelectedItem = (this.PopupListViewItemsSource as ObservableCollection<Item>)[(this.PopupListViewItemsSource as ObservableCollection<Item>).Count-1];
                UnderTextBox_LostFocus(null, new RoutedEventArgs());

            }
        }

        private void MainBorderClick(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (IsEditableText)
            {
                MainBorder.Visibility = Visibility.Collapsed;
                UnderBorder.Visibility = Visibility.Visible;
                //UnderTextBox.LostFocus += UnderTextBox_LostFocus;
                UnderTextBox.Focus(FocusState.Programmatic);
            } 
            else
            {
                ShowPopup(sender,e);
            }
        }

        private void UnderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MainBorder.Visibility = Visibility.Visible;
            UnderBorder.Visibility = Visibility.Collapsed;
        }

        private void UnderBorderClick(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainBorder.Visibility = Visibility.Visible;
            UnderBorder.Visibility =  Visibility.Collapsed;
        }
        private void ClearSelectedItem(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.SelectedItem = null;
        }      

        private void MainTextBox_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //MainTextBox.Visibility = Visibility.Collapsed; 
        }

        private void ShowPopup(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            //ClearBorder.Visibility = ClearBorder.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            var t = this.SelectedItem;
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
            //MainTextBox.Text = GetSelectedValueString(PopupListView.SelectedValue);
            this.SelectedItem = PopupListView.SelectedValue;
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            MainTextBox.Visibility = Visibility.Visible;
        }

        private string GetSelectedValueString(object selectedValue)
        {
            if  (selectedValue == null) { return String.Empty; }

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

        private void ClearBorderPointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ClearBorder.Background = new SolidColorBrush(Colors.AliceBlue);
        }

        private void ClearBorderPointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ClearBorder.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void ShowBorderPointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ShowBorder.Background = new SolidColorBrush(Colors.AliceBlue);
        }

        private void ShowBorderPointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            ShowBorder.Background = new SolidColorBrush(Colors.Transparent);
        }


        public class Item
        {
            public string Text { get; set; }


        }
    }
}
