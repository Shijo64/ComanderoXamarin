using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ComanderoMovil.Helpers;
using ComanderoMovil.Models;
using ComanderoMovil.ViewModels;
using Xamarin.Forms;

namespace ComanderoMovil.Views
{
    public partial class DishesView : ContentPage
    {
        public DishesView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<GroupsViewModel>(this, "SelectedGroup", (sender) =>
            {
                var dishes = this.GroupsList.ItemsSource as ObservableCollection<GroupingHelper<string, DishModel>>;
                var group = dishes.Where(x => x.Key == sender.SelectedItem).FirstOrDefault();
                this.GroupsList.ScrollTo(group.First(), ScrollToPosition.Start, true);
            });

            this.BindingContext = new GroupsViewModel(Navigation);
        }
    }
}
