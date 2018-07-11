using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core;
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
				if (_locator == null)
				{
					// Initialize the MVVM Light DispatcherHelper.
					// This needs to be called on the UI thread.
					DispatcherHelper.Initialize();

					// Configure and register the MVVM Light NavigationService
					var nav = new NavigationService();
					SimpleIoc.Default.Register<INavigationService>(() => nav);

					SimpleIoc.Default.Register<IStorage, Storage>();

					nav.Configure(ViewModelLocator.CREATE_AIM_PAGE_KEY, typeof(CreateAimActivity));
					nav.Configure(ViewModelLocator.MAIN_PAGE_KEY, typeof(MainActivity));

					_locator = new ViewModelLocator();
				}

				return _locator;
			}
		}
	}
}