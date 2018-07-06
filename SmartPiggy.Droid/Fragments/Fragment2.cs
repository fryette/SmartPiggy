using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using SmartPiggy.Core;

namespace SmartPiggy.Droid.Fragments
{
	public class Fragment2 : Fragment
	{
		private ChartView _chartView;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public static Fragment2 NewInstance()
		{
			var frag2 = new Fragment2 { Arguments = new Bundle() };
			return frag2;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			var fragment = inflater.Inflate(Resource.Layout.fragment2, null);
			_chartView = fragment.FindViewById<ChartView>(Resource.Id.chartView);

			SetupChart();

			return fragment;
		}

		private void SetupChart()
		{
			var entries = new[]
			{
				new Entry(60)
				{
					Label = "Done",
					ValueLabel = "60",
					Color = SKColor.Parse("#005800"),
				},
				new Entry(40)
				{
					Label = "Lost",
					ValueLabel = "40",
					Color = SKColor.Parse("#8B0000")
				}
			};

			var chart = new DonutChart()
			{
				Entries = entries,
				BackgroundColor = SKColors.Transparent,
				LabelTextSize = 50
			};

			_chartView.Chart = chart;
		}
	}
}