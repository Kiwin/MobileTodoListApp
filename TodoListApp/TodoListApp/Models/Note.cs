using TodoListApp.Services;
using SQLite;

namespace TodoListApp.Models
{
    public class Note : IIdentifiable
    {
        public Note(int id)
        {
            Id = id;
            Title = string.Empty;
            Text = string.Empty;
            Location = string.Empty;
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
    }
}