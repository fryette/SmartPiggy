using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.Interfaces;
using SmartPiggy.Core.ViewModels;

namespace SmartPiggy.Droid
{
	public static class App
	{
		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get
			{
				if (_locator != null)
				{
					return _locator;
				}

				// Initialize the MVVM Light DispatcherHelper.
				// This needs to be called on the UI thread.
				DispatcherHelper.Initialize();

				// Configure and register the MVVM Light NavigationService
				var nav = new NavigationService();
				SimpleIoc.Default.Register<INavigationService>(() => nav);

				SimpleIoc.Default.Register<IStorage, Storage>();

				nav.Configure(PageKeys.MAIN_PAGE.ToString(), typeof(MainActivity));
				nav.Configure(PageKeys.CREATE_AIM_PAGE.ToString(), typeof(CreateAimActivity));

				_locator = new ViewModelLocator();

				return _locator;
			}
		}
	}
}