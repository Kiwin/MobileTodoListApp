using System;

using TodoListApp.Models;

namespace TodoListApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public PostItNote Item { get; set; }
        public ItemDetailViewModel(PostItNote item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
