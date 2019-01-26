/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPF_ExampleApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MahApps.Metro.Controls.Dialogs;
using WPF_ExampleApp.ServiceInterfaces;
using WPF_ExampleApp.MockServices;
using WPF_ExampleApp.Services;

namespace WPF_ExampleApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            bool mockAnimalSound = false;

            if (mockAnimalSound)
            {
                SimpleIoc.Default.Register<IAnimalSoundService, AnimalSoundServiceMock>();
            }
            else
            {
                SimpleIoc.Default.Register<IAnimalSoundService, AnimalSoundService>();
            }

            if (ViewModelBase.IsInDesignModeStatic)
            {
                return;
            }    

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDialogCoordinator, DialogCoordinator>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PageOneViewModel>();
            SimpleIoc.Default.Register<PageTwoViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PageOneViewModel PageOne
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PageOneViewModel>();
            }
        }

        public PageTwoViewModel PageTwo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PageTwoViewModel>();
            }
        }
    }
}