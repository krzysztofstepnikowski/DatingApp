using System;
using System.Collections.ObjectModel;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace DatingApp.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        #region Properties;

        private ObservableCollection<string> _menuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }

        #endregion

        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<string>();
        }
    }
}
