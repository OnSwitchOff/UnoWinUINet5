using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;



// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyCombo2 : UserControl
    {

        public static readonly DependencyProperty MainTextBoxForegroundProperty = DependencyProperty
           .Register("MainTextBoxForeground",
               typeof(Brush),
               typeof(MyComboBox),
               new PropertyMetadata(Application.Current.Resources["ApplicationForegroundThemeBrush"] as Brush));

        public Brush MainTextBoxForeground
        {
            get { return (Brush)GetValue(MainTextBoxForegroundProperty); }
            set { SetValue(MainTextBoxForegroundProperty, value); }
        }

        public MyCombo2()
        {
            this.InitializeComponent();
            ObservableCollection<Item> source = new ObservableCollection<Item>();
            for (int i = 0; i < 10; i++)
            {
                source.Add(new Item() { Text = "Item" + i });
            }
            PopupListView.ItemsSource = source;
            TextBox2.Visibility = Visibility.Collapsed;
            MainTextBox.PointerPressed += MainTextBox_PointerPressed;
            TextBox2.LostFocus += TextBox2_LostFocus;
        }

        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox2.Visibility = Visibility.Collapsed; 
            MainTextBox.Visibility = Visibility.Visible;
        }

        private void MainTextBox_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            TextBox2.Text = MainTextBox.Text;
            TextBox2.Visibility = Visibility.Visible;
            TextBox2.Focus(FocusState.Programmatic);
            TextBox2.SelectionStart = TextBox2.Text.Length;
            MainTextBox.Visibility = Visibility.Collapsed; ;
        }

        private void ShowPopup(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
            PopupScrolViewer.Width = MainGrid.ActualWidth;
            PopupBorder.PointerExited += PopupBorder_PointerExited;
            PopupListView.SelectionChanged += PopupListView_SelectionChanged;

        }

        private void PopupListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTextBox.Text = GetSelectedValueString(PopupListView.SelectedValue);
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            TextBox2.Visibility = Visibility.Collapsed; ;
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

        private class Item
        {
            public string Text { get; set; }
        }
    }
}
