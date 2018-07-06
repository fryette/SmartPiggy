using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace SmartPiggy.Core.ViewModels
{
	public class ViewModelLocator
	{
		/// <summary>
		/// The key used by the NavigationService to go to the second page.
		/// </summary>
		public const string SecondPageKey = "SecondPage";

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
		}

		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}
