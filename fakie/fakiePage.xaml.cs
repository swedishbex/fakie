using System.Collections.Generic;
using System;

using Xamarin.Forms;


namespace fakie
{
	public partial class fakiePage : ContentPage
	{
		public fakiePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			contactBtn.Command = new Command(async o => { Device.OpenUri(new Uri("https://www.facebook.com/skatefakie/")); });
		}

		void goPark(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ParkLetters());
		}

		void goCity(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CityLetters());
		}

		void goLan(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LanPage());
		}

	}
}