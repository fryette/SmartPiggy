using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Core
{
	public class AimManager
	{
		private readonly IStorage _storage;
		private const string PURSES_STRING = "PURSES";
		public AimManager(IStorage storage)
		{
			_storage = storage;
		}

		public Task<IEnumerable<Aim>> LoadAimsAsync()
		{
			return _storage.GetAllAsync<Aim>(PURSES_STRING);
		}

		public Task RemoveAim(Aim aim)
		{
			return _storage.DeleteAsync(PURSES_STRING, aim.Name);
		}

		public Task SaveChanges(Aim aim)
		{
			return _storage.SaveAsync(PURSES_STRING, aim.Name, aim);
		}

		public double GetPeriodMoney(Aim aim)
		{
			var needToCollect = aim.FinalBalance - aim.CurrentBalance;
			var period = aim.FinalDate - aim.StartDate;
			var totalWeeks = period.TotalDays / aim.DayPeriod;

			var everyWeekMoneyNeed = needToCollect / totalWeeks;

			return everyWeekMoneyNeed;
		}

		public List<DateTime> CalculateIdealTimePoints(Aim aim)
		{
			var result = new List<DateTime>();
			for (var date = aim.StartDate; date < aim.FinalDate;)
			{
				result.Add(date);
				date = date.AddDays(aim.DayPeriod);
			}

			return result;
		}

		public List<KeyValuePair<DateTime, double>> CalculateActualTimePoints(Aim aim)
		{
			var result = new List<KeyValuePair<DateTime, double>>();

			var startDate = aim.StartDate;

			if (aim.History.Any())
			{
				startDate = aim.History.Last().Key;
				result.AddRange(aim.History);
			}

			for (var date = startDate; date < aim.FinalDate;)
			{
				result.Add(new KeyValuePair<DateTime, double>(date, aim.DayPeriod));
				date = date.AddDays(aim.DayPeriod);
			}

			return result;
		}
	}
}
