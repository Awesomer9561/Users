using System;
using Users.Views;
using Users.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Users.ViewModels;

namespace Users
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            try
            {
                ViewModelLocator.Initialize();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                MainPage = new UsersView();
            }
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
