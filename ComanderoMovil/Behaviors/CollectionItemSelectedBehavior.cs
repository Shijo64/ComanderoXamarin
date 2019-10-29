using System;
using System.Linq;
using System.Windows.Input;
using ComanderoMovil.Models;
using Xamarin.Forms;

namespace ComanderoMovil.Behaviors
{
    public class CollectionItemSelectedBehavior : Behavior<CollectionView>
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(CollectionItemSelectedBehavior), null);

        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemTappedCommandProperty);
            }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }

        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SelectionChanged += Bindable_ItemSelected;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SelectionChanged -= Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ItemTappedCommand == null)
            {
                return;
            }
            var item = e.CurrentSelection.FirstOrDefault() as GroupModel;

            item.TextColor = Color.White;
            item.GroupColor = Color.DimGray;

            var previousItem = e.PreviousSelection.FirstOrDefault() as GroupModel;
            if (previousItem != null)
            {
                previousItem.TextColor = Color.DimGray;
                previousItem.GroupColor = Color.White;
            }

            if (ItemTappedCommand.CanExecute(item))
            {
                ItemTappedCommand.Execute(item);
            }
        }
    }
}
