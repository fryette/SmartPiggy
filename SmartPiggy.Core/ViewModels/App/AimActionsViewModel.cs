using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SmartPiggy.Core.Interfaces;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core.ViewModels.App
{
	public class AimActionsViewModel : ViewModelBase
	{
		private readonly IAimManager _aimManager;

		public AimActionsViewModel(IAimManager aimManager)
		{
			_aimManager = aimManager;
		}

		public async Task RemoveAimAsync(AimModel model)
		{
			await _aimManager.RemoveAim(model);
		}
	}
}
