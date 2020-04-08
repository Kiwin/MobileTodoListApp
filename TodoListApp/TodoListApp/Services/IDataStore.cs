using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoListApp.Services
{
    public interface IDataStore<T> where T : IIdentifiable
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
    }
}
