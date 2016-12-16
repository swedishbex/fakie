using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Globalization;

namespace fakie
{
	public partial class CityIndex : ContentPage
	{
		ObservableCollection<string> cities = new ObservableCollection<string>();
		static JObject regionsData = null;

		private string charKey;
		public CityIndex(string sortChar)
		{
			InitializeComponent();
			charKey = sortChar;
			lblLetter.Text = sortChar;
			loadData();
		}

		async void loadData()
		{
			if (regionsData == null)
			{
				regionsData = await firebaseAPI.doGet("regions", "", "");
			}

			foreach (var region in regionsData)
			{
				var lclCities = (JObject) region.Value;

				foreach (var city in lclCities["Cities"])
				{
					if (city.ToString().ToLower().StartsWith(charKey.ToLower(), StringComparison.Ordinal))
					{
						cities.Add(city.ToString().ToUpper());
					}
				}


			}

			var culture = new CultureInfo("sv-SE");
			// Use culture in StringComparer.Create. But StringComparer.Create does not exists? Why?
			CityList.ItemsSource = cities.OrderBy(i=>i, StringComparer.CurrentCulture);
		}

		void goCityParkIndex(object sender, EventArgs e)
		{
			var cityName = ((Button)sender).Text;
			Navigation.PushAsync(new CityParkIndex());
		}

	}
}


