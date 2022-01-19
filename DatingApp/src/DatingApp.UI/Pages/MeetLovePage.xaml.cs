using DatingApp.Core.ViewModels.MeetLove;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Threading.Tasks;

namespace DatingApp.UI.Pages
{
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Main Page")]
    public partial class MeetLovePage : MvxContentPage<MeetLoveViewModel>
    {
        public MeetLovePage()
        {
            InitializeComponent();
        }

        private void CloseTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            SwipeCardView.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left);
        }

        private void StarTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            SwipeCardView.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
        }

        private async void LikeTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var currentUser = (UserViewModel)SwipeCardView.TopItem;

            currentUser.IsFavorite = true;

            await Task.Delay(2000);

            currentUser.IsFavorite = false;
        }
    }
}
