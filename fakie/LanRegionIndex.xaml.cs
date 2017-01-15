using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace fakie
{
	public enum LanArea
	{
		Sodra,
		Mellan,
		Norra
	}
	public partial class LanRegionIndex : ContentPage
	{
		ObservableCollection<string> regions = new ObservableCollection<string>();
		static JObject regionsData = null;

		string areaSelector = "";

		public LanRegionIndex(LanArea region)
		{
			InitializeComponent();
			var regionName = "";
			switch (region)
			{
				case LanArea.Sodra:
					regionName = "Södra Sverige";
					areaSelector = "Södra";
					break;
				case LanArea.Mellan:
					regionName = "Mellansverige";
					areaSelector = "Mellan";
					break;
				case LanArea.Norra:
					regionName = "Norra Sverige";
					areaSelector = "Norra";
					break;
			}

			regionName = regionName.ToUpper();
			lblLanRegion.Text = regionName;

			loadData();
		}

		async void loadData()
		{
			if (regionsData == null)
			{
				//regionsData = await firebaseAPI.doGet("regions", "", "");
				regionsData = await DataManager.GetRegions();
			}

			foreach (var region in regionsData)
			{
				var area = region.Value["Area"].ToString();
				if (area == areaSelector)
				{
					regions.Add(region.Key.ToUpper());
				}
			}

			RegionList.ItemsSource = regions.OrderBy(ind => ind, StringComparer.CurrentCulture);
		}

		void goArea(object sender, EventArgs e)
		{
			var areaName = ((Button)sender).Text;
			Navigation.PushAsync(new RegionAreaIndex(areaName));
		}

	}
}
