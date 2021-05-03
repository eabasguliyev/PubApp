using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Documents;
using PubApp.Annotations;
using PubApp.Command;
using PubApp.Models;
using PubApp.Views;

namespace PubApp.ViewModels
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private Page _page;
        private int _lastPageCounter;
        public RelayCommand ChangePageCommand { get; set; }

        public ObservableCollection<DrinkBill> DrinkBills { get; set; }

        public RelayCommand BuyCommand { get; set; }

        public RelayCommand ShowHistoryCommand { get; set; }

        public ObservableCollection<Page> LastPages { get; set; }

        public RelayCommand BackCommand { get; set; }
        public RelayCommand AddCurrentPageCommand { get; set; }

        public int LastPageCounter
        {
            get => _lastPageCounter;
            set
            { 
                _lastPageCounter = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Page = new MainPage();

            var page = Page.DataContext as MainViewModel;
            page.MainPage = Page;
            page.ChangePageCommand = new RelayCommand(ChangePage);

            BuyCommand = new RelayCommand(BuyDrink);

            DrinkBills = new ObservableCollection<DrinkBill>();

            ShowHistoryCommand = new RelayCommand((object param) =>
            {
                var historyPage = new HistoryPageView()
                {
                    DataContext = new HistoryPageViewModel()
                    {
                        DrinkBills = DrinkBills.ToList()
                    }
                };

                ChangePage(historyPage);
            });

            BackCommand = new RelayCommand((object param) =>
            {
                var lastPageIndex = LastPages.Count - 1;
                if (lastPageIndex < 0)
                    return;

                var lastPage = LastPages[lastPageIndex];
                LastPages.RemoveAt(lastPageIndex);
                LastPageCounter--;
                
                ChangePage(lastPage);
            });

            LastPages = new ObservableCollection<Page>();

            AddCurrentPageCommand = new RelayCommand((object param) =>
            {
                LastPages.Add(param as Page);
                LastPageCounter++;
            });

            page.AddCurrentPageCommand = AddCurrentPageCommand;
        }

        public Page Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        private void ChangePage(object parameter)
        {
            Page = parameter as Page;

            if (Page is ProductPage productPage)
            {
                var productPageViewModel = productPage.DataContext as ProductPageViewModel;

                productPageViewModel.AddBillDatabaseCommand = BuyCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BuyDrink(object parameter)
        {
            if (parameter is DrinkBill newBill)
            {
                DrinkBills.Add(newBill);
            }
        }
    }
}