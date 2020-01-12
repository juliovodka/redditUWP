using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using RedditUWP.Services;
using System.Diagnostics.CodeAnalysis;
using Windows.UI.Xaml;

namespace RedditUWP.ViewModels
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
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            SimpleIoc.Default.Register<IRedditService, RedditService>();

            SimpleIoc.Default.Register<StartViewModel>();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
            else
            {
                if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                {
                    var navigationService = new NavigationService();
                    SimpleIoc.Default.Register<INavigationService>(() => navigationService);
                }
            }
        }

        public static ViewModelLocator Instance
        {
            get { return Application.Current.Resources["Locator"] as ViewModelLocator; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public StartViewModel StartInstance
        {
            get { return SimpleIoc.Default.GetInstance<StartViewModel>(); }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

}