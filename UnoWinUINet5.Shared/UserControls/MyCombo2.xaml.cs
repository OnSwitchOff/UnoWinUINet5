using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;



// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoWinUINet5.UserControls
{
    public sealed partial class MyCombo2 : UserControl
    {
        public MyCombo2()
        {
            this.InitializeComponent();
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


            return selectedValue.ToString();
        }

        private void PopupBorder_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PopupListView.SelectionChanged -= PopupListView_SelectionChanged;
            PopupBorder.PointerExited -= PopupBorder_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }
    }
}
