using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using PubApp.Command;
using PubApp.Models;
using PubApp.Views;

namespace PubApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Drink> Drinks { get; set; }

        public RelayCommand ChangePageCommand { get; set; }

        public RelayCommand ListBoxItemClickCommand { get; set; }

        public RelayCommand ChangeFavoriteStatusCommand { get; set; }

        public RelayCommand AddCurrentPageCommand { get; set; }


        public Page MainPage { get; set; } // bu burda olmali deyil. daha yaxshi hell tap. (1)


        public MainViewModel()
        {
            Drinks = new ObservableCollection<Drink>()
            {
                new Drink()
                {
                    Hardness = "Strong",
                    Name = "Korbel Baundy",
                    Price = 200,
                    Sizes = new List<int>()
                    {
                        250,
                        500,
                        750
                    },
                    Favorite = true,
                },
                new Drink()
                {
                    Hardness = "Light",
                    Name = "NZS",
                    Price = 2,
                    Sizes = new List<int>()
                    {
                        250,
                        500,
                        750
                    }
                },
            };

            ListBoxItemClickCommand = new RelayCommand(ListBoxItemClick);

            ChangeFavoriteStatusCommand = new RelayCommand((object param) =>
            { 
                (param as Drink)?.ChangeFavoriteStatus();
            });
        }

        private void ListBoxItemClick(object item)
        {
            var drink = item as Drink;

            var productPage = new ProductPage()
            {
                DataContext = new ProductPageViewModel()
                {
                    Drink = drink,
                    ChangeFavoriteStatusCommand = ChangeFavoriteStatusCommand,
                },
            };

            AddCurrentPageCommand.Execute(null); 

            ChangePageCommand.Execute(productPage);
        }
    }
}