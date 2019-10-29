using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ComanderoMovil.Behaviors
{
    public class SearchBarSearchedBehavior : Behavior<SearchBar>
    {
        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create("TextChangedCommand", typeof(ICommand), typeof(SearchBarSearchedBehavior), null);

        public ICommand TextChangedCommand
        {
            get
            {
                return (ICommand)GetValue(TextChangedCommandProperty);
            }
            set
            {
                SetValue(TextChangedCommandProperty, value);
            }
        }

        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChangedCommand == null)
            {
                return;
            }
            var item = e.NewTextValue;

            if (TextChangedCommand.CanExecute(item))
            {
                TextChangedCommand.Execute(item);
            }
        }
    }
}
