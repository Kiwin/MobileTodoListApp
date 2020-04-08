using System;

using TodoListApp.Models;

namespace TodoListApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Item { get; set; }
        public ItemDetailViewModel(Note item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
