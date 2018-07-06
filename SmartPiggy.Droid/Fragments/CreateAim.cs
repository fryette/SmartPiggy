using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using SmartPiggy.Core;
using SmartPiggy.Core.Models;

namespace SmartPiggy.Droid.Fragments
{
	public class CreateAim : Fragment
	{
		private EditText _startDateEditControl;
		private EditText _purseName;
		private EditText _initialBalance;
		private EditText _finalBalance;
		private EditText _endDateEditControl;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			// Create your fragment here
		}

		public static CreateAim NewInstance()
		{
			var frag1 = new CreateAim { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.CreateAim, null);

			_startDateEditControl = view.FindViewById<EditText>(Resource.Id.date);
			_endDateEditControl = view.FindViewById<EditText>(Resource.Id.endDate);
			var saveButton = view.FindViewById<Button>(Resource.Id.saveButton);
			_purseName = view.FindViewById<EditText>(Resource.Id.aimName);
			_initialBalance = view.FindViewById<EditText>(Resource.Id.initialBalance);
			_finalBalance = view.FindViewById<EditText>(Resource.Id.finalBalance);

			_startDateEditControl.Click += OnChooseStartDateClick;
			_endDateEditControl.Click += OnChooseStartDateClick;
			saveButton.Click += OnSaveButtonClick;

			return view;
		}

		private async void OnSaveButtonClick(object sender, EventArgs e)
		{
			var purse = new Aim
			{
				Name = _purseName.Text,
				FinalBalance = double.Parse(_finalBalance.Text),
				CurrentBalance = double.Parse(_initialBalance.Text),
				StartDate = DateTime.Parse(_startDateEditControl.Text),
				FinalDate = DateTime.Parse(_endDateEditControl.Text)
			};

			var purseManager = new AimManager(new Storage());

			await purseManager.SaveChanges(purse);
			var purses = await purseManager.LoadAimsAsync();
		}

		public void OnChooseStartDateClick(object sender, EventArgs eventArgs)
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