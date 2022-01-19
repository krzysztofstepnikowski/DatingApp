using DatingApp.Core.ViewModels.MeetLove;
using DatingApp.Core.ViewModels.Menu;
using MvvmCross.Navigation;

namespace DatingApp.Core.ViewModels.Home
{
    public class MasterDetailViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MasterDetailViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            await _navigationService.Navigate<MenuViewModel>();
            await _navigationService.Navigate<MeetLoveViewModel>();
        }
    }
}
