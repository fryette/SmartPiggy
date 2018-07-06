using System;
using System.Collections.Generic;

namespace SmartPiggy.Core.Models
{
	public class Aim
	{
		public double CurrentBalance { get; set; }
		public double FinalBalance { get; set; }
		public int DayPeriod = 7;
		public string Name { get; set; }
		public DateTime FinalDate { get; set; }
		public DateTime StartDate { get; set; }
		public List<KeyValuePair<DateTime, double>> History { get; set; }

		public void Add(double value)
		{
			CurrentBalance += value;
		}

		public void Remove(double value)
		{
			CurrentBalance -= value;
		}

		public void ChangeAim(double newAim)
		{
			FinalBalance = newAim;
		}
	}
}
