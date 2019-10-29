using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ComanderoMovil.Helpers;
using ComanderoMovil.Models;
using System.Linq;

namespace ComanderoMovil.Repositorys
{
    public class GroupsRepository
    {
        public ObservableCollection<GroupModel> Groups { get; set; }
        public IList<GroupModel> dbaseGroups { get; set; }

        public GroupsRepository()
        {
            Task.Run(async () => dbaseGroups = await App.DataManager.GetAllGroupsAsync()).Wait();
            Groups = new ObservableCollection<GroupModel>(dbaseGroups.OrderBy(x => x.Name));
        }

        public ObservableCollection<GroupModel> GetAllGroups()
        {
            return Groups;
        }
    }
}
