using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoListApp.Models;
using TodoListApp.Views;
using TodoListApp.ViewModels;

namespace TodoListApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NotesPage : ContentPage
    {
        readonly NotesModelView viewModel;

        public NotesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NotesModelView();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Note)layout.BindingContext;
            await Navigation.PushAsync(new NoteDetailPane(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewNotePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Notes.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}