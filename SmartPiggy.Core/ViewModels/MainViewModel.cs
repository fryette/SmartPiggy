using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.Extensions;
using SmartPiggy.Core.Interfaces;

namespace SmartPiggy.Core.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void NavigateToCreateAimPage()
		{
			_navigationService.NavigateTo(PageKeys.CREATE_AIM_PAGE.ToString());
		}

		/// <summary>
		/// Gets the NavigateCommand.
		/// Goes to the second page, using the navigation service.
		/// Use the "mvvmr*" snippet group to create more such commands.
		/// </summary>
		public RelayCommand NavigateCommand { get; }
	}
}