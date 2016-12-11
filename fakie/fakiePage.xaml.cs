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