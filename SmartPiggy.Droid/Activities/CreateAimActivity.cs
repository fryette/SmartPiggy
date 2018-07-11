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
		private CreateAimViewModel _vm;
		private List<Binding> _bindings;
		private EditText _startDateEditControl;
		private EditText _finalDateEditControl;
		private EditText _aimName;
		private EditText _currentBalance;
		private EditText _finalBalance;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			_vm = App.Locator.CreateAim;

			// Set our view from the "Second" layout resource
			SetContentView(Resource.Layout.create_aim);

			FindViewById<Button>(Resource.Id.saveButton).SetCommand(_vm.SaveCommand);

			_startDateEditControl = FindViewById<EditText>(Resource.Id.startDate);
			_finalDateEditControl = FindViewById<EditText>(Resource.Id.endDate);
			_aimName = FindViewById<EditText>(Resource.Id.aimName);
			_currentBalance = FindViewById<EditText>(Resource.Id.initialBalance);
			_finalBalance = FindViewById<EditText>(Resource.Id.finalBalance);

			_bindings = new List<Binding>
			{
				this.SetBinding(() => _aimName.Text, () => _vm.Name, BindingMode.OneWay),
				this.SetBinding(() => _currentBalance.Text, () => _vm.CurrentBalance, BindingMode.OneWay).ConvertSourceToDouble(),
				this.SetBinding(() => _finalBalance.Text, () => _vm.FinalBalance, BindingMode.OneWay).ConvertSourceToDouble(),
				this.SetBinding(() => _startDateEditControl.Text, () => _vm.StartDate, BindingMode.OneWay).ConvertSourceToDateTime(),
				this.SetBinding(() => _finalDateEditControl.Text, () => _vm.FinalDate, BindingMode.OneWay).ConvertSourceToDateTime()
			};

			_startDateEditControl.Click += OnChooseStartDateClick;
			_finalDateEditControl.Click += OnChooseStartDateClick;
		}


		public void OnChooseStartDateClick(object sender, EventArgs eventArgs)
		{
			var textControl = (EditText)sender;

			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				textControl.Text = time.ToLongDateString();
			});

			frag.Show(FragmentManager, frag.TAG);
		}
	}
}