using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Models;
using Xunit;

namespace TodoListApp.Tests.Services
{
    public class IdentifiablesDataStore
    {
        [Fact]
        public async void AddItemAsync_Should_Add_Item_To_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<Note>();
            var note = new Note(1);
            
            await dataStore.AddItemAsync(note);

            var retrievedPostItNote = await dataStore.GetItemAsync(note.Id);
            Assert.Equal(retrievedPostItNote, note);
        }

        [Fact]
        public async void GetItemAsync_Should_Retrieve_Item_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<Note>();
            var note = new Note(1);

            await dataStore.AddItemAsync(note);

            var retrievedPostItNote = await dataStore.GetItemAsync(note.Id);
            Assert.Equal(retrievedPostItNote, note);
        }

        [Fact]
        public async void DeleteItemAsync_Should_Remove_Item_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<Note>();
            var note = new Note(1);

            await dataStore.AddItemAsync(note);
            await dataStore.DeleteItemAsync(note.Id);

            var retrievedPostItNote = await dataStore.GetItemAsync(note.Id);
            Assert.Null(retrievedPostItNote);
        }

        [Fact]
        public async void GetItemAsync_Should_Retrieve_All_Items_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<Note>();
            var note = new Note(1);
            var note2 = new Note(2);
            var note3 = new Note(3);

            await dataStore.AddItemAsync(note);
            await dataStore.AddItemAsync(note2);
            await dataStore.AddItemAsync(note3);

            var items = await dataStore.GetAllItemsAsync();
            var expectedItems = new List<Note> { note, note2, note3 };
            Assert.Equal(items, expectedItems);
        }
    }
}
