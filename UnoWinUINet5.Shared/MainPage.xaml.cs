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
using System.Diagnostics;


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

   

        // Handles the Click event on the Button on the page and opens the Popup. 
      

        private void Item0Clicked(object sender, RoutedEventArgs e)
        {
            SelectedItem = null;

        }

       
       

       
        

        Popup popup;
        ListView listView;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        
           

       
    }
}
