using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ComanderoMovil.Models;

namespace ComanderoMovil.Helpers
{
    public class DishGroup : ObservableCollection<DishModel>, INotifyPropertyChanged
    {
        private bool _isExpanded;

        public string Name { get; set; }
        public string GroupName
        {
            get
            {
                return string.Format("{0}", Name);
            }
        }

        public int DishCount { get; set; }
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if(_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }

        public DishGroup(string name, bool expanded = true)
        {
            Name = name;
            IsExpanded = expanded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
