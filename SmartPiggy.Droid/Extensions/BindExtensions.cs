using System;
using GalaSoft.MvvmLight.Helpers;

namespace SmartPiggy.Droid.Extensions
{
	public static class BindExtensions
	{
		public static Binding ConvertSourceToDouble(this Binding<string, double> binding)
		{
			return binding.ConvertSourceToTarget(arg =>
			{
				double.TryParse(arg, out var result);
				return result;
			});
		}

		public static Binding ConvertSourceToDateTime(this Binding<string, DateTime?> binding)
		{
			return binding.ConvertSourceToTarget(arg =>
			{
				DateTime.TryParse(arg, out var result);
				return result;
			});
		}
	}
}