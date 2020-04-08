using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoListApp.Services;
using TodoListApp.Models;
using TodoListApp.Views;

namespace TodoListApp
{
    public partial class App : Application
    {
        public static string SQLITE_DB_FILE_PATH;

        public App(string sqliteDbFilePath)
        {
            SQLITE_DB_FILE_PATH = sqliteDbFilePath;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DependencyService.Register<IdentifiablesDataStore<Note>>();
            MainPage = new NotesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
