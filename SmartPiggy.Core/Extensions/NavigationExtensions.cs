using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.ViewModels;

namespace SmartPiggy.Core.Extensions
{
	public static class NavigationExtensions
	{
		public static void NavigateTo(this INavigationService navigation, PageKeys key)
		{
			navigation.NavigateTo(key.ToString());
		}
	}
}
