using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartPiggy.Core.Interfaces;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core
{
	public class AimManager : IAimManager
	{
		private readonly IStorage _storage;
		private const string PURSES_STRING = "PURSES";
		public AimManager(IStorage storage)
		{
			_storage = storage;
		}

		public Task<IEnumerable<AimModel>> LoadAimsAsync()
		{
			return _storage.GetAllAsync<AimModel>(PURSES_STRING);
		}

		public Task RemoveAim(AimModel aimModel)
		{
			return _storage.DeleteAsync(PURSES_STRING, aimModel.Name);
		}

		public Task SaveChangesAsync(AimModel aimModel)
		{
			return _storage.SaveAsync(PURSES_STRING, aimModel.Name, aimModel);
		}

		public double GetPeriodMoney(AimModel aimModel)
		{
			var needToCollect = aimModel.FinalBalance - aimModel.CurrentBalance;
			var period = aimModel.FinalDate - aimModel.StartDate;
			var totalWeeks = period.TotalDays / aimModel.DayPeriod;

			var everyWeekMoneyNeed = needToCollect / totalWeeks;

			return everyWeekMoneyNeed;
		}

		public List<DateTime> CalculateIdealTimePoints(AimModel aimModel)
		{
			var result = new List<DateTime>();
			for (var date = aimModel.StartDate; date < aimModel.FinalDate;)
			{
				result.Add(date);
				date = date.AddDays(aimModel.DayPeriod);
			}

			return result;
		}

		public List<KeyValuePair<DateTime, double>> CalculateActualTimePoints(AimModel aimModel)
		{
			var result = new List<KeyValuePair<DateTime, double>>();

			var startDate = aimModel.StartDate;

			if (aimModel.History.Any())
			{
				startDate = aimModel.History.Last().Key;
				result.AddRange(aimModel.History);
			}

			for (var date = startDate; date < aimModel.FinalDate;)
			{
				result.Add(new KeyValuePair<DateTime, double>(date, aimModel.DayPeriod));
				date = date.AddDays(aimModel.DayPeriod);
			}

			return result;
		}
	}
}
