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
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<PostItNote>();
            var postItNote = new PostItNote();
            
            await dataStore.AddItemAsync(postItNote);

            var retrievedPostItNote = await dataStore.GetItemAsync(postItNote.Id);
            Assert.Equal(retrievedPostItNote, postItNote);
        }

        [Fact]
        public async void GetItemAsync_Should_Retrieve_Item_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<PostItNote>();
            var postItNote = new PostItNote();

            await dataStore.AddItemAsync(postItNote);

            var retrievedPostItNote = await dataStore.GetItemAsync(postItNote.Id);
            Assert.Equal(retrievedPostItNote, postItNote);
        }

        [Fact]
        public async void DeleteItemAsync_Should_Remove_Item_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<PostItNote>();
            var postItNote = new PostItNote();

            await dataStore.AddItemAsync(postItNote);
            await dataStore.DeleteItemAsync(postItNote.Id);

            var retrievedPostItNote = await dataStore.GetItemAsync(postItNote.Id);
            Assert.Null(retrievedPostItNote);
        }

        [Fact]
        public async void GetItemAsync_Should_Retrieve_All_Items_From_Store()
        {
            var dataStore = new TodoListApp.Services.IdentifiablesDataStore<PostItNote>();
            var postItNote = new PostItNote();
            var postItNote2 = new PostItNote();
            var postItNote3 = new PostItNote();

            await dataStore.AddItemAsync(postItNote);
            await dataStore.AddItemAsync(postItNote2);
            await dataStore.AddItemAsync(postItNote3);

            var items = await dataStore.GetAllItemsAsync();
            var expectedItems = new List<PostItNote> { postItNote, postItNote2, postItNote3 };
            Assert.Equal(items, expectedItems);
        }
    }
}
