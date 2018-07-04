namespace SmartPiggy.Core.Models
{
	public class Purse
	{
		public double Current { get; set; }
		public double Aim { get; set; }
		public string Name { get; set; }
		public void Add(double value)
		{
			Current += value;
		}

		public void Remove(double value)
		{
			Current -= value;
		}

		public void ChangeAim(double newAim)
		{
			Aim = newAim;
		}
	}
}
