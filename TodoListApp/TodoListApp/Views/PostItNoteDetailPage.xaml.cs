﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoListApp.Models;
using TodoListApp.ViewModels;

namespace TodoListApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new PostItNote
            {
                Title = "Item 1",
                Text = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("Note Deletion", "Are you sure you want to delete this note PERMANENTLY?", "Yes", "No");
            if (answer) { 
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
            await Navigation.PopAsync();
            }
        }
    }
}