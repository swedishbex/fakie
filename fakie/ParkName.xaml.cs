using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fakie
{
	public partial class ParkName : ContentPage
	{
		public ParkName(string parkName)
		{
			InitializeComponent();
			lblParkName.Text = parkName;
		}
	}
}
