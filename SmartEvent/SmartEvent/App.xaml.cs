using SmartEvent.View;
using System;
using System.IO;
using SmartEvent.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MasterMainPage());
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Cook.Logged = false;
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
