using System;
using TodoListApp.Services;
using Xamarin.Essentials;
using Xunit;

namespace TodoListApp.Tests.Models
{
    public class PostItNote
    {
        [Fact]
        public void Constructor_Should_Set_Id()
        {
            var id = 1;
            var note = new TodoListApp.Models.Note(id);
            Assert.Equal(id, note.Id);
        }
        [Fact]
        public void Property_Id_Should_Be_Readable()
        {
            var id = 1;
            var note = new TodoListApp.Models.Note(id);
            Assert.Equal(id, note.Id);
        }
        [Fact]
        public void Property_Title_Should_Be_Assignable_And_Readable()
        {
            var note = new TodoListApp.Models.Note(1);
            var expectedValue = "This is a title";
            note.Title = expectedValue;
            Assert.Equal(note.Title, expectedValue);
        }
        [Fact]
        public void Property_Text_Should_Be_Assignable_And_Readable()
        {
            var note = new TodoListApp.Models.Note(1);
            var expectedValue = "This is a text";
            note.Text = expectedValue;
            Assert.Equal(note.Text, expectedValue);
        }
        [Fact]
        public void Property_Location_Should_Be_Assignable_And_Readable()
        {
            var note = new TodoListApp.Models.Note(1);
            var expectedValue = new Location(120, 230).ToString();
            note.Location = expectedValue;
            Assert.Equal(note.Location, expectedValue);
        }
    }
}