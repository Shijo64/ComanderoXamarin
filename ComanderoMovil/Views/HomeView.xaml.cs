using System;
using System.Collections.Generic;
using ComanderoMovil.Repositorys;
using ComanderoMovil.ViewModels;
using Xamarin.Forms;

namespace ComanderoMovil.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<MenuRepository>(this, "NoConnection", (sender) =>
            {
                DisplayAlert("Aviso", "Revisa la conexión del dispositivo.", "Aceptar");
            });
            this.BindingContext = new HomeViewModel(Navigation);
        }
    }
}
