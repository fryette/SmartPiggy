using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using SmartPiggy.Core;
using SmartPiggy.Droid.Fragments.Adapters;

namespace SmartPiggy.Droid.Fragments
{
	public class Fragment3 : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public static Fragment3 NewInstance()
		{
			var frag3 = new Fragment3 { Arguments = new Bundle() };
			return frag3;
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);
			var fragment = inflater.Inflate(Resource.Layout.fragment3, null);


			var listview = fragment.FindViewById<ListView>(Resource.Id.aims);

			Task.Factory.StartNew(
				async () =>
				{
					var purseManager = new AimManager(new Storage());
					var aims = await purseManager.LoadAimsAsync();

					Activity.RunOnUiThread(
						() =>
						{
							listview.Adapter = new AimsAdapter(Activity, aims.ToList());
						});
				});

			listview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
			{
				Toast.MakeText(Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
			};

			return fragment;
		}
	}
}