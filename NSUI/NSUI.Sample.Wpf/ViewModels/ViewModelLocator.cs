using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using NSUI.Sample.Services;
using NSUI.Sample.Views;

namespace NSUI.Sample.ViewModels
{
    public class ViewModelLocator
    {
        public const string UserProfileViewKey = "UserProfile";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();

        public UserProfileViewModel UserProfile => ServiceLocator.Current.GetInstance<UserProfileViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterInstance(CreateNavigationService());

            containerBuilder.RegisterType<HomeViewModel>();
            containerBuilder.RegisterType<UserProfileViewModel>();

            return containerBuilder.Build();
        }

        private static AppNavigationService CreateNavigationService()
        {
            var navigationService = new AppNavigationService();
            navigationService.Config(UserProfileViewKey, typeof(UserProfileView));
            return navigationService;
        }
    }
}