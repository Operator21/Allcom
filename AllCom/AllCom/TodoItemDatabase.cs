using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCom
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;
        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Game>().Wait();
            database.CreateTableAsync<Category>().Wait();
        }
        public Task<List<Category>> GetCategories(int id)
        {
            return database.Table<Category>().Where(i => i.GameID == id).ToListAsync();
        }
        public Task<List<Game>> GetItemsAsync()
        {
            return database.Table<Game>().ToListAsync();
        }
        public Task<int> DeleteTable()
        {
            return database.DropTableAsync<Game>();
        }

        public Task<int> SaveItemAsync(Game item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync(Category item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(Category item)
        {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteItemAsync(Game item)
        {
            return database.DeleteAsync(item);
        }
    }
}
