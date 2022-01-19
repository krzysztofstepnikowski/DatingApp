using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Core.Api;
using DatingApp.Core.ViewModels.DetailsProfile;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;

namespace DatingApp.Core.ViewModels.MeetLove
{
    public class MeetLoveViewModel : BaseViewModel
    {
        #region Fields

        private readonly IApiService _apiService;
        private readonly IMvxNavigationService _navigationService;

        #endregion

        #region Properties

        private List<UserViewModel> _users = new List<UserViewModel>();
        public List<UserViewModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        private List<string> _avatars;
        public List<string> Avatars
        {
            get => _avatars;
            set
            {
                _avatars = value;
                RaisePropertyChanged(() => Avatars);
            }
        }

        private LayoutState _currentState;
        public LayoutState CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                RaisePropertyChanged(() => CurrentState);
            }
        }

        public MvxNotifyTask LoadUsersTask { get; private set; }

        #endregion

        #region Commands

        private IMvxCommand _openProfileCommand;
        public IMvxCommand OpenProfileCommand => _openProfileCommand ?? (_openProfileCommand = new MvxAsyncCommand<UserViewModel>(OpenProfileAsync));

        #endregion

        public MeetLoveViewModel(IApiService apiService, IMvxNavigationService navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadUsersTask = MvxNotifyTask.Create(LoadUsersAsync);

            return Task.FromResult(0);
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                CurrentState = LayoutState.Loading;
                var users = await _apiService.GetUsers(2);

                if (users != null)
                {
                    var usersVm = users.Data.Select(user => new UserViewModel(user)
                    {
                        OpenProfileCommand = OpenProfileCommand
                    }).ToList();

                    // Increased users count
                    Users.AddRange(usersVm);
                    Users.AddRange(usersVm);
                    Users.AddRange(usersVm);

                    Avatars = Users.Select(x => x.ImageUrl).ToList();
                }
            }
            catch(Exception)
            {
                CurrentState = LayoutState.Error;
            }

            finally
            {
                CurrentState = LayoutState.None;
            }
        }

        private async Task OpenProfileAsync(UserViewModel obj)
        {
            await _navigationService.Navigate<DetailProfileViewModel, UserViewModel>(obj);
        }
    }
}
