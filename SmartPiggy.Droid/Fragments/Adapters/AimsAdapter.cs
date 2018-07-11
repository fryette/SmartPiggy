using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.Views;
using Android.Widget;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Droid.Fragments.Adapters
{
	public class AimsAdapter : BaseAdapter<AimModel>
	{
		private readonly List<AimModel> _items;
		private readonly Activity _context;
		public AimsAdapter(Activity context, List<AimModel> items)
		{
			_context = context;
			_items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}

		public override AimModel this[int position] => _items[position];

		public override int Count => _items.Count;

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = _items[position];
			var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.aim_list_item, null);

			var entries = new[]
			{
				new Entry((float)item.CurrentBalance)
				{
					Label = "Done",
					ValueLabel = "60",
					Color = SKColor.Parse("#005800"),
				},
				new Entry((float)item.FinalBalance)
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

			view.FindViewById<TextView>(Resource.Id.persentage).Text = (item.CurrentBalance * 100 / item.FinalBalance).ToString(CultureInfo.InvariantCulture);
			view.FindViewById<ChartView>(Resource.Id.chartView).Chart = chart;
			view.FindViewById<TextView>(Resource.Id.header).Text = item.Name;
			return view;
		}
	}
}
