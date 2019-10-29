using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ComanderoMovil.Helpers;
using ComanderoMovil.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace ComanderoMovil.Repositorys
{
    public class DishesRepository
    {
        public ObservableCollection<DishModel> Dishes { get; set; }
        public IList<DishModel> dbaseDishes { get; set; }

        public DishesRepository()
        {
            Task.Run(async () => dbaseDishes = await App.DataManager.GetAllDishesAsync()).Wait();
            Dishes = new ObservableCollection<DishModel>(dbaseDishes);
        }

        public ObservableCollection<DishModel> GetAll()
        {
            return Dishes;
        }

        public ObservableCollection<DishModel> GetFilteredByGroup(GroupModel group)
        {
            var dishes = Dishes.Where(o => o.GroupId == group.Id);
            return new ObservableCollection<DishModel>(dishes);
            //var platillos = Platillos.First();
            //ObservableCollection<DishModel> nueva = new ObservableCollection<DishModel>();
            //nueva = GroupPlatillos(platillos);
            //return nueva;
        }

        public ObservableCollection<GroupingHelper<string, DishModel>> GroupDishes(ObservableCollection<DishModel> list)
        {
            IEnumerable<GroupingHelper<string, DishModel>> sorted = new GroupingHelper<string, DishModel>[0];
            if (list != null)
            {
                sorted = from p in list
                         orderby p.GroupName
                         group p by p.GroupName
                         into theGroup
                         select new GroupingHelper<string, DishModel>(theGroup.Key);
            }

            return new ObservableCollection<GroupingHelper<string, DishModel>>(sorted);
        }
    }
}
