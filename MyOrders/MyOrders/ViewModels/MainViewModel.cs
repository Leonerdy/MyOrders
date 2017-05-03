using GalaSoft.MvvmLight.Command;
using MyOrders.Pages;
using MyOrders.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace MyOrders.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;
        ApiService apiService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
            apiService = new ApiService();

            Orders = new ObservableCollection<OrderViewModel>();

            LoadMenu();
            
        }

        #region Properties
        public OrderViewModel NewOrder { get; private set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion

        #region Comandos
        public ICommand GoToCommand
        {
            get { return new RelayCommand<string>(GoTo); }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        } 
        #endregion

        private async void Start()
        {
            var list = await apiService.GetAllOrders();
            Orders.Clear();
            foreach (var item in list)
            {
                Orders.Add(new OrderViewModel()
                {
                    Title = item.Title,
                    DeliveryDate = item.DeliveryDate,
                    Description = item.Description
                });
            }

            navigationService.SetMainPage("MasterPage");
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_add",
                Title = "Pedidos",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_add",
                Title = "Alarm",
                PageName = "AlarmsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_add",
                Title = "Clientes",
                PageName = "ClientsPage"
            });
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_action_add",
                Title = "Settings",
                PageName = "Settings"
            });
        }

        
    }
}
