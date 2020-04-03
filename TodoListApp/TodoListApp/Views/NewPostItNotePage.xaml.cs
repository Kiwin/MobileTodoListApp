using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoListApp.Models;

namespace TodoListApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewPostItNotePage : ContentPage
    {
        public PostItNote Item { get; set; }

        public NewPostItNotePage()
        {
            InitializeComponent();

            Item = new PostItNote
            {
                Title = "Item name",
                Text = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Location_Clicked(object sender, EventArgs e)
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