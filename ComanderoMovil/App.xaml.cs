using System;
using ComanderoMovil.Data;
using ComanderoMovil.Services;
using ComanderoMovil.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComanderoMovil
{
    public partial class App : Application
    {
        private static DataManager dataManager;

        public static DataManager DataManager
        {
            get
            {
                if(dataManager == null)
                {
                    dataManager = new DataManager(DependencyService.Get<IFileHelper>().GetLocalFilePath("menudata.db3"));
                }

                return dataManager;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
