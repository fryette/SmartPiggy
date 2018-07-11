using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SmartPiggy.Core.Interfaces;

namespace SmartPiggy.Core.ViewModels
{
	public class ViewModelLocator
	{
		public const string CREATE_AIM_PAGE_KEY = "CreateAimPage";
		public const string MAIN_PAGE_KEY = "MainPageKey";

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<CreateAimViewModel>();

			SimpleIoc.Default.Register<IAimManager, AimManager>();
		}

		public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
		public CreateAimViewModel CreateAim => ServiceLocator.Current.GetInstance<CreateAimViewModel>();

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}
