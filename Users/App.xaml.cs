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

        protected override async void OnStart()
        {

            var serializedCounter = Xamarin.Essentials.Preferences.Get("counter", "");
            int.TryParse(serializedCounter, out int value);
            await Current.MainPage.DisplayAlert("", $"App has been opened {value} times", "Ok");
            Xamarin.Essentials.Preferences.Set("counter", (++value).ToString());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
