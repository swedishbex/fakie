using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fakie
{
	public partial class ParkIndex : ContentPage
	{
		public ParkIndex(string cityName)
		{
			InitializeComponent();
			lblCityName.Text = cityName;
		}
	}
}


// Kopiera Cityindex med nya namn