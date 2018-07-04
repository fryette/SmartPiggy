using System;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using SmartPiggy.Core;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Droid.Fragments
{
	public class Fragment1 : Fragment
	{
		private EditText _dateEditControl;
		private EditText _purseName;
		private EditText _initialBalance;
		private EditText _finalBalance;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			// Create your fragment here
		}

		public static Fragment1 NewInstance()
		{
			var frag1 = new Fragment1 { Arguments = new Bundle() };
			return frag1;
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.fragment1, null);

			_dateEditControl = view.FindViewById<EditText>(Resource.Id.date);
			var saveButton = view.FindViewById<Button>(Resource.Id.saveButton);
			_purseName = view.FindViewById<EditText>(Resource.Id.purseName);
			_initialBalance = view.FindViewById<EditText>(Resource.Id.initialBalance);
			_finalBalance = view.FindViewById<EditText>(Resource.Id.finalBalance);

			_dateEditControl.Click += OnChooseDateClick;
			saveButton.Click += OnSaveButtonClick;

			return view;
		}

		private async void OnSaveButtonClick(object sender, EventArgs e)
		{
			var purse = new Purse
			{
				Aim = double.Parse(_finalBalance.Text),
				Current = double.Parse(_initialBalance.Text),
				Name = _purseName.Text
			};

			var purseManager = new PurseManager(new Storage());

			await purseManager.SaveChanges(purse);
			var purses = await purseManager.LoadPursesAsync();
		}

		public void OnChooseDateClick(object sender, EventArgs eventArgs)
		{
			var textControl = sender as EditText;

			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				textControl.Text = time.ToLongDateString();
			});

			frag.Show(Activity.FragmentManager, frag.TAG);
		}
	}
}