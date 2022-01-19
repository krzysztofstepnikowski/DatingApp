using DatingApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace DatingApp.Core.ViewModels.MeetLove
{
    public class UserViewModel : MvxViewModel
    {
        #region Fields

        private readonly User _user;

        #endregion
        
        #region Properties

        public string Name => $"{_user.FirstName} {_user.LastName}";
        public string ImageUrl => _user.Avatar;

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                _isFavorite = value;
                RaisePropertyChanged(() => IsFavorite);
            }
        }

        #endregion

        #region Commands

        public IMvxCommand OpenProfileCommand { get; set; }

        #endregion

        #region Constructor(s)

        public UserViewModel(User user)
        {
            _user = user;
        }

        #endregion
    }
}
