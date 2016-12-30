using System.Collections.Generic;
using System;


using Xamarin.Forms;

namespace fakie
{
	public partial class LanPage : ContentPage
	{
		public LanPage()
		{
			InitializeComponent();
		}

		void goLanSodra(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LanRegionIndex(LanArea.Sodra));
		}

		void goLanMellan(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LanRegionIndex(LanArea.Mellan));
		}

		void goLanNorra(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LanRegionIndex(LanArea.Norra));
		}
	}
}
