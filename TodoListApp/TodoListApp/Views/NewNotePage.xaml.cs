using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoListApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewNotePage : ContentPage
    {
        static int noteCreatedCount = 0;
        public Models.Note Item { get; set; }

        public NewNotePage()
        {

            Item = new Models.Note(noteCreatedCount++)
            {
                Title = "Item name",
                Text = "This is an item description."

            };

            BindingContext = this;
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void Location_Clicked(object sender, EventArgs e)
        {
            var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            if (location != null)
            {
                Item.Location = location.ToString();
                Console.WriteLine(Item.Location);
            }

        }
    }
}