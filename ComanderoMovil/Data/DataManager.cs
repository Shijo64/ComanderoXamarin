using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComanderoMovil.Models;
using SQLite;

namespace ComanderoMovil.Data
{
    public class DataManager
    {
        private readonly SQLiteAsyncConnection database;

        public DataManager(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<GroupModel>().Wait();
            database.CreateTableAsync<DishModel>().Wait();
            database.CreateTableAsync<GroupTypeModel>().Wait();
            database.CreateTableAsync<SizesModel>().Wait();
            database.CreateTableAsync<LevelModel>().Wait();
            database.CreateTableAsync<DishModifierModel>().Wait();
            database.CreateTableAsync<GroupSizeModel>().Wait();
        }

        public Task SaveGroupsAsync(GroupModel group)
        {
            var data = database.Table<GroupModel>().Where(x => x.Id == group.Id).FirstOrDefaultAsync().Result;

            if(data != null)
            {
                return database.UpdateAsync(group);
            }
            else
            {
                return database.InsertAsync(group);
            }
        }

        public async Task<List<GroupModel>> GetAllGroupsAsync()
        {
            return await database.Table<GroupModel>().OrderBy(x => x.Order).ToListAsync();
        }

        public Task SaveDishesAsync(DishModel dish)
        {
            var data = database.Table<DishModel>().Where(x => x.Id == dish.Id).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(dish);
            }
            else
            {
                return database.InsertAsync(dish);
            }
        }

        public async Task<List<DishModel>> GetAllDishesAsync()
        {
            return await database.Table<DishModel>().OrderBy(x => x.Order).ToListAsync();
        }

        public Task SaveDishModifiersAsync(DishModifierModel dishModifier)
        {
            var data = database.Table<DishModifierModel>().Where(x => x.ModifierId == dishModifier.ModifierId).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(dishModifier);
            }
            else
            {
                return database.InsertAsync(dishModifier);
            }
        }

        public Task SaveGroupSizeAsync(GroupSizeModel groupSize)
        {
            var data = database.Table<GroupSizeModel>().Where(x => x.SizeId == groupSize.SizeId).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(groupSize);
            }
            else
            {
                return database.InsertAsync(groupSize);
            }
        }

        public Task SaveGroupTypeAsync(GroupTypeModel groupType)
        {
            var data = database.Table<GroupTypeModel>().Where(x => x.Id == groupType.Id).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(groupType);
            }
            else
            {
                return database.InsertAsync(groupType);
            }
        }

        public Task SaveLevelsAsync(LevelModel level)
        {
            var data = database.Table<LevelModel>().Where(x => x.Number == level.Number).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(level);
            }
            else
            {
                return database.InsertAsync(level);
            }
        }

        public Task SaveSizesAsync(SizesModel size)
        {
            var data = database.Table<SizesModel>().Where(x => x.Id == size.Id).FirstOrDefaultAsync().Result;
            if (data != null)
            {
                return database.UpdateAsync(size);
            }
            else
            {
                return database.InsertAsync(size);
            }
        }
    }
}
