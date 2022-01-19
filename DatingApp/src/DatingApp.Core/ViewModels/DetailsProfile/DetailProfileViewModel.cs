using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Core.Models;
using DatingApp.Core.Providers;
using DatingApp.Core.ViewModels.MeetLove;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace DatingApp.Core.ViewModels.DetailsProfile
{
    public class DetailProfileViewModel : BaseViewModel<UserViewModel>
    {
        #region Fields

        private readonly IMvxNavigationService _navigationService;
        private readonly IHobbiesProvider _hobbiesProvider;

        #endregion

        #region Properties

        private UserViewModel _userDetails;
        public UserViewModel UserDetails
        {
            get => _userDetails;
            set
            {
                _userDetails = value;
                RaisePropertyChanged(() => UserDetails);
            }
        }

        private List<Hobby> _hobbies;
        public List<Hobby> Hobbies
        {
            get => _hobbies;
            set
            {
                _hobbies = value;
                RaisePropertyChanged(() => Hobbies);
            }
        }

        #endregion

        #region Commands

        public IMvxCommand BackCommand => new MvxAsyncCommand(BackAsync);

        #endregion

        public DetailProfileViewModel(IMvxNavigationService navigationService, IHobbiesProvider hobbiesProvider)
        {
            _navigationService = navigationService;
            _hobbiesProvider = hobbiesProvider;
        }

        public override void Prepare(UserViewModel userDetailsParameter)
        {
            _userDetails = userDetailsParameter;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            UserDetails = _userDetails;
            Hobbies = InitialHobbies();
        }

        private async Task BackAsync()
        {
            await _navigationService.Close(this);
        }

        private List<Hobby> InitialHobbies()
        {
            var hobbies = _hobbiesProvider.GetHobbies();

            return new List<Hobby>(hobbies);
        }
    }
}
