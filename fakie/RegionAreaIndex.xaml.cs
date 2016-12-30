using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace fakie
{
	public partial class RegionAreaIndex : ContentPage
	{

		ObservableCollection<string> areas = new ObservableCollection<string>();
		static JObject regionsData = null;
		string selectedArea = "";

		public RegionAreaIndex(string areaName)
		{
			InitializeComponent();
			lblAreaName.Text = areaName;
			selectedArea = areaName;
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
				if (region.Key.ToUpper() == selectedArea)
				{
					foreach (var city in region.Value["Cities"])
					{
						areas.Add(city.ToString().ToUpper());
					}
					break;
				}
			}

			AreaList.ItemsSource = areas.OrderBy(ind => ind, StringComparer.CurrentCulture);
		}

		void goCityParkIndex(object sender, EventArgs e)
		{
			var cityName = ((Button)sender).Text;
			Navigation.PushAsync(new CityParkIndex(cityName));
		}
	}
}
