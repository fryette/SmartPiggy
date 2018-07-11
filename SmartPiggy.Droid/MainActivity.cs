using Android.App;
using Android.OS;
using SmartPiggy.Droid.Fragments;
using Android.Support.Design.Widget;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace SmartPiggy.Droid
{
	[Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon")]
	public class MainActivity : ActivityBase
	{
		BottomNavigationView _bottomNavigation;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.main);
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			if (toolbar != null)
			{
				SetActionBar(toolbar);
				ActionBar.SetDisplayHomeAsUpEnabled(false);
				ActionBar.SetHomeButtonEnabled(false);
			}

			_bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
			_bottomNavigation.NavigationItemSelected += OnBottomNavigationItemSelected;

			LoadFragment(Resource.Id.menu_home);
		}

		private void OnBottomNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
		{
			LoadFragment(e.Item.ItemId);
		}

		private void LoadFragment(int id)
		{
			Fragment fragment = null;
			switch (id)
			{
				case Resource.Id.menu_home:
					fragment = AimListFragment.NewInstance();
					break;
				case Resource.Id.menu_audio:
					fragment = Fragment2.NewInstance();
					break;
				case Resource.Id.menu_video:
					break;
				default:
					break;
			}
			if (fragment == null)
				return;

			FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment)
				.Commit();
		}
	}
}

