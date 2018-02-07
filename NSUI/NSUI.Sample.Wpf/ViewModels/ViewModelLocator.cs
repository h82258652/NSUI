using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;

namespace NSUI.Sample.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<HomeViewModel>();

            return containerBuilder.Build();
        }
    }
}