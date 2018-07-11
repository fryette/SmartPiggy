using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.Extensions;
using SmartPiggy.Core.Interfaces;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core.ViewModels
{
	public class CreateAimViewModel : ViewModelBase
	{
		public ErrorDetails Error { get; private set; }

		public RelayCommand SaveCommand { get; }

		public DateTime? FinalDate { get; set; }

		public DateTime? StartDate { get; set; }

		public double FinalBalance { get; set; }

		public double CurrentBalance { get; set; }

		public string Name { get; set; }

		public CreateAimViewModel(INavigationService navigation, IAimManager manager)
		{
			SaveCommand = new RelayCommand(async () =>
			{
				var errorDetails = IsAimFilledCorrectly();

				if (errorDetails == null)
				{
					await manager.SaveChangesAsync(new AimModel
					{
						Name = Name,
						CurrentBalance = CurrentBalance,
						FinalBalance = FinalBalance,
						FinalDate = FinalDate.Value,
						StartDate = StartDate.Value,
					});

					navigation.NavigateTo(PageKeys.MAIN_PAGE);
				}
				else
				{
					Error = errorDetails;
				}
			});
		}

		private ErrorDetails IsAimFilledCorrectly()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return new ErrorDetails("Name issue", "Please enter name");
			}

			if (CurrentBalance >= FinalBalance)
			{
				return new ErrorDetails("Balance issue", "Current balance should be less than your aim, please recheck");
			}

			if (CurrentBalance < 0)
			{
				return new ErrorDetails("Current balance issue", "Current balance should be greater than 0 ");
			}

			if (FinalBalance < 0)
			{
				return new ErrorDetails("Final balance issue", "Final balance should be greater than 0 ");
			}

			if (StartDate == null)
			{
				return new ErrorDetails("Start date issue", "Please enter start date");
			}

			if (FinalDate == null)
			{
				return new ErrorDetails("Final date issue", "Please enter final date");
			}

			if (StartDate > FinalDate)
			{
				return new ErrorDetails("Date issue", "Please enter valid start and end dates. Final date should be greater than start date.");
			}

			return null;
		}
	}
}