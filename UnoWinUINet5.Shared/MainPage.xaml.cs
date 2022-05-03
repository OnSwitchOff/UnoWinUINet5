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
using System.Xml;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI;
using static UnoWinUINet5.UserControls.MyCombo2;
using System.ComponentModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoWinUINet5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Item> source = new ObservableCollection<Item>();
        public ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
        public Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));

            for (int i = 0; i < 10; i++)
            {
                source.Add(new Item() { Text = "Item" + i });
            }

            this.Loaded += MainPage_Loaded;
            SelectedItem = source[0];
            // gridgrid.PointerPressed += Gridgrid_PointerPressed;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedItem = source[1];
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

        private void Item0Clicked(object sender, RoutedEventArgs e)
        {
            SelectedItem = null;

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
            brdr2.PointerExited += Brdr2_PointerExited;
            lb.SelectionChanged += Lb_SelectionChanged;

        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl2.Text = (lb.SelectedValue as TextBlock).Text;
            lb.SelectionChanged -= Lb_SelectionChanged;
            brdr2.PointerExited -= Brdr2_PointerExited;
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }

        private void Brdr2_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            lb.SelectionChanged -= Lb_SelectionChanged;
            brdr2.PointerExited -= Brdr2_PointerExited;
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }

        private void Brdr1_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            brdr2.RightTapped -= Brdr1_RightTapped;
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }

        private void StandardPopup_LostFocus2(object sender, RoutedEventArgs e)
        {

            StandardPopup2.LostFocus -= StandardPopup_LostFocus2;
            if (StandardPopup2.IsOpen) { StandardPopup2.IsOpen = false; }
        }


        Popup popup;
        ListView listView;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        private void ShowPopupOffsetClicked3(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 

            popup = new Popup();


            Border bg = new Border();
            bg.BorderThickness = new Thickness(2);
            bg.BorderBrush = new SolidColorBrush(Colors.Blue);
            bg.Background = new SolidColorBrush(Colors.White);


            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.MaxHeight = 200;
            scrollViewer.Width = cbbx3.ActualWidth;

            listView = new ListView();
            //StringReader stringReader = new StringReader("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock Text=\"Text\"/></DataTemplate>");
            //XmlReader xmlReader = XmlReader.Create(stringReader);

            //DataTemplate dataTemplate = XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock Text=\"Text\"/></DataTemplate>") as DataTemplate;

            //listView.ItemTemplate = dataTemplate;

            string[] source = new string[] { "item1", "item2", "item3", "item2", "item3", "item2", "item3" };
            listView.ItemsSource = source;


            StandardPopup2.LostFocus += StandardPopup_LostFocus2;
            brdr2.PointerExited += Brdr2_PointerExited;
            lb.SelectionChanged += Lb_SelectionChanged;

            scrollViewer.Content = listView;
            cbbx3.Children.Add(popup);
            Grid.SetColumnSpan(popup, 2);
            bg.Child = scrollViewer;
            popup.Child = bg;
       

            scrollViewer.PointerExited += ScrollViewer_PointerExited;
            listView.SelectionChanged += ListView_SelectionChanged;
            popup.IsOpen = true;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            popup.IsOpen = false;
            listView.SelectionChanged -= ListView_SelectionChanged;

            lbl3.Text = listView.SelectedValue.ToString();
            cbbx3.Children.Remove(popup);
        }

        private void ScrollViewer_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            popup.IsOpen = false;
            listView.SelectionChanged -= ListView_SelectionChanged;
            cbbx3.Children.Remove(popup);
        }


        private void ShowPopupOffsetClicked4(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup4.IsOpen) { StandardPopup4.IsOpen = true; }
            scr4.Width = cbbx4.ActualWidth;
            brdr4.PointerExited += Brdr4_PointerExited; 
            lb4.SelectionChanged += Lb_SelectionChanged4; 

        }

        private void Lb_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            lbl4.Text = (lb4.SelectedValue as TextBlock).Text;
            lb4.SelectionChanged -= Lb_SelectionChanged4;
            brdr4.PointerExited -= Brdr4_PointerExited;
            if (StandardPopup4.IsOpen) { StandardPopup4.IsOpen = false; }
        }

        private void Brdr4_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            lb4.SelectionChanged -= Lb_SelectionChanged4;
            brdr4.PointerExited -= Brdr4_PointerExited;
            if (StandardPopup4.IsOpen) { StandardPopup4.IsOpen = false; }
        }
    }
}
