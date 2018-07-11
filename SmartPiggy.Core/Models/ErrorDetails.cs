namespace SmartPiggy.Core.Models
{
	public class ErrorDetails
	{
		public string ErrorTitle { get; }
		public string ErrorDescription { get; }

		public ErrorDetails(string errorTitle, string errorDescription)
		{
			ErrorTitle = errorTitle;
			ErrorDescription = errorDescription;
		}
	}
}
