using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Universidad
{
    public partial class App : Application
    {
        public static string RUTA_BD;
        public App(string ruta_bd)
        {
            InitializeComponent();

            MainPage = new NavigationPage((new MainPage()));
            RUTA_BD = ruta_bd;
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
