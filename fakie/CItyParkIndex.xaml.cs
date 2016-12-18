using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace fakie
{
	public partial class CityParkIndex : ContentPage
	{

		ObservableCollection<string> parks = new ObservableCollection<string>();
		static JObject parksData = null;
		string CityName = string.Empty;

		public CityParkIndex(string cityName)
		{
			InitializeComponent();
			CityName = cityName.ToUpper();
			lblCityName.Text = CityName;
			loadData();
		}

		async void loadData()
		{
			if (parksData == null)
			{
				parksData = await firebaseAPI.doGet("parks", "", "");
			}

			foreach (var park in parksData)
			{
				var parkName = park.Key;
				var parkObj = ((JObject) park.Value);

				var lclCityName = parkObj["City"].ToString().ToUpper();
				if (lclCityName == CityName)
				{
					parks.Add(parkName.ToUpper());
				}
			}

			//var culture = new CultureInfo("sv-SE");
			// Use culture in StringComparer.Create. But StringComparer.Create does not exists? Why?
			ParkList.ItemsSource = parks.OrderBy(ind=>ind, StringComparer.CurrentCulture);
		}

		void goPark(object sender, EventArgs e)
		{
			var parkName = ((Button)sender).Text;
			Navigation.PushAsync(new ParkName(parkName));
		}

	}
}
