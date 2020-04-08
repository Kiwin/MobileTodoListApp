using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TodoListApp.Views;
using TodoListApp.Models;
using SQLite;

namespace TodoListApp.ViewModels
{
    public class NotesModelView : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadItemsCommand { get; set; }

        public NotesModelView()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewNotePage, Note>(this, "AddItem", async (obj, item) =>
            {
                var newPostItNote = item as Note;

                //Save newly created note to database.
                using (SQLiteConnection conn = new SQLiteConnection(App.SQLITE_DB_FILE_PATH))
                {
                    conn.CreateTable<Note>(); //Create table if it does not exist.
                    conn.Insert(newPostItNote);
                }

                Notes.Add(newPostItNote);
                await DataStore.AddItemAsync(newPostItNote);
            });
            MessagingCenter.Subscribe<NoteDetailPane, Note>(this, "DeleteItem", async (obj, item) =>
            {
                var newPostItNote = item as Note;

                //Delete the selected note from database.
                using (SQLiteConnection conn = new SQLiteConnection(App.SQLITE_DB_FILE_PATH))
                {
                    conn.CreateTable<Note>(); //Create table if it does not exist.
                    conn.Delete(newPostItNote);
                }

                var newItem = item as Note;
                Notes.Remove(newItem);
                await DataStore.DeleteItemAsync(newItem.Id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Notes.Clear();
                var items = await DataStore.GetAllItemsAsync(true);
                foreach (var note in items)
                {
                    Notes.Add(note);
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