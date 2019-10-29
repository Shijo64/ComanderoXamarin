using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ComanderoMovil.Data;
using ComanderoMovil.Helpers;
using ComanderoMovil.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace ComanderoMovil.Repositorys
{
    public class MenuRepository
    {
        public MenuModel Menu { get; set; }

        public MenuRepository()
        {
            Task.Run(async () => await GetMenu()).Wait();
        }


        public MenuModel GetCompleteMenu()
        {
            return Menu;
        }

        public async Task GetMenu()
        {
            var url = "https://www.wansoft.net/public/json1.json";
            var helper = new HttpHelper<MenuModel>();
            var result = helper.GetRestServiceDataAsync(url);
            Menu = await result;
            await SaveMenu();
        }

        public async Task SaveMenu()
        {
            foreach (var group in Menu.Groups)
            {
                group.IsExpanded = false;
                await App.DataManager.SaveGroupsAsync(group);
            }

            foreach (var dish in Menu.Dishes)
            {
                var group = Menu.Groups.Where(x => x.Id == dish.GroupId).FirstOrDefault();
                if (group != null)
                {
                    dish.GroupName = group.Name;
                }
                else
                {
                    dish.GroupName = "Otro";
                }
                await App.DataManager.SaveDishesAsync(dish);
            }
        }
    }
}
