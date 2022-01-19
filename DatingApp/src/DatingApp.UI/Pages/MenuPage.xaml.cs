using DatingApp.Core.ViewModels.Menu;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace DatingApp.UI.Pages
{
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "Menu")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}
