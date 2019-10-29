using System;
using System.Windows.Input;
using ComanderoMovil.Models;
using Xamarin.Forms;

namespace ComanderoMovil.Behaviors
{
    public class ListViewSelectedItemBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty SelectedItemCommandProperty =
            BindableProperty.Create("SelectedItemCommand", typeof(ICommand), typeof(ListViewSelectedItemBehavior), null);

        public ICommand SelectedItemCommand
        {
            get
            {
                return (ICommand)GetValue(SelectedItemCommandProperty);
            }
            set
            {
                SetValue(SelectedItemCommandProperty, value);
            }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += Bindable_ItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (SelectedItemCommand == null)
            {
                return;
            }
            var item = e.SelectedItem as GroupModel;
            //item.TextColor = Color.Black;
            //var previousItem = e.PreviousSelection.FirstOrDefault() as GroupModel;
            //if (previousItem != null)
            //{
            //    previousItem.TextColor = Color.Gray;
            //}

            if (SelectedItemCommand.CanExecute(item))
            {
                SelectedItemCommand.Execute(item);
            }
        }
    }
}
