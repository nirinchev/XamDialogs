﻿using System;
using UIKit;
using DHDialogs;
using Foundation;
using System.Collections.Generic;

namespace DHDialogsSample
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			this.View.BackgroundColor = UIColor.White;

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
			
		async partial void ShowDatePicker (UIButton sender)
		{

			var dialog = new DHDatePickerDialog(UIDatePickerMode.DateAndTime)
			{
				Title = "Who are you?",
				Message = "Please enter your username and password to get access to the system.",
				BlurEffectStyle = UIBlurEffectStyle.ExtraLight,
				CancelButtonText = "Cancel",
				ConstantUpdates = false,
			};
				
			dialog.SelectedDate = new DateTime(1978,6,30,7,30,00,00);

			dialog.ButtonMode = ButtonMode.OkAndCancel;

			dialog.ValidateSubmit = (DateTime data)=>
			{
				return true;
			};

			dialog.OnSelectedDateChanged += (object s, DateTime e) => 
			{
				Console.WriteLine(e);
			};

			dialog.Show();

			//
			//var result = await DHDatePickerDialog.ShowDialog(UIDatePickerMode.DateAndTime,"Date of Birth","Select your Date of Birth", new DateTime(1978,6,30,7,30,00,00) );

			//Console.WriteLine(result);
		}

		async partial void ShowSimplePicker (UIButton sender)
		{
			var dialog = new DHSimplePickerDialog(new List<String>(){"Dave","Rob","Jamie"})
			{
				Title = "Who are you?",
				Message = "Please enter your username and password to get access to the system.",
				BlurEffectStyle = UIBlurEffectStyle.ExtraLight,
				CancelButtonText = "Cancel",
				ConstantUpdates = false,
			};
				
			dialog.OnSelectedItemChanged += (object s, string e) => 
			{
				Console.WriteLine(e);
			};

			dialog.SelectedItem = "Rob";

			dialog.Show();

			//var result = await DHSimplePickerDialog.ShowDialog("Who are you?","Select your name", new List<String>(){"Dave","Rob","Jamie"}, "Rob");
			//Console.WriteLine(result);
		}
	}
}
