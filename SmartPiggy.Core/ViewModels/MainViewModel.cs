using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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

			NavigateCommand =
				new RelayCommand(() => _navigationService.NavigateTo(ViewModelLocator.CREATE_AIM_PAGE_KEY));
		}

		public void NavigateToCreateAimPage()
		{
			_navigationService.NavigateTo(ViewModelLocator.CREATE_AIM_PAGE_KEY);
		}

		/// <summary>
		/// Gets the NavigateCommand.
		/// Goes to the second page, using the navigation service.
		/// Use the "mvvmr*" snippet group to create more such commands.
		/// </summary>
		public RelayCommand NavigateCommand { get; }
	}
}