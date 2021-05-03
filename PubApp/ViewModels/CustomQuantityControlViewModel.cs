using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using PubApp.Annotations;
using PubApp.Command;

namespace PubApp.ViewModels
{
    public class CustomQuantityControlViewModel:DependencyObject, INotifyPropertyChanged
    {
        private int _quantity;
        public RelayCommand IncreaseCommand { get; set; }
        public RelayCommand DecreaseCommand { get; set; }

        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Quantity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(int), typeof(CustomQuantityControlViewModel), new PropertyMetadata(0));


        public CustomQuantityControlViewModel()
        {
            IncreaseCommand = new RelayCommand((object param) =>
            {
                Quantity++;
            });

            DecreaseCommand = new RelayCommand((object param) =>
            {
                if(Quantity > 1)
                    Quantity--;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}