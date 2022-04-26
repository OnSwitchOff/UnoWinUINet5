using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoWinUINet5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
        public MainPage()
        {
            this.InitializeComponent();
            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));
           // gridgrid.PointerPressed += Gridgrid_PointerPressed;
        }

        //private void Gridgrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    tb.Focus(FocusState.Programmatic);
        //}

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {

            StandardPopup.LostFocus -= StandardPopup_LostFocus;
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }

            StandardPopup.LostFocus += StandardPopup_LostFocus;

            StandardPopup.PointerExited += StandardPopup_PointerExited;

            StandardPopup.PointerCaptureLost += StandardPopup_PointerCaptureLost;

            StandardPopup.RightTapped += StandardPopup_RightTapped;

            StandardPopup.LosingFocus += StandardPopup_LosingFocus;

            StandardPopup.PointerEntered += StandardPopup_PointerEntered;

            StandardPopup.PointerMoved += StandardPopup_PointerMoved;

            StandardPopup.Tapped += StandardPopup_Tapped;

            brdr1.PointerExited += Brdr1_PointerExited;
        }

        private void Brdr1_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            brdr1.PointerExited -= Brdr1_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void StandardPopup_Tapped(object sender, TappedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StandardPopup_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            StandardPopup.PointerExited -= StandardPopup_PointerExited;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void StandardPopup_LostFocus(object sender, RoutedEventArgs e)
        {

            StandardPopup.LostFocus -= StandardPopup_LostFocus;
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void ClosePopupClicked2(object sender, RoutedEventArgs e)
        {

            StandardPopup2.LostFocus -= StandardPopup_LostFocus2;
            // if the Popup is open, then close it 
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked2(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup2.IsOpen) { StandardPopup2.IsOpen = true; }

            StandardPopup2.LostFocus += StandardPopup_LostFocus2;
        }

        private void StandardPopup_LostFocus2(object sender, RoutedEventArgs e)
        {

            StandardPopup2.LostFocus -= StandardPopup_LostFocus2;
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }
    }
}
