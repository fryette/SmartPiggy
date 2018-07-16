using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.ViewModels.App;

namespace SmartPiggy.Core.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		public readonly AimActionsViewModel AimActionsViewModel;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(INavigationService navigationService, AimActionsViewModel aimActionsViewModel)
		{
			_navigationService = navigationService;
			AimActionsViewModel = aimActionsViewModel;
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