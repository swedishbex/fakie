using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;


namespace fakie
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new CityLetters());
			//MainPage = new NavigationPage(new fakiePage());
			                              
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

	}
}
