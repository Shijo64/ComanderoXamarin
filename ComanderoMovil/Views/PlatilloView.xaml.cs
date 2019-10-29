using System;
using System.Collections.Generic;
using ComanderoMovil.Models;
using ComanderoMovil.ViewModels;
using Xamarin.Forms;

namespace ComanderoMovil.Views
{
    public partial class PlatilloView : ContentPage
    {
        public PlatilloView(DishModel platilloSeleccionado)
        {
            InitializeComponent();
            //this.BindingContext = new PlatilloSeleccionadoViewModel(platilloSeleccionado, Navigation);
        }
    }
}
