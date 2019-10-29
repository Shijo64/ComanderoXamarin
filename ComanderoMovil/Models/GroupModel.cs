using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ComanderoMovil.Repositorys;
using SQLite;
using Xamarin.Forms;


namespace ComanderoMovil.Models
{
    public class GroupModel : INotifyPropertyChanged
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupTypeId { get; set; }
        public bool AskCode { get; set; }
        public string Color { get; set; }
        public int Order { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<DishModel> _dishes;
        [Ignore]
        public ObservableCollection<DishModel> Dishes
        {
            get => _dishes;
            set
            {
                _dishes = value;
                OnPropertyChanged();
            }
        }

        private Color _groupColor;
        [Ignore]
        public Color GroupColor
        {
            get => _groupColor;
            set
            {
                _groupColor = value;
                OnPropertyChanged();
            }
        }

        private Color _textColor;
        [Ignore]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
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
