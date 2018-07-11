using System.Collections.Generic;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SmartPiggy.Core.Interfaces;

namespace SmartPiggy.Core.ViewModels
{
	public class ViewModelLocator
	{
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

	public enum PageKeys
	{
		MAIN_PAGE,
		CREATE_AIM_PAGE
	}
}
