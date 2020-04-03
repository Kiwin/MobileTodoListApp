using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoListApp.Services
{
    public interface IDataStore<T> where T : IIdentifiable
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(Guid id);
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
    }
}
