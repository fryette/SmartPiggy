using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace SmartPiggy.Core.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private string _welcomeTitle;
		private RelayCommand _navigateCommand;
		private readonly INavigationService _navigationService;

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			WelcomeTitle = "Home Page";
		}

		public string WelcomeTitle
		{
			get => _welcomeTitle;
			set => Set(ref _welcomeTitle, value);
		}

		/// <summary>
		/// Gets the NavigateCommand.
		/// Goes to the second page, using the navigation service.
		/// Use the "mvvmr*" snippet group to create more such commands.
		/// </summary>
		public RelayCommand NavigateCommand
		{
			get
			{
				return _navigateCommand ?? (_navigateCommand =
					       new RelayCommand(() => _navigationService.NavigateTo(ViewModelLocator.SecondPageKey)));
			}
		}
	}
}