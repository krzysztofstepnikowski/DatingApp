using MvvmCross.IoC;
using MvvmCross.ViewModels;
using DatingApp.Core.ViewModels.Home;
using MvvmCross;
using DatingApp.Core.Api;
using Refit;
using DatingApp.Core.Constants;
using DatingApp.Core.Providers;

namespace DatingApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IApiService>(() => RestService.For<IApiService>(Urls.ApiUrl));
            Mvx.IoCProvider.RegisterSingleton<IHobbiesProvider>(() => new HobbiesProvider());
            RegisterAppStart<MasterDetailViewModel>();
        }
    }
}
