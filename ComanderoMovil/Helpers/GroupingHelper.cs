using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ComanderoMovil.Helpers
{
    public class GroupingHelper<K, T> : ObservableCollection<T>
    {
        internal object nombre;

        public K Key { get; }

        public GroupingHelper(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach(var item in items)
            {
                Items.Add(item);
            }
        }

        public GroupingHelper(K key)
        {
            Key = key;
        }
    }
}
