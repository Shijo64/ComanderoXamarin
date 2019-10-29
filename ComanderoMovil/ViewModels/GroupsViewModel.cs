using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ComanderoMovil.Helpers;
using ComanderoMovil.Models;
using ComanderoMovil.Repositorys;
using Xamarin.Forms;

namespace ComanderoMovil.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        public ObservableCollection<GroupModel> Groups { get; set;}
        public ObservableCollection<DishModel> UngroupedDishes { get; set; }
        public ObservableCollection<GroupingHelper<string, DishModel>> Dishes { get; set; }
        private INavigation Navigation;
        public Command SelectedItemCommand { get; set; }
        public Command SearchBarTextChangedCommand { get; set; }
        public Command SelectGroupHeader { get; set; }
        public Command SelectedDishCommand { get; set; }
        public Command TextSearchCommand { get; set; }
        DishesRepository dishRepo = new DishesRepository();
        public bool groupVisible { get; set; }
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public GroupsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GroupsRepository repo = new GroupsRepository();
            Groups = repo.GetAllGroups();
            UngroupedDishes = dishRepo.GetAll();
            Dishes = dishRepo.GroupDishes(UngroupedDishes);
            SelectedItemCommand = new Command(async (item) => await SelectedGroup((GroupModel)item));
            SelectGroupHeader = new Command(async (item) => await SelectedGroupHeader((string)item));
            SelectedDishCommand = new Command(async (dish) => await SelectedDish((DishModel)dish));
            TextSearchCommand = new Command(async (search) => await SearchText((string)search));
            groupVisible = false;
        }

        private async Task SelectedGroup(GroupModel item)
        {
            foreach (var dishGroup in Dishes)
            {
                if(item.Name == dishGroup.Key)
                {
                    if (!item.IsExpanded)
                    {
                        UngroupedDishes.Where(x => x.GroupName == item.Name).ToList().ForEach(dishGroup.Add);
                        SelectedItem = item.Name;
                        item.IsExpanded = true;
                    }
                }
            }

            MessagingCenter.Send<GroupsViewModel>(this, "SelectedGroup");
        }

        private async Task SelectedGroupHeader(string item)
        {
            var groupModel = Groups.Where(x => x.Name == item).FirstOrDefault();

            foreach (var dishGroup in Dishes)
            {
                if (item == dishGroup.Key)
                {
                    if (groupModel.IsExpanded)
                    {
                        dishGroup.Clear();
                        groupModel.IsExpanded = false;
                    }
                    else
                    {
                        UngroupedDishes.Where(x => x.GroupName == item).ToList().ForEach(dishGroup.Add);
                        groupModel.IsExpanded = true;
                        SelectedItem = groupModel.Name;
                        MessagingCenter.Send<GroupsViewModel>(this, "SelectedGroup");
                    }
                }
            }
        }

        private async Task SelectedDish(DishModel dish)
        {
            var prueba = "Prueba";
        }

        private async Task SearchText(string text)
        {
            var result = new ObservableCollection<DishModel>(UngroupedDishes.Where(x => x.Name.Contains(text)).ToList());
            if (result.Count > 0)
            {
                List<string> groupsList = new List<string>();
                foreach (var prueba in result)
                {
                    var prueba2 = prueba.GroupName;
                    groupsList.Add(prueba2);
                }

                var distinct = groupsList.Distinct().ToList();

                foreach (var dishGroupName in distinct)
                {
                    var groupModel = Groups.Where(x => x.Name == dishGroupName).FirstOrDefault();
                    var dishGroup = Dishes.Where(x => x.Key == dishGroupName).FirstOrDefault();
                    if(dishGroup.Where(x => x.Name.Contains(text)).Count() < 1)
                    {
                        result.Where(x => x.GroupName == dishGroupName).Distinct().ToList().ForEach(dishGroup.Add);
                        groupModel.IsExpanded = true;
                    }
                }

                SelectedItem = result.FirstOrDefault().GroupName;
                MessagingCenter.Send<GroupsViewModel>(this, "SelectedGroup");
            }
        }
    }
}
