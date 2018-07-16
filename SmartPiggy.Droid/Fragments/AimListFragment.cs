using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using SmartPiggy.Core;
using SmartPiggy.Core.ViewModels;
using SmartPiggy.Droid.Fragments.Adapters;

namespace SmartPiggy.Droid.Fragments
{
	public class AimListFragment : Fragment
	{
		private MainViewModel _viewModel;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public static AimListFragment NewInstance()
		{
			var frag3 = new AimListFragment { Arguments = new Bundle() };
			return frag3;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			_viewModel = App.Locator.Main;

			var fragment = inflater.Inflate(Resource.Layout.aim_list_fragment, null);

			var listview = fragment.FindViewById<ListView>(Resource.Id.aims);

			Task.Factory.StartNew(
				async () =>
				{
					var purseManager = new AimManager(new Storage());
					var aims = await purseManager.LoadAimsAsync();

					Activity.RunOnUiThread(
						() =>
						{
							listview.Adapter = new AimsAdapter(Activity, aims.ToList(), CreateDialog());
						});
				});

			listview.ItemClick += delegate
			{
				_viewModel.NavigateToCreateAimPage();
				//Toast.MakeText(Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
			};

			return fragment;
		}

		private AlertDialog CreateDialog()
		{
			var builder = new AlertDialog.Builder(View.Context);

			builder.SetItems(new[] { "REMOVE" }, HandleDialogClick);
			return builder.Create();
		}

		private void HandleDialogClick(object sender, DialogClickEventArgs e)
		{
			if (e.Which == 0)
			{
				//_viewModel.AimActionsViewModel.RemoveAimAsync()
			}
		}
	}
}