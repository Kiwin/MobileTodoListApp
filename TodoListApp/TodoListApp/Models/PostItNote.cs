using System;
using TodoListApp.Services;
using Xamarin.Essentials;

namespace TodoListApp.Models
{
    public class PostItNote : IIdentifiable
    {
        public PostItNote()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
    }
}