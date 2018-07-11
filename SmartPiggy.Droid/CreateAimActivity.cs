using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using SmartPiggy.Core.ViewModels;
using SmartPiggy.Droid.Extensions;
using SmartPiggy.Droid.Fragments;

namespace SmartPiggy.Droid
{
	[Activity(Label = "@string/app_name", LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon")]
	public class CreateAimActivity : ActivityBase
	{
		private CreateAimViewModel Vm => App.Locator.CreateAim;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "Second" layout resource
			SetContentView(Resource.Layout.create_aim);

			_startDateEditControl = FindViewById<EditText>(Resource.Id.startDate);
			_finalDateEditControl = FindViewById<EditText>(Resource.Id.endDate);
			FindViewById<Button>(Resource.Id.saveButton).SetCommand(Vm.SaveCommand);
			_aimName = FindViewById<EditText>(Resource.Id.aimName);
			_currentBalance = FindViewById<EditText>(Resource.Id.initialBalance);
			_finalBalance = FindViewById<EditText>(Resource.Id.finalBalance);

			_bindings = new List<Binding>
			{
				this.SetBinding(() => _aimName.Text, () => Vm.Name, BindingMode.OneWay),
				this.SetBinding(() => _currentBalance.Text, () => Vm.CurrentBalance, BindingMode.OneWay).ConvertSourceToDouble(),
				this.SetBinding(() => _finalBalance.Text, () => Vm.FinalBalance, BindingMode.OneWay).ConvertSourceToDouble(),
				this.SetBinding(() => _startDateEditControl.Text, () => Vm.StartDate, BindingMode.OneWay).ConvertSourceToDateTime(),
				this.SetBinding(() => _finalDateEditControl.Text, () => Vm.FinalDate, BindingMode.OneWay).ConvertSourceToDateTime()
			};

			_startDateEditControl.Click += OnChooseStartDateClick;
			_finalDateEditControl.Click += OnChooseStartDateClick;
		}

		private EditText _startDateEditControl;
		private EditText _aimName;
		private EditText _currentBalance;
		private EditText _finalBalance;
		private EditText _finalDateEditControl;
		private List<Binding> _bindings;

		public void OnChooseStartDateClick(object sender, EventArgs eventArgs)
		{
			var textControl = sender as EditText;

			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				textControl.Text = time.ToLongDateString();
			});

			frag.Show(FragmentManager, frag.TAG);
		}
	}
}