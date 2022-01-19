using FFImageLoading.Svg.Forms;
using UIKit;

namespace DatingApp.iOS
{
    public static class Application
    {
        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, nameof(AppDelegate));
            var ignore = typeof(SvgCachedImage);
        }
    }
}
