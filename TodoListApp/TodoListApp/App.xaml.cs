using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoListApp.Services;
using TodoListApp.Views;
using TodoListApp.Models;

namespace TodoListApp
{
    public partial class App : Application
    {
        public static readonly string SQLITE_DB_FILE_PATH;
        public App()
        {
            InitializeComponent();
            Initialize();

        }

        public App(string sqliteDbFilePath)
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DependencyService.Register<IdentifiablesDataStore<PostItNote>>();
            MainPage = new MainPage();
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
