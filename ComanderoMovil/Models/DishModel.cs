using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Xamarin.Forms;

namespace ComanderoMovil.Models
{
    public class DishModel : INotifyPropertyChanged
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int GroupId { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
        public int Order { get; set; }
        public string Color { get; set; }
        public bool AskWeight { get; set; }
        public bool AskCode { get; set; }
        public bool AskPrice { get; set; }

        private string _groupName;
        public string GroupName
        {
            get => _groupName;
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
