using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Users.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Users.ViewModels
{
    public class UserDetailsViewModel : BaseViewModel
    {
        private User _user;
        public User User { get => _user; set { _user = value; RaisePropertyChanged(nameof(User)); }}

        public ICommand EmailUserCommand { get; }
        public ICommand CloseCommand { get; }
        public UserDetailsViewModel()
        {
            EmailUserCommand = new Command(EmailUser);
            CloseCommand = new Command(Close);
        }

        private void Close(object obj)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private void EmailUser(object obj)
        {
            Email.ComposeAsync(new EmailMessage("Hi", "Coming from within the app", new string[] { User.Email }));
        }
    }
}
