using System.Windows;
using System.Windows.Controls;

namespace PubApp.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for ListBoxItem.xaml
    /// </summary>
    public partial class ListBoxItem : UserControl
    {


        public string DrinkName
        {
            get { return (string)GetValue(DrinkNameProperty); }
            set { SetValue(DrinkNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrinkName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrinkNameProperty =
            DependencyProperty.Register("DrinkName", typeof(string), typeof(ListBoxItem));



        public string BottleSize
        {
            get { return (string)GetValue(BottleSizeProperty); }
            set { SetValue(BottleSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BottleSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BottleSizeProperty =
            DependencyProperty.Register("BottleSize", typeof(string), typeof(ListBoxItem));



        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(string), typeof(ListBoxItem));


        public ListBoxItem()
        {
            InitializeComponent();
        }
    }
}
