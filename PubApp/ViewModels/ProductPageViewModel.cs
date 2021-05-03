using System;
using System.Windows.Controls;
using PubApp.Command;
using PubApp.Models;

namespace PubApp.ViewModels
{
    public class ProductPageViewModel
    {
        public Drink Drink { get; set; }

        public RelayCommand AddBillDatabaseCommand { get; set; }

        public RelayCommand BuyDrinkCommand { get; set; }

        public RelayCommand ListboxItemClickCommand { get; set; }

        public RelayCommand ChangeFavoriteStatusCommand { get; set; }
        public int DrinkSize { get; set; }

        public Page ProducPage { get; set; } // bu burda olmali deyil. daha yaxshi hell tap. (2)
        public ProductPageViewModel()
        {
            BuyDrinkCommand = new RelayCommand(BuyDrink);
            ListboxItemClickCommand = new RelayCommand(ListBoxItemClick);
        }

        private void BuyDrink(object parameter)
        {
            
            var newBill = CreateNewBill((int)parameter);

            AddBillDatabaseCommand.Execute(newBill);
        }

        private DrinkBill CreateNewBill(int itemCount)
        {
            return new DrinkBill()
            {
                Drink = Drink,
                Size = DrinkSize,
                Count = itemCount,
                Cost = Drink.Price*itemCount,
            };
        }

        private void ListBoxItemClick(object parameter)
        {
            DrinkSize = (int) parameter;
        }
    }
}