using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Users.Models;
using Users.Services;
using Users.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Users.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        #region Properties
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users { get => _users; set { _users = value; RaisePropertyChanged(nameof(Users)); } }

        private bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing; set { _isRefreshing = value; RaisePropertyChanged(nameof(IsRefreshing)); } }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
        private bool IsDataLoaded { get; set; }

        #endregion

        #region Commands
        public ICommand LoadNextPageCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand ItemSelectedCommand { get; }
        #endregion

        private readonly IUserService _userService;
        public UsersViewModel(IUserService userService)
        {
            LoadDataCommand = new Command(LoadDataAsync);
            LoadNextPageCommand = new Command(LoadNextPageAsync);
            ItemSelectedCommand = new Command<User>(OnItemSelectedAsync);
            Users = new ObservableCollection<User>();
            _userService = userService;
        }

        #region Commands Impl
        private async void OnItemSelectedAsync(User user)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new UserDetailsView(user));
        }

        private async void LoadNextPageAsync(object obj)
        {
            if (!CanLoadMore())
            { return; }

            var pagedResponse = await GetPageAsync();
            pagedResponse.ForEach(user => Users.Add(user));
        }

        private async void LoadDataAsync(object obj)
        {
            var pagedResponse = await GetPageAsync();
            Users = new ObservableCollection<User>(pagedResponse);
        }
        private async Task<IEnumerable<User>> GetPageAsync()
        {
            var pagedResponse = await _userService.GetAllUsers(TotalCount / 6, 6, CancellationToken.None);
            TotalCount = pagedResponse.Total;
            IsRefreshing = false;
            return pagedResponse.Data;
        }

        private bool CanLoadMore()
        {
            return Users.Count < TotalCount;
        }

        protected override async Task InitialiseAsync()
        {
            if (!IsDataLoaded)
            {
                LoadDataCommand.Execute(null);
                IsDataLoaded = true;
            }
        }
        #endregion
    }
}
