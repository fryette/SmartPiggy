using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core.Interfaces
{
	public interface IAimManager
	{
		List<KeyValuePair<DateTime, double>> CalculateActualTimePoints(AimModel aimModel);
		List<DateTime> CalculateIdealTimePoints(AimModel aimModel);
		double GetPeriodMoney(AimModel aimModel);
		Task<IEnumerable<AimModel>> LoadAimsAsync();
		Task RemoveAim(AimModel aimModel);
		Task SaveChangesAsync(AimModel aimModel);
	}
}