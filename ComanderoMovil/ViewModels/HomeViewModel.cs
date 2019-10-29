using System;
using System.Threading.Tasks;
using ComanderoMovil.Models;
using ComanderoMovil.Repositorys;
using ComanderoMovil.Views;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace ComanderoMovil.ViewModels
{
    public class HomeViewModel
    {
        public MenuModel Menu { get; set; }
        public Command NewOrderCommand { get; set; }
        private INavigation Navigation;

        public HomeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            NewOrderCommand = new Command(async () => await NavigateToGroupsView());
            if (CrossConnectivity.Current.IsConnected)
            {
                var menuRepo = new MenuRepository();
                Menu = menuRepo.GetCompleteMenu();
            }
        }

        public async Task NavigateToGroupsView()
        {
            await Navigation.PushAsync(new DishesView());
        }
    }
}
