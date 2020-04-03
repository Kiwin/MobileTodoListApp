using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TodoListApp.Models;
using TodoListApp.Views;

namespace TodoListApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<PostItNote> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<PostItNote>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewPostItNotePage, PostItNote>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as PostItNote;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
            MessagingCenter.Subscribe<ItemDetailPage, PostItNote>(this, "DeleteItem", async (obj, item) =>
            {
                var newItem = item as PostItNote;
                Items.Remove(newItem);
                await DataStore.DeleteItemAsync(newItem.Id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetAllItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}