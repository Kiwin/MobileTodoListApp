using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class IdentifiablesDataStore<T> : IDataStore<T> where T : IIdentifiable
    {
        private readonly List<T> items;

        public IdentifiablesDataStore()
        {
            items = new List<T>();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var itemToRemove = items.FirstOrDefault(item => item.Id == id); ;
            return await Task.FromResult(items.Remove(itemToRemove));
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(item => item.Id == id));
        }

        public async Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = items.FirstOrDefault(item2 => item2.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
